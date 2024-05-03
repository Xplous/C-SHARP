using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class MouseDownRectangle
    {
        public MouseEventArgs e;
        public Point startPoint;
        public Rectangle currentRectangle;
        public bool isDrawing;
        // Конструктор класса в (переменные которые используются классом при создании экземпляра)
        public MouseDownRectangle(MouseEventArgs e, Point startPoint,Rectangle currentRectangle, bool isDrawing)
        {
            this.e = e;
            this.startPoint = startPoint;
            this.currentRectangle = currentRectangle;
            this.isDrawing = isDrawing;
        }

        public void MouseDown()
        {
            if (e.Button == MouseButtons.Left)
            {
                // При нажатии прямоугольник начинает рисоваться
                startPoint = e.Location;
                currentRectangle = new Rectangle(startPoint, Size.Empty);
                isDrawing = true;
            }
        }
    }
}
