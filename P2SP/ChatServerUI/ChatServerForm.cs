/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-5-8
 * Time: 17:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using CCWin;
using Helper;
using Chat;
using Trans;
using ChatTrans;
using P2PService;

namespace ChatServerUI
{
    /// <summary>
    /// Description of ChatServerForm.
    /// </summary>
    public partial class ChatServerForm : CCSkinMain
	{
		private delegate void AppendRecveMsgDelegate(string msg, Color color);
		private AppendRecveMsgDelegate appendRecveMsg;
		
		private static object recveMsgLocker = new object();
		private static object userListLocker = new object();
		
		private int serverTcpPort;
		
		public int ServerTcpPort {
			get { return serverTcpPort; }
			set { serverTcpPort = value; }
		}
		
		private Hashtable userList = new Hashtable();
		public Hashtable UserList {
			get { return userList; }
			set { userList = value; }
		}
		
		private P2PChatServer server;
		public P2PChatServer Server {
			get { return server; }
			set { server = value; }
		}
		
		private void InitTracer()
		{
			System.Diagnostics.Trace.Listeners.Clear();
            System.Diagnostics.Trace.AutoFlush = true;
            System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(Application.StartupPath + "\\app.log"));
		}
		
		private void InitBaseProperty()
		{
			this.appendRecveMsg = new ChatServerForm.AppendRecveMsgDelegate(AppendRecveMsgRslt);
		}
		
		private void InitP2PChatServer()
		{
			if (this.server == null)
			{
				this.serverTcpPort = Convert.ToInt32(AppConfigMgr.Instance.GetAttribute(AppConfigMgr.ServerTcpPort));
				this.server = new P2PChatServer(this.serverTcpPort);
				this.server.TcpListenerStart += new TcpListenerStartEventHandler(ChatServerForm_TcpListenerStart);
				this.server.TcpListenerStop += new TcpListenerStopEventHandler(ChatServerForm_TcpListenerStop);
				this.server.TcpRecve += new TcpRecveEventHandler(ChatServerForm_TcpRecve);
				this.server.TcpSend += new TcpSendEventHandler(ChatServerForm_TcpSend);
				this.server.TcpDisConnect += new TcpDisConnectEventHandler(ChatServerForm_TcpDisConnect);
				this.server.TcpAccept += new TcpAcceptEventHandler(ChatServerForm_TcpAccept);
			}
		}

		void ChatServerForm_TcpListenerStop(object sender, TcpListenerStopEventArgs e)
		{
			string msg = "Server is stop to listen [" + e.Port + "]";
			this.BeginInvoke(this.appendRecveMsg, new object[]{msg, Color.Red});
		}

		void ChatServerForm_TcpListenerStart(object sender, TcpListenerStartEventArgs e)
		{
			string msg = "Server is listening at: [" + e.Port + "]";
			this.BeginInvoke(this.appendRecveMsg, new object[]{msg, Color.Green});
		}		

		void ChatServerForm_TcpAccept(object sender, TcpAcceptEventArgs e)
		{
			string msg = e.Client.Client.RemoteEndPoint.ToString() + " connect success";
			this.BeginInvoke(this.appendRecveMsg, new object[]{msg, Color.Green});
		}
		
		void ChatServerForm_TcpDisConnect(object sender, TcpDisConnectEventArgs e)
		{
			string userId = this.GetUserIdByClient(e.ReadWriteObj.Client);
			string msg = "";
			if (string.IsNullOrEmpty(userId))
			{
				return;
			}
			this.RemoveUserByUserId(userId);
			this.SendOffline(userId);
			msg = "[" + userId + "] logout";
			this.BeginInvoke(this.appendRecveMsg, new object[]{msg, Color.Red});
		}

		void ChatServerForm_TcpSend(object sender, TcpSendEventArgs e)
		{
			
		}

		void ChatServerForm_TcpRecve(object sender, TcpRecveEventArgs e)
		{
			this.ProcNetCommand(e.Trans, e.Client);
		}
		
		public ChatServerForm()
		{
			InitializeComponent();
			this.InitTracer();
			this.InitBaseProperty();
			this.InitP2PChatServer();
		}
		
		private void AppendRecveMsgRslt(string msg, Color color)
		{
			lock(recveMsgLocker)
			{
				this.rtxtRecve.SelectionColor = color;
				this.rtxtRecve.AppendText("[" + System.DateTime.Now.ToString() + "] : " + msg + "\n");
			}
		}
		
