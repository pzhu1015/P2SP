/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-8
 * Time: 15:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Resources;

namespace Complents.ChatComp
{
	/// <summary>
	/// Description of FilePanel.
	/// </summary>
	public partial class FilePanel : UserControl
	{
		public const int WIDTH = 230;
		private const int CLOSE_SIZE = 10;
		
		public FilePanel()
		{
			InitializeComponent();
		}
		
		private void DrawCloseButton(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			using(Pen p = new Pen(Color.Gray, 2))
			{
				Rectangle rec = this.Bounds;
				g.DrawLine(
					p,
					rec.Width - CLOSE_SIZE - 8,
					7,
					rec.Width - 8,
					CLOSE_SIZE + 7);
				g.DrawLine(
					p,
					rec.Width -  CLOSE_SIZE - 8,
					CLOSE_SIZE + 7,
					rec.Width - 8,
					7);
			}
		}
		
		private static object listLocker = new object();
		
		private Dictionary<string, SendRecveFileControl> controlList = new Dictionary<string, SendRecveFileControl>();
		
		public Panel PanelMain
		{
			get { return this.panelMain; }
		}
		
		public event CloseFilePanelHandler CloseFilePanel;
		public event EmptyControlsHandler EmptyControls;
		
		protected virtual void OnCloseFilePanel(CloseFilePanelEventArgs e)
		{
			if (this.CloseFilePanel != null)
			{
				this.CloseFilePanel(this, e);
			}
		}
		
		protected virtual void OnEmptyControls(EmptyControlsEventArgs e)
		{
			if (this.EmptyControls != null)
			{
				this.EmptyControls(this, e);
			}
		}
		
		public void AddItem(SendRecveFileControl control)
		{
			control.Dock = DockStyle.Top;
			this.panelMain.Controls.Add(control);
			control.BringToFront();
			lock(listLocker)
			{
				this.controlList.Add(control.FileId, control);
			}
		}
		
		public void RemoveItem(SendRecveFileControl control)
		{
			this.panelMain.Controls.Remove(control);
			control.Dispose();
			if (this.panelMain.Controls.Count == 0)
	        {
				this.OnEmptyControls(new EmptyControlsEventArgs());
			}
		}
		
		public void RemoveItem(string fileId)
		{
			SendRecveFileControl control = this.controlList[fileId];
			if (control != null)
			{
				lock(listLocker)
				{
					this.controlList.Remove(fileId);
				}
				this.RemoveItem(control);
			}
		}
		
		public SendRecveFileControl GetControl(string fileId)
		{
			lock(listLocker)
			{
				if (!this.controlList.ContainsKey(fileId))
				{
					return null;
				}
				return this.controlList[fileId];
			}
		}
		
		void FilePanelPaint(object sender, PaintEventArgs e)
		{
			this.DrawCloseButton(e);
		}
		
		void FilePanelMouseClick(object sender, MouseEventArgs e)
		{
			if(e.Button  == MouseButtons.Left)
			{
				int x = e.X,y =e.Y;
				Rectangle rec = this.Bounds;
				
				rec.Offset(rec.Width  - CLOSE_SIZE - 8, 7);
				rec.Width = CLOSE_SIZE;
				rec.Height = CLOSE_SIZE;
				
				bool isClose = x > rec.X 
				&& x < rec.Right 
				&& y > rec.Y 
				&& y < rec.Bottom;
				
				if(isClose)
				{
					this.OnCloseFilePanel(new CloseFilePanelEventArgs());
				}
			}
		}
	}
}
