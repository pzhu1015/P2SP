/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-21
 * Time: 15:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SendFileService
{
	/// <summary>
	/// Description of ReadFolderEventArgs.
	/// </summary>
	
	public delegate void ReadFolderHandler(object sender, ReadFolderEventArgs args);
	public class ReadFolderEventArgs : EventArgs
	{
		private string subName;
		
		public string SubName {
			get { return subName; }
			set { subName = value; }
		}
		public ReadFolderEventArgs(string _subName)
			:
			base()
		{
			this.subName = _subName;
		}
	}
}
