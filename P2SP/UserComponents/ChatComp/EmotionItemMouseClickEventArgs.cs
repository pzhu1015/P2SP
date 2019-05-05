using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UserComponents.ChatComp
{
    public delegate void EmotionItemMouseEventHandler(
        object sender,
        EmotionItemMouseClickEventArgs e);

    public class EmotionItemMouseClickEventArgs : MouseEventArgs
    {
        private EmotionItem _item;

        public EmotionItemMouseClickEventArgs(EmotionItem item, MouseEventArgs e)
            : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
        {
            _item = item;
        }

        public EmotionItem Item
        {
            get { return _item; }
        }
    }
}
