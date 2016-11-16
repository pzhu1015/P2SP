/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-6
 * Time: 9:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using CCWin.SkinControl;
using Helper;

namespace Complents.ChatComp
{
	/// <summary>
	/// Description of AudioPanel.
	/// </summary>
	public partial class AudioPanel : UserControl
	{
		private bool isSend = false;
		public const int WIDTH = 200;
		private const int CLOSE_SIZE = 10;
		public AudioPanel()
		{
			InitializeComponent();
		}
		
		public void SetSendRecve(bool _isSend)
		{
			this.isSend = _isSend;
			if (this.isSend)
			{
				this.lblCommon.Text = "等待对方接收邀请...";
				this.btnAccecpt.Visible = false;
				this.btnCancel.Visible = true;
			}
			else
			{
				this.lblCommon.Text = "对方邀请你语音通话...";
				this.btnAccecpt.Visible = true;
				this.btnCancel.Visible = true;
				this.btnCancel.Text = "拒绝";
			}
		}
		
		public event CloseAudioPanelHandler CloseAudioPanel;
		public event CancelAudioClickHandler CancelAudioClick;
		public event AccecptAudioClickHandler AccecptAudioClick;
		
		protected virtual void OnCloseAudioPanel(CloseAudioPanelEventArgs e)
		{
			if (this.CloseAudioPanel != null)
			{
				this.CloseAudioPanel(this, e);
			}
		}
		
		protected virtual void OnCancelAudioClick(CancelAudioClickEventArgs e)
		{
			if (this.CancelAudioClick != null)
			{
				this.CancelAudioClick(this, e);
			}
		}
		
		protected virtual void OnAccecptAudioClick(AccecptAudioClickEventArgs e)
		{
			if (this.AccecptAudioClick != null)
			{
				this.AccecptAudioClick(this, e);
			}
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
		
		void AudioPanelPaint(object sender, PaintEventArgs e)
		{
			this.DrawCloseButton(e);
		}
		
		void AudioPanelMouseClick(object sender, MouseEventArgs e)
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
					this.OnCloseAudioPanel(new CloseAudioPanelEventArgs());
				}
			}
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.OnCancelAudioClick(new CancelAudioClickEventArgs());
		}
		
		void BtnAccecptClick(object sender, EventArgs e)
		{
			this.SetAccecpt();
			this.OnAccecptAudioClick(new AccecptAudioClickEventArgs());
		}
		
		public void SetAccecpt()
		{
			if (!this.isSend)
			{
				this.btnAccecpt.Visible = false;
			}
			this.btnCancel.Text = "挂断";
			this.btnCancel.Image = Complents.Resource.hang;
			this.lblCommon.Visible = false;
			this.panelSetting.Visible = true;
		}
		
		private bool isVoiceDisable = true;
		void BtnVoiceClick(object sender, EventArgs e)
		{
			if (this.isVoiceDisable)
			{
				this.btnVoice.Image = Complents.Resource.sound_disable;
			}
			else
			{
				this.btnVoice.Image = Complents.Resource.sound_enable;
			}
			this.isVoiceDisable = !this.isVoiceDisable;
		}
		
		private bool isMicDisable = true;
		void BtnMicClick(object sender, EventArgs e)
		{
			if (this.isMicDisable)
			{
				this.btnMic.Image = Complents.Resource.mic_disable;
			}
			else
			{
				this.btnMic.Image = Complents.Resource.mic_enable;
			}
			this.isMicDisable = !this.isMicDisable;
		}
		
		private void GetSoundVolume()
        {
            UInt32 d, v;
            d = 0;
            long i = DLLHelper.waveOutGetVolume(d, out v);
            UInt32 vleft = v & 0xFFFF;
            UInt32 vright = (v & 0xFFFF0000) >> 16;
            this.tbVoice.Value = (int.Parse(vleft.ToString()) | int.Parse(vright.ToString())) * (this.tbVoice.Maximum - this.tbVoice.Minimum) / 0xFFFF;
        }

		
		void TbMicScroll(object sender, EventArgs e)
		{
			
		}
		
		void TbVoiceScroll(object sender, EventArgs e)
		{
			UInt32 Value = (System.UInt32)((double)0xffff * (double)this.tbVoice.Value / (double)(this.tbVoice.Maximum - this.tbVoice.Minimum));        
            if (Value < 0) Value = 0;
            if (Value > 0xffff) Value = 0xffff;
            UInt32 left = (System.UInt32)Value;   
            UInt32 right = (System.UInt32)Value; 
            DLLHelper.waveOutSetVolume(0, left << 16 | right);   
		}
	}
}
