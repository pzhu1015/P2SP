/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-6
 * Time: 10:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.IO.Compression;

namespace Helper
{
	/// <summary>
	/// Description of CompressionHelper.
	/// </summary>
	public class CompressionHelper
	{
		public CompressionHelper()
		{
		}
		
		public enum CompressionType
        { 
            GZip = 0 ,
            Deflate = 1
        }

        public static void Compress(CompressionType type, Stream orgStream, Stream cmpStream)
        {
            switch( type )
            {
                case CompressionType.GZip:
                    (new GZipCompression()).Compress(orgStream, cmpStream); break;
                case CompressionType.Deflate:
                    (new DeflateCompression()).Compress(orgStream, cmpStream); break;
            }
        }

        public static void DeCompress(CompressionType type, Stream cmpStream, Stream orgStream)
        {
            switch( type )
            {
                case CompressionType.GZip:
                    (new GZipCompression()).DeCompress(cmpStream, orgStream);break;
                case CompressionType.Deflate:
                    (new DeflateCompression()).DeCompress(cmpStream, orgStream);break;
            }
        }
        
        public static byte[] Compress(CompressionType type, byte[] bytes)
        {
        	switch( type )
            {
                case CompressionType.GZip:
                    return (new GZipCompression()).Compress(bytes);
                case CompressionType.Deflate:
                    return (new DeflateCompression()).Compress(bytes);
                default: 
                    return null;
            }
        }
        
        public static byte[] Decompress(CompressionType type, byte[] bytes)
        {
        	switch( type )
            {
                case CompressionType.GZip:
                    return (new GZipCompression()).DeCompress(bytes);
                case CompressionType.Deflate:
                    return (new DeflateCompression()).DeCompress(bytes);
                default:
                    return null;
            }
        }
	}
}
