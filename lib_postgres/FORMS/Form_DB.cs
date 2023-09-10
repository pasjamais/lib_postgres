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
            if (Directory.Exists(Deploy.backup_dir_path))
                openFileDialog_BD_Backup.InitialDirectory = Deploy.backup_dir_path;
            else
            {
                openFileDialog_BD_Backup.InitialDirectory = @"C:\";
            }
            if (openFileDialog_BD_Backup.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog_BD_Backup.FileName;
            Deploy.Restore_BD(filename, Deploy.is_DB_Exists());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LL_Load_Empty_BD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Deploy.Restore_Empty_BD((Deploy.is_DB_Exists()));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
