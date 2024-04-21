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
    public partial class FormEditColorPen : Form
    {
        public Color penColor;
        public FormEditColorPen(Color penColor)
        {
            InitializeComponent();
            this.penColor = penColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
