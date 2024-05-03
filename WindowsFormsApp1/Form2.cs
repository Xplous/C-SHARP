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
    // Форма ребёнок
    public partial class Form2 : Form
    {
        private Point startPoint;
        private Rectangle currentRectangle;
        private bool isDrawing;
        private List<Rectangle> savedRectangles;

        public Form2()
        {
            InitializeComponent();
            // Сохранённые прямоугольники
            savedRectangles = new List<Rectangle>();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            // Создаём экзэмпляр класса PaintClassRectangle, в котором происходит отрисовка
            PaintClassRectangle paintClass = new PaintClassRectangle(savedRectangles,currentRectangle,e);
            paintClass.PaintRectangle();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            // Создаём экзэмпляр класса MouseDownRectangle
            MouseDownRectangle mouseDownRectangle = new MouseDownRectangle(e, startPoint, currentRectangle, isDrawing);
            mouseDownRectangle.MouseDown();
            // Получаю данные после нажатия мыши
            startPoint = mouseDownRectangle.startPoint;
            currentRectangle = mouseDownRectangle.currentRectangle;
            isDrawing = mouseDownRectangle.isDrawing;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // Создаём экзэмпляр класса MouseMoveRectangle
                MouseMoveRectangle mouseMoveRectangle = new MouseMoveRectangle(startPoint, currentRectangle,e);
                mouseMoveRectangle.MouseMove();
                // Получаю данные после движения мыши
                currentRectangle = mouseMoveRectangle.currentRectangle;
                // Для отрисовки, перерисовывается рисующийся прямоуголньник
                this.Invalidate();
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Создаём экзэмпляр класса MouseUpRectangle
                MouseUpRectangle mouseUpRectangle = new MouseUpRectangle(e, isDrawing, savedRectangles, currentRectangle);
                mouseUpRectangle.MouseUp();
                // Получаю данные после отпускания кнопки мыши
                isDrawing = mouseUpRectangle.isDrawing;
                savedRectangles = mouseUpRectangle.savedRectangles;
                currentRectangle = mouseUpRectangle.currentRectangle;
                // Для отрисовки, при отпускании кнопки перерисовываются прямоугольники
                this.Invalidate();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
