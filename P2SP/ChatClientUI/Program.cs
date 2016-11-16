/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-5-8
 * Time: 15:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Drawing;

using Chat;

namespace ChatClientUI
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			LoginForm loginFrm = new LoginForm();
			Application.Run(loginFrm);
		}
		
		public static Image GetHeadImage(string head)
		{
			return Image.FromFile(Application.StartupPath + @"\" + FileName.Head + @"\" + head);
		}
		
		public static Bitmap GetHeadBitmap(string head)
		{
			return new Bitmap(Application.StartupPath +  @"\" + FileName.Head + @"\" + head);
		}
	}
}
