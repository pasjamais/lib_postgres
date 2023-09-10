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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Graphviz));
            this.panel_opt_bottom = new System.Windows.Forms.Panel();
            this.LL_Graphviz = new System.Windows.Forms.LinkLabel();
            this.BT_Show = new System.Windows.Forms.Button();
            this.BT_Cancel = new System.Windows.Forms.Button();
            this.panel_opt_top = new System.Windows.Forms.Panel();
            this.CB_Visualisation = new System.Windows.Forms.ComboBox();
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
            resources.ApplyResources(this.panel_opt_bottom, "panel_opt_bottom");
            this.panel_opt_bottom.Controls.Add(this.LL_Graphviz);
            this.panel_opt_bottom.Controls.Add(this.BT_Show);
            this.panel_opt_bottom.Controls.Add(this.BT_Cancel);
            this.panel_opt_bottom.Name = "panel_opt_bottom";
            // 
            // LL_Graphviz
            // 
            resources.ApplyResources(this.LL_Graphviz, "LL_Graphviz");
            this.LL_Graphviz.Name = "LL_Graphviz";
            this.LL_Graphviz.TabStop = true;
            this.LL_Graphviz.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Graphviz_LinkClicked);
            // 
            // BT_Show
            // 
            resources.ApplyResources(this.BT_Show, "BT_Show");
            this.BT_Show.Name = "BT_Show";
            this.BT_Show.UseVisualStyleBackColor = true;
            this.BT_Show.Click += new System.EventHandler(this.BT_Show_Click);
            // 
            // BT_Cancel
            // 
            resources.ApplyResources(this.BT_Cancel, "BT_Cancel");
            this.BT_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_Cancel.Name = "BT_Cancel";
            this.BT_Cancel.UseVisualStyleBackColor = true;
            // 
            // panel_opt_top
            // 
            resources.ApplyResources(this.panel_opt_top, "panel_opt_top");
            this.panel_opt_top.Controls.Add(this.CB_Visualisation);
            this.panel_opt_top.Controls.Add(this.label_preset);
            this.panel_opt_top.Controls.Add(this.CB_Preset);
            this.panel_opt_top.Name = "panel_opt_top";
            // 
            // CB_Visualisation
            // 
            resources.ApplyResources(this.CB_Visualisation, "CB_Visualisation");
            this.CB_Visualisation.FormattingEnabled = true;
            this.CB_Visualisation.Name = "CB_Visualisation";
            // 
            // label_preset
            // 
            resources.ApplyResources(this.label_preset, "label_preset");
            this.label_preset.Name = "label_preset";
            // 
            // CB_Preset
            // 
            resources.ApplyResources(this.CB_Preset, "CB_Preset");
            this.CB_Preset.FormattingEnabled = true;
            this.CB_Preset.Name = "CB_Preset";
            this.CB_Preset.TextChanged += new System.EventHandler(this.CB_Preset_TextChanged);
            // 
            // panel_DGV_opt
            // 
            resources.ApplyResources(this.panel_DGV_opt, "panel_DGV_opt");
            this.panel_DGV_opt.Controls.Add(this.DGV_Graph_Options);
            this.panel_DGV_opt.Name = "panel_DGV_opt";
            // 
            // DGV_Graph_Options
            // 
            resources.ApplyResources(this.DGV_Graph_Options, "DGV_Graph_Options");
            this.DGV_Graph_Options.AllowUserToAddRows = false;
            this.DGV_Graph_Options.AllowUserToDeleteRows = false;
            this.DGV_Graph_Options.AllowUserToResizeRows = false;
            this.DGV_Graph_Options.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Graph_Options.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RelatedTo,
            this.property,
            this.value});
            this.DGV_Graph_Options.MultiSelect = false;
            this.DGV_Graph_Options.Name = "DGV_Graph_Options";
            this.DGV_Graph_Options.RowHeadersVisible = false;
            this.DGV_Graph_Options.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_Graph_Options.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Graph_Options_CellContentClick);
            // 
            // RelatedTo
            // 
            resources.ApplyResources(this.RelatedTo, "RelatedTo");
            this.RelatedTo.Name = "RelatedTo";
            this.RelatedTo.ReadOnly = true;
            // 
            // property
            // 
            resources.ApplyResources(this.property, "property");
            this.property.Name = "property";
            this.property.ReadOnly = true;
            // 
            // value
            // 
            resources.ApplyResources(this.value, "value");
            this.value.Name = "value";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.panel_DGV_opt);
            this.panel2.Controls.Add(this.panel_opt_bottom);
            this.panel2.Controls.Add(this.panel_opt_top);
            this.panel2.Name = "panel2";
            // 
            // panel_browser
            // 
            resources.ApplyResources(this.panel_browser, "panel_browser");
            this.panel_browser.Name = "panel_browser";
            // 
            // Form_Graphviz
            // 
            this.AcceptButton = this.BT_Show;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_Cancel;
            this.Controls.Add(this.panel_browser);
            this.Controls.Add(this.panel2);
            this.Name = "Form_Graphviz";
            this.panel_opt_bottom.ResumeLayout(false);
            this.panel_opt_bottom.PerformLayout();
            this.panel_opt_top.ResumeLayout(false);
            this.panel_opt_top.PerformLayout();
            this.panel_DGV_opt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Graph_Options)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private Panel panel_browser;
        private LinkLabel LL_Graphviz;
        private ComboBox CB_Visualisation;
        private DataGridViewTextBoxColumn RelatedTo;
        private DataGridViewTextBoxColumn property;
        private DataGridViewTextBoxColumn value;
    }
}