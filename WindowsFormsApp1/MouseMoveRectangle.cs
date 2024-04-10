using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    [Serializable]
    internal class MouseMoveRectangle
    {
        public Point startPoint;
        public Rectangle currentRectangle;
        private MouseEventArgs e;
        public MouseMoveRectangle(Point startPoint, Rectangle currentRectangle, MouseEventArgs e)
        {
            this.startPoint = startPoint;
            this.currentRectangle = currentRectangle;
            this.e = e;
        }

        public void MouseMove()
        {
            {
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);
                int left = Math.Min(startPoint.X, e.X);
                int top = Math.Min(startPoint.Y, e.Y);
                currentRectangle = new Rectangle(left, top, width, height);
            }
        }
    }
}
