using lib_postgres.CODE;
using lib_postgres.CODE.DEPLOY;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace lib_postgres.FORMS
{
    public partial class Form_DB : Form
    {
        private Color DefaultLabelColor;
        enum Option
        {
            New,
            Restore,
            Existing,
            None
        }
        private Option option = Option.None;
        public Form_DB()
        {
            InitializeComponent();
            Initial_Langues_Menu_Load();
            L_Resume.Text = "";
            DefaultLabelColor = L_Resume.ForeColor;
        }

        private void LL_Load_Existing_BD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Option_Restore();
        }

        private void LL_Load_Empty_BD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Option_New();
        }

        private void Initial_Langues_Menu_Load()
        {
            Localization.Initial_Langues_Form_Menu_Load(ToolStripMenuItem_UI_Language);
        }

        private void ToolStripMenuItem_UI_Language_Changing_Click(object sender, EventArgs e)
        {
            Localization.Change_Language(this, sender.ToString(), ToolStripMenuItem_UI_Language);
        }

        private void LL_Connect_to_Existing_BD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Option_Connection();
        }


        private void Option_Connection()
        {
            option = Option.Existing;
            pictureBox1.Image = Properties.Resources.wand;
            Hide_all_Options(false);
            Show_or_Hide_Option_Connection(true);
            Connection connection = new Connection();
            TB_Password.Text = connection.Get_Password();
        }

        private void Option_New()
        {
            option = Option.New;
            pictureBox1.Image = Properties.Resources.creation01;
            Hide_all_Options(false);
            Show_or_Hide_Option_New(true);
            Connection connection = new Connection();
            TB_Password.Text = connection.Get_Password();

        }

        private void Option_Restore()
        {
            option = Option.Restore;
            pictureBox1.Image = Properties.Resources.img_HDD;
            Hide_all_Options(false);
            Show_or_Hide_Option_Restore(true);
            Connection connection = new Connection();
            TB_Password.Text = connection.Get_Password();

        }

        private void Hide_all_Options(bool to_show)
        {
            Show_or_Hide_Option(LB_existDB, LL_Connect_to_Existing_BD, to_show);
            Show_or_Hide_Option(LL_NewDB, LL_Load_Empty_BD, to_show);
            Show_or_Hide_Option(LB_RestoreBD, LL_Load_Existing_BD, to_show);
            L_main.Visible = to_show;
        }

        private void Show_or_Hide_Option(Label label, LinkLabel linklanel, bool to_show)
        {
            label.Visible = linklanel.Visible = to_show;
        }

        private void Connect_Test_Click(object sender, EventArgs e)
        {
            Connection connection = new Connection();
            connection.Set_Password(TB_Password.Text);
            string conn_str = connection.Prepare_Connection_String(true);
            switch (option)
            {
                case Option.Restore:
                    {
                        if (Queries_SQL_Direct.Connection_Test(conn_str))
                        {
                            pictureBox1.Image = Properties.Resources.img_HDD;
                            L_Resume.ForeColor = Color.Green;
                            L_Resume.Text = Localization.Substitute("Connection_established");
                            LL_SelectBackupFile.Enabled = true;
                            connection.Save_Crypt_to_INI_File();
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.img_noconnect;
                            L_Resume.ForeColor = Color.Red;
                            L_Resume.Text = Localization.Substitute("Info_DB_No_Connection");
                            LL_SelectBackupFile.Enabled = false;
                        }
                        break;
                    }
                case Option.Existing:
                    {
                        if (Queries_SQL_Direct.Connection_Test(conn_str))
                        {
                            connection.Save_Crypt_to_INI_File();
                            if (connection.is_DB_Exists())
                            {
                                if (connection.has_DB_Tables())
                                {
                                    pictureBox1.Image = Properties.Resources.img_good_DB;
                                    L_Resume.ForeColor = Color.Green;
                                    L_Resume.Text = Localization.Substitute("Connection_established");
                                    connection.Save_Crypt_to_INI_File();
                                    LL_Connect.Enabled = true;
                                }
                                else
                                {
                                    pictureBox1.Image = Properties.Resources.broken_base;
                                    L_Resume.ForeColor = Color.Red;
                                    L_Resume.Text = Localization.Substitute("Info_DB_corrupted");
                                }
                            }
                            else
                            {
                                pictureBox1.Image = Properties.Resources.black_hole;
                                L_Resume.ForeColor = Color.Red;
                                L_Resume.Text = Localization.Substitute("Info_Connect_OK_DB_not_found");
                            }
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.img_noconnect;
                            L_Resume.ForeColor = Color.Red;
                            L_Resume.Text = Localization.Substitute("Info_DB_No_Connection");
                        }
                     break;
                    }
                case Option.New:
                    {
                        if (Queries_SQL_Direct.Connection_Test(conn_str))
                        {
                            pictureBox1.Image = Properties.Resources.creation01;
                            L_Resume.ForeColor = Color.Green;
                            L_Resume.Text = Localization.Substitute("Connection_established");
                            LL_CreateDB.Enabled = true;
                            connection.Save_Crypt_to_INI_File();
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.img_noconnect;
                            L_Resume.ForeColor = Color.Red;
                            L_Resume.Text = Localization.Substitute("Info_DB_No_Connection");
                            LL_SelectBackupFile.Enabled = false;
                        }
                        break;
                    }

                default:
                    break;
            }           
           
        }
        private void Show_or_Hide_Option_New(bool to_show)
        {
            CHB_fill_with_initial.Visible = LL_Test_Connect.Visible = LL_CreateDB.Visible = L_Resume.Visible =
                LL_Back.Visible = label_password.Visible = TB_Password.Visible = to_show;
        }
        private void Show_or_Hide_Option_Connection(bool to_show)
        {
            LL_Test_Connect.Visible = LL_Connect.Visible = L_Resume.Visible = 
                LL_Back.Visible = label_password.Visible = TB_Password.Visible = to_show;
        }
        private void Show_or_Hide_Option_Restore(bool to_show)
        {
            LL_SelectBackupFile.Visible = LL_Test_Connect.Visible = L_Resume.Visible =
                LL_Back.Visible = label_password.Visible = TB_Password.Visible = to_show;
        }
        private void LL_Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.happy_HDD;
            Show_or_Hide_Option_Connection(false);
            Show_or_Hide_Option_Restore(false);
            Show_or_Hide_Option_New(false);
            L_Resume.Text = TB_Password.Text = "";
            L_Resume.ForeColor = DefaultBackColor;
            option = Option.None;
            Hide_all_Options(true);
        }

        private void LL_Connect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                this.DialogResult = DialogResult.OK;
                DB_Agent.Renew_Connection();
               this.Close();
        }

        private void LL_SelectBackupFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = Restore.Choose_RestoreBD(openFileDialog_BD_Backup);
            if (DialogResult != DialogResult.OK)
            {
                DialogResult = DialogResult.None;
                pictureBox1.Image = Properties.Resources.img_HDD;
                Hide_all_Options(false);
            }
            this.Close();
        }

        private void LL_CreateDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Connection connection = new Connection();
            Restore.Restore_Empty_BD((connection.is_DB_Exists()), CHB_fill_with_initial.Checked);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
