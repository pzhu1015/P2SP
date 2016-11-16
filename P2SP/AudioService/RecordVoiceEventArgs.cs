/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-10
 * Time: 18:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace AudioService
{
	/// <summary>
	/// Description of RecordVoiceEventArgs.
	/// </summary>
	public delegate void RecordVoiceHandler(object sender, RecordVoiceEventArgs args);
	public class RecordVoiceEventArgs : EventArgs
	{
		private byte[] buffer;
		
		public byte[] Buffer {
			get { return buffer; }
			set { buffer = value; }
		}
		public RecordVoiceEventArgs(byte[] _buffer)
			:
			base()
		{
			this.buffer = _buffer;
		}
	}
}
