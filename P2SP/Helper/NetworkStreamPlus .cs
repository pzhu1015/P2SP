/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-7-23
 * Time: 11:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Threading;
using System.Net.Sockets;

namespace Helper
{
	/// <summary>  
    /// 构造函数和析构函数  
    /// </summary>  
    public partial class NetworkStreamPlus : IDisposable  
    {  
        /// <summary>  
        /// 网络数据流，只读字段  
        /// </summary>  
        public readonly NetworkStream Stream;  
  
        /// <summary>  
        /// 构造函数  
        /// </summary>  
        public NetworkStreamPlus(NetworkStream netStream)  
        {   // 只读字段只能在构造函数中初始化  
            Stream = netStream;  
        }  
  
        /// <summary>  
        /// 释放所有托管资源和非托管资源  
        /// </summary>  
        public void Dispose()  
        {  
            // 关闭加密传输模块  
            SecurityClose();  
  
            // 请求系统不要调用指定对象的终结器  
            GC.SuppressFinalize(this);  
        }  
  
        /// <summary>  
        /// 析构函数  
        /// </summary>  
        ~NetworkStreamPlus()  
        {  
            Dispose();  
        }  
    }
    
    /// <summary>  
    /// 异步写状态对象  
    /// </summary>  
    internal class AsyncWriteStateObject  
    {  
        public ManualResetEvent eventDone;  
        public NetworkStream stream;  
        public Exception exception;  
    }  
  
    /// <summary>  
    /// 实现TcpClient的异步发送  
    /// </summary>  
    public partial class NetworkStreamPlus  
    {  
        /// <summary>  
        /// 异步发送  
        /// </summary>  
        /// <param name="buffer">字节数组</param>  
        /// <param name="offset">起始偏移量</param>  
        /// <param name="size">字节数</param>  
        public void Write(Byte[] buffer, Int32 offset, Int32 size)  
        {  
            // 用户定义对象  
            AsyncWriteStateObject State = new AsyncWriteStateObject  
            {   // 将事件状态设置为非终止状态，导致线程阻止  
                eventDone = new ManualResetEvent(false),  
                stream = Stream,  
                exception = null,  
            };  
              
            Byte[] BytesArray;  
            if (String.IsNullOrEmpty(_secretKey))  
            {   // 在数据前插入长度信息  
                Int32 Length = size + 4;    // 加入4字节长度信息后的总长度  
                BytesArray = new Byte[Length];  
                Array.Copy(BitConverter.GetBytes(Length), BytesArray, 4);  
                Array.Copy(buffer, offset, BytesArray, 4, size);  
            }  
            else  
            {   // 数据加密  
                Byte[] Cipher = Encrypt(buffer, offset, size);   
                  
                // 在数据前插入长度信息  
                Int32 Length = Cipher.Length + 4;  
                BytesArray = new Byte[Length];  
                Array.Copy(BitConverter.GetBytes(Length), BytesArray, 4);  
                Array.Copy(Cipher, 0, BytesArray, 4, Cipher.Length);  
            }          
  
            // 写入加长度信息头的数据  
            Stream.BeginWrite(BytesArray, 0, BytesArray.Length, new AsyncCallback(AsyncWriteCallback), State);  
  
            // 等待操作完成信号  
            if (State.eventDone.WaitOne(Stream.WriteTimeout, false))  
            {   // 接收到信号  
                if (State.exception != null) throw State.exception;  
            }  
            else  
            {   // 超时异常  
                throw new TimeoutException();  
            }  
        }  
  
        /// <summary>  
        /// 异步发送  
        /// </summary>  
        /// <param name="data">字节数组</param>  
        public void Write(Byte[] data)  
        {  
            Write(data, 0, data.Length);  
        }  
  
        /// <summary>  
        /// 异步发送  
        /// </summary>  
        /// <param name="command">字符串</param>  
        /// <param name="codePage">代码页</param>  
        /// <remarks>  
        /// 代码页：  
        ///     936：简体中文GB2312  
        ///     54936：简体中文GB18030  
        ///     950：繁体中文BIG5  
        ///     1252：西欧字符CP1252  
        ///     65001：UTF-8编码  
        /// </remarks>  
        public void Write(String command, Int32 codePage)  
        {  
            Write(Encoding.GetEncoding(codePage).GetBytes(command));  
        }  
  
        /// <summary>  
        /// 异步写入回调函数  
        /// </summary>  
        /// <param name="ar">异步操作结果</param>  
        private static void AsyncWriteCallback(IAsyncResult ar)  
        {  
            AsyncWriteStateObject State = ar.AsyncState as AsyncWriteStateObject;  
            try  
            {   // 异步写入结束  
                State.stream.EndWrite(ar);  
            }  
  
            catch (Exception e)  
            {   // 异步连接异常  
                State.exception = e;  
            }  
  
            finally  
            {   // 将事件状态设置为终止状态，线程继续  
                State.eventDone.Set();  
            }  
        }  
    }
    
