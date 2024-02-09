using lib_postgres.VIEW.NOTICE;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Art_To_Read));
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Comment = new System.Windows.Forms.TextBox();
            this.Label_Comment = new System.Windows.Forms.Label();
            this.groupBox_Source = new System.Windows.Forms.GroupBox();
            this.BT__Toread_Author_Source = new System.Windows.Forms.Button();
            this.BT_Add_Art_Source = new System.Windows.Forms.Button();
            this.RB_Source_Another = new VIEW.NOTICE.RadioButton_Colorized();
            this.RB_Source_Author = new VIEW.NOTICE.RadioButton_Colorized();
            this.RB_Source_Art = new VIEW.NOTICE.RadioButton_Colorized();
            this.BT__Another_Source_Add = new System.Windows.Forms.Button();
            this.Label_Source_Another = new System.Windows.Forms.Label();
            this.CB_Source_Another = new System.Windows.Forms.ComboBox();
            this.Label_Source_Author = new System.Windows.Forms.Label();
            this.CB_Source_Author = new System.Windows.Forms.ComboBox();
            this.Label_Source_Art = new System.Windows.Forms.Label();
            this.CB_Source_Art = new System.Windows.Forms.ComboBox();
            this.groupBox_ToRead = new System.Windows.Forms.GroupBox();
            this.RB_Toread_Author = new VIEW.NOTICE.RadioButton_Colorized();
            this.RB_Toread_Art = new VIEW.NOTICE.RadioButton_Colorized();
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
            resources.ApplyResources(this.button_OK, "button_OK");
            this.button_OK.Name = "button_OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.button_Cancel, "button_Cancel");
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // dateTimePicker
            // 
            resources.ApplyResources(this.dateTimePicker, "dateTimePicker");
            this.dateTimePicker.Name = "dateTimePicker";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TB_Comment
            // 
            resources.ApplyResources(this.TB_Comment, "TB_Comment");
            this.TB_Comment.Name = "TB_Comment";
            // 
            // Label_Comment
            // 
            resources.ApplyResources(this.Label_Comment, "Label_Comment");
            this.Label_Comment.Name = "Label_Comment";
            // 
            // groupBox_Source
            // 
            this.groupBox_Source.Controls.Add(this.BT__Toread_Author_Source);
            this.groupBox_Source.Controls.Add(this.BT_Add_Art_Source);
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
            resources.ApplyResources(this.groupBox_Source, "groupBox_Source");
            this.groupBox_Source.Name = "groupBox_Source";
            this.groupBox_Source.TabStop = false;
            // 
            // BT__Toread_Author_Source
            // 
            resources.ApplyResources(this.BT__Toread_Author_Source, "BT__Toread_Author_Source");
            this.BT__Toread_Author_Source.Name = "BT__Toread_Author_Source";
            this.BT__Toread_Author_Source.UseVisualStyleBackColor = true;
            this.BT__Toread_Author_Source.Click += new System.EventHandler(this.BT__Toread_Author_Source_Click);
            // 
            // BT_Add_Art_Source
            // 
            resources.ApplyResources(this.BT_Add_Art_Source, "BT_Add_Art_Source");
            this.BT_Add_Art_Source.Name = "BT_Add_Art_Source";
            this.BT_Add_Art_Source.Tag = "CB_Source_Art";
            this.BT_Add_Art_Source.UseVisualStyleBackColor = true;
            this.BT_Add_Art_Source.Click += new System.EventHandler(this.BT_Add_Art_Source_Click);
            // 
            // RB_Source_Another
            // 
            resources.ApplyResources(this.RB_Source_Another, "RB_Source_Another");
            this.RB_Source_Another.Name = "RB_Source_Another";
            this.RB_Source_Another.TabStop = true;
            this.RB_Source_Another.Tag = "SourceToreadAnother";
            this.RB_Source_Another.UseVisualStyleBackColor = true;
            this.RB_Source_Another.CheckedChanged += new System.EventHandler(this.radioButton_Source_CheckedChanged);
            // 
            // RB_Source_Author
            // 
            resources.ApplyResources(this.RB_Source_Author, "RB_Source_Author");
            this.RB_Source_Author.Name = "RB_Source_Author";
            this.RB_Source_Author.TabStop = true;
            this.RB_Source_Author.Tag = "Author";
            this.RB_Source_Author.UseVisualStyleBackColor = true;
            this.RB_Source_Author.CheckedChanged += new System.EventHandler(this.radioButton_Source_CheckedChanged);
            // 
            // RB_Source_Art
            // 
            resources.ApplyResources(this.RB_Source_Art, "RB_Source_Art");
            this.RB_Source_Art.Name = "RB_Source_Art";
            this.RB_Source_Art.TabStop = true;
            this.RB_Source_Art.Tag = "Art";
            this.RB_Source_Art.UseVisualStyleBackColor = true;
            this.RB_Source_Art.CheckedChanged += new System.EventHandler(this.radioButton_Source_CheckedChanged);
            // 
            // BT__Another_Source_Add
            // 
            resources.ApplyResources(this.BT__Another_Source_Add, "BT__Another_Source_Add");
            this.BT__Another_Source_Add.Name = "BT__Another_Source_Add";
            this.BT__Another_Source_Add.UseVisualStyleBackColor = true;
            this.BT__Another_Source_Add.Click += new System.EventHandler(this.BT__Another_Source_Add_Click);
            // 
            // Label_Source_Another
            // 
            resources.ApplyResources(this.Label_Source_Another, "Label_Source_Another");
            this.Label_Source_Another.Name = "Label_Source_Another";
            // 
            // CB_Source_Another
            // 
            this.CB_Source_Another.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Source_Another.FormattingEnabled = true;
            resources.ApplyResources(this.CB_Source_Another, "CB_Source_Another");
            this.CB_Source_Another.Name = "CB_Source_Another";
            this.CB_Source_Another.SelectionChangeCommitted += new System.EventHandler(this.CB_Source_Another_SelectionChangeCommitted);
            // 
            // Label_Source_Author
            // 
            resources.ApplyResources(this.Label_Source_Author, "Label_Source_Author");
            this.Label_Source_Author.Name = "Label_Source_Author";
            // 
            // CB_Source_Author
            // 
            this.CB_Source_Author.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Source_Author.FormattingEnabled = true;
            resources.ApplyResources(this.CB_Source_Author, "CB_Source_Author");
            this.CB_Source_Author.Name = "CB_Source_Author";
            this.CB_Source_Author.SelectionChangeCommitted += new System.EventHandler(this.CB_Source_Author_SelectionChangeCommitted);
            // 
            // Label_Source_Art
            // 
            resources.ApplyResources(this.Label_Source_Art, "Label_Source_Art");
            this.Label_Source_Art.Name = "Label_Source_Art";
            // 
            // CB_Source_Art
            // 
            this.CB_Source_Art.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Source_Art.FormattingEnabled = true;
            resources.ApplyResources(this.CB_Source_Art, "CB_Source_Art");
            this.CB_Source_Art.Name = "CB_Source_Art";
            this.CB_Source_Art.SelectionChangeCommitted += new System.EventHandler(this.CB_Source_Art_SelectionChangeCommitted);
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
            resources.ApplyResources(this.groupBox_ToRead, "groupBox_ToRead");
            this.groupBox_ToRead.Name = "groupBox_ToRead";
            this.groupBox_ToRead.TabStop = false;
            // 
            // RB_Toread_Author
            // 
            resources.ApplyResources(this.RB_Toread_Author, "RB_Toread_Author");
            this.RB_Toread_Author.Name = "RB_Toread_Author";
            this.RB_Toread_Author.TabStop = true;
            this.RB_Toread_Author.UseVisualStyleBackColor = true;
            this.RB_Toread_Author.CheckedChanged += new System.EventHandler(this.radioButton_ToRead_CheckedChanged);
            // 
            // RB_Toread_Art
            // 
            resources.ApplyResources(this.RB_Toread_Art, "RB_Toread_Art");
            this.RB_Toread_Art.Name = "RB_Toread_Art";
            this.RB_Toread_Art.TabStop = true;
            this.RB_Toread_Art.Tag = "";
            this.RB_Toread_Art.UseVisualStyleBackColor = true;
            this.RB_Toread_Art.CheckedChanged += new System.EventHandler(this.radioButton_ToRead_CheckedChanged);
            // 
            // BT__Toread_Author
            // 
            resources.ApplyResources(this.BT__Toread_Author, "BT__Toread_Author");
            this.BT__Toread_Author.Name = "BT__Toread_Author";
            this.BT__Toread_Author.UseVisualStyleBackColor = true;
            this.BT__Toread_Author.Click += new System.EventHandler(this.BT__Toread_Author_Click);
            // 
            // BT_Add_Art
            // 
            resources.ApplyResources(this.BT_Add_Art, "BT_Add_Art");
            this.BT_Add_Art.Name = "BT_Add_Art";
            this.BT_Add_Art.Tag = "CB_Toread_Art";
            this.BT_Add_Art.UseVisualStyleBackColor = true;
            this.BT_Add_Art.Click += new System.EventHandler(this.BT_Add_Art_Click);
            // 
            // Label_Toread_Author
            // 
            resources.ApplyResources(this.Label_Toread_Author, "Label_Toread_Author");
            this.Label_Toread_Author.Name = "Label_Toread_Author";
            // 
            // CB_Toread_Author
            // 
            this.CB_Toread_Author.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Toread_Author.FormattingEnabled = true;
            resources.ApplyResources(this.CB_Toread_Author, "CB_Toread_Author");
            this.CB_Toread_Author.Name = "CB_Toread_Author";
            this.CB_Toread_Author.SelectionChangeCommitted += new System.EventHandler(this.CB_Toread_Author_SelectionChangeCommitted);
            // 
            // Label_Toread_Art
            // 
            resources.ApplyResources(this.Label_Toread_Art, "Label_Toread_Art");
            this.Label_Toread_Art.Name = "Label_Toread_Art";
            // 
            // CB_Toread_Art
            // 
            this.CB_Toread_Art.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Toread_Art.FormattingEnabled = true;
            resources.ApplyResources(this.CB_Toread_Art, "CB_Toread_Art");
            this.CB_Toread_Art.Name = "CB_Toread_Art";
            this.CB_Toread_Art.SelectionChangeCommitted += new System.EventHandler(this.CB_Toread_Art_SelectionChangeCommitted);
            // 
            // Form_Art_To_Read
            // 
            this.AcceptButton = this.button_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.Controls.Add(this.groupBox_ToRead);
            this.Controls.Add(this.groupBox_Source);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_Art_To_Read";
            this.ShowInTaskbar = false;
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
        public RadioButton_Colorized RB_Toread_Author;
        public RadioButton_Colorized RB_Toread_Art;
        public RadioButton_Colorized RB_Source_Another;
        public RadioButton_Colorized RB_Source_Author;
        public RadioButton_Colorized RB_Source_Art;
        public Button BT_Add_Art_Source;
        public Button BT__Toread_Author_Source;
    }
}