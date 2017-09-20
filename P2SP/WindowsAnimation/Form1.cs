using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Helper;
using CCWin;

namespace WindowsAnimation
{
    public partial class Form1 : CCSkinMain
    {

        [DllImportAttribute("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //正面_水平方向
        const int AW_HOR_POSITIVE = 0x0001;
        //负面_水平方向
        const int AW_HOR_NEGATIVE = 0x0002;
        //正面_垂直方向
        const int AW_VER_POSITIVE = 0x0004;
        //负面_垂直方向
        const int AW_VER_NEGATIVE = 0x0008;
        //由中间四周展开或由四周向中间缩小
        const int AW_CENTER = 0x0010;
        //隐藏对象
        const int AW_HIDE = 0x10000;
        //显示对象
        const int AW_ACTIVATE = 0x20000;
        //拉幕滑动效果
        const int AW_SLIDE = 0x40000;
        //淡入淡出渐变效果
        const int AW_BLEND = 0x80000;

        private Form2 f2 = null;

        public Form2 F2
        {
            get
            {
                return f2;
            }

            set
            {
                f2 = value;
            }
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.f2 = new Form2();
            this.f2.F1 = this;
            this.f2.Location = new Point(0, 0);
            this.f2.Show();
            this.f2.Hide();
        }

        private void ShowAnother()
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                AnimateWindow(this.f2.Handle, 1000, AW_ACTIVATE | AW_HOR_NEGATIVE);
            }));

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.Animate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Animate();
            //Helper.DLLHelper.CLAYUI_OnAnimation(this.Handle, 0, 1, 0, 0);
            //this.f2.Show();
        }

        private void Animate()
        {
            AnimateWindow(this.Handle, 500, AW_HIDE | AW_HOR_POSITIVE);
            AnimateWindow(this.f2.Handle, 500, AW_ACTIVATE | AW_HOR_NEGATIVE);
            this.f2.Location = new Point(0, 0);
        }
    }
}
