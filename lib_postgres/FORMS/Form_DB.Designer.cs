namespace lib_postgres.FORMS
{
    partial class Form_DB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DB));
            this.openFileDialog_BD_Backup = new System.Windows.Forms.OpenFileDialog();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.L_main = new System.Windows.Forms.Label();
            this.LL_Load_Empty_BD = new System.Windows.Forms.LinkLabel();
            this.LL_Load_Existing_BD = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_UI_Language = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_UI_Language_RU = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_UI_Language_FR = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_UI_Language_EN = new System.Windows.Forms.ToolStripMenuItem();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LL_Connect_to_Existing_BD = new System.Windows.Forms.LinkLabel();
            this.label_password = new System.Windows.Forms.Label();
            this.LB_existDB = new System.Windows.Forms.Label();
            this.LL_NewDB = new System.Windows.Forms.Label();
            this.LB_RestoreBD = new System.Windows.Forms.Label();
            this.LL_Back = new System.Windows.Forms.LinkLabel();
            this.L_Resume = new System.Windows.Forms.Label();
            this.LL_Test_Connect = new System.Windows.Forms.LinkLabel();
            this.LL_Connect = new System.Windows.Forms.LinkLabel();
            this.LL_SelectBackupFile = new System.Windows.Forms.LinkLabel();
            this.LL_CreateDB = new System.Windows.Forms.LinkLabel();
            this.CHB_fill_with_initial = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog_BD_Backup
            // 
            resources.ApplyResources(this.openFileDialog_BD_Backup, "openFileDialog_BD_Backup");
            // 
            // button_OK
            // 
            resources.ApplyResources(this.button_OK, "button_OK");
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Name = "button_OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            resources.ApplyResources(this.button_Cancel, "button_Cancel");
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // L_main
            // 
            resources.ApplyResources(this.L_main, "L_main");
            this.L_main.Name = "L_main";
            // 
            // LL_Load_Empty_BD
            // 
            resources.ApplyResources(this.LL_Load_Empty_BD, "LL_Load_Empty_BD");
            this.LL_Load_Empty_BD.Name = "LL_Load_Empty_BD";
            this.LL_Load_Empty_BD.TabStop = true;
            this.LL_Load_Empty_BD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Load_Empty_BD_LinkClicked);
            // 
            // LL_Load_Existing_BD
            // 
            resources.ApplyResources(this.LL_Load_Existing_BD, "LL_Load_Existing_BD");
            this.LL_Load_Existing_BD.Name = "LL_Load_Existing_BD";
            this.LL_Load_Existing_BD.TabStop = true;
            this.LL_Load_Existing_BD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Load_Existing_BD_LinkClicked);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_UI_Language});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // ToolStripMenuItem_UI_Language
            // 
            resources.ApplyResources(this.ToolStripMenuItem_UI_Language, "ToolStripMenuItem_UI_Language");
            this.ToolStripMenuItem_UI_Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_UI_Language_RU,
            this.ToolStripMenuItem_UI_Language_FR,
            this.ToolStripMenuItem_UI_Language_EN});
            this.ToolStripMenuItem_UI_Language.Name = "ToolStripMenuItem_UI_Language";
            // 
            // ToolStripMenuItem_UI_Language_RU
            // 
            resources.ApplyResources(this.ToolStripMenuItem_UI_Language_RU, "ToolStripMenuItem_UI_Language_RU");
            this.ToolStripMenuItem_UI_Language_RU.Name = "ToolStripMenuItem_UI_Language_RU";
            this.ToolStripMenuItem_UI_Language_RU.Click += new System.EventHandler(this.ToolStripMenuItem_UI_Language_Changing_Click);
            // 
            // ToolStripMenuItem_UI_Language_FR
            // 
            resources.ApplyResources(this.ToolStripMenuItem_UI_Language_FR, "ToolStripMenuItem_UI_Language_FR");
            this.ToolStripMenuItem_UI_Language_FR.Name = "ToolStripMenuItem_UI_Language_FR";
            this.ToolStripMenuItem_UI_Language_FR.Click += new System.EventHandler(this.ToolStripMenuItem_UI_Language_Changing_Click);
            // 
            // ToolStripMenuItem_UI_Language_EN
            // 
            resources.ApplyResources(this.ToolStripMenuItem_UI_Language_EN, "ToolStripMenuItem_UI_Language_EN");
            this.ToolStripMenuItem_UI_Language_EN.Name = "ToolStripMenuItem_UI_Language_EN";
            this.ToolStripMenuItem_UI_Language_EN.Click += new System.EventHandler(this.ToolStripMenuItem_UI_Language_Changing_Click);
            // 
            // TB_Password
            // 
            resources.ApplyResources(this.TB_Password, "TB_Password");
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::lib_postgres.Properties.Resources.happy_HDD;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // LL_Connect_to_Existing_BD
            // 
            resources.ApplyResources(this.LL_Connect_to_Existing_BD, "LL_Connect_to_Existing_BD");
            this.LL_Connect_to_Existing_BD.Name = "LL_Connect_to_Existing_BD";
            this.LL_Connect_to_Existing_BD.TabStop = true;
            this.LL_Connect_to_Existing_BD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Connect_to_Existing_BD_LinkClicked);
            // 
            // label_password
            // 
            resources.ApplyResources(this.label_password, "label_password");
            this.label_password.Name = "label_password";
            // 
            // LB_existDB
            // 
            resources.ApplyResources(this.LB_existDB, "LB_existDB");
            this.LB_existDB.Name = "LB_existDB";
            // 
            // LL_NewDB
            // 
            resources.ApplyResources(this.LL_NewDB, "LL_NewDB");
            this.LL_NewDB.Name = "LL_NewDB";
            // 
            // LB_RestoreBD
            // 
            resources.ApplyResources(this.LB_RestoreBD, "LB_RestoreBD");
            this.LB_RestoreBD.Name = "LB_RestoreBD";
            // 
            // LL_Back
            // 
            resources.ApplyResources(this.LL_Back, "LL_Back");
            this.LL_Back.Name = "LL_Back";
            this.LL_Back.TabStop = true;
            this.LL_Back.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Back_LinkClicked);
            // 
            // L_Resume
            // 
            resources.ApplyResources(this.L_Resume, "L_Resume");
            this.L_Resume.Name = "L_Resume";
            // 
            // LL_Test_Connect
            // 
            resources.ApplyResources(this.LL_Test_Connect, "LL_Test_Connect");
            this.LL_Test_Connect.Name = "LL_Test_Connect";
            this.LL_Test_Connect.TabStop = true;
            this.LL_Test_Connect.Click += new System.EventHandler(this.Connect_Test_Click);
            // 
            // LL_Connect
            // 
            resources.ApplyResources(this.LL_Connect, "LL_Connect");
            this.LL_Connect.Name = "LL_Connect";
            this.LL_Connect.TabStop = true;
            this.LL_Connect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Connect_LinkClicked);
            // 
            // LL_SelectBackupFile
            // 
            resources.ApplyResources(this.LL_SelectBackupFile, "LL_SelectBackupFile");
            this.LL_SelectBackupFile.Name = "LL_SelectBackupFile";
            this.LL_SelectBackupFile.TabStop = true;
            this.LL_SelectBackupFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_SelectBackupFile_LinkClicked);
            // 
            // LL_CreateDB
            // 
            resources.ApplyResources(this.LL_CreateDB, "LL_CreateDB");
            this.LL_CreateDB.Name = "LL_CreateDB";
            this.LL_CreateDB.TabStop = true;
            this.LL_CreateDB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_CreateDB_LinkClicked);
            // 
            // CHB_fill_with_initial
            // 
            resources.ApplyResources(this.CHB_fill_with_initial, "CHB_fill_with_initial");
            this.CHB_fill_with_initial.Checked = true;
            this.CHB_fill_with_initial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHB_fill_with_initial.Name = "CHB_fill_with_initial";
            this.CHB_fill_with_initial.UseVisualStyleBackColor = true;
            // 
            // Form_DB
            // 
            this.AcceptButton = this.button_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.Controls.Add(this.L_main);
            this.Controls.Add(this.CHB_fill_with_initial);
            this.Controls.Add(this.LL_CreateDB);
            this.Controls.Add(this.LL_SelectBackupFile);
            this.Controls.Add(this.LL_Connect);
            this.Controls.Add(this.LL_Test_Connect);
            this.Controls.Add(this.L_Resume);
            this.Controls.Add(this.LL_Back);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.LL_Connect_to_Existing_BD);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TB_Password);
            this.Controls.Add(this.LL_Load_Existing_BD);
            this.Controls.Add(this.LL_Load_Empty_BD);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.LL_NewDB);
            this.Controls.Add(this.LB_existDB);
            this.Controls.Add(this.LB_RestoreBD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_DB";
            this.ShowInTaskbar = false;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog_BD_Backup;
        private Button button_OK;
        private Button button_Cancel;
        private LinkLabel LL_Load_Empty_BD;
        private LinkLabel LL_Load_Existing_BD;
        protected internal Label L_main;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItem_UI_Language;
        private ToolStripMenuItem ToolStripMenuItem_UI_Language_RU;
        private ToolStripMenuItem ToolStripMenuItem_UI_Language_FR;
        private ToolStripMenuItem ToolStripMenuItem_UI_Language_EN;
        private TextBox TB_Password;
        private PictureBox pictureBox1;
        private LinkLabel LL_Connect_to_Existing_BD;
        private Label label_password;
        private Label LB_existDB;
        private Label LL_NewDB;
        private Label LB_RestoreBD;
        private LinkLabel LL_Back;
        private Label L_Resume;
        private LinkLabel LL_Test_Connect;
        private LinkLabel LL_Connect;
        private LinkLabel LL_SelectBackupFile;
        private LinkLabel LL_CreateDB;
        private CheckBox CHB_fill_with_initial;
    }
}