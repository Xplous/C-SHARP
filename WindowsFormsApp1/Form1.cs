using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.FormEditWidthPen;

namespace WindowsFormsApp1
{
    public partial class Форма : Form
    {
        string fileName;
        bool newFormCreated;
        Form activeChildForm;
        public Color penColor;
        public Color backgroundColor;
        public int penWidth;
        public ColorDialog colorDialog;
        public string selectedIndex { get; set; }
        public Форма()
        {
            InitializeComponent();
            saveToolStripMenuItem.Enabled = false;
            saveHowToolStripMenuItem.Enabled = false;
            penColor = Color.Black;
            backgroundColor = Color.White;
            penWidth = 2;
            colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = Color.Black;
        }
        public void EnableSaveHowMenuItem()
        {
            saveHowToolStripMenuItem.Enabled = false;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            if (e.Button == MouseButtons.Left) {
                string s = e.X.ToString();
                g.DrawString(s, new Font("Times New Roman", 24),
                new SolidBrush(Color.White), new Point(e.X, e.Y));
            } 
            else
            {
                g.Clear(Color.White);
                MessageBox.Show("Поле было очищено","Сообщение");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFormCreated = true;
            FormSize formSize = new FormSize();
            formSize.ShowDialog(this); 
            Form2 f = new Form2(newFormCreated);
            f.MdiParent = this;
            f.Text = "Рисунок " + this.MdiChildren.Length.ToString();
            fileName = f.Text;
            f.BackColor = backgroundColor;
            f.penColor = penColor;
            f.penWidth = penWidth;
            f.Width = formSize.GetSelectedWidth();
            f.Height = formSize.GetSelectedHeight();
            f.Show();
            saveToolStripMenuItem.Enabled = false;
            saveHowToolStripMenuItem.Enabled = true;
        }
        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeChildForm != null)
            {
                SaveAndOpen saveWindow = new SaveAndOpen(activeChildForm, MdiParent);
                var response = saveWindow.saveToolStripMenuItem_Click(sender,e, activeChildForm.Text);
                if (response == true)
                {
                    saveToolStripMenuItem.Enabled = false;
                    saveHowToolStripMenuItem.Enabled = false;
                }
            }
        }

        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAndOpen openWindow = new SaveAndOpen(activeChildForm, MdiParent);
            var responce = openWindow.openToolStripMenuItem_Click(sender, e);
            if (responce == true)
            {
                saveToolStripMenuItem.Enabled = false;
                saveHowToolStripMenuItem.Enabled = false;
            }
        }

        public void saveHowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeChildForm != null)
            {
                SaveAndOpen saveWindow = new SaveAndOpen(activeChildForm, MdiParent);
                var responce = saveWindow.saveHowToolStripMenuItem_Click(sender, e);
                if (responce == true)
                {
                    saveToolStripMenuItem.Enabled = false;
                    saveHowToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void Форма_MdiChildActivate(object sender, EventArgs e)
        {
            this.activeChildForm = Form.ActiveForm;
            saveToolStripMenuItem.Enabled = false;
            saveHowToolStripMenuItem.Enabled = false;
        }

        private void цветЛинииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (colorDialog.ShowDialog(this) == DialogResult.OK)
                {
                    penColor = colorDialog.Color;
                }
            }
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                backgroundColor = colorDialog.Color;
            }
        }

        private void толщинаЛинииToolStripMenuItem_Click(object sender, EventArgs e)
        {
                FormEditWidthPen formEditWidthPen = new FormEditWidthPen(penWidth);
                formEditWidthPen.ShowDialog();
                penWidth = formEditWidthPen.GetSelectedWidth();
        }
    }
}
