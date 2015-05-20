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
    public partial class Form4 : Form
    {
        static double currentmaxr = 0;
        static double currentminr = 0;
        static double currentmaxi = 0;
        static double currentmini = 0;

        public Form4()
        {
            InitializeComponent();
        }

        Bitmap MandelbrotSet(PictureBox pictureBox1, double maxr, double minr, double maxi, double mini)
        {
            currentmaxr = maxr;
            currentmaxi = maxi;
            currentminr = minr;
            currentmini = mini;
            //размер изображения в соответствии с размерами pictureBox1
            Bitmap img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            double zx = 0;
            double zy = 0;
            double cx = 0;
            double cy = 0;
            double xjump = ((maxr - minr) / Convert.ToDouble(img.Width));
            double yjump = ((maxi - mini) / Convert.ToDouble(img.Height));
            double tempzx = 0;
            //Размытость изображения
            int loopmax = 1000;
            int loopgo = 0;
            for (int x = 0; x < img.Width; x++)
            {
                cx = (xjump * x) - Math.Abs(minr);
                for (int y = 0; y < img.Height; y++)
                {
                    zx = 0;
                    zy = 0;
                    cy = (yjump * y) - Math.Abs(mini);
                    loopgo = 0;
                    while (zx * zx + zy * zy <= 4 && loopgo < loopmax)
                    {
                        loopgo++;
                        tempzx = zx;
                        zx = (zx * zx) - (zy * zy) + cx;
                        zy = (2 * tempzx * zy) + cy;
                    }
                    //Задание цветовой палитры отображения изображения
                    //Для внешнего окружения Множества Мандельброта
                    if (loopgo != loopmax)
                        img.SetPixel(x, y, Color.FromArgb(loopgo % 128 * 2, loopgo % 4 * 33, loopgo % 2 * 66));
                    //альтернативная запись в таком формате .FromArgb(190,44,66));
                    else
                        //Для внутреннего окружения Множества Мандельброта
                        img.SetPixel(x, y, Color.Black);

                }
            }
            return img;

        }
       

        private void Form4_Load(object sender, EventArgs e)
        {
            //запрос на выполнение отрисовки картинки с уточнением параметров её размещения
            Bitmap img = MandelbrotSet(pictureBox1, 2, -2, 2, -2);
            pictureBox1.Image = img;
        }

    }
}
