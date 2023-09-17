namespace lib_postgres
{
    public partial class Form_Art
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Art));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.BT_Add_Langue_Original = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Langue = new System.Windows.Forms.ComboBox();
            this.TB_YearCreation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Genre = new System.Windows.Forms.ComboBox();
            this.BT_Add_Genre = new System.Windows.Forms.Button();
            this.DGV_All_Authors = new System.Windows.Forms.DataGridView();
            this.DGV_Selected_Authors = new System.Windows.Forms.DataGridView();
            this.BT_Select_Author = new System.Windows.Forms.Button();
            this.BT_Add_Author = new System.Windows.Forms.Button();
            this.BT_Deselect_Author = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChB_Language = new System.Windows.Forms.CheckBox();
            this.ChB_Genre = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_All_Authors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Selected_Authors)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tb_Name
            // 
            resources.ApplyResources(this.tb_Name, "tb_Name");
            this.tb_Name.Name = "tb_Name";
            // 
            // button_Cancel
            // 
            resources.ApplyResources(this.button_Cancel, "button_Cancel");
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            resources.ApplyResources(this.button_OK, "button_OK");
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Name = "button_OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // BT_Add_Langue_Original
            // 
            resources.ApplyResources(this.BT_Add_Langue_Original, "BT_Add_Langue_Original");
            this.BT_Add_Langue_Original.Name = "BT_Add_Langue_Original";
            this.BT_Add_Langue_Original.UseVisualStyleBackColor = true;
            this.BT_Add_Langue_Original.Click += new System.EventHandler(this.BT_Add_Langue_Original_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // CB_Langue
            // 
            resources.ApplyResources(this.CB_Langue, "CB_Langue");
            this.CB_Langue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Langue.FormattingEnabled = true;
            this.CB_Langue.Name = "CB_Langue";
            // 
            // TB_YearCreation
            // 
            resources.ApplyResources(this.TB_YearCreation, "TB_YearCreation");
            this.TB_YearCreation.Name = "TB_YearCreation";
            this.TB_YearCreation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_YearCreation_KeyPress);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // CB_Genre
            // 
            resources.ApplyResources(this.CB_Genre, "CB_Genre");
            this.CB_Genre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Genre.FormattingEnabled = true;
            this.CB_Genre.Name = "CB_Genre";
            // 
            // BT_Add_Genre
            // 
            resources.ApplyResources(this.BT_Add_Genre, "BT_Add_Genre");
            this.BT_Add_Genre.Name = "BT_Add_Genre";
            this.BT_Add_Genre.UseVisualStyleBackColor = true;
            this.BT_Add_Genre.Click += new System.EventHandler(this.BT_Add_Genre_Click);
            // 
            // DGV_All_Authors
            // 
            resources.ApplyResources(this.DGV_All_Authors, "DGV_All_Authors");
            this.DGV_All_Authors.AllowUserToAddRows = false;
            this.DGV_All_Authors.AllowUserToDeleteRows = false;
            this.DGV_All_Authors.AllowUserToResizeRows = false;
            this.DGV_All_Authors.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.DGV_All_Authors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_All_Authors.MultiSelect = false;
            this.DGV_All_Authors.Name = "DGV_All_Authors";
            this.DGV_All_Authors.ReadOnly = true;
            this.DGV_All_Authors.RowHeadersVisible = false;
            this.DGV_All_Authors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_All_Authors.DoubleClick += new System.EventHandler(this.DGV_All_Authors_DoubleClick);
            // 
            // DGV_Selected_Authors
            // 
            resources.ApplyResources(this.DGV_Selected_Authors, "DGV_Selected_Authors");
            this.DGV_Selected_Authors.AllowUserToAddRows = false;
            this.DGV_Selected_Authors.AllowUserToDeleteRows = false;
            this.DGV_Selected_Authors.AllowUserToResizeRows = false;
            this.DGV_Selected_Authors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_Selected_Authors.MultiSelect = false;
            this.DGV_Selected_Authors.Name = "DGV_Selected_Authors";
            this.DGV_Selected_Authors.ReadOnly = true;
            this.DGV_Selected_Authors.RowHeadersVisible = false;
            this.DGV_Selected_Authors.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.DGV_Selected_Authors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Selected_Authors.DoubleClick += new System.EventHandler(this.DGV_Selected_Authors_DoubleClick);
            // 
            // BT_Select_Author
            // 
            resources.ApplyResources(this.BT_Select_Author, "BT_Select_Author");
            this.BT_Select_Author.Name = "BT_Select_Author";
            this.BT_Select_Author.UseVisualStyleBackColor = true;
            this.BT_Select_Author.Click += new System.EventHandler(this.BT_Select_Author_Click);
            // 
            // BT_Add_Author
            // 
            resources.ApplyResources(this.BT_Add_Author, "BT_Add_Author");
            this.BT_Add_Author.Name = "BT_Add_Author";
            this.BT_Add_Author.UseVisualStyleBackColor = true;
            this.BT_Add_Author.Click += new System.EventHandler(this.BT_Add_Author_Click);
            // 
            // BT_Deselect_Author
            // 
            resources.ApplyResources(this.BT_Deselect_Author, "BT_Deselect_Author");
            this.BT_Deselect_Author.Name = "BT_Deselect_Author";
            this.BT_Deselect_Author.UseVisualStyleBackColor = true;
            this.BT_Deselect_Author.Click += new System.EventHandler(this.BT_Deselect_Author_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.TB_YearCreation);
            this.groupBox1.Controls.Add(this.ChB_Language);
            this.groupBox1.Controls.Add(this.ChB_Genre);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BT_Deselect_Author);
            this.groupBox1.Controls.Add(this.DGV_Selected_Authors);
            this.groupBox1.Controls.Add(this.tb_Name);
            this.groupBox1.Controls.Add(this.BT_Add_Genre);
            this.groupBox1.Controls.Add(this.CB_Genre);
            this.groupBox1.Controls.Add(this.BT_Add_Langue_Original);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CB_Langue);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // ChB_Language
            // 
            resources.ApplyResources(this.ChB_Language, "ChB_Language");
            this.ChB_Language.Name = "ChB_Language";
            this.ChB_Language.UseVisualStyleBackColor = true;
            this.ChB_Language.CheckedChanged += new System.EventHandler(this.ChB_Language_CheckedChanged);
            // 
            // ChB_Genre
            // 
            resources.ApplyResources(this.ChB_Genre, "ChB_Genre");
            this.ChB_Genre.Name = "ChB_Genre";
            this.ChB_Genre.UseVisualStyleBackColor = true;
            this.ChB_Genre.CheckedChanged += new System.EventHandler(this.ChB_Genre_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.DGV_All_Authors);
            this.groupBox2.Controls.Add(this.BT_Add_Author);
            this.groupBox2.Controls.Add(this.BT_Select_Author);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // Form_Art
            // 
            this.AcceptButton = this.button_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_Art";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Art_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_All_Authors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Selected_Authors)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        public TextBox tb_Name;
        private Button BT_Add_Langue_Original;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button BT_Add_Genre;
        private DataGridView DGV_All_Authors;
        private Button BT_Select_Author;
        private Button BT_Add_Author;
        public Button button_Cancel;
        public Button button_OK;
        public ComboBox CB_Langue;
        public TextBox TB_YearCreation;
        public ComboBox CB_Genre;
        public DataGridView DGV_Selected_Authors;
        private Button BT_Deselect_Author;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label5;
        public CheckBox ChB_Language;
        public CheckBox ChB_Genre;
    }
}