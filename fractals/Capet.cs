using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace fractals
{
    class Carpet :Fractal
    {
        /// <summary>
        /// Объявление класса, рисующего ковер.
        /// </summary>
        /// <param name="picture">Поле для вывода фрактала</param>
        public Carpet(PictureBox picture) : base()
        {
            this.picture = picture;
            Count = 5;
        }
        /// <summary>
        /// Вспомогающая функция для рисования.
        /// </summary>
        public override void StartDraw()
        {
            map = new Bitmap(picture.Width, picture.Height);
            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            RectangleF carpet = new RectangleF(picture.Width / 2 - picture.Height / 10 * 4, picture.Height / 10, picture.Height / 10 * 8, picture.Height / 10 * 8);
            Pen = new System.Drawing.Pen(StartColor);
            DrawFractal(Count, carpet);
            picture.BackgroundImage = map;
        }
        /// <summary>
        /// Рисуем фрактал.
        /// </summary>
        /// <param name="level">Количество итераций.</param>
        /// <param name="carpet">Координаты левого верхнего угла с длинной и шириной квадрата.</param>
        private void DrawFractal(int level, RectangleF carpet)
        {
            if (level >= 0)
            {
                //Находим координаты левого верхнего угла для 9ти квадратов.
                var width = carpet.Width / 3f;
                var height = carpet.Height / 3f;
                var x1 = carpet.Left;
                var x2 = x1 + width;
                var x3 = x1 + 2f * width;
                var y1 = carpet.Top;
                var y2 = y1 + height;
                var y3 = y1 + 2f * height;
                DrawFractal(level - 1, new RectangleF(x1, y1, width, height));
                DrawFractal(level - 1, new RectangleF(x2, y1, width, height));
                DrawFractal(level - 1, new RectangleF(x3, y1, width, height));
                DrawFractal(level - 1, new RectangleF(x1, y2, width, height)); 
                DrawFractal(level - 1, new RectangleF(x3, y2, width, height));
                DrawFractal(level - 1, new RectangleF(x1, y3, width, height));
                DrawFractal(level - 1, new RectangleF(x2, y3, width, height)); 
                DrawFractal(level - 1, new RectangleF(x3, y3, width, height));
                //Закрашиваем центральный квадрат.
                g.FillRectangle(new SolidBrush(GetColor(level)), new RectangleF(x2, y2, width, height));
            }
        }
    }
}
