namespace lib_postgres.FORMS
{
    partial class Form_ArtRead
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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.CB_Art = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.TB_Comment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Mark = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CB_BookFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_PaperBook = new System.Windows.Forms.ComboBox();
            this.ChB_PaperBook = new System.Windows.Forms.CheckBox();
            this.CB_Langue = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(437, 516);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(94, 29);
            this.button_Cancel.TabIndex = 84;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(14, 516);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(94, 29);
            this.button_OK.TabIndex = 85;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(35, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 20);
            this.label16.TabIndex = 87;
            this.label16.Text = "Произведение:";
            // 
            // CB_Art
            // 
            this.CB_Art.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Art.FormattingEnabled = true;
            this.CB_Art.Location = new System.Drawing.Point(161, 61);
            this.CB_Art.Name = "CB_Art";
            this.CB_Art.Size = new System.Drawing.Size(338, 28);
            this.CB_Art.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 90;
            this.label2.Text = "Дата прочтения:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(161, 15);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(227, 27);
            this.dateTimePicker.TabIndex = 89;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(43, 372);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 92;
            this.label13.Text = "Комментарий:";
            // 
            // TB_Comment
            // 
            this.TB_Comment.Location = new System.Drawing.Point(161, 369);
            this.TB_Comment.Name = "TB_Comment";
            this.TB_Comment.Size = new System.Drawing.Size(338, 27);
            this.TB_Comment.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 94;
            this.label1.Text = "Бумажная книга:";
            // 
            // CB_Mark
            // 
            this.CB_Mark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Mark.FormattingEnabled = true;
            this.CB_Mark.Location = new System.Drawing.Point(161, 329);
            this.CB_Mark.Name = "CB_Mark";
            this.CB_Mark.Size = new System.Drawing.Size(227, 28);
            this.CB_Mark.TabIndex = 96;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(99, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 95;
            this.label9.Text = "Оценка:";
            // 
            // CB_BookFormat
            // 
            this.CB_BookFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_BookFormat.FormattingEnabled = true;
            this.CB_BookFormat.Location = new System.Drawing.Point(161, 166);
            this.CB_BookFormat.Name = "CB_BookFormat";
            this.CB_BookFormat.Size = new System.Drawing.Size(227, 28);
            this.CB_BookFormat.TabIndex = 98;
            this.CB_BookFormat.SelectionChangeCommitted += new System.EventHandler(this.CB_BookFormat_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 97;
            this.label3.Text = "Формат:";
            // 
            // CB_PaperBook
            // 
            this.CB_PaperBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PaperBook.FormattingEnabled = true;
            this.CB_PaperBook.Location = new System.Drawing.Point(14, 259);
            this.CB_PaperBook.Name = "CB_PaperBook";
            this.CB_PaperBook.Size = new System.Drawing.Size(518, 28);
            this.CB_PaperBook.TabIndex = 99;
            // 
            // ChB_PaperBook
            // 
            this.ChB_PaperBook.AutoSize = true;
            this.ChB_PaperBook.Enabled = false;
            this.ChB_PaperBook.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChB_PaperBook.Location = new System.Drawing.Point(161, 237);
            this.ChB_PaperBook.Name = "ChB_PaperBook";
            this.ChB_PaperBook.Size = new System.Drawing.Size(31, 16);
            this.ChB_PaperBook.TabIndex = 100;
            this.ChB_PaperBook.UseVisualStyleBackColor = true;
            this.ChB_PaperBook.CheckedChanged += new System.EventHandler(this.ChB_PaperBook_CheckedChanged);
            this.ChB_PaperBook.CheckStateChanged += new System.EventHandler(this.ChB_PaperBook_CheckStateChanged);
            // 
            // CB_Langue
            // 
            this.CB_Langue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Langue.FormattingEnabled = true;
            this.CB_Langue.Location = new System.Drawing.Point(161, 132);
            this.CB_Langue.Name = "CB_Langue";
            this.CB_Langue.Size = new System.Drawing.Size(227, 28);
            this.CB_Langue.TabIndex = 101;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 102;
            this.label4.Text = "Язык прочтения:";
            // 
            // Form_ArtRead
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(544, 560);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CB_Langue);
            this.Controls.Add(this.ChB_PaperBook);
            this.Controls.Add(this.CB_PaperBook);
            this.Controls.Add(this.CB_BookFormat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CB_Mark);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TB_Comment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.CB_Art);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form_ArtRead";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление книги в прочитанные";
            this.Load += new System.EventHandler(this.Form_ArtRead_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_Cancel;
        private Button button_OK;
        public Label label16;
        public ComboBox CB_Art;
        public Label label2;
        public DateTimePicker dateTimePicker;
        public Label label13;
        public TextBox TB_Comment;
        public Label label1;
        public ComboBox CB_Mark;
        public Label label9;
        public ComboBox CB_BookFormat;
        public Label label3;
        public ComboBox CB_PaperBook;
        public CheckBox ChB_PaperBook;
        public ComboBox CB_Langue;
        public Label label4;
    }
}