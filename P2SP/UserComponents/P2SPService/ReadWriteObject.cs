/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/13 星期四
 * Time: 下午 4:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.P2SPService
{
	/// <summary>
	/// Description of ReadWriteObject.
	/// </summary>
	public class ReadWriteObject
	{
		private bool isHeader = true;
		
		public bool IsHeader {
			get { return isHeader; }
			set { isHeader = value; }
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
		
		public ReadWriteObject()
		{
		}
		
		public void SetSendBuff(byte[] _buff)
		{
			byte[] header_buff = BitConverter.GetBytes(_buff.Length);
			this.sendBuff = new byte[_buff.Length + header_buff.Length];
			Buffer.BlockCopy(header_buff, 0, this.sendBuff, 0, header_buff.Length);
			Buffer.BlockCopy(_buff, 0, this.sendBuff, header_buff.Length, _buff.Length);
		}
		
		public void SetReadBuff(int _len, bool _isHeader)
		{
			this.readBuff = new byte[_len];
			this.isHeader = _isHeader;
			this.totalReadLength = 0;
		}
	}
}
