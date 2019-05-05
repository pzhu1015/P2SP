/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-24
 * Time: 13:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text;
using System.Collections.Generic;

using CCWin;
using CCWin.SkinControl;
using SendFileService;
using Helper;
using Chat;
using ChatTrans;
using Trans;

using UserComponents;
using UserComponents.ChatComp;
using AudioService;

namespace ChatClientUI
{
	/// <summary>
	/// Description of ChatForm.
	/// </summary>
	public partial class ChatForm : CCSkinMain
	{
		private static object recveMsgLocker = new object();
		private static object rightPanelLocker = new object();
		private int rightWidth = 0;
		private int defaultWidth = 0;
		private EmotionDropdown emotion;
		private UserControl rightPanel;

		private MainForm mainFrm;
		public MainForm MainFrm {
			get { return mainFrm; }
			set { mainFrm = value; }
		}
		
		private ChatFriend chatFriend;
		public ChatFriend ChatFriend {
			get { return chatFriend; }
			set { chatFriend = value; }
		}
		
		public ChatForm()
		{
			InitializeComponent();
			this.InitBaseProperties();
		}
		
		#region 发送接文件控件管理

		public void InitSendRecveFilePanel()
		{
			try
			{
				if (this.GetFilePanel() == null)
				{
					FilePanel filePanel = new FilePanel();
					filePanel.CloseFilePanel += new CloseFilePanelHandler(filePanel_CloseFilePanel);
					filePanel.EmptyControls += new EmptyControlsHandler(filePanel_EmptyControls);
					int dw = filePanel.Width - this.rightWidth;
					this.splitContainerMain.Panel2.Controls.Add(filePanel);
					filePanel.Dock = DockStyle.Fill;
					if (this.WindowState == FormWindowState.Maximized)
					{
						this.splitContainerMain.SplitterDistance -= dw;
					}
					else if (this.WindowState == FormWindowState.Normal)
					{
						int w = this.splitContainerMain.SplitterDistance;
						this.Width += dw;
						this.splitContainerMain.SplitterDistance = w;
					}
					this.rightWidth = this.splitContainerMain.Panel2.Width;
					this.SetRightPanel(filePanel);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		void filePanel_EmptyControls(object sender, EmptyControlsEventArgs args)
		{
			try
			{
				this.ClearRightPanel(FilePanel.WIDTH, this.GetFilePanel());
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		void filePanel_CloseFilePanel(object sender, CloseFilePanelEventArgs args)
		{
			this.ClearAllSendRecveFile(false);
		}
		
		public void RemoveControlByFileId(string fileId)
		{
			try
			{
				FilePanel filePanel = this.GetFilePanel();
				DebugHelper.Assert(filePanel != null);
				filePanel.RemoveItem(fileId);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public SendRecveFileControl GetControlByFileId(string fileId)
		{
			FilePanel filePanel = this.GetFilePanel();
			DebugHelper.Assert(filePanel != null);
			return filePanel.GetControl(fileId);
		}
		
		private SendRecveFileControl AddSendFileControl(SendReader reader)
		{
			this.InitSendRecveFilePanel();
			SendRecveFileControl control = new SendRecveFileControl();
			control.Type = reader.Type;
			control.FileId = reader.FileId;
			control.IsSend = true;
			control.FileName = reader.Name;
			control.Length = reader.TotalLength;
			control.Comment = "发送" + EnumHelper.GetEnumDescription(reader.Type);
			control.Image = reader.Image;
			control.CancelClick += new CancelClickEventHandler(control_CancelClick);
			this.GetFilePanel().AddItem(control);
			return control;
		}
		
		public SendRecveFileControl AddRecveFileControl(SendFileTrans reqTrans)
		{
			this.InitSendRecveFilePanel();
			SendRecveFileControl control = new SendRecveFileControl();
			control.Type = reqTrans.Type;
			control.Count = reqTrans.Count;
			control.FileId = reqTrans.FileId;
			control.IsSend = false;
			control.FileName = reqTrans.Name;
			control.Length = reqTrans.Length;
			control.Comment = "接收" + EnumHelper.GetEnumDescription(reqTrans.Type);
			control.Image = reqTrans.Image;
			control.CancelClick += new CancelClickEventHandler(control_CancelClick);
			control.RecveClick += new RecveClickEventHandler(control_RecveClick);
			control.SaveClick += new SaveClickEventHandler(control_SaveClick);
			this.GetFilePanel().AddItem(control);
			return control;
		}
	
		#endregion
		
		#region 发送语音控件管理

		public void InitSendAudioPanel(bool _isSend)
		{
			try
			{
				if (this.GetAudioPanel() == null)
				{
					AudioPanel audioPanel = new AudioPanel();
					audioPanel.CloseAudioPanel += new CloseAudioPanelHandler(audioPanel_CloseAudioPanel);
					audioPanel.CancelAudioClick += new CancelAudioClickHandler(audioPanel_CancelAudioClick);
					if (!_isSend)
					{
						audioPanel.AccecptAudioClick += new AccecptAudioClickHandler(audioPanel_AccecptAudioClick);
					}
					audioPanel.SetSendRecve(_isSend);
					int dw = audioPanel.Width - this.rightWidth;
					this.splitContainerMain.Panel2.Controls.Add(audioPanel);
					audioPanel.Dock = DockStyle.Fill;
					if (this.WindowState == FormWindowState.Maximized)
					{
						this.splitContainerMain.SplitterDistance -= dw;
					}
					else if (this.WindowState == FormWindowState.Normal)
					{
						int w = this.splitContainerMain.SplitterDistance;
						this.Width += dw;
						this.splitContainerMain.SplitterDistance = w;
					}
					this.rightWidth = this.splitContainerMain.Panel2.Width;
					this.SetRightPanel(audioPanel);
					if (this.chatFriend.Voice == null)
					{
						this.chatFriend.Voice = new VoiceCapture(10, 4410, this.Handle);
						this.chatFriend.Voice.RecordVoice += new RecordVoiceHandler(ChatForm_RecordVoice);
						this.chatFriend.Voice.Init();
					}
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		void audioPanel_AccecptAudioClick(object sender, AccecptAudioClickEventArgs args)
		{
			try
			{
				this.chatFriend.Voice.Start();
				BaseTrans trans = new SendAudioResponseTrans(
					this.chatFriend.UserId,
					this.mainFrm.User.UserId);
				this.mainFrm.SendPackage(trans);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		void ChatForm_RecordVoice(object sender, RecordVoiceEventArgs args)
		{
			try
			{
				BaseTrans trans = new SendAudioBufferTrans(
					args.Buffer, 
					this.chatFriend.UserId, 
					this.mainFrm.User.UserId);
				this.mainFrm.SendPackage(trans);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		void audioPanel_CancelAudioClick(object sender, CancelAudioClickEventArgs args)
		{
			this.CancelAudio(true, false);
		}

		void audioPanel_CloseAudioPanel(object sender, CloseAudioPanelEventArgs args)
		{
			this.CancelAudio(true, false);
		}
		
		#endregion
		
		#region 其它

		private void InitBaseProperties()
		{
			this.rightWidth = this.splitContainerMain.Panel2.Width;
			this.defaultWidth = this.splitContainerMain.Panel2.Width;
		}
		
		private void SetRightPanel(UserControl control)
		{
			lock(rightPanelLocker)
			{
				if (this.rightPanel != null)
				{
					this.rightPanel.Dispose();
				}
				this.rightPanel = control;
			}
		}
		
		public FilePanel GetFilePanel()
		{
			lock(rightPanelLocker)
			{
				if (this.rightPanel == null)
				{
					return null;
				}
				return this.rightPanel as FilePanel;
			}
		}
		
		public AudioPanel GetAudioPanel()
		{
			lock(rightPanelLocker)
			{
				if (this.rightPanel == null)
				{
					return null;
				}
				return this.rightPanel as AudioPanel;
			}
		}
		
		public void AppendMessage(string date, string userId, RtfRichTextBox.RtfColor color, string msg, bool isRtf)
		{
			lock(recveMsgLocker)
			{
				string title = userId + " " + date + "\n";
				this.txtRecve.AppendTextAsRtf(title, new Font(this.Font, FontStyle.Regular), color);
				if (isRtf)
	            {
	                this.txtRecve.AppendRtf(msg);
	            }
	            else
	            {
	                this.txtRecve.AppendText(msg);
	            }
	            this.txtRecve.AppendText("\n");
	            this.txtRecve.Select(this.txtRecve.Text.Length, 0);
	            this.txtRecve.ScrollToCaret();
			}
		}
		
		public void AppendMessage(string msg)
		{
			this.AppendMessage(DateTime.Now.ToString(), "[系统消息]", RtfRichTextBox.RtfColor.Gray, msg, false);
		}
		
		private void ClearAllSendRecveFile(bool isClose)
		{
			try
			{
				foreach(SendRecveFileControl control in this.GetFilePanel().PanelMain.Controls)
				{
					if (!control.IsSend)
					{
						this.CancelRecveFile(control, isClose);
					}
					else
					{
						this.CancelSendFile(control, isClose);
					}
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ClearRightPanel(int width, Control control)
		{
			this.splitContainerMain.Panel2.Controls.Remove(control);
			this.SetRightPanel(null);
			if (this.WindowState == FormWindowState.Maximized)
			{
				this.splitContainerMain.SplitterDistance += (width -this.defaultWidth);
			}
			else if (this.WindowState == FormWindowState.Normal)
			{
				int w = this.splitContainerMain.SplitterDistance;
				this.Width -= (width - this.defaultWidth);
				this.splitContainerMain.SplitterDistance = w;
			}
			else if (this.WindowState == FormWindowState.Minimized)
			{
				this.WindowState = FormWindowState.Normal;
				int w = this.splitContainerMain.SplitterDistance;
				this.Width -= (width - this.defaultWidth);
				this.splitContainerMain.SplitterDistance = w;
			}
			this.rightWidth = this.splitContainerMain.Panel2.Width;
		}
		
		public void CancelAudio(bool _toSend, bool isClose)
		{
			try
			{
				if (!isClose)
				{
					this.ClearRightPanel(AudioPanel.WIDTH, this.GetAudioPanel());
				}
				this.chatFriend.Voice.Stop();
				this.chatFriend.Voice.Dispose();
				this.chatFriend.Voice = null;
				if (_toSend)
				{
					BaseTrans trans = new AudioCancelTrans(
						this.chatFriend.UserId,
						this.mainFrm.User.UserId);
					this.mainFrm.SendPackage(trans);
					this.AppendMessage("您取消了语音通信");
				}
				else
				{
					this.AppendMessage("对方取消了语音通信");
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ClearRightPanel(bool isClose)
		{
			if (this.rightPanel is AudioPanel)
			{
				this.CancelAudio(true, isClose);
			}
			else if (this.rightPanel is FilePanel)
			{
				this.ClearAllSendRecveFile(isClose);
			}
			else
			{
				return;
			}
		}
		
		private void AsyncLoadFaceCb()
		{
			DirectoryInfo dirInfo = new DirectoryInfo(Application.StartupPath + "\\Face");
			Dictionary<string, Image> imageMap = new Dictionary<string, Image>();
			foreach(FileInfo info in dirInfo.GetFiles())
			{
				try
				{
					if (info.Extension != ".gif")
					{
						continue;
					}
					imageMap.Add(info.Name, Image.FromFile(info.FullName));
					
				}
				catch(Exception ex)
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Error(ex, sf);
					DebugHelper.Console(info.FullName, sf);
				}
			}
			this.BeginInvoke(new MethodInvoker(delegate()
			{   
			    foreach(KeyValuePair<string, Image> entry in imageMap)
			    {
			    	this.emotion.AddImage(entry.Key, entry.Value);
			    }
			    this.emotion.EcDefault.Refresh();
			}));
			
		}
		
		private void CancelRecveFile(SendRecveFileControl control, bool isClose)
		{
			string fileId = control.FileId;
			string fileName = control.FileName;
			RecveWriter writer = this.chatFriend.GetWriter(fileId);
			if (writer != null)
			{
				this.chatFriend.RemoveWriter(fileId);
				writer.Dispose();
			}
			if (!isClose)
			{
				this.RemoveControlByFileId(fileId);
			}
			BaseTrans trans = new RecveFileCancelTrans(
	        	fileId,
	        	this.chatFriend.UserId,
	        	this.mainFrm.User.UserId);
			this.mainFrm.SendPackage(trans);
			this.AppendMessage("您已经拒绝接收文件, [" + fileName + "]");
		}
		
		private void CancelSendFile(SendRecveFileControl control, bool isClose)
		{
			string fileId = control.FileId;
			string fileName = control.FileName;
			SendReader reader = this.chatFriend.GetReader(fileId);
			if (reader != null)
			{
				this.chatFriend.RemoveReader(fileId);
				reader.Dispose();
			}
			if (!isClose)
			{
				this.RemoveControlByFileId(fileId);
			}
			BaseTrans trans = new SendFileCancelTrans(
				fileId, 
				this.chatFriend.UserId,
				this.mainFrm.User.UserId);
			this.mainFrm.SendPackage(trans);
			this.AppendMessage("您已经取消发送文件, [" + fileName + "]");
		}
				
		private string GetSaveFilePath()
		{
			string defDir = Application.StartupPath + "\\" + FileName.AllUser + "\\" + this.mainFrm.User.UserId + "\\" + FileName.RecveFile;
			string recveDir = AppConfigMgr.Instance.GetAttribute(AppConfigMgr.RecveDirectroy, defDir);
			if (!Directory.Exists(recveDir))
			{
				Directory.CreateDirectory(recveDir);
			}
			return recveDir;
		}
		
		public void Vibration()
        {
			AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(AsyncVibrationCb);
			ah.BeginInvoke(null, null);
		}
		
		private void AsyncVibrationCb()
		{
			Point pOld = this.Location;
	        int radius = 3;
	        for (int n = 0; n < 3; n++)
	        {
	        	for (int i = -radius; i <= radius; i++)
	        	{
	        		int x = Convert.ToInt32(Math.Sqrt(radius * radius - i * i));
	        		int y = -i;
	                this.BeginInvoke(new MethodInvoker(delegate()
	                {
	        			this.Location = new Point(pOld.X + x, pOld.Y + y);
	                }));
	                Thread.Sleep(2);
	        	}
	        	for (int j = radius; j >= -radius; j--)
	        	{
	        		int x = -Convert.ToInt32(Math.Sqrt(radius * radius - j * j));
	        		int y = -j;
	        		this.BeginInvoke(new MethodInvoker(delegate()
	                {
						this.Location = new Point(pOld.X + x, pOld.Y + y);
	                }));
	                Thread.Sleep(2);
	        	}
	        }
	        this.Location = pOld;
        }
		
		private void LoadRecveMsg()
		{
			if (this.chatFriend != null)
			{
				while(this.chatFriend.CountRecvePackage() > 0)
				{
					SendMsgTrans trans = (SendMsgTrans)this.chatFriend.PopRecvePackage();
					string fromUserId = trans.TransId.FromId;
					string toUserId = trans.TransId.ToId;
					string date = trans.Date;
					string msg = trans.Msg;
					this.AppendMessage(date, fromUserId, RtfRichTextBox.RtfColor.Blue, msg, true);
				}
			}
			this.txtSend.Focus();
		}
		
		private void SendAudio()
		{
			try
			{
				this.InitSendAudioPanel(true);
				BaseTrans trans = new SendAudioTrans(
					this.chatFriend.UserId,
					this.mainFrm.User.UserId);
				this.mainFrm.SendPackage(trans);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void SendFile(string path)
		{	
			try
			{
				SendReader reader = this.CreateReader(path);
				this.InitSendRecveFilePanel();
				SendRecveFileControl control = this.AddSendFileControl(reader);
				BaseTrans trans = new SendFileTrans(
					reader.FileId,
					reader.Name,
					reader.Image,
					reader.TotalLength,
					reader.TotalCount,
					reader.Type,
					this.chatFriend.UserId,
					this.mainFrm.User.UserId);
				this.mainFrm.SendPackage(trans);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void SendMsg()
		{
			try
			{
				if (this.mainFrm.Client.ServerConnection == null || !this.mainFrm.Client.ServerConnection.Connected)
				{
					this.AppendMessage("您已经离线, 无法发送消息");
				}
				if (string.IsNullOrEmpty(this.txtSend.Text))
				{
					return;
				}
				string date = DateTime.Now.ToString();
				string toUserId = this.chatFriend.UserId;
				string fromUserId = this.mainFrm.User.UserId;
				BaseTrans trans = new SendMsgTrans(date, this.txtSend.Rtf, toUserId, fromUserId);
				this.mainFrm.SendPackage(trans);
				this.AppendMessage(date, fromUserId, RtfRichTextBox.RtfColor.Green, this.txtSend.Rtf, true);
				this.txtSend.Text = string.Empty;
				this.txtSend.Focus();
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}	
	
		#endregion
		
		#region 加载样式

		private void SetFontSize(float size)
		{
			FontFamily oldFamily = this.txtSend.Font.FontFamily;
			FontStyle oldStyle = this.txtSend.Font.Style;
			this.txtSend.Font = new Font(oldFamily, size, oldStyle);
		}
		
		private void SetFontFamily(string name)
		{
			float oldSize = this.txtSend.Font.Size;
			FontStyle oldStyle = this.txtSend.Font.Style;
			this.txtSend.Font = new Font(name, oldSize, oldStyle);
		}
		
		private void SetBold(bool check)
		{
			if (!check)
			{
				return;
			}
			Font oldFont = this.txtSend.Font;
			this.txtSend.Font = new Font(oldFont, oldFont.Style | FontStyle.Bold);
		}
		
		private void SetItalic(bool check)
		{
			if (!check)
			{
				return;
			}
			Font oldFont = this.txtSend.Font;
			this.txtSend.Font = new Font(oldFont, oldFont.Style | FontStyle.Italic);
		}
		
		private void SetUnderLine(bool check)
		{
			if (!check)
			{
				return;
			}
			Font oldFont = this.txtSend.Font;
			this.txtSend.Font = new Font(oldFont, oldFont.Style | FontStyle.Underline);
		}
		
		private void SetForeColor(Color color)
		{
			this.txtSend.ForeColor = color;
		}
		
		private void FillFontFamily()
		{
			if (this.tscmbFontFamily.Items.Count == 0)
			{
				string fontFamily = AppConfigMgr.Instance.GetAttribute(AppConfigMgr.FontFamily, System.Drawing.SystemFonts.DefaultFont.Name);
				Graphics g = this.CreateGraphics(); 
				//foreach(FontFamily ff in FontFamily.GetFamilies(g))
				foreach(FontFamily ff in FontFamily.Families)
				{
					this.tscmbFontFamily.Items.Add(ff.Name);
					if (ff.Name == fontFamily)
					{
						this.tscmbFontFamily.SelectedIndex = this.tscmbFontFamily.Items.Count - 1;
					}
				}
				
			}
		}
		
		private void FillFontSize()
		{
			if (this.tscmbFontSize.Items.Count == 0)
			{
				float fontSize = (float)AppConfigMgr.Instance.GetAttributeDouble(AppConfigMgr.FontSize, System.Drawing.SystemFonts.DefaultFont.Size);
				float [] fontSizeArray = {9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22};
				foreach(float f in fontSizeArray)
				{
					this.tscmbFontSize.Items.Add(f);
					if (f == fontSize)
					{
						this.tscmbFontSize.SelectedIndex = this.tscmbFontSize.Items.Count - 1;
					}
				}
			}
		}
		
		private void SetSendShortKey()
		{
			bool sendkey = AppConfigMgr.Instance.GetAttributeBool(AppConfigMgr.SendKey);
			this.tsmiEnter.Checked = sendkey;
			this.tsmiCtrlEnter.Checked = !sendkey;
		}
				
		private void LoadFont()
		{
			this.SetFontFamily(AppConfigMgr.Instance.GetAttribute(AppConfigMgr.FontFamily));
			this.SetFontSize((float)AppConfigMgr.Instance.GetAttributeDouble(AppConfigMgr.FontSize, 12));
			this.SetBold(AppConfigMgr.Instance.GetAttributeBool(AppConfigMgr.Bold));
			this.SetItalic(AppConfigMgr.Instance.GetAttributeBool(AppConfigMgr.Italic));
			this.SetUnderLine(AppConfigMgr.Instance.GetAttributeBool(AppConfigMgr.UnderLine));
			this.SetForeColor(ColorTranslator.FromHtml(AppConfigMgr.Instance.GetAttribute(AppConfigMgr.ForeColor)));
			this.FillFontFamily();
			this.FillFontSize();
			this.SetSendShortKey();
		}
		
		private void LoadUser()
		{
			this.Text = "与 " + this.chatFriend.UserId + " 对话中";
			this.lblUserId.Text = this.chatFriend.UserId;
			this.panelFriendHeadImage.BackgroundImage = Program.GetHeadImage(this.chatFriend.Head);
		}
		
		#endregion
		
		#region 读文件事件

		private SendReader CreateReader(string path)
		{
			SendReader reader = SendReader.GetReader(path);
			reader.FileId = FileIdMgr.Instance.GetFileId(this.mainFrm.User.UserId, this.chatFriend.UserId);
			reader.ReadBuffer += new ReadBufferHandler(reader_ReadBuffer);
			reader.CompleteRead += new CompleteReadHandler(reader_CompleteRead);
			reader.UpdateProgress += new UpdateProgressHandler(reader_UpdateProgress);
			reader.ReadFolder += new ReadFolderHandler(reader_ReadFolder);
			this.chatFriend.AddReader(reader.FileId, reader);
			return reader;
		}

		void reader_ReadFolder(object sender, ReadFolderEventArgs args)
		{
			try
			{
				SendReader reader = sender as SendReader;
				if (this.chatFriend.GetReader(reader.FileId) == null)
				{
					reader.Stop();
					reader.Dispose();
					return;
				}
				BaseTrans trans = null;
				if (reader != null)
				{
					trans = new SendFolderTrans(
						reader.FileId,
						args.SubName,
						this.chatFriend.UserId,
						this.mainFrm.User.UserId);
					this.mainFrm.SendPackage(trans);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		void reader_ReadBuffer(object sender, ReadBufferEventArgs args)
		{
			try
			{
				SendReader reader = sender as SendReader;
				if (this.chatFriend.GetReader(reader.FileId) == null)
				{
					reader.Stop();
					reader.Dispose();
					return;
				}
				BaseTrans trans = null;
				if (reader != null)
				{
					if (reader.Type == SendType.eFolder)
					{
						trans = new SendFileBufferTrans(
							args.SubName,
							args.Length,
							reader.FileId,
							args.Offset,
							args.Buffer, 
							this.chatFriend.UserId,
							this.mainFrm.User.UserId);
					}
					else if (reader.Type == SendType.eFile)
					{
						trans = new SendFileBufferTrans(
							reader.FileId,
							args.Offset, 
							args.Buffer, 
							this.chatFriend.UserId,
							this.mainFrm.User.UserId);
					}
					this.mainFrm.SendPackage(trans);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		void reader_CompleteRead(object sender, CompleteReadEventArgs args)
		{
			try
			{
				SendReader reader = sender as SendReader;
				if (reader != null)
				{
					BaseTrans trans = null;
					if (reader.Type == SendType.eFolder)
					{
						if (args.SubType == SendType.eFolder)
						{
							trans = new SendFolderTrans(
								reader.FileId,
								args.SubName,
								this.chatFriend.UserId,
								this.mainFrm.User.UserId);
						}
						else
						{
							{
								System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
								System.Diagnostics.StackFrame sf = st.GetFrame(0);
								DebugHelper.Console("last buff: " + args.SubName , sf);
							}
							trans = new SendFileBufferTrans(
								args.SubName,
								args.Length,
								reader.FileId,
								args.Offset,
								args.Buffer, 
								this.chatFriend.UserId,
								this.mainFrm.User.UserId);
						}
					}
					else if (reader.Type == SendType.eFile)
					{
						trans = new SendFileBufferTrans(
							reader.FileId,
							args.Offset, 
							args.Buffer, 
							this.chatFriend.UserId,
							this.mainFrm.User.UserId);
					}
					this.mainFrm.SendPackage(trans);
					this.chatFriend.RemoveReader(reader.FileId);
					reader.Stop();
					reader.Dispose();
					this.BeginInvoke(new MethodInvoker(delegate()
					{
						this.RemoveControlByFileId(reader.FileId);
						this.AppendMessage("发送文件完毕, [" + reader.Name + "]");
					}));
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		void reader_UpdateProgress(object sender, UpdateProgressEventArgs args)
		{
			try
			{
				SendReader reader = sender as SendReader;
				if (reader.TotalPosition == 0)
				{
					return;
				}
				FilePanel filePanel = this.GetFilePanel();
				if (filePanel == null)
				{
					return;
				}
				SendRecveFileControl sendControl = filePanel.GetControl(reader.FileId);
				if (sendControl != null)
				{
					this.BeginInvoke(new MethodInvoker(delegate()
					{
						sendControl.TransSize = reader.TotalPosition;
					}));
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
				
		#endregion
				
		#region 写文件事件

		private void CreateWriter(string path, SendRecveFileControl control)
		{
			RecveWriter writer = RecveWriter.GetWriter(control.Type, control.Count, control.FileId, path, control.FileName, control.Length);
			writer.CompleteWrite += new CompleteWriteHandler(writer_CompleteWrite);
			writer.WriteBuffer += new WriteBufferHandler(writer_WriteBuffer);
			writer.UpdateProgress += new UpdateProgressHandler(writer_UpdateProgress);
			writer.WriteFolder += new WriteFolderHandler(writer_WriteFolder);
			writer.Start();
			this.chatFriend.AddWriter(writer.FileId, writer);
		}

		void writer_WriteFolder(object sender, WriteFolderEventArgs args)
		{
			try
			{
				RecveWriter writer = sender as RecveWriter;
				if (this.chatFriend.GetWriter(writer.FileId) == null)
				{
					writer.Stop();
					writer.Dispose();
					return;
				}
				BaseTrans trans = null;
				if (writer != null)
				{
					trans = new SendFileResponseTrans(
						writer.FileId,
						this.chatFriend.UserId,
						this.mainFrm.User.UserId);
					this.mainFrm.SendPackage(trans);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		void writer_WriteBuffer(object sender, WriteBufferEventArgs args)
		{
			try
			{
				RecveWriter writer = sender as RecveWriter;
				BaseTrans trans = null;
				if (this.chatFriend.GetWriter(writer.FileId) == null)
				{
					writer.Stop();
					writer.Dispose();
					return;
				}
				if (writer != null)
				{
					trans = new SendFileResponseTrans(
						writer.FileId,
						this.chatFriend.UserId,
						this.mainFrm.User.UserId);
					this.mainFrm.SendPackage(trans);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		void writer_CompleteWrite(object sender, CompleteWriteEventArgs args)
		{
			try
			{
				RecveWriter writer = sender as RecveWriter;
				if (writer != null)
				{
					this.chatFriend.RemoveWriter(writer.FileId);
					writer.Stop();
					writer.Dispose();
					this.BeginInvoke(new MethodInvoker(delegate()
					{
					    this.RemoveControlByFileId(writer.FileId);
					    this.AppendMessage("接收文件完毕, [" + writer.Name + "]");
					}));
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		void writer_UpdateProgress(object sender, UpdateProgressEventArgs args)
		{
			try
			{
				RecveWriter writer = sender as RecveWriter;
				if (writer.TotalPosition == 0)
				{
					return;
				}
				FilePanel filePanel = this.GetFilePanel();
				if (filePanel == null)
				{
					return;
				}
				SendRecveFileControl recvControl = filePanel.GetControl(writer.FileId);
				if (recvControl != null)
				{
					this.BeginInvoke(new MethodInvoker(delegate()
					{
						recvControl.TransSize = writer.TotalPosition;
					}));
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
				
		#endregion
		
		#region 窗体事件
		
		void control_SaveClick(object sender, SaveClickEventArgs e)
		{
			try
			{
				FolderBrowserDialog fbd = new FolderBrowserDialog();
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					SendRecveFileControl control = e.SendRecveFileControl as SendRecveFileControl;
					control.StartTime = DateTime.Now;
					control.SetRecveControl();
					if (this.chatFriend.GetWriter(control.FileId) == null)
					{
						this.CreateWriter(fbd.SelectedPath, control);
					}
					
					BaseTrans respTrans = new SendFileResponseTrans(
						control.FileId,
						this.chatFriend.UserId,
						this.mainFrm.User.UserId);
					this.mainFrm.SendPackage(respTrans);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		void control_RecveClick(object sender, RecveClickEventArgs e)
		{
			try
			{
				SendRecveFileControl control = e.SendRecveFileControl as SendRecveFileControl;
				control.StartTime = DateTime.Now;
				control.SetRecveControl();
				if (this.chatFriend.GetWriter(control.FileId) == null)
				{
					this.CreateWriter(this.GetSaveFilePath(), control);
				}
				
				BaseTrans respTrans = new SendFileResponseTrans(
					control.FileId,
					this.chatFriend.UserId,
					this.mainFrm.User.UserId);
				this.mainFrm.SendPackage(respTrans);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		void control_CancelClick(object sender, CancelClickEventArgs e)
		{
			try
			{
				SendRecveFileControl control = e.SendRecveFileControl as SendRecveFileControl;
				if (!control.IsSend)
				{
					this.CancelRecveFile(control, false);
				}
				else
				{
					this.CancelSendFile(control, false);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}	
		
		void TsbFontClick(object sender, EventArgs e)
		{
			this.skToolMenuFont.Visible = !this.skToolMenuFont.Visible;
			this.tsbFont.Checked = !this.tsbFont.Checked;
			if (this.skToolMenuFont.Visible)
			{
				this.tsbBold.Checked = AppConfigMgr.Instance.GetAttributeBool(AppConfigMgr.Bold);
				this.tsbItalic.Checked = AppConfigMgr.Instance.GetAttributeBool(AppConfigMgr.Italic);
				this.tsbUnderLine.Checked = AppConfigMgr.Instance.GetAttributeBool(AppConfigMgr.UnderLine);
			}
		}
		
		void TsbBoldClick(object sender, EventArgs e)
		{
			this.tsbBold.Checked = !this.tsbBold.Checked;
			bool check = this.tsbBold.Checked;
			AppConfigMgr.Instance.SetAttribute(AppConfigMgr.Bold, check);
			Font oldFont = this.txtSend.Font;
			if (oldFont.Bold)
			{
				this.txtSend.Font = new Font(oldFont, oldFont.Style ^ FontStyle.Bold);
			}
			else
			{
				this.txtSend.Font = new Font(oldFont, oldFont.Style | FontStyle.Bold);
			}
		}
		
		void TsbItalicClick(object sender, EventArgs e)
		{
			this.tsbItalic.Checked = !this.tsbItalic.Checked;
			bool check = this.tsbItalic.Checked;
			AppConfigMgr.Instance.SetAttribute(AppConfigMgr.Italic, check);
			Font oldFont = this.txtSend.Font;
			if (oldFont.Italic)
			{
				this.txtSend.Font = new Font(oldFont, oldFont.Style ^ FontStyle.Italic);
			}
			else
			{
				this.txtSend.Font = new Font(oldFont, oldFont.Style | FontStyle.Italic);
			}
		}
		
		void TsbUnderLineClick(object sender, EventArgs e)
		{
			this.tsbUnderLine.Checked = !this.tsbUnderLine.Checked;
			bool check = this.tsbUnderLine.Checked;
			AppConfigMgr.Instance.SetAttribute(AppConfigMgr.UnderLine, check);
			Font oldFont = this.txtSend.Font;
			if (oldFont.Underline)
			{
				this.txtSend.Font = new Font(oldFont, oldFont.Style ^ FontStyle.Underline);
			}
			else
			{
				this.txtSend.Font = new Font(oldFont, oldFont.Style | FontStyle.Underline);
			}
		}
		
		void ChatFormLoad(object sender, EventArgs e)
		{
			this.LoadUser();
			this.LoadRecveMsg();
			this.LoadFont();
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void TsbTwitterClick(object sender, EventArgs e)
		{
			this.AppendMessage("您发送了一个窗口抖动");
			BaseTrans trans = new VibrationTrans(
				this.chatFriend.UserId, 
				this.mainFrm.User.UserId);
			this.mainFrm.SendPackage(trans);
			this.Vibration();
		}
		
		void TsbFaceClick(object sender, EventArgs e)
		{
			try
			{
				if (this.emotion == null)
				{
					this.emotion = new EmotionDropdown();
					this.emotion.EcDefault.ItemClick += new EmotionItemMouseEventHandler(ChatForm_ItemClick);
					AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(AsyncLoadFaceCb);
					ah.BeginInvoke(null, null);
				}
				this.emotion.Show(this.Location.X, Cursor.Position.Y - this.emotion.Height);
//				Control control = sender as Control;
//				this.emotion.Show(control, control.Left, control.Top);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		void ChatForm_ItemClick(object sender, EmotionItemMouseClickEventArgs e)
		{
//			this.txtSend.InsertImageUseGifBox("Face\\" + e.Item.Text);
			this.txtSend.InsertImage(e.Item.Image);
		}
		
		void TsbSendPicClick(object sender, EventArgs e)
		{
			
		}
		
		void TsbCutPicClick(object sender, EventArgs e)
		{
			
		}
		
		void TssbColorButtonClick(object sender, EventArgs e)
		{
			
		}
		
		void BtnSendClick(object sender, EventArgs e)
		{
			DebugHelper.Assert(this.mainFrm != null);
			this.SendMsg();
		}
		
		void TsmiSendFileClick(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "选择文件";
			openFileDialog.Filter = "所有文件(*.*)|*.*";
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.SendFile(openFileDialog.FileName);
				}
				catch(Exception ex)
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Error(ex, sf);
				}
			}
		}
		
		void ChatFormFormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.ClearRightPanel(true);
				this.chatFriend.ChatFrm = null;
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		void TxtSendKeyDown(object sender, KeyEventArgs e)
		{
			bool sendkey = AppConfigMgr.Instance.GetAttributeBool(AppConfigMgr.SendKey);
			if (sendkey)
			{
				if (e.KeyCode == Keys.Enter)
				{
					this.SendMsg();
				}
			}
			else
			{
				if (e.KeyCode == Keys.Enter && e.Control)
				{
					this.SendMsg();
				}
			}
			
			if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                this.txtSend.Paste(DataFormats.GetFormat(DataFormats.Text)); 
            }
		}
		
		void TsmiClearClick(object sender, EventArgs e)
		{
			this.txtRecve.Clear();
		}
		
		void TsmiSendFloderClick(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			if (folderDialog.ShowDialog() == DialogResult.OK)
            {
				try
				{
					this.SendFile(folderDialog.SelectedPath);
				}
				catch(Exception ex)
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Error(ex, sf);
				}
			}
		}
		
		void BtnShortKeyDropDownClick(object sender, EventArgs e)
		{
			this.menuStripShortKey.Show(this.btnShortKeyDropDown,
			    0,
			    this.btnShortKeyDropDown.Location.Y + this.btnShortKeyDropDown.Height);
		}
		
		void TsmiEnterClick(object sender, EventArgs e)
		{
			if (this.tsmiEnter.Checked == true)
			{
				this.tsmiCtrlEnter.Checked = false;
				AppConfigMgr.Instance.SetAttribute(AppConfigMgr.SendKey, true);
				return;
			}
			this.tsmiEnter.Checked = true;
			this.tsmiCtrlEnter.Checked = false;
		}
		
		void TsmiCtrlEnterClick(object sender, EventArgs e)
		{
			if (this.tsmiCtrlEnter.Checked == true)
			{
				AppConfigMgr.Instance.SetAttribute(AppConfigMgr.SendKey, false);
				this.tsmiEnter.Checked = false;
				return;
			}
			this.tsmiCtrlEnter.Checked = true;
			this.tsmiEnter.Checked = false;
		}
		
		void TscmbFontSizeSelectedIndexChanged(object sender, EventArgs e)
		{
			float f = (float)Convert.ToInt32((this.tscmbFontSize.SelectedItem.ToString()));
			this.SetFontSize(f);
			AppConfigMgr.Instance.SetAttribute(AppConfigMgr.FontSize, f);
		}
		
		void TscmbFontFamilySelectedIndexChanged(object sender, EventArgs e)
		{
			string s = this.tscmbFontFamily.SelectedItem.ToString();
			this.SetFontFamily(s);
			AppConfigMgr.Instance.SetAttribute(AppConfigMgr.FontFamily, s);
		}
		
		void TssbColorClick(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				this.SetForeColor(colorDialog.Color);
				AppConfigMgr.Instance.SetAttribute(AppConfigMgr.ForeColor, ColorTranslator.ToHtml(colorDialog.Color));
			}
		}
		
		void TsmiStartAudioClick(object sender, EventArgs e)
		{
			try
			{
				this.SendAudio();
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}

		void ChatFormDragDrop(object sender, DragEventArgs e)
		{
			try
			{
				Array array = ((System.Array)e.Data.GetData(DataFormats.FileDrop));
				for(int i=0; i< array.Length; i++)
				{
					string path = array.GetValue(i).ToString();
					this.SendFile(path);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		void ChatFormDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		
		#endregion
		
	}
}
