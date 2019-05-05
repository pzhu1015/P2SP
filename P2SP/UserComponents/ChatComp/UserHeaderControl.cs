/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-8-22
 * Time: 10:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UserComponents.ChatComp
{
	/// <summary>
	/// Description of UserHeaderControl.
	/// </summary>
	public partial class UserHeaderControl : UserControl
	{
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
		public UserHeaderControl()
		{
			InitializeComponent();
		}
	}
	
}
