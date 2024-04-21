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
namespace WindowsFormsApp1
{
    public partial class Форма : Form
    {
        string fileName;
        bool newFormCreated;
        Form activeChildForm;
        public Форма()
        {
            InitializeComponent();
            saveToolStripMenuItem.Enabled = false;
            saveHowToolStripMenuItem.Enabled = false;
            
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
            Form f = new Form2(newFormCreated);
            f.MdiParent = this;
            f.Text = "Рисунок " + this.MdiChildren.Length.ToString();
            fileName = f.Text;
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
    }
}
