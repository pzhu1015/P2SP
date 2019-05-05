/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-18
 * Time: 15:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Helper;
using CCWin;
using CCWin.SkinControl;
using SendFileService;

namespace UserComponents.ChatComp
{
	/// <summary>
	/// Description of SendRecveFile.
	/// </summary>
	public partial class SendRecveFileControl : UserControl
	{	
		private int count;
		
		public int Count {
			get { return count; }
			set { count = value; }
		}
		
		private SendType type;
		
		public SendType Type {
			get { return type; }
			set { type = value; }
		}
		
		private string fileId;
		
		public string FileId {
			get { return fileId; }
			set { fileId = value; }
		}
		
		private Image image;
		
		public Image Image {
			get { return image; }
			set 
			{
				image = value; 
				if (image != null)
				{
					this.picBoxFile.Image = image;
				}
			}
		}
		
        private string comment;
        
		public string Comment {
			get { return comment; }
			set 
			{
				if (comment != value)
				{
					comment = value; 
					this.lblCommon.Text = comment;
				}
			}
		}
        
        private string fileName;
        
		public string FileName {
			get { return fileName; }
			set 
			{ 
				if (fileName != value)
				{
					fileName = value; 
					this.lblFileName.Text = fileName;
				}
			}
		}
        
        private long length;
        
		public long Length {
			get { return length; }
			set 
			{ 
				if (length != value)
				{
					length = value;
					this.lblCurrentLength.Text = DiskHelper.GetSize(length);
				}
			}
		}
        
        private long transSize;
        
        public long TransSize
        {
            get { return transSize; }
            set
            {
                if (transSize != value)
                {
                    transSize = value;
                    float size = transSize / (length * 1.0f);
                    if (this.length != 0)
                    {
                        int barValue = (int)(size * 100);
                        if (barValue > 100)
                            barValue = 100;
                        this.progressBar.Value = barValue;
                    }
                    this.lblCurrentLength.Text = string.Format("{0}/{1}",
                        DiskHelper.GetSize(transSize), DiskHelper.GetSize(length));
                    this.lblSpeed.Text = this.GetSpeedText();
                }
            }
        }

        private bool isSend = true;
        
		public bool IsSend {
			get { return isSend; }
            set
            {
                isSend = value;
                if (isSend)
                {
                    this.lblSave.Hide();
                    this.lblRecve.Hide();
                }
                else
                {
                    this.lblSave.Show();
                    this.lblRecve.Show();
                }
                this.InitText();
            }
		}

        private DateTime startTime;
        
		public DateTime StartTime {
			get { return startTime; }
			set { startTime = value; }
		}
        
        public void SetRecveControl()
        {
        	this.lblSave.Hide();
            this.lblRecve.Hide();
            this.lblCancel.Text = "取消";
        }
        
        public event CancelClickEventHandler CancelClick;
        public event RecveClickEventHandler RecveClick;
        public event SaveClickEventHandler SaveClick;
        
		public SendRecveFileControl()
		{
			InitializeComponent();
			this.InitText();
			this.InitEvents();
		}
		
		protected virtual void OnCancelClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
            {
                if (this.CancelClick != null)
                {
                	this.CancelClick(sender, new CancelClickEventArgs(this));
                }
            }
		}
		
		protected virtual void OnRecveClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
            {
                if (this.RecveClick != null)
                {
                	this.RecveClick(sender, new RecveClickEventArgs(this));
                }
            }
		}
		
		protected virtual void OnSaveClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
            {
                if (this.SaveClick != null)
                {
                	this.SaveClick(sender, new SaveClickEventArgs(this));
                }
            }
		}
		
		private void InitEvents()
        {
            this.lblRecve.MouseEnter += new EventHandler(OnLabelMouseEnter);
            this.lblRecve.MouseLeave += new EventHandler(OnLabelMouseLeave);
            this.lblRecve.MouseClick += new MouseEventHandler(OnRecveClick);

            this.lblSave.MouseEnter += new EventHandler(OnLabelMouseEnter);
            this.lblSave.MouseLeave += new EventHandler(OnLabelMouseLeave);
            this.lblSave.MouseClick += new MouseEventHandler(OnSaveClick);

            this.lblCancel.MouseEnter += new EventHandler(OnLabelMouseEnter);
            this.lblCancel.MouseLeave += new EventHandler(OnLabelMouseLeave);
            this.lblCancel.MouseClick += new MouseEventHandler(OnCancelClick);
        }

		private void InitText()
		{
			if (this.isSend)
            {
                this.lblCancel.Text = "取消";
            }
            else
            {
                this.lblCancel.Text = "拒绝";
            }

            this.lblSave.Text = "另存为...";
            this.lblRecve.Text = "接收";
		}
		
		private string GetText(double size)
        {
            if (size < 1024)
                return string.Format("{0} B", size.ToString());
            else if (size < 1024 * 1024)
                return string.Format("{0} KB", (size / 1024.0f).ToString("0.0"));
            else
                return string.Format("{0} MB", (size / (1024.0f * 1024.0f)).ToString("0.0"));
        }
		
		private string GetSpeedText()
        {
			try
			{
	            TimeSpan span = DateTime.Now - this.startTime;
	            double seconds = span.TotalSeconds;
	            double speed = this.transSize / seconds;
	            {
	            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("speed: " + speed.ToString() + " transSize: " + this.transSize + " seconds: " + seconds, sf);
				}
	            if ((long)speed == 0)
	            {
	            	string.Format("{0}/s", "0B");
	            }
	            return string.Format("{0}/s", DiskHelper.GetSize((long)speed));
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				return "";
			}
        }
		
        void OnLabelMouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
                label.ForeColor = Color.Blue;
        }

        void OnLabelMouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
                label.ForeColor = Color.Red;
        }
	}
}
