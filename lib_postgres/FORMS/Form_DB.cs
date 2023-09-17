using lib_postgres.CODE.DEPLOY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lib_postgres.FORMS
{
    public partial class Form_DB : Form
    {
        public Form_DB()
        {
            InitializeComponent();
        }

        private void LL_Load_Existing_BD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = Restore.Choose_RestoreBD(openFileDialog_BD_Backup);
            this.Close();
        }

        private void LL_Load_Empty_BD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Restore.Restore_Empty_BD((Deploy.is_DB_Exists()));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
