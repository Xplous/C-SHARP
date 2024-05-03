using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class PaintClassRectangle
    {
        private List<Rectangle> savedRectangles;
        private Rectangle currentRectangle;
        private PaintEventArgs e;
        // Конструктор принимает переменные и устанавливает в переменные класса
        public PaintClassRectangle(List<Rectangle> savedRectangles, Rectangle currentRectangle, PaintEventArgs e) {
            this.savedRectangles = savedRectangles;
            this.currentRectangle = currentRectangle;
            this.e = e;
        }
        public void PaintRectangle()
        {
            // Отрисовка сохранённых прямоугольников
            foreach (var rect in savedRectangles)
            {
                Pen pen = new Pen(Color.Black, 2);
                e.Graphics.DrawRectangle(pen, rect);
            }
            // Отрисовка текущего прямоугольника(который мы рисуем)
            if (currentRectangle != null)
            {
                Pen pen = new Pen(Color.Black, 2);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, currentRectangle);
            }
        }
    }
}
