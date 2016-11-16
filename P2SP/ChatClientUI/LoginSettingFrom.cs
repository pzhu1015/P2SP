/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-2-18
 * Time: 16:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using CCWin;
using CCWin.SkinControl;
using CCWin.SkinClass;

using Chat;
using Helper;
namespace ChatClientUI
{
	/// <summary>
	/// Description of LoginSettingFrom.
	/// </summary>
	public partial class LoginSettingFrom : CCSkinMain
	{
		private LoginForm loginFrm;
		
		public LoginForm LoginFrm {
			get { return loginFrm; }
			set { loginFrm = value; }
		}
		
		public LoginSettingFrom()
		{
			InitializeComponent();
		}
		
		void LoginSettingFromLoad(object sender, EventArgs e)
		{
			this.txtServerIp.Text = AppConfigMgr.Instance.GetAttribute(AppConfigMgr.ServerIp);
			this.txtTcpPort.Text = AppConfigMgr.Instance.GetAttribute(AppConfigMgr.ServerTcpPort);
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Hide();
			this.loginFrm.Show();
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			AppConfigMgr.Instance.SetAttribute(AppConfigMgr.ServerIp, this.txtServerIp.Text);
			AppConfigMgr.Instance.SetAttribute(AppConfigMgr.ServerTcpPort, this.txtTcpPort.Text);
			AppConfigMgr.Instance.SaveConfig();
			this.Hide();
			this.loginFrm.Show();
		}
		
		void LoginSettingFromFormClosed(object sender, FormClosedEventArgs e)
		{
			this.loginFrm.Dispose();
			Application.Exit();
		}
	}
}
