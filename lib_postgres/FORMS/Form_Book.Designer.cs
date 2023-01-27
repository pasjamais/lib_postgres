namespace lib_postgres
{
    partial class Form_Book
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
            this.label17 = new System.Windows.Forms.Label();
            this.TB_Code = new System.Windows.Forms.TextBox();
            this.ChB_Series = new System.Windows.Forms.CheckBox();
            this.ChB_Language = new System.Windows.Forms.CheckBox();
            this.ChB_City = new System.Windows.Forms.CheckBox();
            this.ChB_Publishing_House = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.CB_Art = new System.Windows.Forms.ComboBox();
            this.BT_Add_PubHouse = new System.Windows.Forms.Button();
            this.BT_Add_City = new System.Windows.Forms.Button();
            this.BT_Add_Serie = new System.Windows.Forms.Button();
            this.BT_Add_Langue_Book = new System.Windows.Forms.Button();
            this.CB_Book_Language = new System.Windows.Forms.ComboBox();
            this.CB_Series = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TB_Comment = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TB_Notes = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TB_Family_Notes = new System.Windows.Forms.TextBox();
            this.CB_Art_Book = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TB_Pages = new System.Windows.Forms.TextBox();
            this.CB_City = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_Publishing_House = new System.Windows.Forms.ComboBox();
            this.TB_Publication_Year = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_Jacket = new System.Windows.Forms.CheckBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.BT_Add_Art = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(304, 332);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 15);
            this.label17.TabIndex = 81;
            this.label17.Text = "Шифр";
            // 
            // TB_Code
            // 
            this.TB_Code.Location = new System.Drawing.Point(351, 329);
            this.TB_Code.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Code.Name = "TB_Code";
            this.TB_Code.Size = new System.Drawing.Size(89, 23);
            this.TB_Code.TabIndex = 80;
            // 
            // ChB_Series
            // 
            this.ChB_Series.AutoSize = true;
            this.ChB_Series.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChB_Series.Location = new System.Drawing.Point(26, 98);
            this.ChB_Series.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChB_Series.Name = "ChB_Series";
            this.ChB_Series.Size = new System.Drawing.Size(25, 13);
            this.ChB_Series.TabIndex = 79;
            this.ChB_Series.UseVisualStyleBackColor = true;
            this.ChB_Series.CheckedChanged += new System.EventHandler(this.ChB_Series_CheckedChanged);
            // 
            // ChB_Language
            // 
            this.ChB_Language.AutoSize = true;
            this.ChB_Language.Checked = true;
            this.ChB_Language.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChB_Language.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChB_Language.Location = new System.Drawing.Point(26, 127);
            this.ChB_Language.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChB_Language.Name = "ChB_Language";
            this.ChB_Language.Size = new System.Drawing.Size(25, 13);
            this.ChB_Language.TabIndex = 76;
            this.ChB_Language.UseVisualStyleBackColor = true;
            this.ChB_Language.CheckedChanged += new System.EventHandler(this.ChB_Language_CheckedChanged);
            // 
            // ChB_City
            // 
            this.ChB_City.AutoSize = true;
            this.ChB_City.Checked = true;
            this.ChB_City.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChB_City.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChB_City.Location = new System.Drawing.Point(26, 70);
            this.ChB_City.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChB_City.Name = "ChB_City";
            this.ChB_City.Size = new System.Drawing.Size(25, 13);
            this.ChB_City.TabIndex = 74;
            this.ChB_City.UseVisualStyleBackColor = true;
            this.ChB_City.CheckedChanged += new System.EventHandler(this.ChB_City_CheckedChanged);
            // 
            // ChB_Publishing_House
            // 
            this.ChB_Publishing_House.AutoSize = true;
            this.ChB_Publishing_House.Checked = true;
            this.ChB_Publishing_House.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChB_Publishing_House.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChB_Publishing_House.Location = new System.Drawing.Point(26, 42);
            this.ChB_Publishing_House.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChB_Publishing_House.Name = "ChB_Publishing_House";
            this.ChB_Publishing_House.Size = new System.Drawing.Size(25, 13);
            this.ChB_Publishing_House.TabIndex = 73;
            this.ChB_Publishing_House.UseVisualStyleBackColor = true;
            this.ChB_Publishing_House.CheckedChanged += new System.EventHandler(this.ChB_Publishing_House_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(41, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 15);
            this.label16.TabIndex = 72;
            this.label16.Text = "Произведение:";
            // 
            // CB_Art
            // 
            this.CB_Art.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Art.FormattingEnabled = true;
            this.CB_Art.Location = new System.Drawing.Point(144, 7);
            this.CB_Art.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Art.Name = "CB_Art";
            this.CB_Art.Size = new System.Drawing.Size(296, 23);
            this.CB_Art.TabIndex = 71;
            // 
            // BT_Add_PubHouse
            // 
            this.BT_Add_PubHouse.Location = new System.Drawing.Point(446, 34);
            this.BT_Add_PubHouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT_Add_PubHouse.Name = "BT_Add_PubHouse";
            this.BT_Add_PubHouse.Size = new System.Drawing.Size(23, 23);
            this.BT_Add_PubHouse.TabIndex = 70;
            this.BT_Add_PubHouse.Text = "+";
            this.BT_Add_PubHouse.UseVisualStyleBackColor = true;
            this.BT_Add_PubHouse.Click += new System.EventHandler(this.BT_Add_Maison_Click);
            // 
            // BT_Add_City
            // 
            this.BT_Add_City.Location = new System.Drawing.Point(446, 63);
            this.BT_Add_City.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT_Add_City.Name = "BT_Add_City";
            this.BT_Add_City.Size = new System.Drawing.Size(23, 23);
            this.BT_Add_City.TabIndex = 69;
            this.BT_Add_City.Text = "+";
            this.BT_Add_City.UseVisualStyleBackColor = true;
            this.BT_Add_City.Click += new System.EventHandler(this.BT_Add_City_Click);
            // 
            // BT_Add_Serie
            // 
            this.BT_Add_Serie.Location = new System.Drawing.Point(446, 92);
            this.BT_Add_Serie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT_Add_Serie.Name = "BT_Add_Serie";
            this.BT_Add_Serie.Size = new System.Drawing.Size(23, 23);
            this.BT_Add_Serie.TabIndex = 68;
            this.BT_Add_Serie.Text = "+";
            this.BT_Add_Serie.UseVisualStyleBackColor = true;
            this.BT_Add_Serie.Click += new System.EventHandler(this.BT_Add_Serie_Click);
            // 
            // BT_Add_Langue_Book
            // 
            this.BT_Add_Langue_Book.Location = new System.Drawing.Point(446, 122);
            this.BT_Add_Langue_Book.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT_Add_Langue_Book.Name = "BT_Add_Langue_Book";
            this.BT_Add_Langue_Book.Size = new System.Drawing.Size(23, 23);
            this.BT_Add_Langue_Book.TabIndex = 67;
            this.BT_Add_Langue_Book.Text = "+";
            this.BT_Add_Langue_Book.UseVisualStyleBackColor = true;
            this.BT_Add_Langue_Book.Click += new System.EventHandler(this.BT_Add_Langue_Book_Click);
            // 
            // CB_Book_Language
            // 
            this.CB_Book_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Book_Language.FormattingEnabled = true;
            this.CB_Book_Language.Location = new System.Drawing.Point(144, 122);
            this.CB_Book_Language.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Book_Language.Name = "CB_Book_Language";
            this.CB_Book_Language.Size = new System.Drawing.Size(296, 23);
            this.CB_Book_Language.TabIndex = 46;
            // 
            // CB_Series
            // 
            this.CB_Series.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Series.Enabled = false;
            this.CB_Series.FormattingEnabled = true;
            this.CB_Series.Location = new System.Drawing.Point(144, 92);
            this.CB_Series.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Series.Name = "CB_Series";
            this.CB_Series.Size = new System.Drawing.Size(296, 23);
            this.CB_Series.TabIndex = 66;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(97, 95);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 15);
            this.label15.TabIndex = 65;
            this.label15.Text = "Серия";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(54, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 15);
            this.label13.TabIndex = 62;
            this.label13.Text = "Комментарий";
            // 
            // TB_Comment
            // 
            this.TB_Comment.Location = new System.Drawing.Point(144, 219);
            this.TB_Comment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Comment.Name = "TB_Comment";
            this.TB_Comment.Size = new System.Drawing.Size(296, 23);
            this.TB_Comment.TabIndex = 61;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(84, 275);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 15);
            this.label12.TabIndex = 60;
            this.label12.Text = "Отметки";
            // 
            // TB_Notes
            // 
            this.TB_Notes.Location = new System.Drawing.Point(144, 272);
            this.TB_Notes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Notes.Name = "TB_Notes";
            this.TB_Notes.Size = new System.Drawing.Size(296, 23);
            this.TB_Notes.TabIndex = 59;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 15);
            this.label11.TabIndex = 58;
            this.label11.Text = "Семейные пометки";
            // 
            // TB_Family_Notes
            // 
            this.TB_Family_Notes.Location = new System.Drawing.Point(144, 245);
            this.TB_Family_Notes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Family_Notes.Name = "TB_Family_Notes";
            this.TB_Family_Notes.Size = new System.Drawing.Size(296, 23);
            this.TB_Family_Notes.TabIndex = 57;
            // 
            // CB_Art_Book
            // 
            this.CB_Art_Book.AutoSize = true;
            this.CB_Art_Book.Location = new System.Drawing.Point(268, 177);
            this.CB_Art_Book.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Art_Book.Name = "CB_Art_Book";
            this.CB_Art_Book.Size = new System.Drawing.Size(80, 19);
            this.CB_Art_Book.TabIndex = 56;
            this.CB_Art_Book.Text = "Beau Livre";
            this.CB_Art_Book.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 15);
            this.label10.TabIndex = 55;
            this.label10.Text = "Страниц";
            // 
            // TB_Pages
            // 
            this.TB_Pages.Location = new System.Drawing.Point(349, 150);
            this.TB_Pages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Pages.Name = "TB_Pages";
            this.TB_Pages.Size = new System.Drawing.Size(91, 23);
            this.TB_Pages.TabIndex = 54;
            // 
            // CB_City
            // 
            this.CB_City.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_City.FormattingEnabled = true;
            this.CB_City.Location = new System.Drawing.Point(144, 63);
            this.CB_City.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_City.Name = "CB_City";
            this.CB_City.Size = new System.Drawing.Size(296, 23);
            this.CB_City.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(98, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 15);
            this.label9.TabIndex = 52;
            this.label9.Text = "Город";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 51;
            this.label8.Text = "Издательство";
            // 
            // CB_Publishing_House
            // 
            this.CB_Publishing_House.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Publishing_House.FormattingEnabled = true;
            this.CB_Publishing_House.Location = new System.Drawing.Point(144, 35);
            this.CB_Publishing_House.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Publishing_House.Name = "CB_Publishing_House";
            this.CB_Publishing_House.Size = new System.Drawing.Size(296, 23);
            this.CB_Publishing_House.TabIndex = 50;
            // 
            // TB_Publication_Year
            // 
            this.TB_Publication_Year.Location = new System.Drawing.Point(144, 150);
            this.TB_Publication_Year.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Publication_Year.Name = "TB_Publication_Year";
            this.TB_Publication_Year.Size = new System.Drawing.Size(91, 23);
            this.TB_Publication_Year.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 48;
            this.label7.Text = "Год издания";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 47;
            this.label6.Text = "Язык издания";
            // 
            // CB_Jacket
            // 
            this.CB_Jacket.AutoSize = true;
            this.CB_Jacket.Location = new System.Drawing.Point(144, 177);
            this.CB_Jacket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Jacket.Name = "CB_Jacket";
            this.CB_Jacket.Size = new System.Drawing.Size(109, 19);
            this.CB_Jacket.TabIndex = 45;
            this.CB_Jacket.Text = "Суперобложка";
            this.CB_Jacket.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(369, 383);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(82, 22);
            this.button_Cancel.TabIndex = 82;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(12, 383);
            this.button_OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(82, 22);
            this.button_OK.TabIndex = 83;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // BT_Add_Art
            // 
            this.BT_Add_Art.Location = new System.Drawing.Point(446, 7);
            this.BT_Add_Art.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT_Add_Art.Name = "BT_Add_Art";
            this.BT_Add_Art.Size = new System.Drawing.Size(23, 23);
            this.BT_Add_Art.TabIndex = 84;
            this.BT_Add_Art.Text = "+";
            this.BT_Add_Art.UseVisualStyleBackColor = true;
            this.BT_Add_Art.Click += new System.EventHandler(this.BT_Add_Art_Click);
            // 
            // Form_Book
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(476, 420);
            this.Controls.Add(this.BT_Add_Art);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.TB_Code);
            this.Controls.Add(this.ChB_Series);
            this.Controls.Add(this.ChB_Language);
            this.Controls.Add(this.ChB_City);
            this.Controls.Add(this.ChB_Publishing_House);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.CB_Art);
            this.Controls.Add(this.BT_Add_PubHouse);
            this.Controls.Add(this.BT_Add_City);
            this.Controls.Add(this.BT_Add_Serie);
            this.Controls.Add(this.BT_Add_Langue_Book);
            this.Controls.Add(this.CB_Book_Language);
            this.Controls.Add(this.CB_Series);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TB_Comment);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TB_Notes);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TB_Family_Notes);
            this.Controls.Add(this.CB_Art_Book);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TB_Pages);
            this.Controls.Add(this.CB_City);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CB_Publishing_House);
            this.Controls.Add(this.TB_Publication_Year);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CB_Jacket);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form_Book";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Книга";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button_Cancel;
        private Button button_OK;
        public Label label17;
        public TextBox TB_Code;
        public CheckBox ChB_Series;
        public CheckBox ChB_Language;
        public CheckBox ChB_City;
        public CheckBox ChB_Publishing_House;
        public Label label16;
        public ComboBox CB_Art;
        public Button BT_Add_PubHouse;
        public Button BT_Add_City;
        public Button BT_Add_Serie;
        public Button BT_Add_Langue_Book;
        public ComboBox CB_Book_Language;
        public ComboBox CB_Series;
        public Label label15;
        public Label label13;
        public TextBox TB_Comment;
        public Label label12;
        public TextBox TB_Notes;
        public Label label11;
        public TextBox TB_Family_Notes;
        public CheckBox CB_Art_Book;
        public Label label10;
        public TextBox TB_Pages;
        public ComboBox CB_City;
        public Label label9;
        public Label label8;
        public ComboBox CB_Publishing_House;
        public TextBox TB_Publication_Year;
        public Label label7;
        public Label label6;
        public CheckBox CB_Jacket;
        public Button BT_Add_Art;
    }
}