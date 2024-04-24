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
    public partial class FormEditWidthPen : Form
    {
        private int penWidth;

        public FormEditWidthPen(int penWidth)
        {
            InitializeComponent();
            this.penWidth = penWidth;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int selectedWidth;
                if (int.TryParse(listBox1.SelectedItem.ToString(), out selectedWidth))
                {
                    penWidth = selectedWidth;
                }
            }
        }
        public int GetSelectedWidth()
        {
            return penWidth;
        }
    }
}
