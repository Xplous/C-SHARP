using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class MouseUpRectangle
    {
        public MouseEventArgs e;
        public Rectangle currentRectangle;
        public bool isDrawing;
        public List<Rectangle> savedRectangles;
        public MouseUpRectangle(MouseEventArgs e, bool isDrawing, List<Rectangle> savedRectangles, Rectangle currentRectangle)
        {
            this.e = e;
            this.isDrawing = isDrawing;
            this.currentRectangle = currentRectangle;
            this.savedRectangles = savedRectangles;
        }
        public void MouseUp()
        {
                isDrawing = false;
                savedRectangles.Add(currentRectangle);
                currentRectangle = Rectangle.Empty;
        }
    }
}
