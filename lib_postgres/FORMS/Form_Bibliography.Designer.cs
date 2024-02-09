namespace lib_postgres.FORMS
{
    partial class Form_Bibliography
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
            label2 = new Label();
            dateTimePicker = new DateTimePicker();
            label13 = new Label();
            TB_Comment = new TextBox();
            TB_Name = new TextBox();
            label1 = new Label();
            DGV_Bibliography = new DataGridView();
            button_OK = new Button();
            button_Cancel = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Bibliography).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(15, 14);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 72;
            label2.Text = "Date:";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(114, 9);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(227, 27);
            dateTimePicker.TabIndex = 71;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ImeMode = ImeMode.NoControl;
            label13.Location = new Point(15, 48);
            label13.Name = "label13";
            label13.Size = new Size(45, 20);
            label13.TabIndex = 74;
            label13.Text = "Note:";
            // 
            // TB_Comment
            // 
            TB_Comment.Location = new Point(114, 81);
            TB_Comment.Name = "TB_Comment";
            TB_Comment.Size = new Size(616, 27);
            TB_Comment.TabIndex = 73;
            // 
            // TB_Name
            // 
            TB_Name.Location = new Point(114, 48);
            TB_Name.Name = "TB_Name";
            TB_Name.Size = new Size(616, 27);
            TB_Name.TabIndex = 75;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(12, 84);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 76;
            label1.Text = "Comment:";
            // 
            // DGV_Bibliography
            // 
            DGV_Bibliography.AllowUserToAddRows = false;
            DGV_Bibliography.AllowUserToDeleteRows = false;
            DGV_Bibliography.AllowUserToResizeRows = false;
            DGV_Bibliography.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Bibliography.Location = new Point(15, 120);
            DGV_Bibliography.MultiSelect = false;
            DGV_Bibliography.Name = "DGV_Bibliography";
            DGV_Bibliography.ReadOnly = true;
            DGV_Bibliography.RowHeadersVisible = false;
            DGV_Bibliography.RowHeadersWidth = 51;
            DGV_Bibliography.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Bibliography.Size = new Size(715, 494);
            DGV_Bibliography.TabIndex = 77;
            // 
            // button_OK
            // 
            button_OK.DialogResult = DialogResult.OK;
            button_OK.ImeMode = ImeMode.NoControl;
            button_OK.Location = new Point(15, 620);
            button_OK.Name = "button_OK";
            button_OK.Size = new Size(94, 29);
            button_OK.TabIndex = 78;
            button_OK.Text = "OK";
            button_OK.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            button_Cancel.DialogResult = DialogResult.Cancel;
            button_Cancel.ImeMode = ImeMode.NoControl;
            button_Cancel.Location = new Point(636, 620);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(94, 29);
            button_Cancel.TabIndex = 79;
            button_Cancel.Text = "Cancel";
            button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Form_Bibliography
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 661);
            Controls.Add(button_Cancel);
            Controls.Add(button_OK);
            Controls.Add(DGV_Bibliography);
            Controls.Add(label1);
            Controls.Add(TB_Name);
            Controls.Add(label13);
            Controls.Add(TB_Comment);
            Controls.Add(label2);
            Controls.Add(dateTimePicker);
            Name = "Form_Bibliography";
            Text = "Form_Bibliography";
            ((System.ComponentModel.ISupportInitialize)DGV_Bibliography).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label label2;
        public DateTimePicker dateTimePicker;
        public Label label13;
        public TextBox TB_Comment;
        public TextBox TB_Name;
        public Label label1;
        public DataGridView DGV_Bibliography;
        private Button button_OK;
        private Button button_Cancel;
    }
}