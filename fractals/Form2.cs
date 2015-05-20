using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fractals
{
    public partial class Form2 : Form
    {
       static Pen pen1;
        static Graphics gr;
        static Pen pen2;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            pen1 = new Pen(Color.Blue, 1);
            pen2 = new Pen(Color.White, 1);
            gr = CreateGraphics();
            var p1 = new PointF(100, 100);
            var p2 = new PointF(400, 100);
            var p3 = new PointF(250, 300);
            gr.DrawLine(pen1, p1, p2);
            gr.DrawLine(pen1, p2, p3);
            gr.DrawLine(pen1, p3, p1);

            Fractal(p1, p2, p3, 4);
            Fractal(p2, p3, p1, 4);
            Fractal(p3, p1, p2, 4);
        }
        static int Fractal(PointF p1, PointF p2, PointF p3, int n)
        {
            if (n > 0)
            {

                var p4 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                var p5 = new PointF((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);
                var ps = new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                var pn = new PointF((4 * ps.X - p3.X) / 3, (4 * ps.Y - p3.Y) / 3);

                gr.DrawLine(pen1, p4, pn);
                gr.DrawLine(pen1, p5, pn);
                gr.DrawLine(pen2, p4, p5);

                Fractal(p4, pn, p5, n - 1);
                Fractal(pn, p5, p4, n - 1);
                Fractal(p1, p4, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), n - 1);
                Fractal(p5, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), n - 1);

            }
            return n;
        }
        
    }
}
