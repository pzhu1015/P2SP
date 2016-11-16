/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-7-24
 * Time: 15:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.DownLoadComp
{
	/// <summary>
	/// Description of DownLoadItemClickEventArgs.
	/// </summary>
	public delegate void DownLoadItemClickHandler(object sender, DownLoadItemClickEventArgs args);
	public class DownLoadItemClickEventArgs : EventArgs
	{
		public DownLoadItemClickEventArgs()
			:
			base()
		{
		}
	}
}
