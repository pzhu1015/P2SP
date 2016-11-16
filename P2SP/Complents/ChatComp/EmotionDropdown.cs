/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-1-17
 * Time: 17:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CCWin;

namespace Complents.ChatComp
{
	/// <summary>
	/// Description of EmotionDropdown.
	/// </summary>
	public partial class EmotionDropdown : UserControl
	{
		private Popup popup;
		
		public Popup Popup {
			get { return popup; }
			set { popup = value; }
		}
		public EmotionDropdown()
		{
			InitializeComponent();
			this.ecDefault.AutoScroll = true;
			this.popup = new Popup(this);
		}
		
		public EmotionContainer EcDefault
		{
			get { return this.ecDefault; }
		}
		
		public void Show(int x, int y)
		{
			this.popup.Show(x, y);
		}
		
		public void Show(Control control)
		{
			this.popup.Show(control);
		}
		
		public void Show(Control control, int x, int y)
		{
			this.popup.Show(control, x, y);
		}
		
		public void AddImage(string text, Image image)
		{
			this.ecDefault.Items.Add(new EmotionItem(text, image));
		}
		
		void EcDefaultItemClick(object sender, EmotionItemMouseClickEventArgs e)
		{
			this.popup.Close();
		}
	}
}
