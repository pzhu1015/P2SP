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

using CCWin.SkinControl;

namespace UserComponents.ChatComp
{
	/// <summary>
	/// Description of LoginUser.
	/// </summary>
	public partial class LoginUserControl : UserControl
	{
		public const int WIDTH = 80;
		
		public event UserControlClickHandler UserControlClick;
		public event UserControlRemoveHandler UserControlRemove;

        protected virtual void OnUserControlClick(UserControlClickEventArgs e)
		{
			if (this.UserControlClick != null)
			{
				this.UserControlClick(this, e);
			}
		}
		
		protected virtual void OnUserControlRemove(UserControlRemoveEventArgs e)
		{
			if (this.UserControlRemove != null)
			{
				this.UserControlRemove(this, e);
			}
		}
		
		public bool IsCheck {
			get { return this.cbIsChecked.Checked; }
		}
				
		private string userId;
		
		public string UserId {
			get { return userId; }
			set { userId = value; }
		}
		private string passWord;
		
		public string PassWord {
			get { return passWord; }
			set { passWord = value; }
		}
		
		private string nickName;
		
		public string NickName {
			get { return nickName; }
			set 
			{
				nickName = value; 
				this.lblNickName.Text = nickName;
			}
		}
		
		private Image head;
		[Category("Custom")]
		[Description("Set/Get user head image")]
		[DefaultValue(null)]
		public Image Head {
			get { return head; }
			set 
			{ 
				head = value; 
				this.headImage.BackgroundImage = head;
			}
		}

		private bool isShowCheckBox;
		[Category("Custom")]
        [Description("Set/Get show check box")]
        [DefaultValue(true)]
		public bool IsShowCheckBox {
			get { return isShowCheckBox; }
			set 
			{				
				isShowCheckBox = value;
				this.cbIsChecked.Visible = this.isShowCheckBox;
			}
		}
        
        private bool isShowNickName;
        [Category("Custom")]
        [Description("Set/Get show nickname")]
        [DefaultValue(true)]
		public bool IsShowNickName {
			get { return isShowNickName; }
			set 
			{				
				isShowNickName = value;
				this.lblNickName.Visible = this.isShowNickName;
			}
		}
        
        private bool isShowRemove;
        [Category("Custom")]
        [Description("Set/Get show nickname")]
        [DefaultValue(true)]
		public bool IsShowRemove {
			get { return isShowRemove; }
			set 
			{				
				isShowRemove = value;
				this.btnRemove.Visible = this.isShowRemove;
			}
		}
		
		public LoginUserControl()
		{
			InitializeComponent();
			this.Head = UserComponents.ChatCompResource.default_head;
			this.isShowCheckBox = true;
			this.isShowNickName = true;
			this.isShowRemove = true;
		}
		
		void BtnStateClick(object sender, EventArgs e)
		{
			this.menuStripState.Show(this.btnState as Control, 0, this.btnState.Height);
		}
		
		void MenuStripStateItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			ToolStripItem item = e.ClickedItem;
			this.btnState.Image = item.Image;
		}
		
		void ClickLoginUserControl(object sender, EventArgs e)
		{
			this.OnUserControlClick(new UserControlClickEventArgs());
		}
		
		void BtnRemoveClick(object sender, EventArgs e)
		{
			this.OnUserControlRemove(new UserControlRemoveEventArgs());
		}
	}
}
