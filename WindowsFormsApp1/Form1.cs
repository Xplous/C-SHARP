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
    public partial class Форма : Form
    {
        public Форма()
        {
            InitializeComponent();
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
    }
}
