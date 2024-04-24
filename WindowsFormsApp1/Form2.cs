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
    [Serializable]
    public partial class Form2 : Form
    {
        private Point startPoint;
        private Rectangle currentRectangle;
        private bool isDrawing;
        public List<Rectangle> savedRectangles;
        public bool newFormCreated;
        public Color penColor;
        public Color backgroundColor;
        public int penWidth;
        public Form2(bool newFormCreated)
        {
            InitializeComponent();
            savedRectangles = new List<Rectangle>();
            this.newFormCreated = newFormCreated;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(300, 300);
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            PaintClassRectangle paintClass = new PaintClassRectangle(savedRectangles,currentRectangle,e);
            paintClass.PaintRectangle(penColor, penWidth);
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

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            string msg = "Вы хотите сохранить?";
            DialogResult result = MessageBox.Show(msg, "Close Confirmation",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (newFormCreated)
                {
                    SaveAndOpen saveWindow = new SaveAndOpen(this, MdiParent);
                    saveWindow.saveHowToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    SaveAndOpen saveWindow = new SaveAndOpen(this, MdiParent);
                    var responce = saveWindow.saveToolStripMenuItem_Click(sender, e, this.Text);
                    if (responce && MdiParent is Форма parentForm)
                    {
                        parentForm.EnableSaveHowMenuItem();
                    }
                }
                e.Cancel = false;
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = false;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
