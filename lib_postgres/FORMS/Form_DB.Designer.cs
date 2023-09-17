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
            this.label1 = new System.Windows.Forms.Label();
            this.LL_Load_Empty_BD = new System.Windows.Forms.LinkLabel();
            this.LL_Load_Existing_BD = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_UI_Language = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_UI_Language_RU = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_UI_Language_FR = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_UI_Language_EN = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.button_OK, "button_OK");
            this.button_OK.Name = "button_OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.button_Cancel, "button_Cancel");
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_UI_Language});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // ToolStripMenuItem_UI_Language
            // 
            this.ToolStripMenuItem_UI_Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_UI_Language_RU,
            this.ToolStripMenuItem_UI_Language_FR,
            this.ToolStripMenuItem_UI_Language_EN});
            this.ToolStripMenuItem_UI_Language.Name = "ToolStripMenuItem_UI_Language";
            resources.ApplyResources(this.ToolStripMenuItem_UI_Language, "ToolStripMenuItem_UI_Language");
            // 
            // ToolStripMenuItem_UI_Language_RU
            // 
            this.ToolStripMenuItem_UI_Language_RU.Name = "ToolStripMenuItem_UI_Language_RU";
            resources.ApplyResources(this.ToolStripMenuItem_UI_Language_RU, "ToolStripMenuItem_UI_Language_RU");
            this.ToolStripMenuItem_UI_Language_RU.Click += new System.EventHandler(this.ToolStripMenuItem_UI_Language_Changing_Click);
            // 
            // ToolStripMenuItem_UI_Language_FR
            // 
            this.ToolStripMenuItem_UI_Language_FR.Name = "ToolStripMenuItem_UI_Language_FR";
            resources.ApplyResources(this.ToolStripMenuItem_UI_Language_FR, "ToolStripMenuItem_UI_Language_FR");
            this.ToolStripMenuItem_UI_Language_FR.Click += new System.EventHandler(this.ToolStripMenuItem_UI_Language_Changing_Click);
            // 
            // ToolStripMenuItem_UI_Language_EN
            // 
            this.ToolStripMenuItem_UI_Language_EN.Name = "ToolStripMenuItem_UI_Language_EN";
            resources.ApplyResources(this.ToolStripMenuItem_UI_Language_EN, "ToolStripMenuItem_UI_Language_EN");
            this.ToolStripMenuItem_UI_Language_EN.Click += new System.EventHandler(this.ToolStripMenuItem_UI_Language_Changing_Click);
            // 
            // Form_DB
            // 
            this.AcceptButton = this.button_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.Controls.Add(this.LL_Load_Existing_BD);
            this.Controls.Add(this.LL_Load_Empty_BD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_DB";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog_BD_Backup;
        private Button button_OK;
        private Button button_Cancel;
        private LinkLabel LL_Load_Empty_BD;
        private LinkLabel LL_Load_Existing_BD;
        protected internal Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItem_UI_Language;
        private ToolStripMenuItem ToolStripMenuItem_UI_Language_RU;
        private ToolStripMenuItem ToolStripMenuItem_UI_Language_FR;
        private ToolStripMenuItem ToolStripMenuItem_UI_Language_EN;
    }
}