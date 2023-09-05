namespace lib_postgres.FORMS
{
    partial class Form_Settings
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
            this.ChB_Backup_on_Start = new System.Windows.Forms.CheckBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.ChB_Show_Deleted_Entities = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ChB_Backup_on_Start
            // 
            this.ChB_Backup_on_Start.AutoSize = true;
            this.ChB_Backup_on_Start.Location = new System.Drawing.Point(12, 12);
            this.ChB_Backup_on_Start.Name = "ChB_Backup_on_Start";
            this.ChB_Backup_on_Start.Size = new System.Drawing.Size(150, 19);
            this.ChB_Backup_on_Start.TabIndex = 0;
            this.ChB_Backup_on_Start.Text = "Бэкап базы при старте";
            this.ChB_Backup_on_Start.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(12, 417);
            this.button_OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(82, 22);
            this.button_OK.TabIndex = 86;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(706, 417);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(82, 22);
            this.button_Cancel.TabIndex = 87;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // ChB_Show_Deleted_Entities
            // 
            this.ChB_Show_Deleted_Entities.AutoSize = true;
            this.ChB_Show_Deleted_Entities.Location = new System.Drawing.Point(12, 37);
            this.ChB_Show_Deleted_Entities.Name = "ChB_Show_Deleted_Entities";
            this.ChB_Show_Deleted_Entities.Size = new System.Drawing.Size(212, 19);
            this.ChB_Show_Deleted_Entities.TabIndex = 88;
            this.ChB_Show_Deleted_Entities.Text = "Показывать удалённые сущности";
            this.ChB_Show_Deleted_Entities.UseVisualStyleBackColor = true;
            // 
            // Form_Settings
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChB_Show_Deleted_Entities);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.ChB_Backup_on_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button_OK;
        private Button button_Cancel;
        public CheckBox ChB_Backup_on_Start;
        public CheckBox ChB_Show_Deleted_Entities;
    }
}