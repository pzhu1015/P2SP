using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CCWin;
using CCWin.SkinClass;

namespace ChatClient
{
    public partial class WeatherForm : CCSkinMain
    {
        private MainForm mainForm;
        public WeatherForm()
        {
            InitializeComponent();
        }

        public MainForm MainForm
        {
            get
            {
                return mainForm;
            }

            set
            {
                mainForm = value;
            }
        }

        private void WeatherForm_MouseEnter(object sender, EventArgs e)
        {
        }

        private void WeatherForm_MouseLeave(object sender, EventArgs e)
        {
            this.mainForm.LeaveWeatherFrom();
        }

        public void LoadWeather()
        {
            this.weatherUserControl.LoadWeather("苏州", this.mainForm.getWeatherBox());
            //this.weatherUserControl.LoadWeather("武汉");
        }

        private void WeatherForm_Load(object sender, EventArgs e)
        {
            int x = this.mainForm.Left - this.Width;
            int y = this.mainForm.Top;
            this.Location = new Point(x, y);
        }
    }
}
