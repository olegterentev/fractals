using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractals
{
    class Triangle : Fractal
    {
        /// <summary>
        /// Класс реализации треугольника Серпинского.
        /// </summary>
        public int leight;

        /// <summary>
        /// Инициализация.
        /// </summary>
        /// <param name="picture">Поле вывода фрактала.</param>
        public Triangle(PictureBox picture) : base()
        {
            this.picture = picture;
            leight = picture.Width;
            Count = 5;
        }
        /// <summary>
        /// Вспомогательная функция для отрисовки.
        /// </summary>
        public override void StartDraw()
        {
            map = new Bitmap(picture.Width, picture.Height);
            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            PointF topPoint = new PointF(picture.Width / 2f, picture.Height / 10);
            PointF leftPoint = new PointF(picture.Width / 10, picture.Height / 10*9);
            PointF rightPoint = new PointF(picture.Width / 10 * 9, picture.Height / 10 * 9);
            Pen = new System.Drawing.Pen(StartColor);
            DrawFractal(topPoint, leftPoint, rightPoint, Count);
            g.DrawLine(new Pen(StartColor), topPoint, leftPoint);
            g.DrawLine(new Pen(StartColor), rightPoint, leftPoint);
            g.DrawLine(new Pen(StartColor), rightPoint, topPoint);
            picture.BackgroundImage = map;
        }
        /// <summary>
        ///  Функция отрисовки фрактала.
        /// </summary>
        /// <param name="top">Координата верхней вершины.</param>
        /// <param name="left">Координата левой вершины.</param>
        /// <param name="right">Координата правой вершины.</param>
        /// <param name="count">Количество итераций.</param>
        void DrawFractal(PointF top, PointF left, PointF right, int count)
        {
            if (count >= 0)
            {
                Pen.Color = GetColor(count);
                var leftMid = MidPoint(top, left);
                var rightMid = MidPoint(top, right);
                var topMid = MidPoint(left, right);
                g.DrawLine(Pen, leftMid, rightMid);
                g.DrawLine(Pen, topMid, rightMid);
                g.DrawLine(Pen, leftMid, topMid);
                DrawFractal(top, leftMid, rightMid, count - 1);
                DrawFractal(leftMid, left, topMid, count - 1);
                DrawFractal(rightMid, topMid, right, count - 1);
            }
        }
        /// <summary>
        /// Поиск координаты по центру отрезка.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private PointF MidPoint(PointF p1, PointF p2)
        {
            return new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
        }
    }
}
