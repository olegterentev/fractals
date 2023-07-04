using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractals
{
    class Tree : Fractal
    {
        /// <summary>
        /// Coefficent - Введенный пользователем коефицент.
        /// LeftAngle - Угол наклона левой ветви дерева.
        /// RightAngle - Угол наклона правой ветки дерева.
        /// </summary>
        public double Coefficent { get; set; }
        public int LeftAngle { get; set; }
        public int RightAngle { get; set; }
        /// <summary>
        /// Класс реализации Фрактального Дерева.
        /// Инициализация класса.
        /// </summary>
        /// <param name="picture">Поле для вывода фрактала.</param>
        public Tree(PictureBox picture) : base()
        {
            this.picture = picture;
            Coefficent = 0.75;
            LeftAngle = 45;
            RightAngle = 45;
            Count = 15;
            
        }
        /// <summary>
        /// Вспомогательная функция для отрисовки.
        /// </summary>
        public override void StartDraw()
        {
            map = new Bitmap(picture.Width, picture.Height);
            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            float x = (picture.Width / 2) - 4;
            float y = picture.Height - Convert.ToSingle(5.4);
            Pen = new System.Drawing.Pen(StartColor); 
            DrawFractal(x, y, 90, LeftAngle, RightAngle, Count, picture.Height / 6 * 2);
            picture.BackgroundImage = map;
            
        }
        /// <summary>
        /// Функция отрисовки фрактала.
        /// </summary>
        /// <param name="x">Координата начала.</param>
        /// <param name="y">Координата начала.</param>
        /// <param name="angle">Угол н который смещена ветвь.</param>
        /// <param name="leftAngle">Угол смещения левой ветки</param>
        /// <param name="rightAngle">Угол смещения правой ветки.</param>
        /// <param name="count">Количество итераций.</param>
        /// <param name="a">Длинна ветки.</param>
        void DrawFractal(double x, double y, int angle, int leftAngle, int rightAngle, int count, double a)
        {
            if (count >= 0 && a > 0.1)
            {
                Pen.Color = GetColor(count);
                double xf = x - (Math.Cos(Math.PI * angle / 180) * Coefficent * a);
                double yf = y - (Math.Sin(Math.PI * angle / 180) * Coefficent * a);
                g.DrawLine(Pen, (float)x, (float)y, (float)xf, (float)yf);
                DrawFractal(xf, yf, angle + leftAngle, leftAngle, rightAngle, count - 1, a * Coefficent);
                DrawFractal(xf, yf, angle - rightAngle, leftAngle, rightAngle, count - 1, a * Coefficent);
            }

        }
    }
}
