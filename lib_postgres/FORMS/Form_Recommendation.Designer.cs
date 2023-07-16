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
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(604, 691);
            this.treeView.TabIndex = 0;
            // 
            // bt_show_art_sources
            // 
            this.bt_show_art_sources.Location = new System.Drawing.Point(19, 17);
            this.bt_show_art_sources.Name = "bt_show_art_sources";
            this.bt_show_art_sources.Size = new System.Drawing.Size(75, 23);
            this.bt_show_art_sources.TabIndex = 1;
            this.bt_show_art_sources.Text = "из книг";
            this.bt_show_art_sources.UseVisualStyleBackColor = true;
            this.bt_show_art_sources.Click += new System.EventHandler(this.bt_show_art_sources_Click);
            // 
            // bt_show_authors_sources
            // 
            this.bt_show_authors_sources.Location = new System.Drawing.Point(19, 46);
            this.bt_show_authors_sources.Name = "bt_show_authors_sources";
            this.bt_show_authors_sources.Size = new System.Drawing.Size(75, 23);
            this.bt_show_authors_sources.TabIndex = 2;
            this.bt_show_authors_sources.Text = "от авторов";
            this.bt_show_authors_sources.UseVisualStyleBackColor = true;
            this.bt_show_authors_sources.Click += new System.EventHandler(this.bt_show_authors_sources_Click);
            // 
            // bt_show_another_sources
            // 
            this.bt_show_another_sources.Location = new System.Drawing.Point(19, 75);
            this.bt_show_another_sources.Name = "bt_show_another_sources";
            this.bt_show_another_sources.Size = new System.Drawing.Size(75, 23);
            this.bt_show_another_sources.TabIndex = 3;
            this.bt_show_another_sources.Text = "от других";
            this.bt_show_another_sources.UseVisualStyleBackColor = true;
            this.bt_show_another_sources.Click += new System.EventHandler(this.bt_show_another_sources_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_cancel.Location = new System.Drawing.Point(19, 656);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 4;
            this.bt_cancel.Text = "Закрыть";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // panel_buttons
            // 
            this.panel_buttons.Controls.Add(this.bt_show_art_sources);
            this.panel_buttons.Controls.Add(this.bt_cancel);
            this.panel_buttons.Controls.Add(this.bt_show_authors_sources);
            this.panel_buttons.Controls.Add(this.bt_show_another_sources);
            this.panel_buttons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_buttons.Location = new System.Drawing.Point(604, 0);
            this.panel_buttons.Name = "panel_buttons";
            this.panel_buttons.Size = new System.Drawing.Size(110, 691);
            this.panel_buttons.TabIndex = 5;
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.treeView);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(604, 691);
            this.panel_main.TabIndex = 6;
            // 
            // Form_Recommendation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_cancel;
            this.ClientSize = new System.Drawing.Size(714, 691);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_buttons);
            this.MinimumSize = new System.Drawing.Size(730, 730);
            this.Name = "Form_Recommendation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рекомендации к чтению";
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