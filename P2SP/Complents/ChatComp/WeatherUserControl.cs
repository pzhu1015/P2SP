using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Complents.ChatComp
{
    public partial class WeatherUserControl : UserControl
    {
        public WeatherUserControl()
        {
            InitializeComponent();
        }

        public void LoadWeather(string _city, PictureBox _pic)
        {
            try
            { 
                WeatherRef.WeatherWebService ww = new WeatherRef.WeatherWebService();
                string[] array = ww.getWeatherbyCityName(_city);
                if (array == null || array.Length < 20)
                {
                    return;
                }
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    try
                    { 
                        this.lblCity.Text = _city;
                        string[] array_10 = array[10].Split('：');
                        string[] array_6 = array[6].Split(' ');
                        if (array_10[2].Contains("；"))
                        { 
                            this.lblTemperature.Text = array_10[2].Split('；')[0];
                        }
                        else
                        {
                            this.lblTemperature.Text = array_10[2];
                        }
                        this.lblWeather.Text = array_6[1] + " " + array[7];
                        this.lblAir.Text = "空气" + array_10[array_10.Length-1];
                        this.tsBtnToday.Text = "  今天  " + array[5];
                        this.tsBtnToday.Image = WeatherCompResource.ResourceManager.GetObject("b_"+ array[8].Split('.')[0]) as Image;
                        _pic.Image = this.tsBtnToday.Image;
                        this.tsBtnTomorrow.Text = "  明天  " + array[12];
                        this.tsBtnTomorrow.Image = WeatherCompResource.ResourceManager.GetObject("b_" + array[15].Split('.')[0]) as Image;
                        this.tsBtnAfter.Text = "  后天  " + array[17];
                        this.tsBtnAfter.Image = WeatherCompResource.ResourceManager.GetObject("b_" + array[20].Split('.')[0]) as Image;
                    }
                    catch(Exception ex)
                    {
                        Helper.LogHelper.Error(ex);
                    }
                }));
            }
            catch(Exception ex)
            {
                Helper.LogHelper.Error(ex);
            }
        }
    }
}
