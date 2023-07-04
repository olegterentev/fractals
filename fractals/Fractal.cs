using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractals
{
    /// <summary>
    /// Базовый класс фракталов, в нем хрянятся общие свойства и переменные других фракталов.
    /// </summary>
    abstract class Fractal
    {
        /// <summary>
        /// Count глубина рекурсии.
        /// </summary>
        public Graphics g;
        public Bitmap map;
        public int Count;
        public Color StartColor;
        public Color EndColor;
        public PictureBox picture;
        public Pen Pen;
        public abstract void StartDraw();
        /// <summary>
        /// Функция для подсчета градиента.
        /// </summary>
        /// <param name="i">Номер итерации</param>
        /// <returns></returns>
        public Color GetColor(int i)
        {
            if (Count > 0)
            {
                int R, G, B;
                R = EndColor.R > StartColor.R ? (EndColor.R - StartColor.R) / (Count) : (StartColor.R - EndColor.R) / (Count);
                G = EndColor.G > StartColor.G ? (EndColor.G - StartColor.G) / (Count) : (StartColor.G - EndColor.G) / (Count);
                B = EndColor.B > StartColor.B ? (EndColor.B - StartColor.B) / (Count) : (StartColor.B - EndColor.B) / (Count);
                return Color.FromArgb(EndColor.R > StartColor.R ? StartColor.R + (R * (Count - i)) : StartColor.R - (R *(Count - i)),
                                        EndColor.G > StartColor.G ? StartColor.G + (G * (Count - i)) : StartColor.G - (G * (Count - i)),
                                        EndColor.B > StartColor.B ? StartColor.B + (B * (Count - i)) : StartColor.B - (B * (Count - i)));
            }
            return StartColor;
        }
    }
}
