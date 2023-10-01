namespace lib_postgres.FORMS
{
    partial class Form_Recommendation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Recommendation));
            this.treeView = new System.Windows.Forms.TreeView();
            this.bt_show_art_sources = new System.Windows.Forms.Button();
            this.bt_show_authors_sources = new System.Windows.Forms.Button();
            this.bt_show_another_sources = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.panel_buttons = new System.Windows.Forms.Panel();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_buttons.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            resources.ApplyResources(this.treeView, "treeView");
            this.treeView.Name = "treeView";
            // 
            // bt_show_art_sources
            // 
            resources.ApplyResources(this.bt_show_art_sources, "bt_show_art_sources");
            this.bt_show_art_sources.Name = "bt_show_art_sources";
            this.bt_show_art_sources.UseVisualStyleBackColor = true;
            this.bt_show_art_sources.Click += new System.EventHandler(this.bt_show_art_sources_Click);
            // 
            // bt_show_authors_sources
            // 
            resources.ApplyResources(this.bt_show_authors_sources, "bt_show_authors_sources");
            this.bt_show_authors_sources.Name = "bt_show_authors_sources";
            this.bt_show_authors_sources.UseVisualStyleBackColor = true;
            this.bt_show_authors_sources.Click += new System.EventHandler(this.bt_show_authors_sources_Click);
            // 
            // bt_show_another_sources
            // 
            resources.ApplyResources(this.bt_show_another_sources, "bt_show_another_sources");
            this.bt_show_another_sources.Name = "bt_show_another_sources";
            this.bt_show_another_sources.UseVisualStyleBackColor = true;
            this.bt_show_another_sources.Click += new System.EventHandler(this.bt_show_another_sources_Click);
            // 
            // bt_cancel
            // 
            resources.ApplyResources(this.bt_cancel, "bt_cancel");
            this.bt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.UseVisualStyleBackColor = true;
            // 
            // panel_buttons
            // 
            this.panel_buttons.Controls.Add(this.bt_show_art_sources);
            this.panel_buttons.Controls.Add(this.bt_cancel);
            this.panel_buttons.Controls.Add(this.bt_show_authors_sources);
            this.panel_buttons.Controls.Add(this.bt_show_another_sources);
            resources.ApplyResources(this.panel_buttons, "panel_buttons");
            this.panel_buttons.Name = "panel_buttons";
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.treeView);
            resources.ApplyResources(this.panel_main, "panel_main");
            this.panel_main.Name = "panel_main";
            // 
            // Form_Recommendation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_cancel;
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_buttons);
            this.Name = "Form_Recommendation";
            this.ShowInTaskbar = false;
            this.panel_buttons.ResumeLayout(false);
            this.panel_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeView treeView;
        private Button bt_show_art_sources;
        private Button bt_show_authors_sources;
        private Button bt_show_another_sources;
        private Button bt_cancel;
        private Panel panel_buttons;
        private Panel panel_main;
    }
}