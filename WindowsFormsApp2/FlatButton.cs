using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class FlatButton : Control
    {
        //Variables
        private SolidBrush borderBrush, textBrush;
        private Rectangle borderRectange;
        private bool active = false;
        private StringFormat stringFormat = new StringFormat();

        //Properties
        public override Cursor Cursor { get; set; } = Cursors.Hand;
        public float BorderThickness { get; set; } = 2;

        //Constructor
        public FlatButton()
        {
            borderBrush = new SolidBrush(ColorTranslator.FromHtml("#31302b"));
            textBrush = new SolidBrush(ColorTranslator.FromHtml("#FFF"));

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            this.Paint += FlatButton_Paint;

        }
        //Events
        public void FlatButton_Paint(object sender, PaintEventArgs e)
        {
            borderRectange = new Rectangle(0, 0, Width, Height);
            e.Graphics.DrawRectangle(new Pen(borderBrush, BorderThickness), borderRectange);
            e.Graphics.DrawString(this.Text, this.Font, (active) ? textBrush : borderBrush, borderRectange, stringFormat);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            base.BackColor = ColorTranslator.FromHtml("#31302b");
            active = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            base.BackColor = ColorTranslator.FromHtml("#FFF");
            active = false;
        }
    }
}
