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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Del_Book_from_Action = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CB_Action_Type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Place = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TB_Comment = new System.Windows.Forms.TextBox();
            this.DGV_AcrtionBooks = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_New_Book = new System.Windows.Forms.Button();
            this.button_Add_Book_to_Action = new System.Windows.Forms.Button();
            this.DGV_AllBooks = new System.Windows.Forms.DataGridView();
            this.button_OK = new System.Windows.Forms.Button();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AcrtionBooks)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AllBooks)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Del_Book_from_Action);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Controls.Add(this.CB_Action_Type);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CB_Place);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.TB_Comment);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1498, 165);
            this.panel1.TabIndex = 0;
            // 
            // button_Del_Book_from_Action
            // 
            this.button_Del_Book_from_Action.Location = new System.Drawing.Point(826, 123);
            this.button_Del_Book_from_Action.Name = "button_Del_Book_from_Action";
            this.button_Del_Book_from_Action.Size = new System.Drawing.Size(94, 29);
            this.button_Del_Book_from_Action.TabIndex = 73;
            this.button_Del_Book_from_Action.Text = "button1";
            this.button_Del_Book_from_Action.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 70;
            this.label2.Text = "Дата";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(131, 19);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(227, 27);
            this.dateTimePicker.TabIndex = 69;
            // 
            // CB_Action_Type
            // 
            this.CB_Action_Type.FormattingEnabled = true;
            this.CB_Action_Type.Location = new System.Drawing.Point(131, 86);
            this.CB_Action_Type.Name = "CB_Action_Type";
            this.CB_Action_Type.Size = new System.Drawing.Size(678, 28);
            this.CB_Action_Type.TabIndex = 67;
            this.CB_Action_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "Действие";
            // 
            // CB_Place
            // 
            this.CB_Place.FormattingEnabled = true;
            this.CB_Place.Location = new System.Drawing.Point(131, 52);
            this.CB_Place.Name = "CB_Place";
            this.CB_Place.Size = new System.Drawing.Size(678, 28);
            this.CB_Place.TabIndex = 65;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 66;
            this.label6.Text = "Место";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 20);
            this.label13.TabIndex = 64;
            this.label13.Text = "Комментарий";
            // 
            // TB_Comment
            // 
            this.TB_Comment.Location = new System.Drawing.Point(131, 123);
            this.TB_Comment.Name = "TB_Comment";
            this.TB_Comment.Size = new System.Drawing.Size(678, 27);
            this.TB_Comment.TabIndex = 63;
            // 
            // DGV_AcrtionBooks
            // 
            this.DGV_AcrtionBooks.AllowUserToAddRows = false;
            this.DGV_AcrtionBooks.AllowUserToDeleteRows = false;
            this.DGV_AcrtionBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_AcrtionBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_AcrtionBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_AcrtionBooks.Location = new System.Drawing.Point(3, 188);
            this.DGV_AcrtionBooks.MultiSelect = false;
            this.DGV_AcrtionBooks.Name = "DGV_AcrtionBooks";
            this.DGV_AcrtionBooks.ReadOnly = true;
            this.DGV_AcrtionBooks.RowHeadersWidth = 51;
            this.DGV_AcrtionBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_AcrtionBooks.Size = new System.Drawing.Size(1498, 164);
            this.DGV_AcrtionBooks.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGV_AcrtionBooks);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1504, 355);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действие";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.DGV_AllBooks);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 355);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1504, 359);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Все книги";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button_New_Book);
            this.panel3.Controls.Add(this.button_Add_Book_to_Action);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1498, 39);
            this.panel3.TabIndex = 3;
            // 
            // button_New_Book
            // 
            this.button_New_Book.Location = new System.Drawing.Point(9, 8);
            this.button_New_Book.Name = "button_New_Book";
            this.button_New_Book.Size = new System.Drawing.Size(94, 29);
            this.button_New_Book.TabIndex = 75;
            this.button_New_Book.Text = "Добавить...";
            this.button_New_Book.UseVisualStyleBackColor = true;
            this.button_New_Book.Click += new System.EventHandler(this.button_New_Book_Click);
            // 
            // button_Add_Book_to_Action
            // 
            this.button_Add_Book_to_Action.Location = new System.Drawing.Point(113, 8);
            this.button_Add_Book_to_Action.Name = "button_Add_Book_to_Action";
            this.button_Add_Book_to_Action.Size = new System.Drawing.Size(41, 29);
            this.button_Add_Book_to_Action.TabIndex = 74;
            this.button_Add_Book_to_Action.Text = "^";
            this.button_Add_Book_to_Action.UseVisualStyleBackColor = true;
            this.button_Add_Book_to_Action.Click += new System.EventHandler(this.button_Add_Book_to_Action_Click);
            // 
            // DGV_AllBooks
            // 
            this.DGV_AllBooks.AllowUserToAddRows = false;
            this.DGV_AllBooks.AllowUserToDeleteRows = false;
            this.DGV_AllBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_AllBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_AllBooks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGV_AllBooks.Location = new System.Drawing.Point(3, 68);
            this.DGV_AllBooks.MultiSelect = false;
            this.DGV_AllBooks.Name = "DGV_AllBooks";
            this.DGV_AllBooks.ReadOnly = true;
            this.DGV_AllBooks.RowHeadersWidth = 51;
            this.DGV_AllBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_AllBooks.Size = new System.Drawing.Size(1498, 288);
            this.DGV_AllBooks.TabIndex = 0;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(12, 6);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(94, 29);
            this.button_OK.TabIndex = 74;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Controls.Add(this.button_Cancel);
            this.panel_Bottom.Controls.Add(this.button_OK);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 714);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(1504, 47);
            this.panel_Bottom.TabIndex = 75;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(116, 6);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(94, 29);
            this.button_Cancel.TabIndex = 75;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Form_Action
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(1504, 761);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel_Bottom);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form_Action";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Action";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AcrtionBooks)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AllBooks)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        public DataGridView DGV_AcrtionBooks;
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
    }
}