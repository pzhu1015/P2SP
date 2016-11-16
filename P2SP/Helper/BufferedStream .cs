/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-6
 * Time: 10:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
	/// <summary>
	/// Description of BufferedStream.
	/// </summary>
    public class BufferedStream : System.IO.Stream
    {
        System.IO.Stream stream;
        /// <summary>
        /// 构建一个内存缓冲流
        /// </summary>
        public BufferedStream() : base() { stream = new System.IO.MemoryStream(); }
        /// <summary>
        /// 从基础流构建流
        /// </summary>
        /// <param name="stream">源流</param>
        public BufferedStream(System.IO.Stream stream) { this.stream = stream; }
        /// <summary>
        /// 从字节数组构建缓冲流
        /// </summary>
        /// <param name="bytes">字节数组</param>
        public BufferedStream(byte[] bytes) { stream = new System.IO.MemoryStream(bytes); }
 
        /// <summary>
        /// 将整个流内容写入字节数组，而与 System.IO.MemoryStream.Position 属性无关。
        /// </summary>
        /// <exception cref="System.InvalidOperationException">如果源流不是一个内存流，将引发此异常</exception>
        /// <returns></returns>
        public byte[] ToArray()
        {
            System.IO.MemoryStream ms = stream as System.IO.MemoryStream;
            if (ms == null)
                throw new InvalidOperationException();
            return ms.ToArray();
        }
        public void Write(long value)
        {
            this.Write(BitConverter.GetBytes(value));
        }
        public void Write(ulong value)
        {
            this.Write(BitConverter.GetBytes(value));
        }
        public void Write(ushort value)
        {
            this.Write(BitConverter.GetBytes(value));
        }
        public void Write(int value)
        {
            this.Write(BitConverter.GetBytes(value));
        }
        public void Write(DateTime value)
        {
            this.Write(BitConverter.GetBytes(value.Ticks));
        }
        public void Write(uint value)
        {
            this.Write(BitConverter.GetBytes(value));
        }
        public void Write(byte[] bytes)
        {
            this.Write(bytes, 0, bytes.Length);
        }
        public void Write(string value)
        {
            byte[] buff = Encoding.UTF8.GetBytes(value);
            this.Write(BitConverter.GetBytes((ushort)buff.Length));
            this.Write(buff);
        }
        public void WriteObject(object obj)
        {
            byte[] bytes = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (System.IO.Compression.GZipStream gz = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress))
                {
                    System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    formatter.Serialize(gz, obj);
                    bytes = ms.GetBuffer();
                }
            }
            this.Write(bytes.Length);
            this.Write(bytes);
        }
        public void WriteUserId(string userId)
        {
            byte[] buff = Encoding.UTF8.GetBytes(userId);
            this.WriteByte((byte)buff.Length);
            this.Write(buff);
        }
 
        public object ReadObject()
        {
            int len = this.ReadInt();
            byte[] bytes = this.Read(len);
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
            {
                using (System.IO.Compression.GZipStream gz = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress))
                {
                    System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    return formatter.Deserialize(gz);
                }
            }
        }
        public uint ReadUInt()
        {
            return BitConverter.ToUInt32(Read(4), 0);
        }
        public int ReadInt()
        {
            return BitConverter.ToInt32(Read(4), 0);
        }
        public ushort ReadUShort()
        {
            byte[] bytes = Read(2);
            return BitConverter.ToUInt16(bytes, 0);
        }
        public DateTime ReadDateTime()
        {
            byte[] bytes = Read(8);
            return new DateTime(BitConverter.ToInt64(bytes, 0));
        }
        public string ReadString()
        {
            ushort len = ReadUShort();
            byte[] buff = Read(len);
            return Encoding.UTF8.GetString(buff);
        }
        public string ReadUserId()
        {
            byte len = (byte)ReadByte();
            byte[] buff = Read(len);
            return Encoding.UTF8.GetString(buff);
        }
        public byte[] Read(int len)
        {
            byte[] buff = new byte[len];
            this.Read(buff, 0, len);
            return buff;
        }
 
        public override bool CanRead
        {
            get { return stream.CanRead; }
        }
 
        public override bool CanSeek
        {
            get { return stream.CanSeek; }
        }
 
        public override bool CanWrite
        {
            get { return stream.CanWrite; }
        }
 
        public override void Flush()
        {
            stream.Flush();
        }
 
        public override long Length
        {
            get { return stream.Length; }
        }
 
        public override long Position
        {
            get
            {
                return stream.Position;
            }
            set
            {
                stream.Position = Position;
            }
        }
 
        public override int Read(byte[] buffer, int offset, int count)
        {
            return stream.Read(buffer, offset, count);
        }
 
        public override long Seek(long offset, System.IO.SeekOrigin origin)
        {
            return stream.Seek(offset, origin);
        }
 
        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }
 
        public override void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer, offset, count);
        }
 
        public override void Close()
        {
            stream.Close();
            base.Close();
        }
    }
}