		private void ProcNetCommand(BaseTrans trans, TcpClient client)
		{
			try
			{
				switch(trans.Command)
				{
				case NetCommand.eLogin:
					this.ProcLogin(trans, client);
					break;
				case NetCommand.eOffline:
					this.ProcOffline(trans, client);
					break;
				default:
					break;
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcOffline(BaseTrans _trans, TcpClient _client)
		{
			OfflineTrans offlineTrans = (OfflineTrans)_trans;
			this.RemoveUserByUserId(offlineTrans.TransId.FromId);
			_client.Close();
		}
						
		private void ProcLogin(BaseTrans _trans, TcpClient _client)
		{
			LoginTrans loginTrans = (LoginTrans)_trans;
			TcpClient client = _client;
			string userId = "", passwd = "";
			BaseTrans trans = null;
			try
			{
				userId = loginTrans.UserId;
				passwd = loginTrans.Password;
				if (!this.CheckAccess(userId, passwd))
				{
					this.BeginInvoke(this.appendRecveMsg, new object[]{"[" + userId + "] login faild", Color.Red});
					trans = new LoginFailTrans(1);
					this.server.AsyncSend(trans, client);
					return;
				}
				
				TcpClient oldclient = this.GetClientByUserId(userId);
				if (oldclient == null)
				{
					this.AddUserToList(userId, client);
					this.BeginInvoke(this.appendRecveMsg, new object[]{"[" + userId + "] login success", Color.Green});
				}
				else
				{
					this.UpdateUserClient(userId, client);
					trans = new KickOffTrans(2);
					this.server.AsyncSend(trans, oldclient);
					this.BeginInvoke(this.appendRecveMsg, new object[]{"[" + userId + "] login in another place, but login success, kick off old user", Color.Green});
				}
				ChatUser user = this.GetUser(userId);
				trans = new LoginSuccessTrans(user);
				this.server.AsyncSend(trans, client);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				this.RemoveUserByUserId(userId);
			}
		}
		
		private string GetUserIdByClient(TcpClient _client)
		{
			lock(userListLocker)
			{
				foreach(DictionaryEntry entry in this.userList)
				{
					ChatUser user = (ChatUser)entry.Value;
					if (_client.GetHashCode() == user.Client.GetHashCode())
					{
						return user.UserId;
					}
				}
				return "";
			}
		}
		
		private TcpClient GetClientByUserId(string _userId)
		{
			lock(userListLocker)
			{
				if (!this.userList.Contains(_userId))
				{
					return null;
				}
				return ((ChatUser)this.userList[_userId]).Client;
			}
		}
		
		private void AddUserToList(string _userId, TcpClient _client)
		{
			lock(userListLocker)
			{
				ChatUser user = new ChatUser();
				user.UserId = _userId;
				user.Client = _client;
				this.userList.Add(_userId, user);
			}
		}
		
		private void UpdateUserClient(string _userId, TcpClient _client)
		{
			lock(userListLocker)
			{
				ChatUser user = (ChatUser)this.userList[_userId];
				user.Client = _client;
			}
		}
		
		private void RemoveUserByUserId(string _userId)
		{
			lock(userListLocker)
			{
				this.userList.Remove(_userId);
			}
		}
			
		private void SendOffline(string _userId)
		{
			BaseTrans trans = new OfflineTrans("", _userId);
			lock(userListLocker)
			{
				foreach(DictionaryEntry entry in this.userList)
				{
					ChatUser user = (ChatUser)entry.Value;
					this.server.AsyncSend(trans, user.Client);
				}
			}
		}
		
		private ChatUser GetUser(string fromUserId)
		{
			lock(userListLocker)
			{
				ChatUser crtUser = this.userList[fromUserId] as ChatUser;
				crtUser.Init();
				List<ChatFriend> friendList = crtUser.FriendList;
				foreach(ChatFriend friend in friendList)
				{
					if (this.userList.Contains(friend.UserId))
					{
						ChatUser chatUser = this.userList[friend.UserId] as ChatUser;
						friend.Ip = chatUser.Ip;
						friend.TcpPort = chatUser.TcpPort;
						friend.Status = ChatStatus.Online;
					}
					else
					{
						friend.Status = ChatStatus.OffLine;
					}
				}
				return crtUser;
			}
		}
		
		private bool CheckAccess(string userId, string passWord)
		{
			DataSet ds = SQLiteHelper.Query("select password from tb_user where userid=" + userId);
			if (ds.Tables[0].Rows.Count != 1)
			{
				return false;
			}
			return (ds.Tables[0].Rows[0][0].ToString() == passWord);
		}
		
		void BtnStartClick(object sender, EventArgs e)
		{
			try
			{
				this.InitP2PChatServer();
				this.btnStart.Enabled = false;
				this.btnStop.Enabled = !this.btnStart.Enabled;
				this.server.Start();
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				this.btnStart.Enabled = true;
			}
		}
		
		void BtnStopClick(object sender, EventArgs e)
		{
			this.btnStart.Enabled = true;
			this.btnStop.Enabled = !this.btnStart.Enabled;
			this.server.Stop();
			this.userList.Clear();
		}
		
		void ChatServerFormLoad(object sender, EventArgs e)
		{
			
		}
		
		void NiMainMouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Visible = true;
            this.Focus();
		}
		
		void TsmiExitClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void TsmiShowClick(object sender, EventArgs e)
		{
			this.Visible = true;
            this.Focus();
		}
	}
}
