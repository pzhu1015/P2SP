/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-4-20
 * Time: 20:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents;
using DevComponents.DotNetBar;

namespace DownLoad.UI
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class AboutForm : Office2007Form
	{
		public AboutForm()
		{
			InitializeComponent();
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			this.Hide();
		}
		
		void AboutFormFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}
	}
}
