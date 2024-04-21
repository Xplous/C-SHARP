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
    internal class PaintClassRectangle
    {
        private List<Rectangle> savedRectangles;
        private Rectangle currentRectangle;
        private PaintEventArgs e;

        public PaintClassRectangle(List<Rectangle> savedRectangles, Rectangle currentRectangle, PaintEventArgs e) {
            this.savedRectangles = savedRectangles;
            this.currentRectangle = currentRectangle;
            this.e = e;
        }
        public void PaintRectangle(Color penColor, int penWidth)
        {
            foreach (var rect in savedRectangles)
            {
                Pen pen = new Pen(penColor, penWidth);
                e.Graphics.DrawRectangle(pen, rect);
            }

            if (currentRectangle != null)
            {
                Pen pen = new Pen(penColor, penWidth);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, currentRectangle);
            }
        }
    }
}
