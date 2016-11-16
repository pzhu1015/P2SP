/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-3-6
 * Time: 21:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ExtendControl
{
	/// <summary>
	/// Description of TSmartProgressBar.
	/// </summary>
	[ToolboxItem(true)]
    [ToolboxBitmap(typeof(System.Windows.Forms.ProgressBar))]
    [Designer(typeof(TSmartProgressBarDesinger),typeof(IDesigner))]
    public class TSmartProgressBar : Label
    { 
        private const int m_MaxBarWidth = 20;
        private const int m_MaxBarSpace = 10;

        private int m_Value = 0;
        private int m_Maximum = 100;

        private int m_ProgressBarBlockWidth = 6;
        private int m_ProgressBarBlockSpace = 1;
        private bool m_ProgressBarPercent = true;
        private bool m_ProgressBarMarginOffset = true;

        private TProgressBarBorderStyle m_ProgressBarBorderStyle = TProgressBarBorderStyle.Flat;
        private SolidBrush m_ProgressBarFillBrush;

        public TSmartProgressBar()
        {
            m_ProgressBarFillBrush = new SolidBrush(Color.Coral);

            base.BackColor = Color.White;
            base.ForeColor = Color.Blue;

            base.AutoSize = false;  // AutoSize is Designer Attribute
            base.TextAlign = ContentAlignment.MiddleCenter;   // TextAlign is Designer Attribute
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    // release managed resource
                }
                m_ProgressBarFillBrush.Dispose();  // release unmanaged resource
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #region  custom or modified properties

        [Category("Custom")]
        [Description("Set/Get progress bar fill color.")]
        [DefaultValue(typeof(Color), "Coral")]
        public Color ProgressBarFillColor
        {
            get
            {
                return m_ProgressBarFillBrush.Color;
            }

            set
            {
                if (m_ProgressBarFillBrush.Color != value)
                {
                    m_ProgressBarFillBrush.Color = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Custom")]
        [Description("Set/Get progress small bar width.")]
        [DefaultValue(6)]
        public int ProgressBarBlockWidth
        {
            get { return m_ProgressBarBlockWidth; }
            set
            {
                if (m_ProgressBarBlockWidth != value)
                {
                    if (value < 1)
                    {
                        m_ProgressBarBlockWidth = 1;
                    }
                    else if (value > m_MaxBarWidth)
                    {
                        m_ProgressBarBlockWidth = m_MaxBarWidth;
                    }
                    else
                    {
                        m_ProgressBarBlockWidth = value;
                    }
                    this.Invalidate();
                }
            }
        }

        [Category("Custom")]
        [Description("Set/Get progress bar space width(smooth when 0).")]
        [DefaultValue(1)]
        public int ProgressBarBlockSpace
        {
            get { return m_ProgressBarBlockSpace; }
            set
            {
                if (m_ProgressBarBlockSpace != value)
                {
                    if (value < 0)
                    {
                        m_ProgressBarBlockSpace = 0;
                    }
                    else if (value > m_MaxBarSpace)
                    {
                        m_ProgressBarBlockSpace = m_MaxBarSpace;
                    }
                    else
                    {
                        m_ProgressBarBlockSpace = value;
                    }
                    this.Invalidate();
                }
            }
        }

        [Category("Custom")]
        [Description("Set/Get progress bar boder style.")]
        [DefaultValue(typeof(TProgressBarBorderStyle), "Flat")]
        public TProgressBarBorderStyle ProgressBarBoderStyle
        {
            get { return m_ProgressBarBorderStyle; }
            set
            {
                if (m_ProgressBarBorderStyle != value)
                {
                    m_ProgressBarBorderStyle = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Custom")]
        [Description("Set/Get show percent text or not.")]
        [DefaultValue(true)]
        public bool ProgressBarPercent
        {
            get { return m_ProgressBarPercent; }
            set
            {
                if (m_ProgressBarPercent != value)
                {
                    m_ProgressBarPercent = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Custom")]
        [Description("Set/Get if progress bar has margin offset.")]
        [DefaultValue(true)]
        public bool ProgressBarMarginOffset
        {
            get { return m_ProgressBarMarginOffset; }
            set
            {
                if (m_ProgressBarMarginOffset != value)
                {
                    m_ProgressBarMarginOffset = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Custom")]
        [Description("Set/Get progress bar background color.")]
        [DefaultValue(typeof(Color), "White")]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if(base.BackColor != value)
                {
                    base.BackColor = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Custom")]
        [Description("Set/Get progress bar text color.")]
        [DefaultValue(typeof(Color), "Blue")]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                if (base.ForeColor != value)
                {
                    base.ForeColor = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Custom")]
        [Description("Set/Get progress bar maximum value.")]
        [DefaultValue(100)]
        public int Maximum
        {
            get { return m_Maximum; }
            set
            {
                if (m_Maximum != value)
                {
                    if (value < 1)
                    {
                        m_Maximum = 1;
                    }
                    else
                    {
                        m_Maximum = value;
                    }
                    if (m_Maximum < m_Value)
                    {
                        m_Value = m_Maximum;
                    }

                    this.Invalidate();
                }
            }
        }

        [Category("Custom")]
        [Description("Set/Get progress bar current value.")]
        [DefaultValue(0)]
        public int Value
        {
            get { return m_Value; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > m_Maximum)
                {
                    m_Value = m_Maximum;
                }
                else
                {
                    m_Value = value;
                }

                this.Invalidate();
                this.Update();
            }
        }

        #endregion

        #region disable base properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AutoEllipsis
        {
            get { return base.AutoEllipsis; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Drawing.ContentAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool CausesValidation
        {
            get { return base.CausesValidation; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AllowDrop
        {
            get { return base.AllowDrop; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get { return base.Padding; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get { return base.ImeMode; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            get { return base.TabStop; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseCompatibleTextRendering
        {
            get { return base.UseCompatibleTextRendering; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseMnemonic
        {
            get { return base.UseMnemonic; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Image Image
        {
            get { return base.Image; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Drawing.ContentAlignment ImageAlign
        {
            get { return base.ImageAlign; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new int ImageIndex
        {
            get { return base.ImageIndex; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new string ImageKey
        {
            get { return base.ImageKey; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageList ImageList
        {
            get { return base.ImageList; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new string Text
        {
            get { return base.Text; }
        }


        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            this.DrawPrgressBarBorder(e.Graphics);
            this.DrawProgressBar(e.Graphics);

            if (m_ProgressBarPercent)
            {
                base.Text = ((double)m_Value / (double)m_Maximum).ToString("##0 %");
            }
            else
            {
                base.Text = string.Empty;
            }

            base.OnPaint(e);
        }

        private int GetTopOffSet()
        {
            if (!m_ProgressBarMarginOffset)  // use no margin
            {
                if (m_ProgressBarBorderStyle == TProgressBarBorderStyle.Sunken || m_ProgressBarBorderStyle == TProgressBarBorderStyle.Flat)
                {
                    return 2;
                }
                else if (m_ProgressBarBorderStyle == TProgressBarBorderStyle.None)
                {
                    return 0;
                }
                return 1;
            }
            else  // use margin
            {
                if (m_ProgressBarBorderStyle == TProgressBarBorderStyle.Flat || m_ProgressBarBorderStyle == TProgressBarBorderStyle.Sunken)
                {
                    return 3;
                }
                else if (m_ProgressBarBorderStyle == TProgressBarBorderStyle.None)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        private int GetLeftOffSet()
        {
            if (!m_ProgressBarMarginOffset)
            {
                if (m_ProgressBarBorderStyle == TProgressBarBorderStyle.Flat)
                {
                    return 2;
                }
                else if (m_ProgressBarBorderStyle == TProgressBarBorderStyle.None)
                {
                    return 0;
                }
                return 1;
            }
            else
            {
                if (m_ProgressBarBorderStyle == TProgressBarBorderStyle.Flat  || m_ProgressBarBorderStyle == TProgressBarBorderStyle.Sunken)
                {
                    return 3;
                }
                else if (m_ProgressBarBorderStyle == TProgressBarBorderStyle.None)
                {
                    return 1;
                }
                return 2;
            }
        }

        private void DrawProgressBar(Graphics g)
        {
            decimal percent = (decimal)m_Value / (decimal)m_Maximum;

            int valueWidth = (int)((this.ClientRectangle.Width - this.GetLeftOffSet() * 2) * percent);  // width corresponds to Value
            int oneBlockWidth = m_ProgressBarBlockWidth + m_ProgressBarBlockSpace;  // bar width + space width
            int blockWidth = (valueWidth / oneBlockWidth) * (oneBlockWidth);  // width corresponds to real blocks

            if (percent > 0.99m)  // add block length to avoid trunc error
            {
                if (this.ClientRectangle.Width - this.GetLeftOffSet() * 2 - blockWidth > 0)
                {
                    blockWidth += (this.ClientRectangle.Width - this.GetLeftOffSet() * 2 - blockWidth) / (oneBlockWidth);
                }
            }

            int left = this.ClientRectangle.Left + this.GetLeftOffSet();
            int top = this.ClientRectangle.Top + this.GetTopOffSet();
            int height = this.ClientRectangle.Height - this.GetTopOffSet() * 2;

            int drawnBlockWidth = oneBlockWidth;
            while (drawnBlockWidth <= blockWidth)
            {
                g.FillRectangle(m_ProgressBarFillBrush, left, top, m_ProgressBarBlockWidth, height);
                left += oneBlockWidth;
                drawnBlockWidth += oneBlockWidth;
            }

            // below code used to draw the tail part.
            
            int tailBarWidth = this.ClientRectangle.Width - left - this.GetLeftOffSet();
            if (tailBarWidth > 0 && tailBarWidth < oneBlockWidth)  // tail is not a full bar
            {
                drawnBlockWidth = this.ClientRectangle.Width - left - this.GetLeftOffSet();
                if (drawnBlockWidth > 0)
                {
                    g.FillRectangle(m_ProgressBarFillBrush, left, top, drawnBlockWidth, height);  // draw partial bar
                }
            }
        }

        private void DrawPrgressBarBorder(Graphics g)
        {
            if (this.m_ProgressBarBorderStyle == TProgressBarBorderStyle.Single)
            {
                ControlPaint.DrawBorder(g, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
            }
            else if (this.m_ProgressBarBorderStyle == TProgressBarBorderStyle.Flat)
            {
                ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Flat);
            }
            else if (this.m_ProgressBarBorderStyle == TProgressBarBorderStyle.Sunken)
            {
                ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Sunken);
            }
            else if (this.m_ProgressBarBorderStyle == TProgressBarBorderStyle.SunkenInner)
            {
                ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.SunkenInner);
            }
            else if (this.m_ProgressBarBorderStyle == TProgressBarBorderStyle.SunkenOut)
            {
                ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.SunkenOuter);
            }
        }

    }

    /// <summary>
    /// border kind
    /// </summary>
    public enum TProgressBarBorderStyle { Flat, SunkenOut, SunkenInner, Sunken, Single, None }

    /// <summary>
    /// smart tag design
    /// </summary>
    public class TSmartProgressBarDesinger : ControlDesigner
    {
        private DesignerActionListCollection m_ActionLists;

        public TSmartProgressBarDesinger(){}

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == m_ActionLists)
                {
                    m_ActionLists = new DesignerActionListCollection();
                    m_ActionLists.Add(new TSmartProgressBarDesignerActionList(this.Component));
                }
                return m_ActionLists;
            }
        }
    }

    /// <summary>
    /// custom smart tag item
    /// </summary>
    public class TSmartProgressBarDesignerActionList : DesignerActionList
    {
        public TSmartProgressBarDesignerActionList(IComponent component) : base(component) { }

        private TSmartProgressBar SmartProgressBar
        {
            get { return this.Component as TSmartProgressBar; }
        }

        public bool ProgressBarPercent
        {
            get { return this.SmartProgressBar.ProgressBarPercent; }
            set { this.SetProperty("ProgressBarPercent", value); }
        }

        public Color ProgressBarFillColor
        {
            get { return this.SmartProgressBar.ProgressBarFillColor; }
            set { this.SetProperty("ProgressBarFillColor", value); }
        }

        public TProgressBarBorderStyle ProgressBarBoderStyle
        {
            get { return this.SmartProgressBar.ProgressBarBoderStyle; }
            set { this.SetProperty("ProgressBarBoderStyle", value); }
        }

        public bool ProgressBarMarginOffset
        {
            get { return this.SmartProgressBar.ProgressBarMarginOffset; }
            set { this.SetProperty("ProgressBarMarginOffset", value); }
        }

        public int ProgressBarBlockWidth
        {
            get { return this.SmartProgressBar.ProgressBarBlockWidth; }
            set { this.SetProperty("ProgressBarBlockWidth", value); }
        }

        public int ProgressBarBlockSpace
        {
            get { return this.SmartProgressBar.ProgressBarBlockSpace; }
            set { this.SetProperty("ProgressBarBlockSpace", value); }
        }

        public Color BackColor
        {
            get { return this.SmartProgressBar.BackColor; }
            set { this.SetProperty("BackColor", value); }
        }

        public Color ForeColor
        {
            get { return this.SmartProgressBar.ForeColor; }
            set { this.SetProperty("ForeColor", value); }
        }

        private void SetProperty(string propertyName, object value)
        {
            PropertyDescriptorCollection propertyCollection = TypeDescriptor.GetProperties(this.SmartProgressBar);
            PropertyDescriptor property = propertyCollection[propertyName];
            property.SetValue(this.SmartProgressBar, value);
        }
    }
}
