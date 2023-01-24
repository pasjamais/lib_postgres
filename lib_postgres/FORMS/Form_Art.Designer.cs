﻿namespace lib_postgres
{
    partial class Form_Art
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.BT_Add_Langue_Original = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Langue = new System.Windows.Forms.ComboBox();
            this.TB_YearCreation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Genre = new System.Windows.Forms.ComboBox();
            this.BT_Add_Genre = new System.Windows.Forms.Button();
            this.DGV_All_Authors = new System.Windows.Forms.DataGridView();
            this.DGV_Selected_Authors = new System.Windows.Forms.DataGridView();
            this.BT_Select_Author = new System.Windows.Forms.Button();
            this.BT_Add_Author = new System.Windows.Forms.Button();
            this.BT_Deselect_Author = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_All_Authors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Selected_Authors)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название:";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(158, 23);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(383, 27);
            this.tb_Name.TabIndex = 5;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(112, 402);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(94, 29);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(12, 402);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(94, 29);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // BT_Add_Langue_Original
            // 
            this.BT_Add_Langue_Original.Location = new System.Drawing.Point(315, 129);
            this.BT_Add_Langue_Original.Name = "BT_Add_Langue_Original";
            this.BT_Add_Langue_Original.Size = new System.Drawing.Size(30, 29);
            this.BT_Add_Langue_Original.TabIndex = 43;
            this.BT_Add_Langue_Original.Text = "+";
            this.BT_Add_Langue_Original.UseVisualStyleBackColor = true;
            this.BT_Add_Langue_Original.Click += new System.EventHandler(this.BT_Add_Langue_Original_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Язык написания";
            // 
            // CB_Langue
            // 
            this.CB_Langue.FormattingEnabled = true;
            this.CB_Langue.Location = new System.Drawing.Point(158, 129);
            this.CB_Langue.Name = "CB_Langue";
            this.CB_Langue.Size = new System.Drawing.Size(151, 28);
            this.CB_Langue.TabIndex = 41;
            // 
            // TB_YearCreation
            // 
            this.TB_YearCreation.Location = new System.Drawing.Point(158, 95);
            this.TB_YearCreation.Name = "TB_YearCreation";
            this.TB_YearCreation.Size = new System.Drawing.Size(85, 27);
            this.TB_YearCreation.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Год написания";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Жанр";
            // 
            // CB_Genre
            // 
            this.CB_Genre.FormattingEnabled = true;
            this.CB_Genre.Location = new System.Drawing.Point(158, 60);
            this.CB_Genre.Name = "CB_Genre";
            this.CB_Genre.Size = new System.Drawing.Size(289, 28);
            this.CB_Genre.TabIndex = 35;
            // 
            // BT_Add_Genre
            // 
            this.BT_Add_Genre.Location = new System.Drawing.Point(453, 59);
            this.BT_Add_Genre.Name = "BT_Add_Genre";
            this.BT_Add_Genre.Size = new System.Drawing.Size(30, 29);
            this.BT_Add_Genre.TabIndex = 44;
            this.BT_Add_Genre.Text = "+";
            this.BT_Add_Genre.UseVisualStyleBackColor = true;
            this.BT_Add_Genre.Click += new System.EventHandler(this.BT_Add_Genre_Click);
            // 
            // DGV_All_Authors
            // 
            this.DGV_All_Authors.AllowUserToAddRows = false;
            this.DGV_All_Authors.AllowUserToDeleteRows = false;
            this.DGV_All_Authors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_All_Authors.Location = new System.Drawing.Point(65, 23);
            this.DGV_All_Authors.MultiSelect = false;
            this.DGV_All_Authors.Name = "DGV_All_Authors";
            this.DGV_All_Authors.ReadOnly = true;
            this.DGV_All_Authors.RowHeadersWidth = 51;
            this.DGV_All_Authors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_All_Authors.Size = new System.Drawing.Size(277, 348);
            this.DGV_All_Authors.TabIndex = 45;
            // 
            // DGV_Selected_Authors
            // 
            this.DGV_Selected_Authors.AllowUserToAddRows = false;
            this.DGV_Selected_Authors.AllowUserToDeleteRows = false;
            this.DGV_Selected_Authors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Selected_Authors.Location = new System.Drawing.Point(158, 177);
            this.DGV_Selected_Authors.MultiSelect = false;
            this.DGV_Selected_Authors.Name = "DGV_Selected_Authors";
            this.DGV_Selected_Authors.ReadOnly = true;
            this.DGV_Selected_Authors.RowHeadersWidth = 51;
            this.DGV_Selected_Authors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Selected_Authors.Size = new System.Drawing.Size(277, 194);
            this.DGV_Selected_Authors.TabIndex = 46;
            // 
            // BT_Select_Author
            // 
            this.BT_Select_Author.Location = new System.Drawing.Point(17, 177);
            this.BT_Select_Author.Name = "BT_Select_Author";
            this.BT_Select_Author.Size = new System.Drawing.Size(30, 29);
            this.BT_Select_Author.TabIndex = 47;
            this.BT_Select_Author.Text = "<";
            this.BT_Select_Author.UseVisualStyleBackColor = true;
            this.BT_Select_Author.Click += new System.EventHandler(this.BT_Select_Author_Click);
            // 
            // BT_Add_Author
            // 
            this.BT_Add_Author.Location = new System.Drawing.Point(17, 26);
            this.BT_Add_Author.Name = "BT_Add_Author";
            this.BT_Add_Author.Size = new System.Drawing.Size(30, 29);
            this.BT_Add_Author.TabIndex = 48;
            this.BT_Add_Author.Text = "+";
            this.BT_Add_Author.UseVisualStyleBackColor = true;
            this.BT_Add_Author.Click += new System.EventHandler(this.BT_Add_Author_Click);
            // 
            // BT_Deselect_Author
            // 
            this.BT_Deselect_Author.Location = new System.Drawing.Point(453, 177);
            this.BT_Deselect_Author.Name = "BT_Deselect_Author";
            this.BT_Deselect_Author.Size = new System.Drawing.Size(30, 29);
            this.BT_Deselect_Author.TabIndex = 49;
            this.BT_Deselect_Author.Text = "-";
            this.BT_Deselect_Author.UseVisualStyleBackColor = true;
            this.BT_Deselect_Author.Click += new System.EventHandler(this.BT_Deselect_Author_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BT_Deselect_Author);
            this.groupBox1.Controls.Add(this.DGV_Selected_Authors);
            this.groupBox1.Controls.Add(this.tb_Name);
            this.groupBox1.Controls.Add(this.BT_Add_Genre);
            this.groupBox1.Controls.Add(this.CB_Genre);
            this.groupBox1.Controls.Add(this.BT_Add_Langue_Original);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CB_Langue);
            this.groupBox1.Controls.Add(this.TB_YearCreation);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 384);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Произведение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 50;
            this.label5.Text = "Авторы";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGV_All_Authors);
            this.groupBox2.Controls.Add(this.BT_Add_Author);
            this.groupBox2.Controls.Add(this.BT_Select_Author);
            this.groupBox2.Location = new System.Drawing.Point(575, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 384);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Все авторы";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Form_Art
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 436);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Art";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Произведение";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_All_Authors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Selected_Authors)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        public TextBox tb_Name;
        private Button BT_Add_Langue_Original;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button BT_Add_Genre;
        private DataGridView DGV_All_Authors;
        private Button BT_Select_Author;
        private Button BT_Add_Author;
        public Button button_Cancel;
        public Button button_OK;
        public ComboBox CB_Langue;
        public TextBox TB_YearCreation;
        public ComboBox CB_Genre;
        public DataGridView DGV_Selected_Authors;
        private Button BT_Deselect_Author;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label5;
    }
}