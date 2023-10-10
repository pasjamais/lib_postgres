using lib_postgres.VIEW.NOTICE;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Book));
            this.label17 = new System.Windows.Forms.Label();
            this.TB_Code = new System.Windows.Forms.TextBox();
            this.ChB_Series = new System.Windows.Forms.CheckBox();
            this.ChB_Language = new System.Windows.Forms.CheckBox();
            this.ChB_City = new System.Windows.Forms.CheckBox();
            this.ChB_Publishing_House = new System.Windows.Forms.CheckBox();
            this.Label_Art = new lib_postgres.VIEW.NOTICE.Label_Colorized();
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
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // TB_Code
            // 
            resources.ApplyResources(this.TB_Code, "TB_Code");
            this.TB_Code.Name = "TB_Code";
            // 
            // ChB_Series
            // 
            resources.ApplyResources(this.ChB_Series, "ChB_Series");
            this.ChB_Series.Name = "ChB_Series";
            this.ChB_Series.UseVisualStyleBackColor = true;
            this.ChB_Series.CheckedChanged += new System.EventHandler(this.ChB_Series_CheckedChanged);
            // 
            // ChB_Language
            // 
            resources.ApplyResources(this.ChB_Language, "ChB_Language");
            this.ChB_Language.Name = "ChB_Language";
            this.ChB_Language.UseVisualStyleBackColor = true;
            this.ChB_Language.CheckedChanged += new System.EventHandler(this.ChB_Language_CheckedChanged);
            // 
            // ChB_City
            // 
            resources.ApplyResources(this.ChB_City, "ChB_City");
            this.ChB_City.Name = "ChB_City";
            this.ChB_City.UseVisualStyleBackColor = true;
            this.ChB_City.CheckedChanged += new System.EventHandler(this.ChB_City_CheckedChanged);
            // 
            // ChB_Publishing_House
            // 
            resources.ApplyResources(this.ChB_Publishing_House, "ChB_Publishing_House");
            this.ChB_Publishing_House.Name = "ChB_Publishing_House";
            this.ChB_Publishing_House.UseVisualStyleBackColor = true;
            this.ChB_Publishing_House.CheckedChanged += new System.EventHandler(this.ChB_Publishing_House_CheckedChanged);
            // 
            // Label_Art
            // 
            resources.ApplyResources(this.Label_Art, "Label_Art");
            this.Label_Art.Name = "Label_Art";
            // 
            // CB_Art
            // 
            resources.ApplyResources(this.CB_Art, "CB_Art");
            this.CB_Art.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Art.FormattingEnabled = true;
            this.CB_Art.Name = "CB_Art";
            // 
            // BT_Add_PubHouse
            // 
            resources.ApplyResources(this.BT_Add_PubHouse, "BT_Add_PubHouse");
            this.BT_Add_PubHouse.Name = "BT_Add_PubHouse";
            this.BT_Add_PubHouse.UseVisualStyleBackColor = true;
            this.BT_Add_PubHouse.Click += new System.EventHandler(this.BT_Add_Maison_Click);
            // 
            // BT_Add_City
            // 
            resources.ApplyResources(this.BT_Add_City, "BT_Add_City");
            this.BT_Add_City.Name = "BT_Add_City";
            this.BT_Add_City.UseVisualStyleBackColor = true;
            this.BT_Add_City.Click += new System.EventHandler(this.BT_Add_City_Click);
            // 
            // BT_Add_Serie
            // 
            resources.ApplyResources(this.BT_Add_Serie, "BT_Add_Serie");
            this.BT_Add_Serie.Name = "BT_Add_Serie";
            this.BT_Add_Serie.UseVisualStyleBackColor = true;
            this.BT_Add_Serie.Click += new System.EventHandler(this.BT_Add_Serie_Click);
            // 
            // BT_Add_Langue_Book
            // 
            resources.ApplyResources(this.BT_Add_Langue_Book, "BT_Add_Langue_Book");
            this.BT_Add_Langue_Book.Name = "BT_Add_Langue_Book";
            this.BT_Add_Langue_Book.UseVisualStyleBackColor = true;
            this.BT_Add_Langue_Book.Click += new System.EventHandler(this.BT_Add_Langue_Book_Click);
            // 
            // CB_Book_Language
            // 
            resources.ApplyResources(this.CB_Book_Language, "CB_Book_Language");
            this.CB_Book_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Book_Language.FormattingEnabled = true;
            this.CB_Book_Language.Name = "CB_Book_Language";
            // 
            // CB_Series
            // 
            resources.ApplyResources(this.CB_Series, "CB_Series");
            this.CB_Series.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Series.FormattingEnabled = true;
            this.CB_Series.Name = "CB_Series";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
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
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // TB_Notes
            // 
            resources.ApplyResources(this.TB_Notes, "TB_Notes");
            this.TB_Notes.Name = "TB_Notes";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // TB_Family_Notes
            // 
            resources.ApplyResources(this.TB_Family_Notes, "TB_Family_Notes");
            this.TB_Family_Notes.Name = "TB_Family_Notes";
            // 
            // CB_Art_Book
            // 
            resources.ApplyResources(this.CB_Art_Book, "CB_Art_Book");
            this.CB_Art_Book.Name = "CB_Art_Book";
            this.CB_Art_Book.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // TB_Pages
            // 
            resources.ApplyResources(this.TB_Pages, "TB_Pages");
            this.TB_Pages.Name = "TB_Pages";
            this.TB_Pages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress_Check);
            // 
            // CB_City
            // 
            resources.ApplyResources(this.CB_City, "CB_City");
            this.CB_City.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_City.FormattingEnabled = true;
            this.CB_City.Name = "CB_City";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // CB_Publishing_House
            // 
            resources.ApplyResources(this.CB_Publishing_House, "CB_Publishing_House");
            this.CB_Publishing_House.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Publishing_House.FormattingEnabled = true;
            this.CB_Publishing_House.Name = "CB_Publishing_House";
            // 
            // TB_Publication_Year
            // 
            resources.ApplyResources(this.TB_Publication_Year, "TB_Publication_Year");
            this.TB_Publication_Year.Name = "TB_Publication_Year";
            this.TB_Publication_Year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress_Check);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // CB_Jacket
            // 
            resources.ApplyResources(this.CB_Jacket, "CB_Jacket");
            this.CB_Jacket.Name = "CB_Jacket";
            this.CB_Jacket.UseVisualStyleBackColor = true;
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
            // BT_Add_Art
            // 
            resources.ApplyResources(this.BT_Add_Art, "BT_Add_Art");
            this.BT_Add_Art.Name = "BT_Add_Art";
            this.BT_Add_Art.UseVisualStyleBackColor = true;
            this.BT_Add_Art.Click += new System.EventHandler(this.BT_Add_Art_Click);
            // 
            // Form_Book
            // 
            this.AcceptButton = this.button_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.Controls.Add(this.BT_Add_Art);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.TB_Code);
            this.Controls.Add(this.ChB_Series);
            this.Controls.Add(this.ChB_Language);
            this.Controls.Add(this.ChB_City);
            this.Controls.Add(this.ChB_Publishing_House);
            this.Controls.Add(this.Label_Art);
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
            this.MaximizeBox = false;
            this.Name = "Form_Book";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Book_FormClosing);
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
        public Label_Colorized Label_Art;
    }
}