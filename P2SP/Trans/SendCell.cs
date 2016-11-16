/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-28
 * Time: 14:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using Helper;

namespace Trans
{
	/// <summary>
	/// Description of SendCell.
	/// </summary>
	[Serializable]
    public class SendCell : IDataCell
    {
        private object data;
        
		public object Data {
			get { return data; }
			set { data = value; }
		}

        public SendCell() { }

        public SendCell(object _data)
        {
        	this.data = _data;
        }

        public byte[] ToBuffer()
        {
            byte[] buff = BufferHelper.Serialize(this.data);
            return buff;
        }

        public void FromBuffer(byte[] buff)
        {
            this.data = BufferHelper.Deserialize(buff, 0);
        }
    }
}
