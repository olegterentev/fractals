using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractals
{
    class Kant : Fractal
    {
        /// <summary>
        /// Класс для фрактала "Множество Канта".
        /// Наследуется от базового фрактала.
        /// </summary>
        public int leight;
        /// <summary>
        /// Инициализация класса.
        /// </summary>
        /// <param name="picture"></param>
        public Kant(PictureBox picture) : base()
        {
            this.picture = picture;
            Count = 5;
            Pen = new System.Drawing.Pen(Color.Black);
            leight = 500;
        }
        /// <summary>
        /// Вспомогательная функция для отрисовки.
        /// </summary>
        public override void StartDraw()
        {
            map = new Bitmap(picture.Width, picture.Height);
            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int x = picture.Width / 2 - leight / 2;
            DrawFractal(x, picture.Height / 5, Count, leight);
            picture.BackgroundImage = map;
        }
        /// <summary>
        /// Функция отрисовки.
        /// </summary>
        /// <param name="x">Х координата.</param>
        /// <param name="y">Y координата.</param>
        /// <param name="count">Количество итераций.</param>
        /// <param name="leight">Длинна отрезка.</param>
        private void DrawFractal(int x, int y, int count, int leight)
        {
             
            if (leight > 0 && count > -1 && y < picture.Height)
            {
                //Отрезки изображаем прямоугольниками для наглядности.
                g.DrawRectangle(Pen, x, y, leight, 12);
                g.FillRectangle(new SolidBrush(GetColor(count)), x, y, leight, 12);

                //Сдвигаемся вниз.
                y = y + 40;

                //Вызываем функцию для двух полученных отрезков.
                DrawFractal(x + leight * 2 / 3, y, count - 1, leight / 3);
                DrawFractal(x, y, count - 1, leight / 3);
            }

        }
    }
}

