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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this.ChB_Backup_on_Start = new System.Windows.Forms.CheckBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.ChB_Show_Deleted_Entities = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ChB_Backup_on_Start
            // 
            resources.ApplyResources(this.ChB_Backup_on_Start, "ChB_Backup_on_Start");
            this.ChB_Backup_on_Start.Name = "ChB_Backup_on_Start";
            this.ChB_Backup_on_Start.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            resources.ApplyResources(this.button_OK, "button_OK");
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Name = "button_OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            resources.ApplyResources(this.button_Cancel, "button_Cancel");
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // ChB_Show_Deleted_Entities
            // 
            resources.ApplyResources(this.ChB_Show_Deleted_Entities, "ChB_Show_Deleted_Entities");
            this.ChB_Show_Deleted_Entities.Name = "ChB_Show_Deleted_Entities";
            this.ChB_Show_Deleted_Entities.UseVisualStyleBackColor = true;
            // 
            // Form_Settings
            // 
            this.AcceptButton = this.button_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.Controls.Add(this.ChB_Show_Deleted_Entities);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.ChB_Backup_on_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_Settings";
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