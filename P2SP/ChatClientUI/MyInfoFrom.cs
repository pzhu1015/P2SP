/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-2-11
 * Time: 11:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using CCWin;
using CCWin.SkinControl;

namespace ChatClientUI
{
	/// <summary>
	/// Description of MyInfoFrom.
	/// </summary>
	public partial class MyInfoFrom : CCWin.CCSkinMain
	{
		private MainForm mainFrm;
		
		public MainForm MainFrm {
			get { return mainFrm; }
			set { mainFrm = value; }
		}
		public MyInfoFrom()
		{
			InitializeComponent();
		}
		
		void MyInfoFromLoad(object sender, EventArgs e)
		{
			
		}
		
		void MyInfoFromFormClosing(object sender, FormClosingEventArgs e)
		{
			this.mainFrm.MyInfoFrm = null;
		}
	}
}
