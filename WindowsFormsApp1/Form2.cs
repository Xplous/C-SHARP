using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private Point startPoint;
        private Rectangle currentRectangle;
        private bool isDrawing;
        private List<Rectangle> savedRectangles;

        public Form2()
        {
            InitializeComponent();
            savedRectangles = new List<Rectangle>();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            foreach (var rect in savedRectangles)
            {
                Pen pen = new Pen(Color.Black, 2);
                e.Graphics.DrawRectangle(pen, rect);
            }

            if (currentRectangle != null)
            {
                Pen pen = new Pen(Color.Black, 2);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, currentRectangle);
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                currentRectangle = new Rectangle(startPoint, Size.Empty);
                isDrawing = true;
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);
                int left = Math.Min(startPoint.X, e.X);
                int top = Math.Min(startPoint.Y, e.Y);
                currentRectangle = new Rectangle(left, top, width, height);
                this.Invalidate();
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
                savedRectangles.Add(currentRectangle);
                currentRectangle = Rectangle.Empty;
                this.Invalidate();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
