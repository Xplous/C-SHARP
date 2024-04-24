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
    public partial class FormSize : Form
    {
        private int selectWidth;
        private int selectHeight;
        public FormSize()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            selectWidth = 320;
            selectHeight = 240;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            selectWidth = 640;
            selectHeight = 480;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            selectWidth = 800;
            selectHeight = 600;
        }
        public int GetSelectedWidth()
        {
            return selectWidth;
        }
        public int GetSelectedHeight()
        {
            return selectHeight;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
