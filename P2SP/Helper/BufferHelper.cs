/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-28
 * Time: 14:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Helper
{
	/// <summary>
	/// Description of BufferHelper.
	/// </summary>
	public class BufferHelper
	{
		public BufferHelper()
		{
		}
		
		public static byte[] Serialize(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bf.Serialize(stream, obj);
            byte[] datas = stream.ToArray();
            stream.Dispose();
            return datas;
        }

        public static object Deserialize(byte[] datas, int index)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(datas, index, datas.Length - index);
            object obj = bf.Deserialize(stream);
            stream.Dispose();
            return obj;
        }
	}
}
