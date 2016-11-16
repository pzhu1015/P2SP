/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-25
 * Time: 9:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Complents.ChatComp
{
	/// <summary>
	/// Description of LoginUserPanel.
	/// </summary>
	public partial class LoginUserPanel : UserControl
	{
		private const int MAXCOUNT = 2;
		public event EmptyControlsHandler EmptyControl;
		
		protected virtual void OnEmptyControl(EmptyControlsEventArgs e)
		{
			if (this.EmptyControl != null)
			{
				this.EmptyControl(this, e);
			}
		}
		public LoginUserPanel()
		{
			InitializeComponent();
		}
		
		public void AddLoginUser(Control control)
		{
			control.Dock = DockStyle.None;
			control.Top = 0;
			this.panelMain.Controls.Add(control);
		}
		
		public void LayOutItem()
		{
			int count = this.panelMain.Controls.Count;
			count = (count > MAXCOUNT) ? MAXCOUNT : count;
			int w = this.panelMain.Width;
			int paddingX = (w - count * LoginUserControl.WIDTH + 1) / (count + 1);
			for(int i = 0; i < this.panelMain.Controls.Count; i++)
			{
				Control c = this.panelMain.Controls[i];
				c.Left = paddingX + i * (LoginUserControl.WIDTH + paddingX);
			}
		}
		
		public void RemoveLoginUser(string userId)
		{
			foreach(Control c in this.panelMain.Controls)
			{
				LoginUserControl control = c as LoginUserControl;
				if (control.UserId == userId)
				{
					this.panelMain.Controls.Remove(c);
					break;
				}
			}
			this.LayOutItem();
			if (this.panelMain.Controls.Count == 0)
			{
				this.OnEmptyControl(new EmptyControlsEventArgs());
			}
		}
		
		public System.Windows.Forms.Control.ControlCollection GetLoginUser()
		{
			return this.panelMain.Controls;
		}
	}
}
