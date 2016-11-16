/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-6-26
 * Time: 17:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

using Helper;

namespace Chat
{
	/// <summary>
	/// Description of ChatUser.
	/// </summary>
	[Serializable]
	public class ChatUser
	{
		[NonSerialized]
		private TcpClient client;
		public TcpClient Client {
			get { return client; }
			set 
			{
				client = value; 
				string[] strEndPoint = client.Client.RemoteEndPoint.ToString().Split(':');
				if (strEndPoint.Length == 2)
				{
					this.ip = strEndPoint[0];
					this.tcpPort = Convert.ToInt32(strEndPoint[1]);
				}
			}
		}
		
		private string userId;	
		public string UserId {
			get { return userId; }
			set { userId = value; }
		}
		
		private string ip;
		public string Ip {
			get { return ip; }
			set { ip = value; }
		}
		
		private int tcpPort;
		public int TcpPort {
			get { return tcpPort; }
			set { tcpPort = value; }
		}
		
		private ChatStatus status;
		public ChatStatus Status {
			get { return status; }
			set { status = value; }
		}
		
		private string password;	
		public string Password {
			get { return password; }
			set { password = value; }
		}
		
		private string nickName;
		public string NickName {
			get { return nickName; }
			set { nickName = value; }
		}
		
		private string displayName;	
		public string DisplayName {
			get { return displayName; }
			set { displayName = value; }
		}
		
		private string personalMsg;
		public string PersonalMsg {
			get { return personalMsg; }
			set { personalMsg = value; }
		}
		
		private string head;
		public string Head {
			get { return head; }
			set { head = value; }
		}
		
		private List<ChatFriend> friendList;
		
		public List<ChatFriend> FriendList {
			get { return friendList; }
			set { friendList = value; }
		}
		
		private void GetFriendList()
		{
			try
			{
				DataSet ds = SQLiteHelper.Query("select * from tb_user where userid<>" + this.userId);
				int rows = ds.Tables[0].Rows.Count;
				if (this.friendList != null)
				{
					this.friendList.Clear();
				}
				else
				{
					this.friendList = new List<ChatFriend>();
				}
				for(int i = 0; i<rows; i++)
				{
					{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console(ds.Tables[0].Rows[i]["userid"].ToString(), sf);
					}
					
					ChatFriend friend = new ChatFriend();
					friend.UserId = ds.Tables[0].Rows[i]["userid"].ToString();
					friend.NickName = ds.Tables[0].Rows[i]["nickname"].ToString();
					friend.PersonalMsg = ds.Tables[0].Rows[i]["personalmsg"].ToString();
					friend.Head = ds.Tables[0].Rows[i]["head"].ToString();
					this.friendList.Add(friend);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void GetUser()
		{
			try
			{
				DataSet ds = SQLiteHelper.Query("select * from tb_user where userid=" + this.userId);
				this.password = ds.Tables[0].Rows[0]["password"].ToString();
				this.nickName = ds.Tables[0].Rows[0]["nickname"].ToString();
				this.displayName = ds.Tables[0].Rows[0]["personalmsg"].ToString();
				this.head = ds.Tables[0].Rows[0]["head"].ToString();
				this.status = ChatStatus.Online;
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public void Init()
		{
			try
			{
				this.GetUser();
				this.GetFriendList();
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public ChatUser()
		{
		}
	}
}
