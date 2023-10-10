using lib_postgres.VIEW.NOTICE;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ArtRead));
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.Label_Art = new lib_postgres.VIEW.NOTICE.Label_Colorized();
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
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.CB_Art.SelectionChangeCommitted += new System.EventHandler(this.CB_Art_SelectionChangeCommitted);
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CB_Mark
            // 
            resources.ApplyResources(this.CB_Mark, "CB_Mark");
            this.CB_Mark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Mark.FormattingEnabled = true;
            this.CB_Mark.Name = "CB_Mark";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // CB_BookFormat
            // 
            resources.ApplyResources(this.CB_BookFormat, "CB_BookFormat");
            this.CB_BookFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_BookFormat.FormattingEnabled = true;
            this.CB_BookFormat.Name = "CB_BookFormat";
            this.CB_BookFormat.SelectionChangeCommitted += new System.EventHandler(this.CB_BookFormat_SelectionChangeCommitted);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // CB_PaperBook
            // 
            resources.ApplyResources(this.CB_PaperBook, "CB_PaperBook");
            this.CB_PaperBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PaperBook.FormattingEnabled = true;
            this.CB_PaperBook.Name = "CB_PaperBook";
            // 
            // ChB_PaperBook
            // 
            resources.ApplyResources(this.ChB_PaperBook, "ChB_PaperBook");
            this.ChB_PaperBook.Name = "ChB_PaperBook";
            this.ChB_PaperBook.UseVisualStyleBackColor = true;
            this.ChB_PaperBook.CheckedChanged += new System.EventHandler(this.ChB_PaperBook_CheckedChanged);
            this.ChB_PaperBook.CheckStateChanged += new System.EventHandler(this.ChB_PaperBook_CheckStateChanged);
            // 
            // CB_Langue
            // 
            resources.ApplyResources(this.CB_Langue, "CB_Langue");
            this.CB_Langue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Langue.FormattingEnabled = true;
            this.CB_Langue.Name = "CB_Langue";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // Form_ArtRead
            // 
            this.AcceptButton = this.button_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.Controls.Add(this.label5);
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
            this.Controls.Add(this.Label_Art);
            this.Controls.Add(this.CB_Art);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_ArtRead";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ArtRead_FormClosing);
            this.Load += new System.EventHandler(this.Form_ArtRead_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_Cancel;
        private Button button_OK;
        public Label_Colorized Label_Art;
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
        public Label label5;
    }
}