using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Complents.ChatComp
{
    #region EmotionItem
    [Serializable]
    [TypeConverter(typeof(EmotionItemConverter))]
    public class EmotionItem : IDisposable
    {
        #region 变量

        private string _text = string.Empty;
        private Image _image;
        private object _tag;
        private string _toolTip = string.Empty;
        private EmotionContainer _owner;
        private Rectangle _clientRectangle;
        private Rectangle _bounds;
        private Bitmap _bitmap;
        private bool _hover;

        #endregion

        #region 构造函数

        public EmotionItem() 
        {
            _text = "EmotionItem";
        }

        internal EmotionItem(EmotionContainer owner)
        {
            if (owner == null)
                throw new ArgumentNullException("owner");
            _owner = owner;
        }

        public EmotionItem(string text)
            : this(text, "", null)
        {
        }

        public EmotionItem(string text, Image image)
            : this(text, "", image)
        {
            _image = image;
        }

        public EmotionItem(string text, string tooltip, Image image)
        {
            _text = text;
            _toolTip = tooltip;
            _image = image;
        }

        #endregion

        #region 属性

        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                }
            }
        }

        [DefaultValue(typeof(Image),"null")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                if (_bitmap != null)
                {
                    _bitmap = null;
                }
                if (!IsNullOwner())
                    Owner.Invalidate(ClientRectangle);
            }
        }

        [DefaultValue("")]
        public string ToolTip
        {
            get { return _toolTip; }
            set 
            {
                if(_toolTip != value)
                    _toolTip = value;
            }
        }

        [Bindable(true)]
        [Localizable(false)]
        [DefaultValue("")]
        [TypeConverter(typeof(StringConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Tag
        {
            get { return _tag; }
            set
            {
                if (_tag != value)
                {
                    _tag = value;
                }
            }
        }

        [Browsable(false)]
        internal EmotionContainer Owner
        {
            get { return _owner; }
            set
            {
                if(_owner != value)
                    _owner = value;
            }
        }

        internal Rectangle ClientRectangle
        {
            get 
            {
                if (_clientRectangle == Rectangle.Empty && !IsNullOwner())
                {
                    Owner.ComputeItemRectangle(this);
                }
                return _clientRectangle;
            }
            set
            {
                if (_clientRectangle != value)
                    _clientRectangle = value;
            }
        }

        internal Rectangle Bounds
        {
            get 
            {
                if (_bounds == Rectangle.Empty)
                {
                    _bounds = ClientRectangle;
                    _bounds.Inflate(2, 2);
                }
                return _bounds; 
            }
            set
            {
                if (_bounds != value)
                {
                    _bounds = value;
                }
            }
        }

        internal Bitmap Bitmap
        {
            get 
            {
                if (_bitmap == null && _image != null)
                    _bitmap = new Bitmap(_image);
                return _bitmap;
            }
        }

        internal bool Honer
        {
            get { return _hover; }
            set
            {
                if (_hover != value)
                {
                    _hover = value;
                    if (!IsNullOwner())
                    {
                        Owner.Invalidate(Bounds);
                    }
                }
            }
        }

        #endregion

        #region Private Method

        private bool IsNullOwner()
        {
            return Owner == null; 
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            if(_image != null)
                _image = null;
            if (_bitmap != null)
                _bitmap = null;
            _tag = null;
        }

        #endregion
    }

    #endregion

    #region EmotionItemConverter

    public class EmotionItemConverter : TypeConverter
    {
        public EmotionItemConverter()
            : base()
        {
        }

        public override bool CanConvertTo(
            ITypeDescriptorContext context, 
            Type destinationType)
        {
            return ((destinationType == typeof(InstanceDescriptor)) || 
                base.CanConvertTo(context, destinationType));
        }

        public override object ConvertTo(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if ((destinationType == typeof(InstanceDescriptor)) &&
                (value is EmotionItem))
            {
                EmotionItem item = (EmotionItem)value;
                MemberInfo member = null;
                object[] arguments = null;

                if (!string.IsNullOrEmpty(item.Text) &&
                    !string.IsNullOrEmpty(item.ToolTip) &&
                    item.Image != null)
                {
                    member = typeof(EmotionItem).GetConstructor(
                        new Type[] { 
                            typeof(string), 
                            typeof(string),
                            typeof(Image) });
                    arguments = new object[] { item.Text, item.ToolTip, item.Image };
                }
                else if (!string.IsNullOrEmpty(item.Text) && item.Image != null)
                {
                    member = typeof(EmotionItem).GetConstructor(
                        new Type[] { typeof(string), 
                            typeof(Image) });
                    arguments = new object[] { item.Text, item.Image };
                }
                else if (!string.IsNullOrEmpty(item.Text))
                {
                    member = typeof(EmotionItem).GetConstructor(
                        new Type[] { typeof(string) });
                    arguments = new object[] { item.Text };
                }
                else
                {
                    member = typeof(EmotionItem).GetConstructor(Type.EmptyTypes);
                }

                if (member != null)
                {
                    return new InstanceDescriptor(member, arguments, true);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    #endregion
}
