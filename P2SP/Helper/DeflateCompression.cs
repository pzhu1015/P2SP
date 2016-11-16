using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Helper
{
    public class DeflateCompression : ICompression
    {

       public DeflateCompression()
        {
        }

        #region ICompression ≥…‘±

        public void Compress(System.IO.Stream orgStream, System.IO.Stream cmpStream)
        {
            System.IO.Compression.DeflateStream zipStream = new System.IO.Compression.DeflateStream(cmpStream, System.IO.Compression.CompressionMode.Compress);

            byte[] buffer = new byte[1024 * 10];
            int offset = 0;
            while (true)
            {
                int bytesRead = orgStream.Read(buffer, offset, 1024 * 10);
                if (bytesRead == 0)
                {
                    break;
                }
                zipStream.Write(buffer, 0, bytesRead);
            }
        }

        public void DeCompress(System.IO.Stream cmpStream, System.IO.Stream orgStream)
        {
            System.IO.Compression.DeflateStream zipStream = new System.IO.Compression.DeflateStream(cmpStream, System.IO.Compression.CompressionMode.Decompress);

            byte[] buffer = new byte[1024 * 10];
            int offset = 0;
            while (true)
            {
                int bytesRead = zipStream.Read(buffer, offset, 1024 * 10);
                if (bytesRead == 0)
                {
                    break;
                }
                orgStream.Write(buffer, 0, bytesRead);
            }
        }

        public byte[] Compress(byte[] orgBytes)
        {
        	using(MemoryStream orgStream = new MemoryStream(orgBytes))
        	{
        		using(MemoryStream cmpStream = new MemoryStream())
        		{
		        	Compress(orgStream, cmpStream);
		        	return cmpStream.ToArray();
        		}
        	}
        }
        
        public byte[] DeCompress(byte[] cmpBytes)
        {
        	using(MemoryStream cmpStream = new MemoryStream(cmpBytes))
        	{
        		using(MemoryStream orgStream = new MemoryStream())
        		{
		        	DeCompress(cmpStream, orgStream);
		        	return orgStream.ToArray();
        		}
        	}
        }
        
        #endregion
    }
}
