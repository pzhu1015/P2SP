/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-5-7
 * Time: 0:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;
using System.Threading;

namespace P2PService
{
	public enum ConnectType
	{
		eClient,
		eServer
	}
	/// <summary>
	/// Description of ReadWriteObject.
	/// </summary>
	public class ReadWriteObject
	{
		private EventWaitHandle eventWait;
		
		public EventWaitHandle EventWait {
			get { return eventWait; }
			set { eventWait = value; }
		}
		
		private string userId;
		
		public string UserId {
			get { return userId; }
			set { userId = value; }
		}
		
		private ConnectType connType;
		
		public ConnectType ConnType {
			get { return connType; }
			set { connType = value; }
		}
		
		private bool isHeader = true;
		
		public bool IsHeader {
			get { return isHeader; }
			set { isHeader = value; }
		}
		
		private TcpClient client;
		
		public TcpClient Client {
			get { return client; }
			set { client = value; }
		}
		
		private NetworkStream netStream;
		
		public NetworkStream NetStream {
			get { return netStream; }
			set { netStream = value; }
		}
		
		private byte[] headerBuff = new byte[sizeof(Int32)];
		
		public byte[] HeaderBuff {
			get { return headerBuff; }
			set { headerBuff = value; }
		}
		
		private byte[] sendBuff;
		
		public byte[] SendBuff {
			get { return sendBuff; }
			set { sendBuff = value; }
		}
		
		private byte[] readBuff;
		
		public byte[] ReadBuff {
			get { return readBuff; }
			set { readBuff = value; }
		}
		
		private int totalReadLength = 0;
		
		public int TotalReadLength {
			get { return totalReadLength; }
			set { totalReadLength = value; }
		}
		
		public ReadWriteObject(TcpClient _client, ConnectType _type)
		{
			this.client = _client;
			this.netStream = this.client.GetStream();
			this.connType = _type;
		}
		
		public ReadWriteObject(TcpClient _client, EventWaitHandle _eventWait, ConnectType _connType, string _userId)
		{
			this.client = _client;
			this.eventWait = _eventWait;
			this.connType = _connType;
			this.userId = _userId;
		}
		
		public void InitNetWorkStream()
		{
			this.netStream = this.client.GetStream();
		}
		
		public void SetSendBuff(byte[] _buff)
		{
			byte[] header_buff = BitConverter.GetBytes(_buff.Length);
			this.sendBuff = new byte[_buff.Length + header_buff.Length];
			Buffer.BlockCopy(header_buff, 0, this.sendBuff, 0, header_buff.Length);
			Buffer.BlockCopy(_buff, 0, this.sendBuff, header_buff.Length, _buff.Length);
		}
		
		public void SetReadBuff(byte[] _buff)
		{
			this.readBuff = _buff;
		}
	}
}
