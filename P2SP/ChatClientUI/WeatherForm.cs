/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-2-19
 * Time: 16:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using Helper;
using CCWin;
using CCWin.SkinControl;
using Chat;

namespace ChatClientUI
{
	/// <summary>
	/// Description of WeatherForm.
	/// </summary>
	public partial class WeatherForm : CCSkinMain
	{		
		private MainForm mainFrm;
		
		public MainForm MainFrm {
			get { return mainFrm; }
			set { mainFrm = value; }
		}
		private Point position;
		
		public Point Position {
			get { return position; }
			set { position = value; }
		}
		public WeatherForm()
		{
			InitializeComponent();
		}
		
		public void SetWeatherInfo(string[] array)
		{
			try
			{
				string weatherPath = Application.StartupPath + "\\" + FileName.Weather + "\\";
				this.lblTemperature.Text = array[5];
				this.lblCity.Text = array[0] + " " + array[1];
				this.lblWeather.Text = array[6] + array[7];
				this.lblSuggest.Text = array[11];
				this.btnToday.Text = array[5];
				if (File.Exists(weatherPath + array[9]))
				{
					this.btnToday.Image = Image.FromFile(weatherPath + array[9]);
				}
				this.btnTomorrow.Text = array[12];
				if (File.Exists(weatherPath + array[16]))
				{
					this.btnTomorrow.Image = Image.FromFile(weatherPath + array[16]);
				}
				this.btnAfter.Text = array[17];
				if (File.Exists(weatherPath + array[21]))
				{
					this.btnAfter.Image = Image.FromFile(weatherPath + array[21]);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void AsyncCb()
		{
			string[] array = this.mainFrm.Weather.GetWeatherByCityName("苏州");
			this.BeginInvoke(new MethodInvoker(delegate()
			{
			    this.SetWeatherInfo(array);
     	    }));
		}
		
		void WeatherFormLoad(object sender, EventArgs e)
		{
			this.Location = this.position;
			AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(AsyncCb);
			ah.BeginInvoke(null, null);
		}
	}
}
