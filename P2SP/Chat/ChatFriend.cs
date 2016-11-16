/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-6
 * Time: 17:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;
using System.Collections.Generic;

using Trans;
using SendFileService;
using AudioService;

namespace Chat
{
    public enum ChatStatus
	{
		Away,
		Busy,
		OffLine,
		Online,
		QMe,
		DontDisturb	
	}
	
	/// <summary>
	/// Description of ChatFriend.
	/// </summary>
	[Serializable]
	public class ChatFriend
	{
		[NonSerialized]
		private VoiceCapture voice;
		public VoiceCapture Voice {
			get { return voice; }
			set { voice = value; }
		}
		
		[NonSerialized]
		private Dictionary<string, SendReader> readerList;
		[NonSerialized]
		private Dictionary<string, RecveWriter> writerList;
		private Queue<BaseTrans> sendPackages;
		[NonSerialized]
		private Queue<BaseTrans> recvePackages;
		[NonSerialized]
		private static object readerLocker;
		[NonSerialized]
		private static object writerLocker;
		[NonSerialized]
		private static object sendQueueLocker;
		[NonSerialized]
		private static object recveQueueLocker;
		[NonSerialized]
		private static object clientLocker;
		
		public void Init()
		{
			this.sendPackages = new Queue<BaseTrans>();
			this.recvePackages = new Queue<BaseTrans>();
			this.readerList = new Dictionary<string, SendReader>();
			this.writerList = new Dictionary<string, RecveWriter>();
			readerLocker = new object();
			writerLocker = new object();
			sendQueueLocker = new object();
			recveQueueLocker = new object();
			clientLocker = new object();
			
		}
		
		public ChatFriend()
		{
		}
		
		public ChatFriend(ChatUser _user)
		{
			this.Init();
			this.userId = _user.UserId;
			this.ip = _user.Ip;
			this.tcpPort = _user.TcpPort;
			this.nickName = _user.NickName;
			this.displayName = _user.DisplayName;
			this.personalMsg = _user.PersonalMsg;
			this.head = _user.Head;
			this.status = _user.Status;
		}
		
		[NonSerialized]
		private object subItem;
		
		public object SubItem {
			get { return subItem; }
			set { subItem = value; }
		}
		
		[NonSerialized]
		private object chatFrm;
		public object ChatFrm {
			get { return chatFrm; }
			set { chatFrm = value; }
		}
	
		[NonSerialized]
		private TcpClient client;
		public TcpClient Client {
			get { return client; }
			set { client = value; }
		}
	
		private ChatStatus status;
		public ChatStatus Status {
			get { return status; }
			set { status = value; }
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
		

		
		#region 外部接口
		
		public void PushRecvePackage(BaseTrans trans)
		{
			lock(recveQueueLocker)
			{
				this.recvePackages.Enqueue(trans);
			}
		}
		
		public BaseTrans PopRecvePackage()
		{
			lock(recveQueueLocker)
			{
				return this.recvePackages.Dequeue();
			}
		}
		
		public int CountRecvePackage()
		{
			lock(recveQueueLocker)
			{
				return this.recvePackages.Count;
			}
		}
		
		public void PushSendPackage(BaseTrans trans)
		{
			lock(sendQueueLocker)
			{
				this.sendPackages.Enqueue(trans);
			}
		}
		
		public BaseTrans PopSendPackage()
		{
			lock(sendQueueLocker)
			{
				return this.sendPackages.Dequeue();
			}
		}
		
		public int CountSendPackage()
		{
			lock(sendQueueLocker)
			{
				return this.sendPackages.Count;
			}
		}
		
		public void AddReader(string md5, SendReader reader)
		{
			lock(readerLocker)
			{
				this.readerList.Add(md5, reader);
			}
		}
		
		public SendReader GetReader(string md5)
		{
			lock(readerLocker)
			{
				if (this.readerList.ContainsKey(md5))
				{
					return this.readerList[md5];
				}
				else
				{
					return null;
				}
			}
		}
		
		public void RemoveReader(string md5)
		{
			lock(readerLocker)
			{
				this.readerList.Remove(md5);
			}
		}
		
		public void AddWriter(string md5, RecveWriter writer)
		{
			lock(writerLocker)
			{
				this.writerList.Add(md5, writer);
			}
		}
		
		public RecveWriter GetWriter(string md5)
		{
			lock(writerLocker)
			{
				if (this.writerList.ContainsKey(md5))
				{
					return this.writerList[md5];
				}
				else
				{
					return null;
				}
			}
		}
		
		public void RemoveWriter(string md5)
		{
			lock(writerLocker)
			{
				this.writerList.Remove(md5);
			}
		}
		
		#endregion
	}
}
