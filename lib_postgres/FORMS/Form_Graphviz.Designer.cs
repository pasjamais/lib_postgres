namespace lib_postgres.FORMS
{
    partial class Form_Graphviz
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
            this.panel_opt_bottom = new System.Windows.Forms.Panel();
            this.BT_Show = new System.Windows.Forms.Button();
            this.BT_Cancel = new System.Windows.Forms.Button();
            this.panel_opt_top = new System.Windows.Forms.Panel();
            this.label_preset = new System.Windows.Forms.Label();
            this.CB_Preset = new System.Windows.Forms.ComboBox();
            this.panel_DGV_opt = new System.Windows.Forms.Panel();
            this.DGV_Graph_Options = new System.Windows.Forms.DataGridView();
            this.RelatedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_browser = new System.Windows.Forms.Panel();
            this.panel_opt_bottom.SuspendLayout();
            this.panel_opt_top.SuspendLayout();
            this.panel_DGV_opt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Graph_Options)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_opt_bottom
            // 
            this.panel_opt_bottom.Controls.Add(this.BT_Show);
            this.panel_opt_bottom.Controls.Add(this.BT_Cancel);
            this.panel_opt_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_opt_bottom.Location = new System.Drawing.Point(0, 525);
            this.panel_opt_bottom.Name = "panel_opt_bottom";
            this.panel_opt_bottom.Size = new System.Drawing.Size(200, 52);
            this.panel_opt_bottom.TabIndex = 91;
            // 
            // BT_Show
            // 
            this.BT_Show.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BT_Show.Location = new System.Drawing.Point(14, 12);
            this.BT_Show.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT_Show.Name = "BT_Show";
            this.BT_Show.Size = new System.Drawing.Size(83, 27);
            this.BT_Show.TabIndex = 84;
            this.BT_Show.Text = "Показать";
            this.BT_Show.UseVisualStyleBackColor = true;
            this.BT_Show.Click += new System.EventHandler(this.BT_Show_Click);
            // 
            // BT_Cancel
            // 
            this.BT_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BT_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_Cancel.Location = new System.Drawing.Point(103, 12);
            this.BT_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT_Cancel.Name = "BT_Cancel";
            this.BT_Cancel.Size = new System.Drawing.Size(83, 27);
            this.BT_Cancel.TabIndex = 85;
            this.BT_Cancel.Text = "Cancel";
            this.BT_Cancel.UseVisualStyleBackColor = true;
            // 
            // panel_opt_top
            // 
            this.panel_opt_top.AutoSize = true;
            this.panel_opt_top.Controls.Add(this.label_preset);
            this.panel_opt_top.Controls.Add(this.CB_Preset);
            this.panel_opt_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_opt_top.Location = new System.Drawing.Point(0, 0);
            this.panel_opt_top.Name = "panel_opt_top";
            this.panel_opt_top.Size = new System.Drawing.Size(200, 47);
            this.panel_opt_top.TabIndex = 90;
            // 
            // label_preset
            // 
            this.label_preset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_preset.AutoSize = true;
            this.label_preset.Location = new System.Drawing.Point(3, 11);
            this.label_preset.Name = "label_preset";
            this.label_preset.Size = new System.Drawing.Size(42, 15);
            this.label_preset.TabIndex = 87;
            this.label_preset.Text = "Preset:";
            // 
            // CB_Preset
            // 
            this.CB_Preset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Preset.FormattingEnabled = true;
            this.CB_Preset.Location = new System.Drawing.Point(52, 8);
            this.CB_Preset.Name = "CB_Preset";
            this.CB_Preset.Size = new System.Drawing.Size(127, 23);
            this.CB_Preset.TabIndex = 86;
            this.CB_Preset.TextChanged += new System.EventHandler(this.CB_Preset_TextChanged);
            // 
            // panel_DGV_opt
            // 
            this.panel_DGV_opt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_DGV_opt.Controls.Add(this.DGV_Graph_Options);
            this.panel_DGV_opt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DGV_opt.Location = new System.Drawing.Point(0, 47);
            this.panel_DGV_opt.Name = "panel_DGV_opt";
            this.panel_DGV_opt.Size = new System.Drawing.Size(200, 478);
            this.panel_DGV_opt.TabIndex = 89;
            // 
            // DGV_Graph_Options
            // 
            this.DGV_Graph_Options.AllowUserToAddRows = false;
            this.DGV_Graph_Options.AllowUserToDeleteRows = false;
            this.DGV_Graph_Options.AllowUserToResizeRows = false;
            this.DGV_Graph_Options.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Graph_Options.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RelatedTo,
            this.property,
            this.value});
            this.DGV_Graph_Options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Graph_Options.Location = new System.Drawing.Point(0, 0);
            this.DGV_Graph_Options.Margin = new System.Windows.Forms.Padding(10);
            this.DGV_Graph_Options.MultiSelect = false;
            this.DGV_Graph_Options.Name = "DGV_Graph_Options";
            this.DGV_Graph_Options.RowHeadersVisible = false;
            this.DGV_Graph_Options.RowHeadersWidth = 51;
            this.DGV_Graph_Options.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_Graph_Options.Size = new System.Drawing.Size(200, 478);
            this.DGV_Graph_Options.TabIndex = 88;
            // 
            // RelatedTo
            // 
            this.RelatedTo.HeaderText = "RelatedTo";
            this.RelatedTo.Name = "RelatedTo";
            this.RelatedTo.ReadOnly = true;
            this.RelatedTo.Visible = false;
            // 
            // property
            // 
            this.property.HeaderText = "свойство";
            this.property.Name = "property";
            this.property.ReadOnly = true;
            this.property.Width = 107;
            // 
            // value
            // 
            this.value.HeaderText = "значение";
            this.value.Name = "value";
            this.value.Width = 107;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel_DGV_opt);
            this.panel2.Controls.Add(this.panel_opt_bottom);
            this.panel2.Controls.Add(this.panel_opt_top);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 577);
            this.panel2.TabIndex = 5;
            // 
            // panel_browser
            // 
            this.panel_browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_browser.Location = new System.Drawing.Point(200, 0);
            this.panel_browser.Name = "panel_browser";
            this.panel_browser.Size = new System.Drawing.Size(847, 577);
            this.panel_browser.TabIndex = 6;
            // 
            // Form_Graphviz
            // 
            this.AcceptButton = this.BT_Show;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_Cancel;
            this.ClientSize = new System.Drawing.Size(1047, 577);
            this.Controls.Add(this.panel_browser);
            this.Controls.Add(this.panel2);
            this.Name = "Form_Graphviz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Визуализация Graphviz";
            this.panel_opt_bottom.ResumeLayout(false);
            this.panel_opt_top.ResumeLayout(false);
            this.panel_opt_top.PerformLayout();
            this.panel_DGV_opt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Graph_Options)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button BT_Show;
        private ComboBox CB_Preset;
        private Button BT_Cancel;
        private Label label_preset;
        public DataGridView DGV_Graph_Options;
        private Panel panel_opt_bottom;
        private Panel panel_opt_top;
        private Panel panel_DGV_opt;
        private Panel panel2;
        private DataGridViewTextBoxColumn RelatedTo;
        private DataGridViewTextBoxColumn property;
        private DataGridViewTextBoxColumn value;
        private Panel panel_browser;
    }
}