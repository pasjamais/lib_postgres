namespace lib_postgres.FORMS
{
    partial class Form_Action
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Action));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Del_Book_from_Action = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CB_Action_Type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Place = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TB_Comment = new System.Windows.Forms.TextBox();
            this.DGV_ActionBooks = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button_New_Book = new System.Windows.Forms.Button();
            this.button_Add_Book_to_Action = new System.Windows.Forms.Button();
            this.DGV_AllBooks = new System.Windows.Forms.DataGridView();
            this.button_OK = new System.Windows.Forms.Button();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ActionBooks)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AllBooks)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button_Del_Book_from_Action);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Controls.Add(this.CB_Action_Type);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CB_Place);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.TB_Comment);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // button_Del_Book_from_Action
            // 
            resources.ApplyResources(this.button_Del_Book_from_Action, "button_Del_Book_from_Action");
            this.button_Del_Book_from_Action.Name = "button_Del_Book_from_Action";
            this.button_Del_Book_from_Action.UseVisualStyleBackColor = true;
            this.button_Del_Book_from_Action.Click += new System.EventHandler(this.button_Del_Book_from_Action_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // dateTimePicker
            // 
            resources.ApplyResources(this.dateTimePicker, "dateTimePicker");
            this.dateTimePicker.Name = "dateTimePicker";
            // 
            // CB_Action_Type
            // 
            this.CB_Action_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Action_Type.FormattingEnabled = true;
            resources.ApplyResources(this.CB_Action_Type, "CB_Action_Type");
            this.CB_Action_Type.Name = "CB_Action_Type";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CB_Place
            // 
            this.CB_Place.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Place.FormattingEnabled = true;
            resources.ApplyResources(this.CB_Place, "CB_Place");
            this.CB_Place.Name = "CB_Place";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // TB_Comment
            // 
            resources.ApplyResources(this.TB_Comment, "TB_Comment");
            this.TB_Comment.Name = "TB_Comment";
            // 
            // DGV_ActionBooks
            // 
            this.DGV_ActionBooks.AllowUserToAddRows = false;
            this.DGV_ActionBooks.AllowUserToDeleteRows = false;
            this.DGV_ActionBooks.AllowUserToResizeRows = false;
            this.DGV_ActionBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_ActionBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.DGV_ActionBooks, "DGV_ActionBooks");
            this.DGV_ActionBooks.MultiSelect = false;
            this.DGV_ActionBooks.Name = "DGV_ActionBooks";
            this.DGV_ActionBooks.ReadOnly = true;
            this.DGV_ActionBooks.RowHeadersVisible = false;
            this.DGV_ActionBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_ActionBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_ActionBooks_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGV_ActionBooks);
            this.groupBox1.Controls.Add(this.panel1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.DGV_AllBooks);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.button_New_Book);
            this.panel3.Controls.Add(this.button_Add_Book_to_Action);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // button_New_Book
            // 
            resources.ApplyResources(this.button_New_Book, "button_New_Book");
            this.button_New_Book.Name = "button_New_Book";
            this.button_New_Book.UseVisualStyleBackColor = true;
            this.button_New_Book.Click += new System.EventHandler(this.button_New_Book_Click);
            // 
            // button_Add_Book_to_Action
            // 
            resources.ApplyResources(this.button_Add_Book_to_Action, "button_Add_Book_to_Action");
            this.button_Add_Book_to_Action.Name = "button_Add_Book_to_Action";
            this.button_Add_Book_to_Action.UseVisualStyleBackColor = true;
            this.button_Add_Book_to_Action.Click += new System.EventHandler(this.button_Add_Book_to_Action_Click);
            // 
            // DGV_AllBooks
            // 
            this.DGV_AllBooks.AllowUserToAddRows = false;
            this.DGV_AllBooks.AllowUserToDeleteRows = false;
            this.DGV_AllBooks.AllowUserToResizeRows = false;
            this.DGV_AllBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_AllBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.DGV_AllBooks, "DGV_AllBooks");
            this.DGV_AllBooks.MultiSelect = false;
            this.DGV_AllBooks.Name = "DGV_AllBooks";
            this.DGV_AllBooks.ReadOnly = true;
            this.DGV_AllBooks.RowHeadersVisible = false;
            this.DGV_AllBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_AllBooks.DoubleClick += new System.EventHandler(this.DGV_AllBooks_DoubleClick);
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.button_OK, "button_OK");
            this.button_OK.Name = "button_OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Controls.Add(this.button_Cancel);
            this.panel_Bottom.Controls.Add(this.button_OK);
            resources.ApplyResources(this.panel_Bottom, "panel_Bottom");
            this.panel_Bottom.Name = "panel_Bottom";
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.button_Cancel, "button_Cancel");
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // Form_Action
            // 
            this.AcceptButton = this.button_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel_Bottom);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_Action";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Action_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ActionBooks)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AllBooks)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        public DataGridView DGV_ActionBooks;
        public Label label13;
        public TextBox TB_Comment;
        public Label label2;
        public ComboBox CB_Action_Type;
        public Label label1;
        public ComboBox CB_Place;
        public Label label6;
        private Button button_Del_Book_from_Action;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel panel3;
        private Button button_New_Book;
        private Button button_Add_Book_to_Action;
        public DataGridView DGV_AllBooks;
        private Button button_OK;
        private Panel panel_Bottom;
        private Button button_Cancel;
        public DateTimePicker dateTimePicker;
        public Label label3;
        public Label label4;
    }
}