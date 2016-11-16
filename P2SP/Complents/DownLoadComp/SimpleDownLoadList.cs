/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-7-31
 * Time: 14:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Complents.DownLoadComp
{
    /// <summary>
    /// Description of SimpleDownLoadList.
    /// </summary>
    public partial class SimpleDownLoadList : UserControl
	{
		private bool mouseIsDown = false;  
        private Rectangle mouseRect = Rectangle.Empty;
        private List<SimpleDownLoadListItem> selectedItem = new List<SimpleDownLoadListItem>();
		public SimpleDownLoadList()
		{
			InitializeComponent();
		}
		
				
		private void ResizeToRectangle(Point p)  
        {  
            DrawRectangle();  
            this.mouseRect.Width = p.X - this.mouseRect.Left;
            int y = p.Y;
            if (y < 0)
            {
            	y = 0;
            }
            this.mouseRect.Height = y - this.mouseRect.Top;  
            DrawRectangle();  
        }  
		
        private void DrawRectangle()  
        {  
            Rectangle rect = this.RectangleToScreen(this.mouseRect);  
            ControlPaint.DrawReversibleFrame(rect, Color.White, FrameStyle.Dashed);  
        }  
        
        private void DrawStart(Point p)  
        {  
            this.panelMain.Capture = true;  
            Cursor.Clip = this.RectangleToScreen(new Rectangle(0, 0, this.panelMain.ClientSize.Width, this.panelMain.ClientSize.Height));
            this.mouseRect = new Rectangle(p.X, p.Y, 0, 0);  
        }  
		
		void PanelMainMouseDown(object sender, MouseEventArgs e)
		{
			this.mouseIsDown = true;
            DrawStart(e.Location);
		}
		
		void PanelMainMouseUp(object sender, MouseEventArgs e)
		{
			this.panelMain.Capture = false;  
            Cursor.Clip = Rectangle.Empty;
            if (this.mouseIsDown)
            {
	            foreach(Control c in this.panelMain.Controls)
	            {
	            	if ((c.Top + c.Height) > e.Location.Y)
	                {
	            		SimpleDownLoadListItem item = c as SimpleDownLoadListItem;
	                	item.IsSelected = true;
	                	this.selectedItem.Add(item);
	                }
	            }
	            this.mouseIsDown = false; 
            }
            DrawRectangle();  
            this.mouseRect = Rectangle.Empty;
		}
		
		void PanelMainMouseMove(object sender, MouseEventArgs e)
		{
			if (this.mouseIsDown)  
			{
                ResizeToRectangle(e.Location);
			}
		}
	}
}
