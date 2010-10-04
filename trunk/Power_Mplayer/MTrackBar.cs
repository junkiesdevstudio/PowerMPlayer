using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Power_Mplayer
{
    [DefaultEvent("OnValueChanged")]
    public partial class MTrackBar : UserControl
    {
        private Bitmap _bmpCache;
        private double _value;
        private int _lineWeight = 4;
        
        private int _padding = 5;

        private int _usablePixel;
        private int _btnLeftMin, _btnLeftMax;

        public event EventHandler OnValueChanged;

        public double Maximum { get; set; }
        public double Minimum { get; set; }

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (_value < Minimum)
                    _value = Minimum;
                else if (_value > Maximum)
                    _value = Maximum;

                button1.Left = (int)((_value / (Maximum - Minimum)) * (_btnLeftMax - _btnLeftMin)) + _btnLeftMin;

                if(OnValueChanged != null)
                    OnValueChanged(this, null);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            _usablePixel = this.ClientSize.Width - _padding * 2;
            _btnLeftMin = 5;
            _btnLeftMax = this.ClientSize.Width - _padding - button1.Width;
        }

        public MTrackBar()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            button1.Left = _btnLeftMin;
            _bmpCache = null;
        }

        private void DrawLine(Graphics g)
        {
            g.Clear(Color.Transparent);

            Pen pen = Pens.DimGray;
            Brush brush = Brushes.DarkGray;

            
            int Top = button1.Top + button1.Height / 2;
            Rectangle rect = new Rectangle(_padding, Top - _lineWeight / 2, _usablePixel, _lineWeight);
            g.DrawRectangle(pen, rect);

            rect = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2);
            g.FillRectangle(brush, rect);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_bmpCache == null)
            {
                _bmpCache = new Bitmap(ClientSize.Width, ClientSize.Height);
                using (Graphics g = Graphics.FromImage(_bmpCache))
                {
                    DrawLine(g);
                    g.Dispose();
                }
            }

            e.Graphics.DrawImage(_bmpCache, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
            
            base.OnPaint(e);
        }

        private bool _mouseDown = false;

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;

            if (sender != button1)
                setBtnPos(e.X);
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
            //MessageBox.Show("mouse up");
        }

        private void setBtnPos(int pos)
        {
            if (_mouseDown)
            {
                int newPos = pos - (button1.Width / 2);

                if (newPos < _btnLeftMin)
                    newPos = _btnLeftMin;
                else if (newPos > _btnLeftMax)
                    newPos = _btnLeftMax;

                if (button1.Left != newPos)
                {
                    button1.Left = newPos;

                    _value = (newPos - _btnLeftMin) / (double)(_btnLeftMax - _btnLeftMin);
                    _value = _value * (Maximum - Minimum);
                    this.Update();
                    button1.Update();

                    if (OnValueChanged != null)
                        OnValueChanged(this, null);
                }
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if(sender == button1)
                setBtnPos(e.X+button1.Left);
            else
                setBtnPos(e.X);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1_MouseUp(null, null);
        }

        private void button1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Checked = false;
        }
    }
}
