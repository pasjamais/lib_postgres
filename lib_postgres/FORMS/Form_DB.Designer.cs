namespace lib_postgres.FORMS
{
    partial class Form_DB
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
            this.openFileDialog_BD_Backup = new System.Windows.Forms.OpenFileDialog();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LL_Load_Empty_BD = new System.Windows.Forms.LinkLabel();
            this.LL_Load_Existing_BD = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_OK.Location = new System.Drawing.Point(12, 138);
            this.button_OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(82, 22);
            this.button_OK.TabIndex = 5;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Visible = false;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_Cancel.Location = new System.Drawing.Point(400, 138);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(82, 22);
            this.button_Cancel.TabIndex = 6;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Можно создать новую базу или загрузить существующую.";
            // 
            // LL_Load_Empty_BD
            // 
            this.LL_Load_Empty_BD.AutoSize = true;
            this.LL_Load_Empty_BD.Location = new System.Drawing.Point(12, 55);
            this.LL_Load_Empty_BD.Name = "LL_Load_Empty_BD";
            this.LL_Load_Empty_BD.Size = new System.Drawing.Size(159, 15);
            this.LL_Load_Empty_BD.TabIndex = 87;
            this.LL_Load_Empty_BD.TabStop = true;
            this.LL_Load_Empty_BD.Text = "Cоздать новую пустую базу";
            this.LL_Load_Empty_BD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Load_Empty_BD_LinkClicked);
            // 
            // LL_Load_Existing_BD
            // 
            this.LL_Load_Existing_BD.AutoSize = true;
            this.LL_Load_Existing_BD.Location = new System.Drawing.Point(12, 84);
            this.LL_Load_Existing_BD.Name = "LL_Load_Existing_BD";
            this.LL_Load_Existing_BD.Size = new System.Drawing.Size(266, 15);
            this.LL_Load_Existing_BD.TabIndex = 88;
            this.LL_Load_Existing_BD.TabStop = true;
            this.LL_Load_Existing_BD.Text = "Загрузить существующую из резервной копии";
            this.LL_Load_Existing_BD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Load_Existing_BD_LinkClicked);
            // 
            // Form_DB
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(510, 176);
            this.Controls.Add(this.LL_Load_Existing_BD);
            this.Controls.Add(this.LL_Load_Empty_BD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_DB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных не обнаружена";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog_BD_Backup;
        private Button button_OK;
        private Button button_Cancel;
        private LinkLabel LL_Load_Empty_BD;
        private LinkLabel LL_Load_Existing_BD;
        protected internal Label label1;
    }
}