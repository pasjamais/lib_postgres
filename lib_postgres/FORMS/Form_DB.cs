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
            Initial_Langues_Menu_Load();
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

        private void Initial_Langues_Menu_Load()
        {
            Localization.Initial_Langues_Form_Menu_Load(ToolStripMenuItem_UI_Language);
        }

        private void ToolStripMenuItem_UI_Language_Changing_Click(object sender, EventArgs e)
        {
            Localization.Change_Language(this, sender.ToString(), ToolStripMenuItem_UI_Language);

        }
    }
}
