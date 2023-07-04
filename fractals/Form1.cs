using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractals
{
    public partial class Form1 : Form
    {
        TableLayoutPanel table;
        /// <summary>
        /// Инициализируем окно.
        /// Задаем минимальное и максимальное значение окну.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Size min = new Size();
            min.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Width / 2;
            min.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height / 2;
            this.MinimumSize = min;
            this.MaximumSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            table = this.tableLayoutPanel3;
        }
        /// <summary>
        /// Переменные фракталов.
        /// </summary>
        Tree Tree;
        CochCurve Coch;
        Triangle Triangle;
        Carpet Carpet;
        Kant Kant;
        /// <summary>
        /// Создание Label.
        /// Функция инициализирует и задает параметры для нового Label.
        /// </summary>
        /// <param name="text">Текст.</param>
        /// <returns></returns>
        Label GetLabel(string text)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = text;
            return label;
        }
        /// <summary>
        /// Выводим интерфес для Дерева.
        /// </summary>
        void GetTreeInterface()
        {
            table.RowCount = 10;
            table.RowStyles[0].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetLabel("Количество Итераций."), 0, 0);
            table.RowStyles[1].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetNumeric(1, 25, 15, "treeiterations"), 0, 1);
            table.RowStyles[2].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetLabel("Коэфицент длинны."), 0, 2);
            table.RowStyles[3].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetNumeric(0.25M, 0.75M, 0.75M, "len"), 0, 3);
            table.RowStyles[4].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetLabel("Первый угл в градусах."), 0, 4);
            table.RowStyles[5].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetNumeric(0, 90, 45, "angle1"), 0, 5);
            table.Controls.Add(GetLabel("Второй угла в градусах."), 0, 6);
            table.Controls.Add(GetNumeric(0, 90, 45, "angle2"), 0, 7);
        }
        /// <summary>
        /// Функция инициализирует и задает параметры для нового NumericUpDown.
        /// Также подключает NumericUpDown к функции при смене значения.
        /// </summary>
        /// <param name="min">Устанавливает минимальное значение.</param>
        /// <param name="max">Устанавливает максимальное значение.</param>
        /// <param name="value">Ставит значение.</param>
        /// <param name="name">Имя.</param>
        /// <returns></returns>
        NumericUpDown GetNumeric(int min, int max, int value, string name)
        {
            NumericUpDown numeric = new NumericUpDown();
            numeric.Minimum = min;
            numeric.Maximum = max;
            numeric.Value = value;
            numeric.BackColor = SystemColors.Control;
            numeric.Name = name;
            numeric.ValueChanged += Numeric_ValueChanged;
            numeric.Dock = DockStyle.Fill;
            return numeric;
        }
        /// <summary>
        /// Ищем какой NumericUpDown был задействован, и отрисовываем фрактал, с новывми параметрами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown a = (NumericUpDown)sender;
            switch (a.Name)
            {
                case "treeiterations":
                    Tree.Count = (int)a.Value;
                    Tree.StartDraw();
                    break;
                case "cochiteration":
                    Coch.Count = (int)a.Value;
                    Coch.StartDraw();
                    break;
                case "len":
                    Tree.Coefficent = Convert.ToDouble(a.Value);
                    Tree.StartDraw();
                    break;
                case "angle1":
                    Tree.LeftAngle = (int)a.Value;
                    Tree.StartDraw();
                    break;
                case "angle2":
                    Tree.RightAngle = (int)a.Value;
                    Tree.StartDraw();
                    break;
                case "trigiteration":
                    Triangle.Count = (int)a.Value;
                    Triangle.StartDraw();
                    break;
                case "carpetiteration":
                    Carpet.Count = (int)a.Value;
                    Carpet.StartDraw();
                    break;
                case "kantiteration":
                    Kant.Count = (int)a.Value;
                    Kant.StartDraw();
                    break;
                case "kantleight":
                    Kant.leight= (int)a.Value;
                    Kant.StartDraw();
                    break;
            }
        }
        /// <summary>
        /// Функция инициализирует и задает параметры для нового NumericUpDown.
        /// Также подключает NumericUpDown к функции при смене значения.
        /// </summary>
        /// <param name="min">Устанавливает минимальное значение.</param>
        /// <param name="max">Устанавливает максимальное значение.</param>
        /// <param name="value">Ставит значение.</param>
        /// <param name="name">Имя.</param>
        /// <returns></returns>
        NumericUpDown GetNumeric(decimal min, decimal max, decimal value, string name)
        {
            NumericUpDown numeric = new NumericUpDown();
            numeric.DecimalPlaces = 3;
            numeric.Increment = 0.001M;
            numeric.Minimum = min;
            numeric.Maximum = max;
            numeric.Value = value;
            numeric.BackColor = SystemColors.Control;
            numeric.Name = name;
            numeric.ValueChanged += Numeric_ValueChanged;
            numeric.Dock = DockStyle.Fill;
            return numeric;
        }

        /// <summary>
        /// Реализует выбор и отрисовывает фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            table.Controls.Clear();
            GetTreeInterface();
            Tree = new Tree(pictureBox1);
            Tree.StartColor = Color.FromArgb(0, 0, 0);
            Tree.EndColor = Color.FromArgb(0, 0, 0);
            Tree.StartDraw();
        }
        /// <summary>
        /// Реализует выбор и отрисовывает фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            table.Controls.Clear();
            Coch = new CochCurve(pictureBox1);
            Coch.StartColor = Color.FromArgb(0, 0, 0);
            Coch.EndColor = Color.FromArgb(0, 0, 0);
            GetCochInterface();
            Coch.StartDraw();
        }

        void GetCochInterface()
        {
            table.RowCount = 2;
            table.RowStyles[0].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetLabel("Количество Итераций."), 0, 0);
            table.RowStyles[1].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetNumeric(0, 10, 5, "cochiteration"), 0, 1);
        }
        /// <summary>
        /// Реализует выбор и отрисовывает фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            table.Controls.Clear();
            Triangle = new Triangle(pictureBox1);
            Triangle.StartColor = Color.FromArgb(0, 0, 0);
            Triangle.EndColor = Color.FromArgb(0, 0, 0);
            GetTrigleInterface();
            Triangle.StartDraw();
        }

        /// <summary>
        /// Выводим интерфес для Треугольника..
        /// </summary>
        void GetTrigleInterface()
        {
            table.RowCount = 2;
            table.RowStyles[0].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetLabel("Количество Итераций."), 0, 0);
            table.RowStyles[1].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetNumeric(0, 20, 5, "trigiteration"), 0, 1);
        }
        /// <summary>
        /// Реализует выбор и отрисовывает фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            table.Controls.Clear();
            Carpet = new Carpet(pictureBox1);
            Carpet.StartColor = Color.FromArgb(0, 0, 0);
            Carpet.EndColor = Color.FromArgb(0, 0, 0);
            GetCarpetInterface();
            Carpet.StartDraw();
        }
        /// <summary>
        /// Выводим интерфес для Ковра..
        /// </summary>
        void GetCarpetInterface()
        {
            table.RowCount = 2;
            table.RowStyles[0].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetLabel("Количество Итераций."), 0, 0);
            table.RowStyles[1].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetNumeric(0, 7, 5, "carpetiteration"), 0, 1);
        }
        /// <summary>
        /// Реализует выбор и отрисовывает фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            table.Controls.Clear();
            Kant = new Kant(pictureBox1);
            Kant.StartColor = Color.FromArgb(0, 0, 0);
            Kant.EndColor = Color.FromArgb(0, 0, 0);
            GetKantInterface();
            Kant.StartDraw();
        }
        /// <summary>
        /// Выводим интерфес для отрезков Канта.
        /// </summary>
        void GetKantInterface()
        {
            table.RowCount = 4;
            table.RowStyles[0].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetLabel("Количество Итераций."), 0, 0);
            table.RowStyles[1].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetNumeric(0, GetCount(), 5, "kantiteration"), 0, 1);
            table.RowStyles[2].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetLabel("Длинна отрезка."), 0, 2);
            table.RowStyles[3].SizeType = SizeType.AutoSize;
            table.Controls.Add(GetNumeric(0, pictureBox1.Width / 4 * 3, 500, "kantleight"), 0, 3);
        }
        /// <summary>
        /// Считает какое максимальное число итераций можно сделать для данной длинны.
        /// </summary>
        /// <returns></returns>
        int GetCount()
        {
            int res = 1;
            while(Math.Pow(3,res) < Kant.leight)
            {
                res++;
            }
            return res - 1;
        }

        /// <summary>
        /// Отрисовывает фрактал при именении размера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                Tree.StartDraw();
            }
            else if (radioButton2.Checked == true)
            {
                Coch.StartDraw();
            }
            else if (radioButton3.Checked == true)
            {
                Carpet.StartDraw();
            }
            else if (radioButton4.Checked == true)
            {
                Triangle.StartDraw();
            }
            else if (radioButton5.Checked == true)
            {
                Kant.StartDraw();
            }
        }
        /// <summary>
        /// Меняет значение конечного цвета.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Color start = Color.FromArgb((int)startR.Value, (int)startG.Value, (int)startB.Value);
            if (radioButton1.Checked == true)
            {
                Tree.StartColor = start;
                Tree.StartDraw();
            }
            else if (radioButton2.Checked == true)
            {
                Coch.StartColor = start;
                Coch.StartDraw();
            }
            else if (radioButton3.Checked == true)
            {
                Carpet.StartColor = start;
                Carpet.StartDraw();
            }
            else if (radioButton4.Checked == true)
            {
                Triangle.StartColor = start;
                Triangle.StartDraw();

            }
            else if (radioButton5.Checked == true)
            {
                Kant.StartColor = start;
                Kant.StartDraw();
            }
        }
        /// <summary>
        /// Меняет значение начального цвета.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endR_ValueChanged(object sender, EventArgs e)
        {
            Color end = Color.FromArgb((int)endR.Value, (int)endG.Value, (int)endB.Value);
            if (radioButton1.Checked == true)
            {
                Tree.EndColor = end;
                Tree.StartDraw();
            }
            else if (radioButton2.Checked == true)
            {
                Coch.EndColor = end;
                Coch.StartDraw();
            }
            else if (radioButton3.Checked == true)
            {
                Carpet.EndColor = end;
                Carpet.StartDraw();
            }
            else if (radioButton4.Checked == true)
            {
                Triangle.EndColor = end;
                Triangle.StartDraw();

            }
            else if (radioButton5.Checked == true)
            {
                Kant.EndColor = end;
                Kant.StartDraw();
            }
        }
    }
}
