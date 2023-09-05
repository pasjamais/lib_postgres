namespace lib_postgres.FORMS
{
    partial class Form_Art_To_Read
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
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Comment = new System.Windows.Forms.TextBox();
            this.Label_Comment = new System.Windows.Forms.Label();
            this.groupBox_Source = new System.Windows.Forms.GroupBox();
            this.RB_Source_Another = new System.Windows.Forms.RadioButton();
            this.RB_Source_Author = new System.Windows.Forms.RadioButton();
            this.RB_Source_Art = new System.Windows.Forms.RadioButton();
            this.BT__Another_Source_Add = new System.Windows.Forms.Button();
            this.Label_Source_Another = new System.Windows.Forms.Label();
            this.CB_Source_Another = new System.Windows.Forms.ComboBox();
            this.Label_Source_Author = new System.Windows.Forms.Label();
            this.CB_Source_Author = new System.Windows.Forms.ComboBox();
            this.Label_Source_Art = new System.Windows.Forms.Label();
            this.CB_Source_Art = new System.Windows.Forms.ComboBox();
            this.groupBox_ToRead = new System.Windows.Forms.GroupBox();
            this.RB_Toread_Author = new System.Windows.Forms.RadioButton();
            this.RB_Toread_Art = new System.Windows.Forms.RadioButton();
            this.BT__Toread_Author = new System.Windows.Forms.Button();
            this.BT_Add_Art = new System.Windows.Forms.Button();
            this.Label_Toread_Author = new System.Windows.Forms.Label();
            this.CB_Toread_Author = new System.Windows.Forms.ComboBox();
            this.Label_Toread_Art = new System.Windows.Forms.Label();
            this.CB_Toread_Art = new System.Windows.Forms.ComboBox();
            this.groupBox_Source.SuspendLayout();
            this.groupBox_ToRead.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(12, 513);
            this.button_OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(82, 22);
            this.button_OK.TabIndex = 86;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(632, 513);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(82, 22);
            this.button_Cancel.TabIndex = 87;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(245, 17);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(176, 23);
            this.dateTimePicker.TabIndex = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 91;
            this.label2.Text = "Дата рекомендации:";
            // 
            // TB_Comment
            // 
            this.TB_Comment.Location = new System.Drawing.Point(223, 129);
            this.TB_Comment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Comment.Multiline = true;
            this.TB_Comment.Name = "TB_Comment";
            this.TB_Comment.Size = new System.Drawing.Size(399, 173);
            this.TB_Comment.TabIndex = 92;
            // 
            // Label_Comment
            // 
            this.Label_Comment.AutoSize = true;
            this.Label_Comment.Location = new System.Drawing.Point(120, 132);
            this.Label_Comment.Name = "Label_Comment";
            this.Label_Comment.Size = new System.Drawing.Size(91, 15);
            this.Label_Comment.TabIndex = 93;
            this.Label_Comment.Text = "Комментарий:";
            // 
            // groupBox_Source
            // 
            this.groupBox_Source.Controls.Add(this.RB_Source_Another);
            this.groupBox_Source.Controls.Add(this.RB_Source_Author);
            this.groupBox_Source.Controls.Add(this.RB_Source_Art);
            this.groupBox_Source.Controls.Add(this.BT__Another_Source_Add);
            this.groupBox_Source.Controls.Add(this.Label_Source_Another);
            this.groupBox_Source.Controls.Add(this.CB_Source_Another);
            this.groupBox_Source.Controls.Add(this.Label_Source_Author);
            this.groupBox_Source.Controls.Add(this.Label_Comment);
            this.groupBox_Source.Controls.Add(this.CB_Source_Author);
            this.groupBox_Source.Controls.Add(this.TB_Comment);
            this.groupBox_Source.Controls.Add(this.Label_Source_Art);
            this.groupBox_Source.Controls.Add(this.CB_Source_Art);
            this.groupBox_Source.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox_Source.Location = new System.Drawing.Point(22, 201);
            this.groupBox_Source.Name = "groupBox_Source";
            this.groupBox_Source.Size = new System.Drawing.Size(679, 307);
            this.groupBox_Source.TabIndex = 94;
            this.groupBox_Source.TabStop = false;
            this.groupBox_Source.Text = "Источник рекомендации:";
            // 
            // RB_Source_Another
            // 
            this.RB_Source_Another.AutoSize = true;
            this.RB_Source_Another.Location = new System.Drawing.Point(47, 94);
            this.RB_Source_Another.Name = "RB_Source_Another";
            this.RB_Source_Another.Size = new System.Drawing.Size(14, 13);
            this.RB_Source_Another.TabIndex = 108;
            this.RB_Source_Another.TabStop = true;
            this.RB_Source_Another.Tag = "SourceToreadAnother";
            this.RB_Source_Another.UseVisualStyleBackColor = true;
            this.RB_Source_Another.CheckedChanged += new System.EventHandler(this.radioButton_Source_CheckedChanged);
            // 
            // RB_Source_Author
            // 
            this.RB_Source_Author.AutoSize = true;
            this.RB_Source_Author.Location = new System.Drawing.Point(47, 57);
            this.RB_Source_Author.Name = "RB_Source_Author";
            this.RB_Source_Author.Size = new System.Drawing.Size(14, 13);
            this.RB_Source_Author.TabIndex = 107;
            this.RB_Source_Author.TabStop = true;
            this.RB_Source_Author.Tag = "Author";
            this.RB_Source_Author.UseVisualStyleBackColor = true;
            this.RB_Source_Author.CheckedChanged += new System.EventHandler(this.radioButton_Source_CheckedChanged);
            // 
            // RB_Source_Art
            // 
            this.RB_Source_Art.AutoSize = true;
            this.RB_Source_Art.Location = new System.Drawing.Point(47, 25);
            this.RB_Source_Art.Name = "RB_Source_Art";
            this.RB_Source_Art.Size = new System.Drawing.Size(14, 13);
            this.RB_Source_Art.TabIndex = 106;
            this.RB_Source_Art.TabStop = true;
            this.RB_Source_Art.Tag = "Art";
            this.RB_Source_Art.UseVisualStyleBackColor = true;
            this.RB_Source_Art.CheckedChanged += new System.EventHandler(this.radioButton_Source_CheckedChanged);
            // 
            // BT__Another_Source_Add
            // 
            this.BT__Another_Source_Add.Location = new System.Drawing.Point(639, 89);
            this.BT__Another_Source_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT__Another_Source_Add.Name = "BT__Another_Source_Add";
            this.BT__Another_Source_Add.Size = new System.Drawing.Size(23, 23);
            this.BT__Another_Source_Add.TabIndex = 105;
            this.BT__Another_Source_Add.Text = "+";
            this.BT__Another_Source_Add.UseVisualStyleBackColor = true;
            this.BT__Another_Source_Add.Click += new System.EventHandler(this.BT__Another_Source_Add_Click);
            // 
            // Label_Source_Another
            // 
            this.Label_Source_Another.AutoSize = true;
            this.Label_Source_Another.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label_Source_Another.Location = new System.Drawing.Point(112, 92);
            this.Label_Source_Another.Name = "Label_Source_Another";
            this.Label_Source_Another.Size = new System.Drawing.Size(105, 15);
            this.Label_Source_Another.TabIndex = 94;
            this.Label_Source_Another.Text = "Другой источник:";
            // 
            // CB_Source_Another
            // 
            this.CB_Source_Another.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Source_Another.FormattingEnabled = true;
            this.CB_Source_Another.Location = new System.Drawing.Point(223, 89);
            this.CB_Source_Another.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Source_Another.Name = "CB_Source_Another";
            this.CB_Source_Another.Size = new System.Drawing.Size(399, 23);
            this.CB_Source_Another.TabIndex = 93;
            // 
            // Label_Source_Author
            // 
            this.Label_Source_Author.AutoSize = true;
            this.Label_Source_Author.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label_Source_Author.Location = new System.Drawing.Point(173, 56);
            this.Label_Source_Author.Name = "Label_Source_Author";
            this.Label_Source_Author.Size = new System.Drawing.Size(44, 15);
            this.Label_Source_Author.TabIndex = 92;
            this.Label_Source_Author.Text = "Автор:";
            // 
            // CB_Source_Author
            // 
            this.CB_Source_Author.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Source_Author.FormattingEnabled = true;
            this.CB_Source_Author.Location = new System.Drawing.Point(223, 53);
            this.CB_Source_Author.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Source_Author.Name = "CB_Source_Author";
            this.CB_Source_Author.Size = new System.Drawing.Size(399, 23);
            this.CB_Source_Author.TabIndex = 91;
            // 
            // Label_Source_Art
            // 
            this.Label_Source_Art.AutoSize = true;
            this.Label_Source_Art.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label_Source_Art.Location = new System.Drawing.Point(120, 25);
            this.Label_Source_Art.Name = "Label_Source_Art";
            this.Label_Source_Art.Size = new System.Drawing.Size(97, 15);
            this.Label_Source_Art.TabIndex = 90;
            this.Label_Source_Art.Text = "Произведение:";
            // 
            // CB_Source_Art
            // 
            this.CB_Source_Art.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Source_Art.FormattingEnabled = true;
            this.CB_Source_Art.Location = new System.Drawing.Point(223, 21);
            this.CB_Source_Art.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Source_Art.Name = "CB_Source_Art";
            this.CB_Source_Art.Size = new System.Drawing.Size(399, 23);
            this.CB_Source_Art.TabIndex = 89;
            // 
            // groupBox_ToRead
            // 
            this.groupBox_ToRead.Controls.Add(this.RB_Toread_Author);
            this.groupBox_ToRead.Controls.Add(this.RB_Toread_Art);
            this.groupBox_ToRead.Controls.Add(this.BT__Toread_Author);
            this.groupBox_ToRead.Controls.Add(this.BT_Add_Art);
            this.groupBox_ToRead.Controls.Add(this.Label_Toread_Author);
            this.groupBox_ToRead.Controls.Add(this.CB_Toread_Author);
            this.groupBox_ToRead.Controls.Add(this.Label_Toread_Art);
            this.groupBox_ToRead.Controls.Add(this.CB_Toread_Art);
            this.groupBox_ToRead.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox_ToRead.Location = new System.Drawing.Point(22, 61);
            this.groupBox_ToRead.Name = "groupBox_ToRead";
            this.groupBox_ToRead.Size = new System.Drawing.Size(679, 116);
            this.groupBox_ToRead.TabIndex = 97;
            this.groupBox_ToRead.TabStop = false;
            this.groupBox_ToRead.Text = "Рекомендация (к прочтению):";
            // 
            // RB_Toread_Author
            // 
            this.RB_Toread_Author.AutoSize = true;
            this.RB_Toread_Author.Location = new System.Drawing.Point(47, 72);
            this.RB_Toread_Author.Name = "RB_Toread_Author";
            this.RB_Toread_Author.Size = new System.Drawing.Size(14, 13);
            this.RB_Toread_Author.TabIndex = 105;
            this.RB_Toread_Author.TabStop = true;
            this.RB_Toread_Author.UseVisualStyleBackColor = true;
            this.RB_Toread_Author.CheckedChanged += new System.EventHandler(this.radioButton_ToRead_CheckedChanged);
            // 
            // RB_Toread_Art
            // 
            this.RB_Toread_Art.AutoSize = true;
            this.RB_Toread_Art.Location = new System.Drawing.Point(47, 29);
            this.RB_Toread_Art.Name = "RB_Toread_Art";
            this.RB_Toread_Art.Size = new System.Drawing.Size(14, 13);
            this.RB_Toread_Art.TabIndex = 98;
            this.RB_Toread_Art.TabStop = true;
            this.RB_Toread_Art.Tag = "";
            this.RB_Toread_Art.UseVisualStyleBackColor = true;
            this.RB_Toread_Art.CheckedChanged += new System.EventHandler(this.radioButton_ToRead_CheckedChanged);
            // 
            // BT__Toread_Author
            // 
            this.BT__Toread_Author.Location = new System.Drawing.Point(639, 67);
            this.BT__Toread_Author.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT__Toread_Author.Name = "BT__Toread_Author";
            this.BT__Toread_Author.Size = new System.Drawing.Size(23, 23);
            this.BT__Toread_Author.TabIndex = 104;
            this.BT__Toread_Author.Text = "+";
            this.BT__Toread_Author.UseVisualStyleBackColor = true;
            this.BT__Toread_Author.Click += new System.EventHandler(this.BT__Toread_Author_Click);
            // 
            // BT_Add_Art
            // 
            this.BT_Add_Art.Location = new System.Drawing.Point(639, 29);
            this.BT_Add_Art.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT_Add_Art.Name = "BT_Add_Art";
            this.BT_Add_Art.Size = new System.Drawing.Size(23, 23);
            this.BT_Add_Art.TabIndex = 103;
            this.BT_Add_Art.Text = "+";
            this.BT_Add_Art.UseVisualStyleBackColor = true;
            this.BT_Add_Art.Click += new System.EventHandler(this.BT_Add_Art_Click);
            // 
            // Label_Toread_Author
            // 
            this.Label_Toread_Author.AutoSize = true;
            this.Label_Toread_Author.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label_Toread_Author.Location = new System.Drawing.Point(173, 71);
            this.Label_Toread_Author.Name = "Label_Toread_Author";
            this.Label_Toread_Author.Size = new System.Drawing.Size(44, 15);
            this.Label_Toread_Author.TabIndex = 100;
            this.Label_Toread_Author.Text = "Автор:";
            // 
            // CB_Toread_Author
            // 
            this.CB_Toread_Author.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Toread_Author.FormattingEnabled = true;
            this.CB_Toread_Author.Location = new System.Drawing.Point(223, 68);
            this.CB_Toread_Author.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Toread_Author.Name = "CB_Toread_Author";
            this.CB_Toread_Author.Size = new System.Drawing.Size(399, 23);
            this.CB_Toread_Author.TabIndex = 99;
            // 
            // Label_Toread_Art
            // 
            this.Label_Toread_Art.AutoSize = true;
            this.Label_Toread_Art.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label_Toread_Art.Location = new System.Drawing.Point(120, 30);
            this.Label_Toread_Art.Name = "Label_Toread_Art";
            this.Label_Toread_Art.Size = new System.Drawing.Size(97, 15);
            this.Label_Toread_Art.TabIndex = 98;
            this.Label_Toread_Art.Text = "Произведение:";
            // 
            // CB_Toread_Art
            // 
            this.CB_Toread_Art.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Toread_Art.FormattingEnabled = true;
            this.CB_Toread_Art.Location = new System.Drawing.Point(223, 30);
            this.CB_Toread_Art.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Toread_Art.Name = "CB_Toread_Art";
            this.CB_Toread_Art.Size = new System.Drawing.Size(399, 23);
            this.CB_Toread_Art.TabIndex = 97;
            // 
            // Form_Art_To_Read
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(726, 559);
            this.Controls.Add(this.groupBox_ToRead);
            this.Controls.Add(this.groupBox_Source);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_Art_To_Read";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Рекомендация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Art_To_Read_FormClosing);
            this.groupBox_Source.ResumeLayout(false);
            this.groupBox_Source.PerformLayout();
            this.groupBox_ToRead.ResumeLayout(false);
            this.groupBox_ToRead.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_OK;
        private Button button_Cancel;
        public DateTimePicker dateTimePicker;
        public Label label2;
        public TextBox TB_Comment;
        public Label Label_Comment;
        private GroupBox groupBox_Source;
        public Label Label_Source_Author;
        public ComboBox CB_Source_Author;
        public Label Label_Source_Art;
        public ComboBox CB_Source_Art;
        public Label Label_Source_Another;
        public ComboBox CB_Source_Another;
        private GroupBox groupBox_ToRead;
        public Label Label_Toread_Author;
        public ComboBox CB_Toread_Author;
        public Label Label_Toread_Art;
        public ComboBox CB_Toread_Art;
        public Button BT_Add_Art;
        public Button BT__Toread_Author;
        public Button BT__Another_Source_Add;
        public RadioButton RB_Toread_Author;
        public RadioButton RB_Toread_Art;
        public RadioButton RB_Source_Another;
        public RadioButton RB_Source_Author;
        public RadioButton RB_Source_Art;
    }
}