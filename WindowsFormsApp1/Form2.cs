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
            PaintClassRectangle paintClass = new PaintClassRectangle(savedRectangles,currentRectangle,e);
            paintClass.PaintRectangle();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownRectangle mouseDownRectangle = new MouseDownRectangle(e, startPoint, currentRectangle, isDrawing);
            mouseDownRectangle.MouseDown();
            startPoint = mouseDownRectangle.startPoint;
            currentRectangle = mouseDownRectangle.currentRectangle;
            isDrawing = mouseDownRectangle.isDrawing;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                MouseMoveRectangle mouseMoveRectangle = new MouseMoveRectangle(startPoint, currentRectangle,e);
                mouseMoveRectangle.MouseMove();
                currentRectangle = mouseMoveRectangle.currentRectangle;
                this.Invalidate();
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseUpRectangle mouseUpRectangle = new MouseUpRectangle(e, isDrawing, savedRectangles, currentRectangle);
                mouseUpRectangle.MouseUp();
                isDrawing = mouseUpRectangle.isDrawing;
                savedRectangles = mouseUpRectangle.savedRectangles;
                currentRectangle = mouseUpRectangle.currentRectangle;
                this.Invalidate();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
