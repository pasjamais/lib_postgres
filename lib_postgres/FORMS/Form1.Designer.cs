namespace lib_postgres
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.book1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.книгаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Book_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Book_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem__Book_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem__Book_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.произведениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Arts_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Arts_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Arts_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Arts_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.авторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Authors_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Author_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Author_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Author_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.фToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Catalogues = new System.Windows.Forms.ToolStripMenuItem();
            this.языкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Language_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Language_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Language_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Language_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_PubHouse = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_PubHouse_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_PubHouse_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_PubHouse_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_PubHouse_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.жанрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Genres_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Genres_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Genres_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem__Genres_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_City = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem__City_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_City_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_City_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_City_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Actions = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Actions_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Action_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Location = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Location_Show = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.book1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // book1BindingSource
            // 
            this.book1BindingSource.DataSource = typeof(lib_postgres.Book1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1184, 487);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.книгаToolStripMenuItem,
            this.произведениеToolStripMenuItem,
            this.авторыToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ToolStripMenuItem_Catalogues,
            this.ToolStripMenuItem_Actions,
            this.ToolStripMenuItem_Location});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // книгаToolStripMenuItem
            // 
            this.книгаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Book_Show,
            this.toolStripSeparator2,
            this.ToolStripMenuItem_Book_Add,
            this.ToolStripMenuItem__Book_Edit,
            this.ToolStripMenuItem__Book_Delete});
            this.книгаToolStripMenuItem.Name = "книгаToolStripMenuItem";
            this.книгаToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.книгаToolStripMenuItem.Text = "Книги";
            // 
            // ToolStripMenuItem_Book_Show
            // 
            this.ToolStripMenuItem_Book_Show.Name = "ToolStripMenuItem_Book_Show";
            this.ToolStripMenuItem_Book_Show.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Book_Show.Text = "Показать";
            this.ToolStripMenuItem_Book_Show.Click += new System.EventHandler(this.ToolStripMenuItem_Book_Show_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // ToolStripMenuItem_Book_Add
            // 
            this.ToolStripMenuItem_Book_Add.Name = "ToolStripMenuItem_Book_Add";
            this.ToolStripMenuItem_Book_Add.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Book_Add.Text = "Добавить";
            this.ToolStripMenuItem_Book_Add.Click += new System.EventHandler(this.ToolStripMenuItem_Book_Add_Click);
            // 
            // ToolStripMenuItem__Book_Edit
            // 
            this.ToolStripMenuItem__Book_Edit.Name = "ToolStripMenuItem__Book_Edit";
            this.ToolStripMenuItem__Book_Edit.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem__Book_Edit.Text = "Изменить...";
            this.ToolStripMenuItem__Book_Edit.Click += new System.EventHandler(this.ToolStripMenuItem__Book_Edit_Click);
            // 
            // ToolStripMenuItem__Book_Delete
            // 
            this.ToolStripMenuItem__Book_Delete.Enabled = false;
            this.ToolStripMenuItem__Book_Delete.Name = "ToolStripMenuItem__Book_Delete";
            this.ToolStripMenuItem__Book_Delete.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem__Book_Delete.Text = "Удалить...";
            // 
            // произведениеToolStripMenuItem
            // 
            this.произведениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Arts_Show,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_Arts_Add,
            this.ToolStripMenuItem_Arts_Edit,
            this.ToolStripMenuItem_Arts_Delete});
            this.произведениеToolStripMenuItem.Name = "произведениеToolStripMenuItem";
            this.произведениеToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.произведениеToolStripMenuItem.Text = "Произведения";
            // 
            // ToolStripMenuItem_Arts_Show
            // 
            this.ToolStripMenuItem_Arts_Show.Name = "ToolStripMenuItem_Arts_Show";
            this.ToolStripMenuItem_Arts_Show.Size = new System.Drawing.Size(224, 26);
            this.ToolStripMenuItem_Arts_Show.Text = "Показать";
            this.ToolStripMenuItem_Arts_Show.Click += new System.EventHandler(this.ToolStripMenuItem_Arts_Show_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // ToolStripMenuItem_Arts_Add
            // 
            this.ToolStripMenuItem_Arts_Add.Name = "ToolStripMenuItem_Arts_Add";
            this.ToolStripMenuItem_Arts_Add.Size = new System.Drawing.Size(224, 26);
            this.ToolStripMenuItem_Arts_Add.Text = "Добавить...";
            this.ToolStripMenuItem_Arts_Add.Click += new System.EventHandler(this.ToolStripMenuItem_Arts_Add_Click);
            // 
            // ToolStripMenuItem_Arts_Edit
            // 
            this.ToolStripMenuItem_Arts_Edit.Name = "ToolStripMenuItem_Arts_Edit";
            this.ToolStripMenuItem_Arts_Edit.Size = new System.Drawing.Size(224, 26);
            this.ToolStripMenuItem_Arts_Edit.Text = "Изменить....";
            this.ToolStripMenuItem_Arts_Edit.Click += new System.EventHandler(this.ToolStripMenuItem_Arts_Edit_Click);
            // 
            // ToolStripMenuItem_Arts_Delete
            // 
            this.ToolStripMenuItem_Arts_Delete.Enabled = false;
            this.ToolStripMenuItem_Arts_Delete.Name = "ToolStripMenuItem_Arts_Delete";
            this.ToolStripMenuItem_Arts_Delete.Size = new System.Drawing.Size(224, 26);
            this.ToolStripMenuItem_Arts_Delete.Text = "Удалить...";
            // 
            // авторыToolStripMenuItem
            // 
            this.авторыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Authors_Show,
            this.toolStripSeparator3,
            this.ToolStripMenuItem_Author_Add,
            this.ToolStripMenuItem_Author_Edit,
            this.ToolStripMenuItem_Author_Delete});
            this.авторыToolStripMenuItem.Name = "авторыToolStripMenuItem";
            this.авторыToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.авторыToolStripMenuItem.Text = "Авторы";
            // 
            // ToolStripMenuItem_Authors_Show
            // 
            this.ToolStripMenuItem_Authors_Show.Name = "ToolStripMenuItem_Authors_Show";
            this.ToolStripMenuItem_Authors_Show.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Authors_Show.Text = "Показать";
            this.ToolStripMenuItem_Authors_Show.Click += new System.EventHandler(this.ToolStripMenuItem_Authors_Show_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
            // 
            // ToolStripMenuItem_Author_Add
            // 
            this.ToolStripMenuItem_Author_Add.Name = "ToolStripMenuItem_Author_Add";
            this.ToolStripMenuItem_Author_Add.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Author_Add.Text = "Добавить...";
            this.ToolStripMenuItem_Author_Add.Click += new System.EventHandler(this.ToolStripMenuItem_Author_Add_Click);
            // 
            // ToolStripMenuItem_Author_Edit
            // 
            this.ToolStripMenuItem_Author_Edit.Name = "ToolStripMenuItem_Author_Edit";
            this.ToolStripMenuItem_Author_Edit.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Author_Edit.Text = "Изменить...";
            this.ToolStripMenuItem_Author_Edit.Click += new System.EventHandler(this.ToolStripMenuItem_Author_Edit_Click);
            // 
            // ToolStripMenuItem_Author_Delete
            // 
            this.ToolStripMenuItem_Author_Delete.Enabled = false;
            this.ToolStripMenuItem_Author_Delete.Name = "ToolStripMenuItem_Author_Delete";
            this.ToolStripMenuItem_Author_Delete.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Author_Delete.Text = "Удалить...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(53, 24);
            this.toolStripMenuItem1.Text = " Test";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // фToolStripMenuItem
            // 
            this.фToolStripMenuItem.Name = "фToolStripMenuItem";
            this.фToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.фToolStripMenuItem.Text = "Get_Action_and_Books";
            this.фToolStripMenuItem.Click += new System.EventHandler(this.фToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_Catalogues
            // 
            this.ToolStripMenuItem_Catalogues.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.языкиToolStripMenuItem,
            this.ToolStripMenuItem_PubHouse,
            this.жанрыToolStripMenuItem,
            this.ToolStripMenuItem_City});
            this.ToolStripMenuItem_Catalogues.Name = "ToolStripMenuItem_Catalogues";
            this.ToolStripMenuItem_Catalogues.Size = new System.Drawing.Size(117, 24);
            this.ToolStripMenuItem_Catalogues.Text = "Справочники";
            this.ToolStripMenuItem_Catalogues.Click += new System.EventHandler(this.ToolStripMenuItem_Catalogues_Click);
            // 
            // языкиToolStripMenuItem
            // 
            this.языкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Language_Show,
            this.toolStripSeparator5,
            this.ToolStripMenuItem_Language_Add,
            this.ToolStripMenuItem_Language_Edit,
            this.ToolStripMenuItem_Language_Delete});
            this.языкиToolStripMenuItem.Name = "языкиToolStripMenuItem";
            this.языкиToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.языкиToolStripMenuItem.Text = "Языки";
            // 
            // ToolStripMenuItem_Language_Show
            // 
            this.ToolStripMenuItem_Language_Show.Name = "ToolStripMenuItem_Language_Show";
            this.ToolStripMenuItem_Language_Show.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Language_Show.Text = "Показать";
            this.ToolStripMenuItem_Language_Show.Click += new System.EventHandler(this.ToolStripMenuItem_Language_Show_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(167, 6);
            // 
            // ToolStripMenuItem_Language_Add
            // 
            this.ToolStripMenuItem_Language_Add.Name = "ToolStripMenuItem_Language_Add";
            this.ToolStripMenuItem_Language_Add.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Language_Add.Text = "Добавить...";
            this.ToolStripMenuItem_Language_Add.Click += new System.EventHandler(this.ToolStripMenuItem_Language_Add_Click);
            // 
            // ToolStripMenuItem_Language_Edit
            // 
            this.ToolStripMenuItem_Language_Edit.Name = "ToolStripMenuItem_Language_Edit";
            this.ToolStripMenuItem_Language_Edit.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Language_Edit.Text = "Изменить...";
            this.ToolStripMenuItem_Language_Edit.Click += new System.EventHandler(this.ToolStripMenuItem_Language_Edit_Click);
            // 
            // ToolStripMenuItem_Language_Delete
            // 
            this.ToolStripMenuItem_Language_Delete.Enabled = false;
            this.ToolStripMenuItem_Language_Delete.Name = "ToolStripMenuItem_Language_Delete";
            this.ToolStripMenuItem_Language_Delete.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Language_Delete.Text = "Удалить...";
            // 
            // ToolStripMenuItem_PubHouse
            // 
            this.ToolStripMenuItem_PubHouse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_PubHouse_Show,
            this.toolStripSeparator6,
            this.ToolStripMenuItem_PubHouse_Add,
            this.ToolStripMenuItem_PubHouse_Edit,
            this.ToolStripMenuItem_PubHouse_Delete});
            this.ToolStripMenuItem_PubHouse.Name = "ToolStripMenuItem_PubHouse";
            this.ToolStripMenuItem_PubHouse.Size = new System.Drawing.Size(185, 26);
            this.ToolStripMenuItem_PubHouse.Text = "Издательства";
            // 
            // ToolStripMenuItem_PubHouse_Show
            // 
            this.ToolStripMenuItem_PubHouse_Show.Name = "ToolStripMenuItem_PubHouse_Show";
            this.ToolStripMenuItem_PubHouse_Show.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_PubHouse_Show.Text = "Показать";
            this.ToolStripMenuItem_PubHouse_Show.Click += new System.EventHandler(this.ToolStripMenuItem_PubHouse_Show_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(167, 6);
            // 
            // ToolStripMenuItem_PubHouse_Add
            // 
            this.ToolStripMenuItem_PubHouse_Add.Name = "ToolStripMenuItem_PubHouse_Add";
            this.ToolStripMenuItem_PubHouse_Add.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_PubHouse_Add.Text = "Добавить...";
            this.ToolStripMenuItem_PubHouse_Add.Click += new System.EventHandler(this.ToolStripMenuItem_PubHouse_Add_Click);
            // 
            // ToolStripMenuItem_PubHouse_Edit
            // 
            this.ToolStripMenuItem_PubHouse_Edit.Name = "ToolStripMenuItem_PubHouse_Edit";
            this.ToolStripMenuItem_PubHouse_Edit.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_PubHouse_Edit.Text = "Изменить...";
            this.ToolStripMenuItem_PubHouse_Edit.Click += new System.EventHandler(this.ToolStripMenuItem_PubHouse_Edit_Click);
            // 
            // ToolStripMenuItem_PubHouse_Delete
            // 
            this.ToolStripMenuItem_PubHouse_Delete.Enabled = false;
            this.ToolStripMenuItem_PubHouse_Delete.Name = "ToolStripMenuItem_PubHouse_Delete";
            this.ToolStripMenuItem_PubHouse_Delete.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_PubHouse_Delete.Text = "Удалить...";
            // 
            // жанрыToolStripMenuItem
            // 
            this.жанрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Genres_Show,
            this.toolStripSeparator4,
            this.ToolStripMenuItem_Genres_Add,
            this.ToolStripMenuItem_Genres_Edit,
            this.ToolStripMenuItem__Genres_Delete});
            this.жанрыToolStripMenuItem.Name = "жанрыToolStripMenuItem";
            this.жанрыToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.жанрыToolStripMenuItem.Text = "Жанры";
            // 
            // ToolStripMenuItem_Genres_Show
            // 
            this.ToolStripMenuItem_Genres_Show.Name = "ToolStripMenuItem_Genres_Show";
            this.ToolStripMenuItem_Genres_Show.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Genres_Show.Text = "Показать";
            this.ToolStripMenuItem_Genres_Show.Click += new System.EventHandler(this.ToolStripMenuItem_Genres_Show_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(167, 6);
            // 
            // ToolStripMenuItem_Genres_Add
            // 
            this.ToolStripMenuItem_Genres_Add.Name = "ToolStripMenuItem_Genres_Add";
            this.ToolStripMenuItem_Genres_Add.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Genres_Add.Text = "Добавить...";
            this.ToolStripMenuItem_Genres_Add.Click += new System.EventHandler(this.ToolStripMenuItem_Genres_Add_Click);
            // 
            // ToolStripMenuItem_Genres_Edit
            // 
            this.ToolStripMenuItem_Genres_Edit.Name = "ToolStripMenuItem_Genres_Edit";
            this.ToolStripMenuItem_Genres_Edit.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_Genres_Edit.Text = "Изменить...";
            this.ToolStripMenuItem_Genres_Edit.Click += new System.EventHandler(this.ToolStripMenuItem_Genres_Edit_Click);
            // 
            // ToolStripMenuItem__Genres_Delete
            // 
            this.ToolStripMenuItem__Genres_Delete.Enabled = false;
            this.ToolStripMenuItem__Genres_Delete.Name = "ToolStripMenuItem__Genres_Delete";
            this.ToolStripMenuItem__Genres_Delete.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem__Genres_Delete.Text = "Удалить...";
            // 
            // ToolStripMenuItem_City
            // 
            this.ToolStripMenuItem_City.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem__City_Show,
            this.toolStripSeparator7,
            this.ToolStripMenuItem_City_Add,
            this.ToolStripMenuItem_City_Edit,
            this.ToolStripMenuItem_City_Delete});
            this.ToolStripMenuItem_City.Name = "ToolStripMenuItem_City";
            this.ToolStripMenuItem_City.Size = new System.Drawing.Size(185, 26);
            this.ToolStripMenuItem_City.Text = "Города";
            // 
            // ToolStripMenuItem__City_Show
            // 
            this.ToolStripMenuItem__City_Show.Name = "ToolStripMenuItem__City_Show";
            this.ToolStripMenuItem__City_Show.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem__City_Show.Text = "Показать";
            this.ToolStripMenuItem__City_Show.Click += new System.EventHandler(this.ToolStripMenuItem__City_Show_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(167, 6);
            // 
            // ToolStripMenuItem_City_Add
            // 
            this.ToolStripMenuItem_City_Add.Name = "ToolStripMenuItem_City_Add";
            this.ToolStripMenuItem_City_Add.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_City_Add.Text = "Добавить...";
            this.ToolStripMenuItem_City_Add.Click += new System.EventHandler(this.ToolStripMenuItem_City_Add_Click);
            // 
            // ToolStripMenuItem_City_Edit
            // 
            this.ToolStripMenuItem_City_Edit.Name = "ToolStripMenuItem_City_Edit";
            this.ToolStripMenuItem_City_Edit.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_City_Edit.Text = "Изменить...";
            this.ToolStripMenuItem_City_Edit.Click += new System.EventHandler(this.ToolStripMenuItem_City_Edit_Click);
            // 
            // ToolStripMenuItem_City_Delete
            // 
            this.ToolStripMenuItem_City_Delete.Enabled = false;
            this.ToolStripMenuItem_City_Delete.Name = "ToolStripMenuItem_City_Delete";
            this.ToolStripMenuItem_City_Delete.Size = new System.Drawing.Size(170, 26);
            this.ToolStripMenuItem_City_Delete.Text = "Удалить...";
            // 
            // ToolStripMenuItem_Actions
            // 
            this.ToolStripMenuItem_Actions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Actions_Show,
            this.toolStripSeparator8,
            this.открытьToolStripMenuItem,
            this.ToolStripMenuItem_Action_Edit});
            this.ToolStripMenuItem_Actions.Name = "ToolStripMenuItem_Actions";
            this.ToolStripMenuItem_Actions.Size = new System.Drawing.Size(88, 24);
            this.ToolStripMenuItem_Actions.Text = "Действия";
            this.ToolStripMenuItem_Actions.Click += new System.EventHandler(this.ToolStripMenuItem_Actions_Click);
            // 
            // ToolStripMenuItem_Actions_Show
            // 
            this.ToolStripMenuItem_Actions_Show.Name = "ToolStripMenuItem_Actions_Show";
            this.ToolStripMenuItem_Actions_Show.Size = new System.Drawing.Size(224, 26);
            this.ToolStripMenuItem_Actions_Show.Text = "Показать";
            this.ToolStripMenuItem_Actions_Show.Click += new System.EventHandler(this.ToolStripMenuItem_Actions_Show_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(221, 6);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_Action_Edit
            // 
            this.ToolStripMenuItem_Action_Edit.Name = "ToolStripMenuItem_Action_Edit";
            this.ToolStripMenuItem_Action_Edit.Size = new System.Drawing.Size(224, 26);
            this.ToolStripMenuItem_Action_Edit.Text = "Создать...";
            this.ToolStripMenuItem_Action_Edit.Click += new System.EventHandler(this.ToolStripMenuItem_Action_Edit_Click);
            // 
            // ToolStripMenuItem_Location
            // 
            this.ToolStripMenuItem_Location.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Location_Show});
            this.ToolStripMenuItem_Location.Name = "ToolStripMenuItem_Location";
            this.ToolStripMenuItem_Location.Size = new System.Drawing.Size(150, 24);
            this.ToolStripMenuItem_Location.Text = "Регистр движения";
            // 
            // ToolStripMenuItem_Location_Show
            // 
            this.ToolStripMenuItem_Location_Show.Name = "ToolStripMenuItem_Location_Show";
            this.ToolStripMenuItem_Location_Show.Size = new System.Drawing.Size(156, 26);
            this.ToolStripMenuItem_Location_Show.Text = "Показать";
            this.ToolStripMenuItem_Location_Show.Click += new System.EventHandler(this.ToolStripMenuItem_Location_Show_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 515);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.book1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BindingSource book1BindingSource;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem книгаToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem_Book_Add;
        private ToolStripMenuItem ToolStripMenuItem__Book_Edit;
        private ToolStripMenuItem ToolStripMenuItem__Book_Delete;
        private ToolStripMenuItem произведениеToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem_Arts_Add;
        private ToolStripMenuItem ToolStripMenuItem_Arts_Edit;
        private ToolStripMenuItem ToolStripMenuItem_Arts_Delete;
        private ToolStripMenuItem авторыToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem_Book_Show;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem ToolStripMenuItem_Arts_Show;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ToolStripMenuItem_Authors_Show;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem ToolStripMenuItem_Author_Add;
        private ToolStripMenuItem ToolStripMenuItem_Author_Edit;
        private ToolStripMenuItem ToolStripMenuItem_Author_Delete;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem ToolStripMenuItem_Catalogues;
        private ToolStripMenuItem языкиToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem_Language_Show;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem ToolStripMenuItem_Language_Add;
        private ToolStripMenuItem ToolStripMenuItem_Language_Edit;
        private ToolStripMenuItem ToolStripMenuItem_Language_Delete;
        private ToolStripMenuItem ToolStripMenuItem_PubHouse;
        private ToolStripMenuItem жанрыToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem_Genres_Show;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem ToolStripMenuItem_Genres_Add;
        private ToolStripMenuItem ToolStripMenuItem_Genres_Edit;
        private ToolStripMenuItem ToolStripMenuItem__Genres_Delete;
        private ToolStripMenuItem ToolStripMenuItem_City;
        private ToolStripMenuItem ToolStripMenuItem_PubHouse_Add;
        private ToolStripMenuItem ToolStripMenuItem_PubHouse_Show;
        private ToolStripMenuItem ToolStripMenuItem_PubHouse_Edit;
        private ToolStripMenuItem ToolStripMenuItem_PubHouse_Delete;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem ToolStripMenuItem__City_Show;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem ToolStripMenuItem_City_Add;
        private ToolStripMenuItem ToolStripMenuItem_City_Edit;
        private ToolStripMenuItem ToolStripMenuItem_City_Delete;
        public DataGridView dataGridView1;
        private ToolStripMenuItem ToolStripMenuItem_Actions;
        private ToolStripMenuItem ToolStripMenuItem_Actions_Show;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem_Location;
        private ToolStripMenuItem ToolStripMenuItem_Location_Show;
        private ToolStripMenuItem фToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem ToolStripMenuItem_Action_Edit;
    }
}