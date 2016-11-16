/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-14
 * Time: 15:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using Helper;
using CCWin;
using CCWin.SkinControl;

namespace ChatClientUI
{
	/// <summary>
	/// Description of UserInfoForm.
	/// </summary>
	public partial class UserInfoForm : CCSkinMain
	{
		private Point position;
		
		public Point Position {
			get { return position; }
			set { position = value; }
		}
		
		private ChatListSubItem item;
		
		public ChatListSubItem Item {
			get { return item; }
			set { item = value; }
		}
        
        public UserInfoForm()
        {
        	InitializeComponent();
        }
		
		void UserInfoFormLoad(object sender, EventArgs e)
		{
			
		}
		
		public void SetInfo()
		{
			DebugHelper.Assert(this.position != null && this.item != null);
			this.Location = this.position;
			this.lblName.Text = string.IsNullOrEmpty(this.item.NicName)?this.item.ID.ToString():this.item.NicName;
			this.lblPersnalMsg.Text = this.item.PersonalMsg;
		}
	}
}
