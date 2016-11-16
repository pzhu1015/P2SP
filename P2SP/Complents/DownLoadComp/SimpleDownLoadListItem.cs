/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-7-31
 * Time: 15:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Drawing;
using System.Windows.Forms;

namespace Complents.DownLoadComp
{
    /// <summary>
    /// Description of SimpleDownLoadListItem.
    /// </summary>
    public partial class SimpleDownLoadListItem : UserControl
	{
		private bool isSelected = false;
		
		public bool IsSelected {
			get { return isSelected; }
			set 
			{
				isSelected = value; 
				if (!isSelected)
				{
					return;
				}
				Font oldFont = this.lblFileName.Font;
				this.lblFileName.Font = new Font(oldFont, oldFont.Style | FontStyle.Bold);
			}
		}
		private string fileName;
		
		public string FileName {
			get { return fileName; }
			set 
			{
				fileName = value; 
				this.lblFileName.Text = fileName;
			}
		}
		
		private string length;
		
		public string Length {
			get { return length; }
			set 
			{
				length = value;
				this.lblCurrentSize.Text = "0KB/" + length.ToString();
			}
		}
		
		private string crtSize;
		
		public string CrtSize {
			get { return crtSize; }
			set 
			{ 
				crtSize = value;
				this.lblCurrentSize.Text = crtSize + "/" + length.ToString();
			}
		}
		
		private Image extistion;
		
		public Image Extistion {
			get { return extistion; }
			set 
			{
				extistion = value; 
				this.picExtision.Image = extistion;
			}
		}
		
		//private DownLoadStatus status;
		
		//public DownLoadStatus Status {
		//	get { return status; }
		//	set 
		//	{
		//		status = value;
		//		string status_str = DownLoadStatusStr.GetName(status);
		//		switch(status)
		//		{
		//		case DownLoadStatus.eFail:
		//			this.btnStatus.Image = Resource.fail;
		//			break;
		//		case DownLoadStatus.eFinish:
		//			this.btnStatus.Image = Resource.finish;
		//			break;
		//		case DownLoadStatus.eStart:
		//			this.btnStatus.Image = Resource.start;
		//			break;
		//		case DownLoadStatus.eStop:
		//			this.btnStatus.Image = Resource.stop;
		//			break;
		//		case DownLoadStatus.eWait:
		//			this.btnStatus.Image = Resource.wait;
		//			break;
		//		default :
		//				break;
		//		}
		//	}
		//}
		
		private int progress;
		
		public int Progress {
			get { return progress; }
			set 
			{ 
				progress = value; 
				this.pbProgress.Value = progress;
			}
		}
		
		private string speed;
		
		public string Speed {
			get { return speed; }
			set 
			{ 
				speed = value; 
				this.lblSpeed.Text = speed;
			}
		}
		
		private string takeTime;
		
		public string TakeTime {
			get { return takeTime; }
			set 
			{ 
				takeTime = value; 
				this.lblTakeTime.Text = takeTime;
			}
		}
		
		//private DownLoadTask task;
		
		//public DownLoadTask Task {
		//	get { return task; }
		//	set { task = value; }
		//}
		
		public SimpleDownLoadListItem()
		{
			InitializeComponent();
		}
		
		
	}
}
