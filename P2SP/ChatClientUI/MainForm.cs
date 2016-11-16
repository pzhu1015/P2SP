/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-23
 * Time: 17:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.IO;

using CCWin;
using CCWin.SkinControl;
using Helper;
using SendFileService;
using Chat;
using Trans;
using ChatTrans;
using Complents.ChatComp;
using Weather;
using P2PService;

namespace ChatClientUI
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : CCSkinMain
	{	
		#region 成员变量
		private static object friendListLocker = new object();
		private Hashtable friendList = new Hashtable();

		private FrmCapture captureFrm;	
		
		private ChatUser user;
		public ChatUser User {
			get { return user; }
			set { user = value; }
		}
		
		private WeatherApi weather = new WeatherApi();
		public WeatherApi Weather {
			get { return weather; }
			set { weather = value; }
		}
		
		private P2PChatClient client;	
		public P2PChatClient Client {
			get { return client; }
			set { client = value; }
		}
		
		private LoginForm loginFrm;
		public LoginForm LoginFrm {
			get { return loginFrm; }
			set { loginFrm = value; }
		}
		
		private MyInfoFrom myInfoFrm;
		public MyInfoFrom MyInfoFrm {
			get { return myInfoFrm; }
			set { myInfoFrm = value; }
		}
		
		private UserInfoForm userInfoFrm;
		public UserInfoForm UserInfoFrm {
			get { return userInfoFrm; }
			set { userInfoFrm = value; }
		}
		
		private WeatherForm weatherFrm;		
		public WeatherForm WeatherFrm {
			get { return weatherFrm; }
			set { weatherFrm = value; }
		}
		
		private SystemSettingForm systemSettingFrm;
		
		public SystemSettingForm SystemSettingFrm {
			get { return systemSettingFrm; }
			set { systemSettingFrm = value; }
		}
		
		#endregion
		
		#region 构造函数
		
		public MainForm()
		{
			InitializeComponent();
			this.InitP2PChatClient();
		}
		
		#endregion
		
		#region 截图
		
		protected override void WndProc(ref Message m) 
		{
            if (m.Msg == DLLHelper.WM_HOTKEY) {
                this.ShowCaptureForm();
            }
            base.WndProc(ref m);
        }
		
		#endregion
		
		#region 初始化
		
		private void InitP2PChatClient()
		{
			if (this.client == null)
			{
				string serverIp = AppConfigMgr.Instance.GetAttribute(AppConfigMgr.ServerIp);
				int serverTcpPort = Convert.ToInt32(AppConfigMgr.Instance.GetAttribute(AppConfigMgr.ServerTcpPort));
				this.client = new P2PChatClient(serverIp, serverTcpPort);
				this.client.TcpConnect += new TcpConnectEventHandler(ChatClientForm_TcpConnect);
				this.client.TcpDisConnect += new TcpDisConnectEventHandler(ChatClientForm_TcpDisConnect);
				this.client.TcpAccept += new TcpAcceptEventHandler(ChatClientForm_TcpAccept);
				this.client.TcpListenerStart += new TcpListenerStartEventHandler(ChatClientForm_TcpListenerStart);
				this.client.TcpListenerStop += new TcpListenerStopEventHandler(ChatClientForm_TcpListenerStop);
				this.client.TcpRecve += new TcpRecveEventHandler(ChatClientForm_TcpRecve);
				this.client.TcpSend += new TcpSendEventHandler(ChatClientForm_TcpSend);
			}
		}
		
		private void InitPosition()
		{
			this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 10, 10 + 10*this.loginFrm.Count);
		}
		
		private void InitHotKey()
		{
			uint auxKey = Convert.ToUInt32((Keys)Enum.Parse(typeof(Keys), AppConfigMgr.Instance.GetAttribute(AppConfigMgr.ScreenCaptureKey, "A")));
			DLLHelper.RegisterHotKey(this.Handle, DLLHelper.HOTKEY_ID, DLLHelper.MOD_CONTROL | DLLHelper.MOD_ALT, auxKey);
		}
				
		#endregion
		
		#region 加载天气

		private void AsyncLoadWeatherCb()
		{
			try
			{
				string[] array = weather.GetWeatherByCityName("苏州");
				string image_path = Application.StartupPath + "\\" + FileName.Weather + "\\b_" + array[9];
				if (!File.Exists(image_path))
				{
					return;
				}
				this.BeginInvoke(new MethodInvoker(delegate()
				{
					this.skpWeather.BackgroundImage = Image.FromFile(image_path);
				}));
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void LoadWeather()
		{
			AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(AsyncLoadWeatherCb);
			ah.BeginInvoke(null, null);
		}
				
		#endregion
		
		#region 网络事件
		
		void ChatClientForm_TcpSend(object sender, TcpSendEventArgs e)
		{
		}

		void ChatClientForm_TcpRecve(object sender, TcpRecveEventArgs e)
		{
			this.ProcNetCommand(e.Trans, e.Client);
		}

		void ChatClientForm_TcpListenerStop(object sender, TcpListenerStopEventArgs e)
		{
		}

		void ChatClientForm_TcpListenerStart(object sender, TcpListenerStartEventArgs e)
		{
		}

		void ChatClientForm_TcpAccept(object sender, TcpAcceptEventArgs e)
		{
		}

		void ChatClientForm_TcpDisConnect(object sender, TcpDisConnectEventArgs e)
		{
			try
			{
				switch(e.ReadWriteObj.ConnType)
				{
					case ConnectType.eClient:
						ChatFriend chatFriend = this.GetChatFriend(e.ReadWriteObj.Client);
						if (chatFriend != null)
						{
							chatFriend.Client = null;
							{
								System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
								System.Diagnostics.StackFrame sf = st.GetFrame(0);
								DebugHelper.Console("disconnect to friend" + chatFriend.UserId, sf);
							}
						}
						break;
					case ConnectType.eServer:
						this.client.ServerConnection = null;
						//set self offline
						//try reconnect to server
						{
							System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
							System.Diagnostics.StackFrame sf = st.GetFrame(0);
							DebugHelper.Console("disconnect to server", sf);
						}
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

		void ChatClientForm_TcpConnect(object sender, TcpConnectEventArgs e)
		{
			try
			{
				switch(e.ReadWriteObj.ConnType)
				{
				case ConnectType.eServer:
					this.ConnectToServerCb(e.ReadWriteObj.Client);
					break;
				case ConnectType.eClient:
					this.ConnectToClientCb(e.ReadWriteObj.Client, e.ReadWriteObj.UserId);
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
				
		private void ConnectToServerCb(TcpClient tcpClient)
		{
			try
			{
				if (tcpClient.Client.Connected)
				{
					this.client.ServerConnection = tcpClient;
					this.client.LocalTcpPort = Convert.ToInt32(tcpClient.Client.LocalEndPoint.ToString().Split(':')[1]);
					this.client.Start();
					Thread.Sleep(2000);
					this.SendLogin();
				}
				else
				{
					this.BeginInvoke(new MethodInvoker(delegate()
					{
					    throw new NotImplementedException();
						//this.ShowLoginForm(3);					   
					}));
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ConnectToClientCb(TcpClient _client, string userId)
		{
			try
			{
				ChatFriend chatFriend = this.GetChatFriend(userId);
				DebugHelper.Assert(chatFriend != null);
				if (chatFriend.Status == ChatStatus.Online)
				{
					if (_client.Connected)
					{
						chatFriend.Client = _client;
						while(chatFriend.CountSendPackage() > 0)
						{
							this.client.AsyncSendToClient(_client, chatFriend.PopSendPackage());
						}
					}
					else
					{
						//send Nat request to server, server help it to Nat
					}
				}
				else
				{
					//user offline pop tooltip or send this msg to server,
					//then the server resend to this friend
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		#endregion
		
		#region 好友列表管理

		private void AddChatFriend(string _userid, ChatFriend _friend)
		{
			_friend.Init();
			lock(friendListLocker)
			{
				this.friendList.Add(_userid, _friend);
			}
		}
		
		private ChatFriend GetChatFriend(TcpClient _client)
		{
			lock(friendListLocker)
			{
				foreach(DictionaryEntry entry in this.friendList)
				{
					ChatFriend chatFriend = (entry.Value) as ChatFriend;
					if (chatFriend.Client != null)
					{
						if (chatFriend.Client.GetHashCode() == _client.GetHashCode())
						{
							return chatFriend;
						}
					}
				}
				return null;
			}
		}
		
		private ChatFriend GetChatFriend(string _userid)
		{
			lock(friendListLocker)
			{
				if (this.friendList.ContainsKey(_userid))
				{
					return this.friendList[_userid] as ChatFriend;
				}
				return null;
			}
		}
		
		private void RemoveChatFriend(string _userid)
		{
			lock(friendListLocker)
			{
				if (this.friendList.ContainsKey(_userid))
				{
					this.friendList.Remove(_userid);
				}
			}
		}
		
		private ChatListSubItem.UserStatus toEnum(string name)
		{
			switch(name)
			{
			case "Away":
				return ChatListSubItem.UserStatus.Away;
			case "Busy":
				return ChatListSubItem.UserStatus.Busy;
			case "DontDisturb":
				return ChatListSubItem.UserStatus.DontDisturb;
			case "Online":
				return ChatListSubItem.UserStatus.Online;
			case "OffLine":
				return ChatListSubItem.UserStatus.OffLine;
			case "QMe":
				return ChatListSubItem.UserStatus.QMe;
			default:
				return ChatListSubItem.UserStatus.OffLine;
			}
		}

		private void AddChatListBoxSubItem(ChatFriend friend)
		{
			try
			{
				ChatFriend crtFriend = this.GetChatFriend(friend.UserId);
				ChatListSubItem subItem = null;
				if (crtFriend == null)
				{
					crtFriend = friend;
					subItem = new ChatListSubItem(
						Convert.ToInt32(friend.UserId),
						string.IsNullOrEmpty(friend.NickName)?friend.UserId:friend.NickName,
						friend.DisplayName,
						friend.PersonalMsg,
						this.toEnum(Enum.GetName(typeof(ChatStatus), friend.Status)),
						Program.GetHeadBitmap(friend.Head));
					subItem.IpAddress = friend.Ip;
					subItem.TcpPort = friend.TcpPort;
					this.chatListBoxBuddy.Items[0].SubItems.AddAccordingToStatus(subItem);
					crtFriend.SubItem = subItem;
					this.AddChatFriend(friend.UserId, crtFriend);
				}
				else
				{
					subItem = crtFriend.SubItem as ChatListSubItem;
					subItem.IpAddress = friend.Ip;
					subItem.TcpPort = friend.TcpPort;
					subItem.HeadImage = Program.GetHeadImage(friend.Head);
					subItem.Status = this.toEnum(Enum.GetName(typeof(ChatStatus), friend.Status));
					crtFriend.Ip = friend.Ip;
					crtFriend.TcpPort = friend.TcpPort;
					crtFriend.Status = friend.Status;
				}

			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		#endregion
		
		#region 处理网络命令
		
		private void ProcNetCommand(BaseTrans trans, TcpClient client)
		{
			try
			{
				switch(trans.Command)
				{
				case NetCommand.eSendMsg:
					this.ProcSendMsg(trans);
					break;
				case NetCommand.eOnline:
					this.ProcOnline(trans);
					break;
				case NetCommand.eLoginFail:
					this.ProcLoginFail(trans);
					break;
				case NetCommand.eLoginSuccess:
					this.ProcLoginSuccess(trans);
					break;
				case NetCommand.eKickOff:
					this.ProcKickOff(trans);
					break;
				case NetCommand.eOffline:
					this.ProcOffline(trans);
					break;
				case NetCommand.eSendFile:
					this.ProcSendFile(trans);
					break;
				case NetCommand.eSendFileResponse:
					this.ProcSendFileResponse(trans);
					break;
				case NetCommand.eSendFileBuffer:
					this.ProcSendFileBuffer(trans);
					break;
				case NetCommand.eSendFolder:
					this.ProcSendFolder(trans);
					break;
				case NetCommand.eSendFileCancel:
					this.ProcSendFileCancel(trans);
					break;
				case NetCommand.eRecveFileCancel:
					this.ProcRecveFileCancel(trans);
					break;
				case NetCommand.eVibration:
					this.ProcVibration(trans);
					break;
				case NetCommand.eSendAudio:
					this.ProcSendAudio(trans);
					break;
				case NetCommand.eSendAudioBuffer:
					this.ProcSendAudioBuffer(trans);
					break;
				case NetCommand.eSendAudioResponse:
					this.ProcSendAudioResponse(trans);
					break;
				case NetCommand.eAudioCancel:
					this.ProcAudioCancel(trans);
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

		private void ProcVibration(BaseTrans trans)
		{
			try
			{
				VibrationTrans vibrationTrans = trans as VibrationTrans;
				ChatFriend chatFriend = this.GetChatFriend(vibrationTrans.TransId.FromId);
				this.BeginInvoke(new MethodInvoker(delegate()
				{
				    ChatForm chatForm = this.ShowChatForm(chatFriend.UserId);
				    chatForm.AppendMessage("您收到了一个窗口抖动");
				    chatForm.Vibration();
				}));
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcSendFileCancel(BaseTrans trans)
		{
			try
			{
				SendFileCancelTrans reqTrans = trans as SendFileCancelTrans;
				ChatFriend chatFriend = this.GetChatFriend(reqTrans.TransId.FromId);
				ChatForm chatForm = (chatFriend.ChatFrm) as ChatForm;
				if (chatForm == null)
				{
					return;
				}
				RecveWriter writer = chatFriend.GetWriter(reqTrans.FileId);
				if (writer != null)
				{
					chatFriend.RemoveWriter(reqTrans.FileId);
					writer.Stop();
					writer.Dispose();
				}
				SendRecveFileControl control = chatForm.GetControlByFileId(reqTrans.FileId);
				this.BeginInvoke(new MethodInvoker(delegate()
				{
					chatForm.RemoveControlByFileId(reqTrans.FileId);
					chatForm.AppendMessage("对方已取消发送文件 [" + control.FileName + "]");
				}));
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}	
		
		private void ProcRecveFileCancel(BaseTrans trans)
		{
			try
			{
				RecveFileCancelTrans reqTrans = trans as RecveFileCancelTrans;
				ChatFriend chatFriend = this.GetChatFriend(reqTrans.TransId.FromId);
				ChatForm chatForm = (chatFriend.ChatFrm) as ChatForm;
				if (chatForm == null)
				{
					return;
				}	
				SendReader reader = chatFriend.GetReader(reqTrans.FileId);
				if (reader != null)
				{	
					chatFriend.RemoveReader(reqTrans.FileId);
					reader.Stop();
					reader.Dispose();
				}
				SendRecveFileControl control = chatForm.GetControlByFileId(reqTrans.FileId);
				this.BeginInvoke(new MethodInvoker(delegate()
				{
					chatForm.RemoveControlByFileId(reqTrans.FileId);
					chatForm.AppendMessage("对方已取消接收文件 [" + control.FileName + "]");
				}));
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		private void ProcSendFileBuffer(BaseTrans trans)
		{
			try
			{
				SendFileBufferTrans reqTrans = trans as SendFileBufferTrans;
				ChatFriend chatFriend = this.GetChatFriend(reqTrans.TransId.FromId);
				RecveWriter writer = chatFriend.GetWriter(reqTrans.FileId);
				if (writer != null)
				{
					if (writer.Type == SendType.eFolder)
					{
						if (reqTrans.Offset == 0)
						{
							writer.Next(reqTrans.SubName, reqTrans.Length);
						}
					}
					writer.Write(reqTrans.Offset, reqTrans.Buffer);
				}
				else
				{
					//do something or do nothing
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcSendFolder(BaseTrans trans)
		{
			try
			{
				SendFolderTrans reqTrans = trans as SendFolderTrans;
				ChatFriend chatFriend = this.GetChatFriend(reqTrans.TransId.FromId);
				RecveWriter writer = chatFriend.GetWriter(reqTrans.FileId);
				if (writer != null)
				{
					writer.Write(reqTrans.SubName);
				}
				else
				{
					//do something or do nothing
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcSendFile(BaseTrans trans)
		{
			try
			{
				SendFileTrans reqTrans = trans as SendFileTrans;
				ChatFriend chatFriend = this.GetChatFriend(reqTrans.TransId.FromId);
				this.BeginInvoke(new MethodInvoker(delegate()
				{
					ChatForm chatForm = this.ShowChatForm(chatFriend.UserId); 
					chatForm.AddRecveFileControl(reqTrans);
				}));
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcSendFileResponse(BaseTrans trans)
		{
			try
			{
				SendFileResponseTrans respTrans = trans as SendFileResponseTrans;
				ChatFriend chatFriend = this.GetChatFriend(respTrans.TransId.FromId);
				SendReader reader = chatFriend.GetReader(respTrans.FileId);
				if (reader != null)
				{
					if (reader.TotalPosition == 0)
					{
						reader.Start();
						ChatForm chatFrm = (chatFriend.ChatFrm) as ChatForm;
						if (chatFrm == null)
						{
							return;
						}
						SendRecveFileControl sendControl = chatFrm.GetControlByFileId(reader.FileId);
						if (sendControl != null)
						{
							this.BeginInvoke(new MethodInvoker(delegate()
							{
								sendControl.StartTime = DateTime.Now;                               
							}));
						}
					}
					else
					{
						reader.Read();
					}
				}
				else
				{
					//may be cancel to send file
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcSendMsg(BaseTrans trans)
		{
			try
			{
				SendMsgTrans sendMsgTrans = trans as SendMsgTrans;
				string fromUserId = sendMsgTrans.TransId.FromId;
				ChatFriend chatFriend = this.GetChatFriend(fromUserId);
				if (chatFriend != null)
				{
					ChatForm chatFrm = (chatFriend.ChatFrm) as ChatForm;
					if (chatFrm != null)
					{
						string toUserId = sendMsgTrans.TransId.ToId;
						string date = sendMsgTrans.Date;
						string msg = sendMsgTrans.Msg;
						this.BeginInvoke(new MethodInvoker(delegate()
						{
							chatFrm.AppendMessage(date, fromUserId, RtfRichTextBox.RtfColor.Blue, msg, true);
						}));
					}
					else
					{
						chatFriend.PushRecvePackage(trans);
						ChatListSubItem subItem = (ChatListSubItem)chatFriend.SubItem;
						DebugHelper.Assert(subItem != null);
						this.BeginInvoke(new MethodInvoker(delegate()
						{
							subItem.IsTwinkle = true;
						 }));
					}
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void SaveUser()
		{
			try
			{
				string homeDir = AppConfigMgr.Instance.GetAttribute(AppConfigMgr.HomeDir, Application.StartupPath + "\\" + FileName.AllUser);
				if (!Directory.Exists(homeDir))
				{
					Directory.CreateDirectory(homeDir);
				}
				string userDir = homeDir + "\\" + this.User.UserId;
				if (!Directory.Exists(userDir))
				{
					Directory.CreateDirectory(userDir);
				}
				
				byte[] buff = BufferHelper.Serialize(this.user);
				string userFile = userDir + "\\" + FileName.User;
				File.WriteAllBytes(userFile, buff);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void SaveFriendList()
		{
			try
			{
				string homeDir = AppConfigMgr.Instance.GetAttribute(AppConfigMgr.HomeDir, Application.StartupPath + "\\" + FileName.AllUser);
				if (!Directory.Exists(homeDir))
				{
					Directory.CreateDirectory(homeDir);
				}
				string userDir = homeDir + "\\" + this.User.UserId;
				if (!Directory.Exists(userDir))
				{
					Directory.CreateDirectory(userDir);
				}
				byte[] buff = BufferHelper.Serialize(this.user.FriendList);
				string friendFile = userDir + "\\" + FileName.Friend;
				File.WriteAllBytes(friendFile, buff);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public void LoadUser()
		{
			Image head = Program.GetHeadBitmap(this.user.Head);
			//this.userHeader.Head = head;
			this.tslblUserName.Text = (string.IsNullOrEmpty(this.user.NickName))? this.user.UserId : this.user.NickName;
			foreach(ChatFriend friend in this.user.FriendList)
			{
				this.AddChatListBoxSubItem(friend);
			}
			this.SendOnline();
		}
		
		private void ProcLoginSuccess(BaseTrans trans)
		{
			try
			{
				LoginSuccessTrans successTrans = trans as LoginSuccessTrans;
				this.user = successTrans.User;
				this.SaveUser();
				this.SaveFriendList();
				this.loginFrm.LoginSuccess(this.user.UserId);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcLoginFail(BaseTrans trans)
		{
			try
			{
				LoginFailTrans failTrans = trans as LoginFailTrans;
				this.BeginInvoke(new MethodInvoker(delegate()
				{
				    throw new NotImplementedException();
//					this.loginFrm.FailLogin(failTrans.Errno);
				}));
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcOnline(BaseTrans trans)
		{
			try
			{
				OnlineTrans onlineTrans = trans as OnlineTrans;
				this.BeginInvoke(new MethodInvoker(delegate()
				{
					this.AddChatListBoxSubItem(onlineTrans.Friend);	                                   	
				}));
				
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
				
		private void ProcOffline(BaseTrans trans)
		{
			try
			{
				OfflineTrans offlineTrans = trans as OfflineTrans;
				string userId = offlineTrans.TransId.FromId;
				ChatFriend chatFriend = this.GetChatFriend(userId);
				DebugHelper.Assert(chatFriend != null);
				ChatListSubItem subItem = chatFriend.SubItem as ChatListSubItem;
				DebugHelper.Assert(subItem != null);
				this.BeginInvoke(new MethodInvoker(delegate()
				{
					subItem.Status = ChatListSubItem.UserStatus.OffLine;                         	
				}));
				chatFriend.Client = null;
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcKickOff(BaseTrans trans)
		{
			try
			{					
				KickOffTrans kickoffTrans = trans as KickOffTrans;
				this.BeginInvoke(new MethodInvoker(delegate()
				{
				    throw new NotImplementedException();
					//this.ShowLoginForm(kickoffTrans.Errno);                    	
				}));
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
			
		}
		
		private void ProcSendAudio(BaseTrans trans)
		{
			try
			{
				SendAudioTrans sendAudioTrans = trans as SendAudioTrans;
				ChatFriend chatFriend = this.GetChatFriend(sendAudioTrans.TransId.FromId);
				this.BeginInvoke(new MethodInvoker(delegate()
				{
					ChatForm chatForm = this.ShowChatForm(chatFriend.UserId); 
					chatForm.InitSendAudioPanel(false);
				}));
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcSendAudioBuffer(BaseTrans trans)
		{
			try
			{
				SendAudioBufferTrans sendAudioBufferTrans = trans as SendAudioBufferTrans;
				ChatFriend chatFriend = this.GetChatFriend(sendAudioBufferTrans.TransId.FromId);
				if (chatFriend.Voice == null)
				{
					return;
				}
				chatFriend.Voice.RecveVoice(sendAudioBufferTrans.Buffer);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcSendAudioResponse(BaseTrans trans)
		{
			try
			{
				SendAudioResponseTrans respTrans = trans as SendAudioResponseTrans;
				ChatFriend chatFriend = this.GetChatFriend(respTrans.TransId.FromId);
				if (chatFriend.Voice == null)
				{
					return;
				}
				ChatForm chatForm = (chatFriend.ChatFrm) as ChatForm;
				if (chatForm == null)
				{
					return;
				}
				chatFriend.Voice.Start();
				this.BeginInvoke(new MethodInvoker(delegate()
				{ 
					chatForm.GetAudioPanel().SetAccecpt();
				}));
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ProcAudioCancel(BaseTrans trans)
		{
			try
			{
				AudioCancelTrans respTrans = trans as AudioCancelTrans;
				ChatFriend chatFriend = this.GetChatFriend(respTrans.TransId.FromId);
				ChatForm chatForm = (chatFriend.ChatFrm) as ChatForm;
				if (chatForm == null)
				{
					return;
				}
				this.BeginInvoke(new MethodInvoker(delegate()
				{ 
					chatForm.CancelAudio(false, false);
				}));
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		#endregion
		
		#region 发送网络命令
		
		public void Login(string _userId, string _passwd)
		{
			if (this.user == null)
			{
				this.user = new ChatUser();
			}
			this.user.UserId = _userId;
			this.user.Password = _passwd;
			AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(AsyncLoginCb);
			ah.BeginInvoke(null, null);
		}
		
		private void AsyncLoginCb()
		{
			try
			{
				this.client.Connect(this.client.ServerIp, this.client.ServerTcpPort, ConnectType.eServer, "");
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public void SendPackage(BaseTrans trans)
		{
			try
			{
				ChatFriend chatFriend = this.GetChatFriend(trans.TransId.ToId);
				if (chatFriend.Client != null && chatFriend.Client.Connected)
				{
					this.client.AsyncSendToClient(chatFriend.Client, trans);
				}
				else
				{
					chatFriend.PushSendPackage(trans);
					IPAddress ip = IPAddress.Parse(chatFriend.Ip);
					int port = chatFriend.TcpPort;
					this.client.Connect(ip, port, ConnectType.eClient, chatFriend.UserId);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		private void SendLogin()
		{
			BaseTrans trans = new LoginTrans(this.user.UserId, this.user.Password);
			this.client.AsyncSendToServer(this.client.ServerConnection, trans);
		}
		
		private void AsyncSendOnlineCb()
		{
			try
			{
				ChatFriend friend = new ChatFriend(this.user);
				foreach(ChatFriend chatFriend in this.friendList.Values)
				{
					if (chatFriend.Status == ChatStatus.Online)
					{
						BaseTrans trans = new OnlineTrans(friend, chatFriend.UserId, this.user.UserId);
						this.SendPackage(trans);
					}
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void SendOnline()
		{
			AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(AsyncSendOnlineCb);
			ah.BeginInvoke(null, null);
		}
		
		private void AsyncSendOfflineCb()
		{
			try
			{
				BaseTrans trans = new OfflineTrans("", this.user.UserId);
				this.client.AsyncSendToServer(this.client.ServerConnection, trans);
				foreach(ChatFriend chatFriend in this.friendList.Values)
				{
					if (chatFriend.Status == ChatStatus.Online)
					{
						trans = new OfflineTrans(chatFriend.UserId, this.user.UserId);
						this.SendPackage(trans);
					}
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void SendOffline()
		{
			AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(AsyncSendOfflineCb);
			ah.BeginInvoke(null, null);
		}
		
		#endregion

		#region 显示子窗口
		
		private void ShowCaptureForm()
		{
			if (this.captureFrm == null || this.captureFrm.IsDisposed)
            {
                this.captureFrm = new FrmCapture();
            }
            this.captureFrm.IsCaptureCursor = true;
            this.captureFrm.Show();
		}
		
		private ChatForm ShowChatForm(string friendId)
		{
			try
			{
				ChatFriend chatFriend = this.GetChatFriend(friendId);
				DebugHelper.Assert(chatFriend != null);
				ChatForm chatForm = null;
				if (chatFriend.ChatFrm == null)
				{
					chatForm = new ChatForm();
					chatForm.ChatFriend = chatFriend;
					chatForm.MainFrm = this;
					chatFriend.ChatFrm = chatForm;
				}
				else
				{
					chatForm = (ChatForm)(chatFriend.ChatFrm);
				}
				DebugHelper.Assert(chatForm != null);
				if (!chatForm.Visible)
				{
					chatForm.Show();
					chatForm.Focus();
				}
				else
				{
					chatForm.WindowState = FormWindowState.Normal;
				}
				return chatForm;
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				return null;
			}
		}
		
		public void ShowMainForm()
		{
			this.Show();
            this.Focus();
            this.TopMost = true;
            this.notifyIconMain.Visible = true;
		}
		
		private void ShowSystemSettingForm()
		{
			if (this.systemSettingFrm == null)
			{
				this.systemSettingFrm = new SystemSettingForm();
				this.systemSettingFrm.MainFrm = this;
			}
			DebugHelper.Assert(this.systemSettingFrm != null);
			if (!this.systemSettingFrm.Visible)
			{
				this.systemSettingFrm.Show(this);
			}
		}
		
		private void ShowMyInfoForm()
		{
			try
			{
				if (this.myInfoFrm == null)
				{
					this.myInfoFrm = new MyInfoFrom();
					this.myInfoFrm.MainFrm = this;
				}
				DebugHelper.Assert(this.myInfoFrm != null);
				if (!this.myInfoFrm.Visible)
				{
					this.myInfoFrm.Show(this);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ShowUserInfoForm(ChatListSubItem item, Point p)
		{
			try
			{
				if (this.userInfoFrm == null)
				{
					this.userInfoFrm = new UserInfoForm();
				}
				DebugHelper.Assert(this.userInfoFrm != null);
				this.userInfoFrm.Item = item;
				this.userInfoFrm.Position = p;
				if (!this.userInfoFrm.Visible)
				{
					this.userInfoFrm.Show(this);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ShowWeatherForm(Point p)
		{
			try
			{
				if (this.weatherFrm == null)
				{
					this.weatherFrm = new WeatherForm();
					this.weatherFrm.MainFrm = this;
				}
				DebugHelper.Assert(this.weatherFrm != null);
				this.weatherFrm.Position = p;
				if (!this.weatherFrm.Visible)
				{
					this.weatherFrm.Show(this);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
			
		#endregion
		
		#region 窗体事件

		void ChatListBoxBuddyDoubleClickSubItem(object sender, ChatListEventArgs e)
		{
			this.ShowChatForm(e.SelectSubItem.ID.ToString());
			e.SelectSubItem.IsTwinkle = false;
		}
		
		void ChatListBoxBuddyMouseEnterHead(object sender, ChatListEventArgs e)
		{
			if (this.userInfoFrm == null)
			{
				this.userInfoFrm = new UserInfoForm();
			}
			int top = this.Top + this.chatListBoxBuddy.Top + (e.MouseOnSubItem.HeadRect.Y - this.chatListBoxBuddy.chatVScroll.Value);
            int left = this.Left - this.userInfoFrm.Width - 0;           
            int ph = Screen.GetWorkingArea(this).Height;
           
            if (top + this.userInfoFrm.Height > ph)
            {
                top = ph - this.userInfoFrm.Height - 0;
            }
            
            if (left < 0)
            {
                left = this.Right + 0;
            }
            this.ShowUserInfoForm(e.MouseOnSubItem, new Point(left, top));
			this.userInfoFrm.SetInfo();
		}
		
		void ChatListBoxBuddyMouseLeaveHead(object sender, ChatListEventArgs e)
		{
			DebugHelper.Assert(this.userInfoFrm != null);
			if (!this.userInfoFrm.Bounds.Contains(Cursor.Position))
			{
				this.userInfoFrm.Hide();
			}
		}
		
		void NotifyIconMainMouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.ShowMainForm();
		}
		
		void TsmiExitClick(object sender, EventArgs e)
		{
			this.Exit(true);
		}
		
		void TsmiShowClick(object sender, EventArgs e)
		{
			this.ShowMainForm();
		}

		void MainFormLoad(object sender, EventArgs e)
		{
			this.InitPosition();
			this.InitHotKey();
			this.LoadWeather();
		}
		
		void TsbtnSysSettingClick(object sender, EventArgs e)
		{
			this.ShowSystemSettingForm();
		}		
		
		void TsmiMineInfoClick(object sender, EventArgs e)
		{
			this.ShowMyInfoForm();
		}
		
		void SkpWeatherMouseEnter(object sender, EventArgs e)
		{
			if (this.weatherFrm == null)
			{
				this.weatherFrm = new WeatherForm();
				this.weatherFrm.MainFrm = this;
			}
			int top = this.Top;
            int left = this.Left - this.weatherFrm.Width - 0;           
            int ph = Screen.GetWorkingArea(this).Height;
           
            if (top + this.weatherFrm.Height > ph)
            {
                top = ph - this.weatherFrm.Height - 0;
            }
            
            if (left < 0)
            {
                left = this.Right + 0;
            }
            this.ShowWeatherForm(new Point(left, top)); 
		}

		void SkpWeatherMouseLeave(object sender, EventArgs e)
		{
			DebugHelper.Assert(this.weatherFrm != null);
			if (!this.weatherFrm.Bounds.Contains(Cursor.Position))
			{
				this.weatherFrm.Hide();
			}
		}	
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			this.Exit(false);
		}
		
		private void Exit(bool isClose)
		{
			this.client.Stop();
			this.notifyIconMain.Dispose();
			this.loginFrm.CheckClosing();
			if (isClose)
			{
				this.Close();
			}
		}
		
		public new void Dispose()
		{
			base.Dispose();
			this.notifyIconMain.Dispose();
		}

		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			this.SendOffline();
		}
	
		void TsmiShowMainClick(object sender, EventArgs e)
		{
			this.ShowMainForm();
		}
		
		#endregion
	}
}
