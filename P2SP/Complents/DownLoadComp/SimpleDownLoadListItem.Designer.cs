/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-7-31
 * Time: 15:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Complents.DownLoadComp
{
	partial class SimpleDownLoadListItem
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.picExtision = new System.Windows.Forms.PictureBox();
			this.lblFileName = new CCWin.SkinControl.SkinLabel();
			this.lblSpeed = new CCWin.SkinControl.SkinLabel();
			this.btnDelete = new CCWin.SkinControl.SkinButtom();
			this.pbProgress = new CCWin.SkinControl.SkinProgressBar();
			this.btnStatus = new CCWin.SkinControl.SkinButtom();
			this.btnOpen = new CCWin.SkinControl.SkinButtom();
			this.lblCurrentSize = new CCWin.SkinControl.SkinLabel();
			this.lblTakeTime = new CCWin.SkinControl.SkinLabel();
			((System.ComponentModel.ISupportInitialize)(this.picExtision)).BeginInit();
			this.SuspendLayout();
			// 
			// picExtision
			// 
			this.picExtision.Location = new System.Drawing.Point(5, 10);
			this.picExtision.Name = "picExtision";
			this.picExtision.Size = new System.Drawing.Size(40, 40);
			this.picExtision.TabIndex = 0;
			this.picExtision.TabStop = false;
			// 
			// lblFileName
			// 
			this.lblFileName.BackColor = System.Drawing.Color.Gainsboro;
			this.lblFileName.BorderColor = System.Drawing.Color.White;
			this.lblFileName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblFileName.Location = new System.Drawing.Point(48, 6);
			this.lblFileName.Name = "lblFileName";
			this.lblFileName.Size = new System.Drawing.Size(303, 23);
			this.lblFileName.TabIndex = 1;
			// 
			// lblSpeed
			// 
			this.lblSpeed.BackColor = System.Drawing.Color.Gainsboro;
			this.lblSpeed.BorderColor = System.Drawing.Color.White;
			this.lblSpeed.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblSpeed.Location = new System.Drawing.Point(48, 32);
			this.lblSpeed.Name = "lblSpeed";
			this.lblSpeed.Size = new System.Drawing.Size(95, 23);
			this.lblSpeed.TabIndex = 2;
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.Transparent;
			this.btnDelete.BaseColor = System.Drawing.Color.Transparent;
			this.btnDelete.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnDelete.DownBack = null;
			this.btnDelete.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnDelete.Image = global::Complents.Resource.button_delete_16;
			this.btnDelete.Location = new System.Drawing.Point(471, 23);
			this.btnDelete.MouseBack = null;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.NormlBack = null;
			this.btnDelete.Size = new System.Drawing.Size(16, 16);
			this.btnDelete.TabIndex = 4;
			this.btnDelete.UseVisualStyleBackColor = true;
			// 
			// pbProgress
			// 
			this.pbProgress.Back = null;
			this.pbProgress.BarBack = null;
			this.pbProgress.Border = System.Drawing.Color.Transparent;
			this.pbProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbProgress.ForeColor = System.Drawing.Color.Black;
			this.pbProgress.Location = new System.Drawing.Point(0, 0);
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(500, 60);
			this.pbProgress.TabIndex = 5;
			this.pbProgress.TrackBack = System.Drawing.Color.White;
			this.pbProgress.TrackFore = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(224)))), ((int)(((byte)(246)))));
			this.pbProgress.TxtShow = false;
			// 
			// btnStatus
			// 
			this.btnStatus.BackColor = System.Drawing.Color.Transparent;
			this.btnStatus.BaseColor = System.Drawing.Color.Transparent;
			this.btnStatus.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnStatus.DownBack = global::Complents.DownLoadComp.DownLoadResource.task_stop_btn_down;
			this.btnStatus.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnStatus.Location = new System.Drawing.Point(354, 21);
			this.btnStatus.Margin = new System.Windows.Forms.Padding(0);
			this.btnStatus.MouseBack = global::Complents.DownLoadComp.DownLoadResource.task_stop_btn_over;
			this.btnStatus.Name = "btnStatus";
			this.btnStatus.NormlBack = global::Complents.DownLoadComp.DownLoadResource.task_stop_btn_normal;
			this.btnStatus.Size = new System.Drawing.Size(55, 22);
			this.btnStatus.TabIndex = 6;
			this.btnStatus.Text = "停止";
			this.btnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnStatus.UseVisualStyleBackColor = true;
			// 
			// btnOpen
			// 
			this.btnOpen.AutoSize = true;
			this.btnOpen.BackColor = System.Drawing.Color.Transparent;
			this.btnOpen.BaseColor = System.Drawing.Color.Transparent;
			this.btnOpen.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnOpen.DownBack = global::Complents.DownLoadComp.DownLoadResource.task_opendir_btn_down;
			this.btnOpen.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOpen.Location = new System.Drawing.Point(415, 21);
			this.btnOpen.Margin = new System.Windows.Forms.Padding(0);
			this.btnOpen.MouseBack = global::Complents.DownLoadComp.DownLoadResource.task_opendir_btn_over;
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.NormlBack = global::Complents.DownLoadComp.DownLoadResource.task_opendir_btn_normal;
			this.btnOpen.Size = new System.Drawing.Size(51, 22);
			this.btnOpen.TabIndex = 7;
			this.btnOpen.Text = "打开";
			this.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOpen.UseVisualStyleBackColor = true;
			// 
			// lblCurrentSize
			// 
			this.lblCurrentSize.BackColor = System.Drawing.Color.Gainsboro;
			this.lblCurrentSize.BorderColor = System.Drawing.Color.White;
			this.lblCurrentSize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblCurrentSize.Location = new System.Drawing.Point(149, 32);
			this.lblCurrentSize.Name = "lblCurrentSize";
			this.lblCurrentSize.Size = new System.Drawing.Size(111, 23);
			this.lblCurrentSize.TabIndex = 8;
			// 
			// lblTakeTime
			// 
			this.lblTakeTime.BackColor = System.Drawing.Color.Gainsboro;
			this.lblTakeTime.BorderColor = System.Drawing.Color.White;
			this.lblTakeTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTakeTime.Location = new System.Drawing.Point(266, 32);
			this.lblTakeTime.Name = "lblTakeTime";
			this.lblTakeTime.Size = new System.Drawing.Size(85, 23);
			this.lblTakeTime.TabIndex = 9;
			// 
			// SimpleDownLoadListItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblTakeTime);
			this.Controls.Add(this.lblCurrentSize);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.picExtision);
			this.Controls.Add(this.btnStatus);
			this.Controls.Add(this.lblFileName);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.lblSpeed);
			this.Controls.Add(this.pbProgress);
			this.MaximumSize = new System.Drawing.Size(500, 60);
			this.MinimumSize = new System.Drawing.Size(500, 60);
			this.Name = "SimpleDownLoadListItem";
			this.Size = new System.Drawing.Size(500, 60);
			((System.ComponentModel.ISupportInitialize)(this.picExtision)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private CCWin.SkinControl.SkinLabel lblCurrentSize;
		private CCWin.SkinControl.SkinProgressBar pbProgress;
		private CCWin.SkinControl.SkinLabel lblTakeTime;
		private CCWin.SkinControl.SkinLabel lblSpeed;
		private System.Windows.Forms.PictureBox picExtision;
		private CCWin.SkinControl.SkinButtom btnOpen;
		private CCWin.SkinControl.SkinButtom btnStatus;
		private CCWin.SkinControl.SkinButtom btnDelete;
		private CCWin.SkinControl.SkinLabel lblFileName;
	}
}
