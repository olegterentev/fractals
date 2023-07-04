using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractals
{
    class CochCurve : Fractal
    {
        /// <summary>
        /// Класс реализации "Кривой Коха".
        /// </summary>
        public double leight;
        /// <summary>
        /// Инициализация класса.
        /// </summary>
        /// <param name="picture">Поле для вывода фрактала.</param>
        public CochCurve(PictureBox picture) : base()
        {
            this.picture = picture;
            leight = picture.Width;
            Count = 5;
            Pen = new System.Drawing.Pen(Color.Black);
        }
        /// <summary>
        /// Вспомогательная функция для отрисовки.
        /// </summary>
        public override void StartDraw()
        {
            map = new Bitmap(picture.Width, picture.Height);
            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            float x = (picture.Width / 2) - 4 - (float)leight / 2;
            float y = (picture.Height / 3) * 2;
            DrawFractal(x, y, leight, 0, Count);
            picture.BackgroundImage = map;
        }
        /// <summary>
        /// Функция отрисовки фрактала.
        /// </summary>
        /// <param name="x">Х координата начала.</param>
        /// <param name="y">Y координата начала.</param>
        /// <param name="leight">Длинна.</param>
        /// <param name="angle">Угол.</param>
        /// <param name="count">Количество итераций</param>
        void DrawFractal(double x, double y, double leight, int angle, int count)
        {
            if(count >= 0)
            {
                Pen.Color = GetColor(count);
                if (count == 0)
                {
                    //Рисуем прямую с заданным углом.
                    double xf = x + (Math.Cos(Math.PI * angle / 180) * leight);
                    double yf = y + (Math.Sin(Math.PI * angle / 180) * leight);
                    g.DrawLine(Pen, (float)x, (float)y, (float)xf, (float)yf);
                }
                else
                {
                    //Отрисовываем первую часть фрактала:"_".
                    DrawFractal(x, y, leight / 3, angle, count - 1);
                    double xf = x + (Math.Cos(Math.PI * angle / 180) * leight / 3);
                    double yf = y + (Math.Sin(Math.PI * angle / 180) * leight / 3);
                    //Отрисовываем вторую часть фрактала:"/".
                    DrawFractal(xf, yf, leight / 3, angle - 60, count - 1);
                    double xg = xf + (Math.Cos(Math.PI * (angle - 60) / 180) * leight / 3);
                    double yg = yf + (Math.Sin(Math.PI * (angle - 60) / 180) * leight / 3);
                    //Отрисовываем вторую часть фрактала:"\".
                    DrawFractal(xg, yg, leight / 3, angle + 60, count - 1);
                    xf = x + (Math.Cos(Math.PI * angle / 180) * leight / 3 * 2);
                    yf = y + (Math.Sin(Math.PI * angle / 180) * leight / 3 * 2);
                    //Отрисовываем вторую часть фрактала:"_".
                    DrawFractal(xf, yf, leight / 3, angle, count - 1);
                    //Получаем целую часть "_/\_".
                }
            }
        }
    }
}
