/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-29
 * Time: 21:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;

namespace DownLoadService
{
	/// <summary>
	/// Description of Block.
	/// </summary>
	public class Block
	{
		private long start;
		private long end;
		private long pos;
		private XmlNode blockNode;
		public int MaxTrys = 10;
		public Block()
		{
		}
		
		public Block(long _s, long _e, long _p)
		{
			this.start = _s;
			this.end = _e;
			this.pos = _p;
		}
		
		public Block(XmlNode node)
		{
			this.blockNode = node;
			XmlElement el = (XmlElement)node;
			this.start = Convert.ToInt64(el.GetAttribute("start"));
			this.end = Convert.ToInt64(el.GetAttribute("end"));
			this.pos = Convert.ToInt64(el.GetAttribute("pos"));
		}
			
		public long Start {
			get { return start; }
			set { start = value; }
		}
			
		public long End {
			get { return end; }
			set { end = value; }
		}
			
		public long Pos {
			get { return pos; }
			set { pos = value; }
		}
				
		public XmlNode BlockNode {
			get { return blockNode; }
			set { blockNode = value; }
		}
	}
}
