/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-4-5
 * Time: 21:12
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
	/// Description of DeleteConfirmForm.
	/// </summary>
	public partial class DeleteConfirmForm : Office2007Form
	{
		private DownLoadForm downLoadFrm;
		
		public DownLoadForm DownLoadFrm {
			get { return downLoadFrm; }
			set { downLoadFrm = value; }
		}
		public DeleteConfirmForm()
		{
			InitializeComponent();
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			this.downLoadFrm.DeleteTask(this.chBoxIsDeleteFile.Checked);
			this.Hide();
		}
		
		void BtnCancleClick(object sender, EventArgs e)
		{
			this.Hide();
		}
		
		void DeleteConfirmFormFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}
	}
}
