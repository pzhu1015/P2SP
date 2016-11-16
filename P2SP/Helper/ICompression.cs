using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Helper
{
    public interface ICompression
    {
        void Compress(Stream orgStream, Stream cmpStream);

        void DeCompress(Stream cmpStream, Stream orgStream);
        
        byte[] Compress(byte[] orgBytes);
        
        byte[] DeCompress(byte[] cmpBytes);
        
    }
}