    /// <summary>  
    /// 异步读状态对象  
    /// </summary>  
    internal class AsyncReadStateObject  
    {  
        public ManualResetEvent eventDone;  
        public NetworkStream stream;  
        public Exception exception;  
        public Int32 numberOfBytesRead;  
    }  
  
    /// <summary>  
    /// 实现TcpClient的异步接收  
    /// </summary>  
    public partial class NetworkStreamPlus  
    {  
        /// <summary>  
        /// 接收缓冲区大小  
        /// </summary>  
        public Int32 ReceiveBufferSize = 8 * 1024;  
  
        /// <summary>  
        /// 异步接收  
        /// </summary>  
        /// <param name="data">接收到的字节数组</param>  
        public void Read(out Byte[] data)  
        {  
            // 用户定义对象  
            AsyncReadStateObject State = new AsyncReadStateObject  
            {   // 将事件状态设置为非终止状态，导致线程阻止  
                eventDone = new ManualResetEvent(false),  
                stream = Stream,  
                exception = null,  
                numberOfBytesRead = -1  
            };  
  
            Byte[] Buffer = new Byte[ReceiveBufferSize];  
            using (MemoryStream memStream = new MemoryStream(ReceiveBufferSize))  
            {  
                Int32 TotalBytes = 0;       // 总共需要接收的字节数  
                Int32 ReceivedBytes = 0;    // 当前已接收的字节数  
                while (true)  
                {  
                    // 将事件状态设置为非终止状态，导致线程阻止  
                    State.eventDone.Reset();  
  
                    // 异步读取网络数据流  
                    Stream.BeginRead(Buffer, 0, Buffer.Length, new AsyncCallback(AsyncReadCallback), State);  
  
                    // 等待操作完成信号  
                    if (State.eventDone.WaitOne(Stream.ReadTimeout, false))  
                    {   // 接收到信号  
                        if (State.exception != null) throw State.exception;  
  
                        if (State.numberOfBytesRead == 0)  
                        {   // 连接已经断开  
                            throw new SocketException();  
                        }  
                        else if (State.numberOfBytesRead > 0)  
                        {  
                            if (TotalBytes == 0)  
                            {   // 提取流头部字节长度信息  
                                TotalBytes = BitConverter.ToInt32(Buffer, 0);  
  
                                // 保存剩余信息  
                                memStream.Write(Buffer, 4, State.numberOfBytesRead - 4);  
                            }  
                            else  
                            {  
                                memStream.Write(Buffer, 0, State.numberOfBytesRead);  
                            }  
  
                            ReceivedBytes += State.numberOfBytesRead;  
                            if (ReceivedBytes >= TotalBytes) break;  
                        }  
                    }  
                    else  
                    {   // 超时异常  
                        throw new TimeoutException();  
                    }  
                }  
  
                // 将流内容写入字节数组  
                if (String.IsNullOrEmpty(_secretKey))  
                {  
                    data = (memStream.Length > 0) ? memStream.ToArray() : null;  
                }  
                else  
                {   // 进行数据解密  
                    data = (memStream.Length > 0) ? Decrypt(memStream.ToArray(), 0, TotalBytes - 4) : null;  
                }   
            }  
        }  
  
        /// <summary>  
        /// 异步接收  
        /// </summary>  
        /// <param name="answer">接收到的字符串</param>  
        /// <param name="codePage">代码页</param>  
        /// <remarks>  
        /// 代码页：  
        ///     936：简体中文GB2312  
        ///     54936：简体中文GB18030  
        ///     950：繁体中文BIG5  
        ///     1252：西欧字符CP1252  
        ///     65001：UTF-8编码  
        /// </remarks>  
        public void Read(out String answer, Int32 codePage)  
        {  
            Byte[] data;  
            Read(out data);  
            answer = (data != null) ? Encoding.GetEncoding(codePage).GetString(data) : null;  
        }  
  
        /// <summary>  
        /// 异步读取回调函数  
        /// </summary>  
        /// <param name="ar">异步操作结果</param>  
        private static void AsyncReadCallback(IAsyncResult ar)  
        {  
            AsyncReadStateObject State = ar.AsyncState as AsyncReadStateObject;  
            try  
            {   // 异步写入结束  
                State.numberOfBytesRead = State.stream.EndRead(ar);  
            }  
  
            catch (Exception e)  
            {   // 异步连接异常  
                State.exception = e;  
            }  
  
            finally  
            {   // 将事件状态设置为终止状态，线程继续  
                State.eventDone.Set();  
            }  
        }  
    }
    
