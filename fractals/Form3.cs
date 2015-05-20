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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public class Triangle
        {
            Random rnd = new Random();
            int i = 0;

            public void RisuemTo4ky(Graphics g, Point[] A1, Point B)
            {

                int k = rnd.Next(0, 3);
                Point B1 = new Point(((A1[k].X + B.X) / 2), ((A1[k].Y + B.Y) / 2));
                g.FillEllipse(new SolidBrush(Color.Black), B1.X, B1.Y, 3, 3);
                
                i++;
                while (i != 8000)
                {
                    RisuemTo4ky(g, A1, B1); 
                }
            }
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            Point[] A = new Point[3];
            A[0] = new Point(10, 10);
            A[1] = new Point(200, 10);
            A[2] = new Point(200, 250);
            Point B = new Point(200, 150);

            Triangle T = new Triangle();
            T.RisuemTo4ky(g, A, B);
            pictureBox1.Image = bmp;
            pictureBox1.Invalidate();
        }
    }
}
