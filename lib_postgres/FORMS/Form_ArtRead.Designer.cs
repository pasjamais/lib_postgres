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
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(382, 387);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(82, 22);
            this.button_Cancel.TabIndex = 84;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(12, 387);
            this.button_OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(82, 22);
            this.button_OK.TabIndex = 85;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(38, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 15);
            this.label16.TabIndex = 87;
            this.label16.Text = "Произведение:";
            // 
            // CB_Art
            // 
            this.CB_Art.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Art.FormattingEnabled = true;
            this.CB_Art.Location = new System.Drawing.Point(141, 46);
            this.CB_Art.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Art.Name = "CB_Art";
            this.CB_Art.Size = new System.Drawing.Size(296, 23);
            this.CB_Art.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 90;
            this.label2.Text = "Дата прочтения:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(141, 11);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(199, 23);
            this.dateTimePicker.TabIndex = 89;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(51, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 15);
            this.label13.TabIndex = 92;
            this.label13.Text = "Комментарий:";
            // 
            // TB_Comment
            // 
            this.TB_Comment.Location = new System.Drawing.Point(141, 224);
            this.TB_Comment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Comment.Name = "TB_Comment";
            this.TB_Comment.Size = new System.Drawing.Size(296, 23);
            this.TB_Comment.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(30, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 94;
            this.label1.Text = "Бумажная книга:";
            // 
            // CB_Mark
            // 
            this.CB_Mark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Mark.FormattingEnabled = true;
            this.CB_Mark.Location = new System.Drawing.Point(141, 194);
            this.CB_Mark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Mark.Name = "CB_Mark";
            this.CB_Mark.Size = new System.Drawing.Size(199, 23);
            this.CB_Mark.TabIndex = 96;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(87, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 15);
            this.label9.TabIndex = 95;
            this.label9.Text = "Оценка:";
            // 
            // CB_BookFormat
            // 
            this.CB_BookFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_BookFormat.FormattingEnabled = true;
            this.CB_BookFormat.Location = new System.Drawing.Point(141, 82);
            this.CB_BookFormat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_BookFormat.Name = "CB_BookFormat";
            this.CB_BookFormat.Size = new System.Drawing.Size(199, 23);
            this.CB_BookFormat.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 97;
            this.label3.Text = "Формат:";
            // 
            // Form_ArtRead
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(476, 420);
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
    }
}