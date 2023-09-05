using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lib_postgres
{
    public partial class Form_Simple_Element : Form
    {
        public Form_Simple_Element()
        {
            InitializeComponent();
        }

        public Form_Simple_Element(string caption, string label)
        {
            InitializeComponent();
            this.Text = caption;
            label1.Text = label;
        }

        private void Form_Simple_Element_Activated(object sender, EventArgs e)
        {
            tb_Name.Focus();
        }
    }
}