    /// <summary>  
    /// 实现传送数据的加解密  
    /// </summary>  
    public partial class NetworkStreamPlus  
    {  
        /// <summary>  
        /// 哈希算法的密钥  
        /// </summary>  
        private const String _hmackey = "昨夜星辰昨夜风，画楼西畔桂堂东。身无彩凤双飞翼，心有灵犀一点通。";  
  
        /// <summary>  
        /// AES对称算法的托管实现  
        /// </summary>  
        protected AesManaged _aes;  
  
        /// <summary>  
        /// 加密密钥字段  
        /// </summary>  
        private String _secretKey;  
  
        /// <summary>  
        /// 加密密钥属性  
        /// </summary>  
        public String SecretKey  
        {  
            get { return _secretKey; }  
            set  
            {  
                _secretKey = value;  
                if (String.IsNullOrEmpty(value))  
                {   // 关闭加密传输模块  
                    SecurityClose();  
                }  
                else  
                {  
                    if (_aes == null) _aes = new AesManaged();  
  
                    // 更新加密密钥（256位）  
                    using (SHA256Managed sha = new SHA256Managed())  
                    {  
                        _aes.Key = sha.ComputeHash(Encoding.UTF8.GetBytes(value + _salt));  
                        sha.Clear();    // 清除敏感数据  
                    }  
  
                    // 更新初始向量（128位）  
                    using (HMACMD5 hmacmd5 = new HMACMD5(Encoding.UTF8.GetBytes(_hmackey)))  
                    {  
                        _aes.IV = hmacmd5.ComputeHash(Encoding.UTF8.GetBytes(_salt));  
                        hmacmd5.Clear();    // 清除敏感数据  
                    }  
                }  
            }  
        }  
  
        /// <summary>  
        /// 最短密码佐料长度  
        /// </summary>  
        public const Int32 MinSaltLength = 16;  
  
        /// <summary>  
        /// 密码佐料字段  
        /// </summary>  
        private String _salt = "雄关漫道真如铁，而今迈步从头越。从头越，苍山如海，残阳如血。";  
  
        /// <summary>  
        /// 密码佐料属性  
        /// </summary>  
        public String Salt  
        {  
            get { return _salt; }  
            set  
            {   // 要求Salt的长度大于16个字符  
                if (!String.IsNullOrEmpty(value) && value.Length >= MinSaltLength)  
                {  
                    _salt = value;  
                    if (!String.IsNullOrEmpty(_secretKey))  
                    {   // 更新加密密钥（256位）  
                        using (SHA256Managed sha = new SHA256Managed())  
                        {  
                            _aes.Key = sha.ComputeHash(Encoding.UTF8.GetBytes(_secretKey + value));  
                            sha.Clear();    // 清除敏感数据  
                        }  
  
                        // 更新初始向量（128位）  
                        using (HMACMD5 hmacmd5 = new HMACMD5(Encoding.UTF8.GetBytes(_hmackey)))  
                        {  
                            _aes.IV = hmacmd5.ComputeHash(Encoding.UTF8.GetBytes(value));  
                            hmacmd5.Clear();    // 清除敏感数据  
                        }  
                    }  
                }  
            }  
        }  
  
        /// <summary>  
        /// 加密数据  
        /// </summary>  
        /// <param name="buffer">原始数据</param>  
        /// <param name="offset">字节偏移量</param>  
        /// <param name="count">要写入当前流的字节数</param>  
        /// <returns>加密后的数据</returns>          
        private Byte[] Encrypt(Byte[] buffer, Int32 offset, Int32 count)  
        {  
            using (MemoryStream ms = new MemoryStream())  
            {  
                using (CryptoStream cs = new CryptoStream(ms, _aes.CreateEncryptor(), CryptoStreamMode.Write))  
                {  
                    cs.Write(buffer, offset, count);  
                    cs.Close();  
                    return ms.ToArray();  
                }  
            }  
        }  
  
        /// <summary>  
        /// 解密数据  
        /// </summary>  
        /// <param name="buffer">原始数据</param>  
        /// <param name="offset">字节偏移量</param>  
        /// <param name="count">要写入当前流的字节数</param>  
        /// <returns>解密后的数据</returns>  
        private Byte[] Decrypt(Byte[] buffer, Int32 offset, Int32 count)  
        {  
            using (MemoryStream ms = new MemoryStream())  
            {  
                using (CryptoStream cs = new CryptoStream(ms, _aes.CreateDecryptor(), CryptoStreamMode.Write))  
                {  
                    cs.Write(buffer, offset, count);  
                    cs.Close();  
                    return ms.ToArray();  
                }  
            }  
        }  
  
        /// <summary>  
        /// 关闭加密传输模块  
        /// </summary>  
        private void SecurityClose()  
        {  
            if (_aes != null)  
            {  
                _aes.Clear();    // 清除敏感数据  
//                _aes.Dispose();  // 释放资源  
                _aes = null;  
            }  
        }  
    }
}
