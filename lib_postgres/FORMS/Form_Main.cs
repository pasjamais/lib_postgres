﻿using lib_postgres.VIEW.DELITEMS;
using lib_postgres.FORMS;
using lib_postgres.VISUAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Globalization;
using System.Threading;
using System.ComponentModel;
using lib_postgres.Properties;
using System.Resources;
using System.Reflection;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Security.Cryptography.Xml;
using lib_postgres.DEPLOY;
using lib_postgres.CRUD;
using lib_postgres.VIEW.CONTEXT_MENU;
using lib_postgres.VIEW;
using lib_postgres.VIEW.SPEC_ENTITIES_VIEWS;
using lib_postgres.QUERIES;
using lib_postgres.LOCALIZATION;
using lib_postgres.VISUAL.TreeViewViz;
using static lib_postgres.VIEW.SPEC_ENTITIES_VIEWS.Structures;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

namespace lib_postgres
{
    public partial class Form_Main : Form
    {
        //current view roules the set of available commands
        private Type? current_Working_Type;
        public Type? Current_Working_Type
        {
            get { return current_Working_Type; }
            set
            {
                current_Working_Type = value;
                After_Current_Working_Type_Changing();
            }
        }
        public Main_Form_Status_Update StatusProperty { get; set; } = new Main_Form_Status_Update();
        const string Caption = "Lib.";
        public Dictionary<string, long> sources_saved_positions = new Dictionary<string, long>();
        DGV_Visualisator dgv_Visualisator;
        public DGV_Visualisator.Turn_Off_or_ON_Current_Menu_Item Turn_Off;
        public DGV_Visualisator.Turn_Off_or_ON_Current_Menu_Item Turn_ON;

        // for reload table after exit from settings form, renew DGV after operations of erasing
        private delegate void Last_DGV_Update_Operation();
        Last_DGV_Update_Operation last_DGV_Update_Operation;

        private Deploy deploy = new Deploy();

        //Singleton added for using Forms's methods in menu construction
        private static Form_Main _instance;
        public static Form_Main GetInstance()
        {
            if (_instance != null) return _instance;
            return _instance = new Form_Main();
        }
        public static bool Is_DGV_Has_rows;
        private Form_Main()
        {
            InitializeComponent();
            Binding_Elements();
            main_menu_generation();
            this.dgv_Visualisator = new DGV_Visualisator();
            Turn_Off = delegate () { this.Turn_Off_Current_Menu_Item(); };
            Turn_ON = delegate () { this.Turn_On_Current_Menu_Item(); };
            sources_saved_positions_Initialisation();
        }

        #region general

        private void Form_Main_Shown(object sender, EventArgs e)
        {
            Type type = typeof(ViewBook);
            Current_Working_Type = type;
            Read_Books();
            Turn_On_Current_Menu_Item();
        }

        private void BackupBD()
        {
            Backup.BackupBD();
        }
        private void After_Current_Working_Type_Changing()
        {
            Update_Context_Menu();
        }
        public bool Is_DGV_Has_Any_Row()
        {
            if (dataGridView.RowCount > 0)
                return true;
            else return false;
        }
        private void sources_saved_positions_Initialisation()
        {
            sources_saved_positions.Add("art_to_read", CRUD_Item_Determinator.Get_ID_of_First_Element_if_Exists<Art>(CRUD_Item_Determinator.Get_All_Elements_of_This_Type_If_Exist<Art>()));
            sources_saved_positions.Add("author_to_read", CRUD_Item_Determinator.Get_ID_of_First_Element_if_Exists<Author>(CRUD_Item_Determinator.Get_All_Elements_of_This_Type_If_Exist<Author>()));
            sources_saved_positions.Add("art", sources_saved_positions["art_to_read"]);
            sources_saved_positions.Add("author", sources_saved_positions["author_to_read"]);
            sources_saved_positions.Add("another", CRUD_Item_Determinator.Get_ID_of_First_Element_if_Exists<SourceToreadAnother>(CRUD_Item_Determinator.Get_All_Elements_of_This_Type_If_Exist<SourceToreadAnother>()));
        }


        #endregion general 

        #region popup

        //book movement history
        private void Cmi_item_find_book_Click(object? sender, EventArgs e)
        {
            if (current_Working_Type == typeof(ViewBook))
            {
                int index = dataGridView.SelectedRows[0].Index;
                long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
                Form_Report form_report = new Form_Report();
                form_report.Text = (string)dataGridView.Rows[index].Cells["Название"].Value + " / " + (string)dataGridView.Rows[index].Cells["АвторЫ"].Value;
                form_report.DGV.DataSource = Queries_SQL_Direct.Fill_DataTable_by_Query_with_Parameter
                    <long>(DB_Agent.Get_Query(2).Text, ":book_id_parameter", id);
                var DialogResult = form_report.ShowDialog();
                if (DialogResult != DialogResult.OK)
                    return;
            }
        }
        private void cmi_item_add_art_to_read_Click(object sender, EventArgs e)
        {
            if (current_Working_Type == typeof(Art))
            {
                int index = dataGridView.SelectedRows[0].Index;
                long id_art = (long)dataGridView.Rows[index].Cells["Id"].Value;
                var id = ArtRead.Create_Item_by_Art(id_art);
                if (id > 0)
                {
                    ToolStripMenuItem__Read_Open_Click(sender, e);
                    General_Manipulations.Show_Row(dataGridView, id.ToString(), "Id");
                }
            }
        }
        private void Update_Context_Menu()
        {
            Is_DGV_Has_rows = Is_DGV_Has_Any_Row();
            contextMenuStrip.Items.Clear();
            contextMenuStrip.Items.AddRange(Ask_for_New_Context_Menu_Strips());
        }

        /// <summary>
        /// In fact, just to transmit some type as generique.
        /// var new_strips = Context_Menu_Controller.Change_Working_Type<current_Working_Type>();
        /// </summary>
        private ToolStripItem[] Ask_for_New_Context_Menu_Strips()
        {
            ToolStripItem[] range = new ToolStripItem[0];
            var methodInfo = typeof(Context_Menu_Controller).GetMethod("Change_Working_Type");
            if (Current_Working_Type is not null)
            {
                var meth_ref = methodInfo.MakeGenericMethod(current_Working_Type);
                range = (ToolStripItem[])meth_ref.Invoke(null, null);
            }
            return range;
        }
        #endregion

        #region additional
        private void Binding_Elements()
        {
            Current_Working_Type = null;
            this.DataBindings.Add("Text", StatusProperty, "Message");
            //     this.DataBindings.Add("ToolStripMenuItem__Book_Edit.Enabled", StatusProperty, "ToolStripMenuItem__Book_Edit");
        }


        public override string Text
        {
            get => base.Text;
            set => base.Text = Caption + value;
        }
        #endregion additional

        #region main_menu_creation
        private void main_menu_generation()
        {
            ToolStripMenuItem newItem = new ToolStripMenuItem(Localization.Substitute("Where_books"));
            ToolStripMenuItem_Books.DropDownItems.Add(newItem);
            newItem.Tag = "Where_books";
            Add_for_Dynamic_Localization(newItem);

            var places = DB_Agent.Get_Places();
            foreach (var place in places)
            {
                ToolStripMenuItem place_item = new ToolStripMenuItem(place.Name);
                newItem.DropDownItems.Add(place_item);
                place_item.Click += show_books_in_place;
            }

            newItem = new ToolStripMenuItem(Localization.Substitute("Who_has_my_books"));
            ToolStripMenuItem_Books.DropDownItems.Add(newItem);
            newItem.Tag = "Who_has_my_books";
            Add_for_Dynamic_Localization(newItem);
            newItem.Click += get_My_Books_in_Other_Hands;


            newItem = new ToolStripMenuItem(Localization.Substitute("Arts_by_language"));
            ToolStripMenuItem_Arts.DropDownItems.Add(newItem);
            newItem.Tag = "Arts_by_language";
            Add_for_Dynamic_Localization(newItem);
            var languages = DB_Agent.Get_Languages();
            var arts = DB_Agent.Get_Arts();
            foreach (var language in languages)
            {
                ToolStripMenuItem language_item = new ToolStripMenuItem(language.Name);
                newItem.DropDownItems.Add(language_item);
                language_item.Click += show_arts_by_langue;
            }

            Initial_Langues_Menu_Load();
        }
        #endregion  main_menu_creation

        #region menu_commands
        private void ToolStripMenuItem_File_BackupBD_Click(object sender, EventArgs e)
        {
            BackupBD();
        }
        private void ToolStripMenuItem_File_RestoreBD_Click(object sender, EventArgs e)
        {
            Restore.Choose_RestoreBD(openFileDialog_BD_Backup);
            last_DGV_Update_Operation();
        }
        private void ToolStripMenuItem_File_Open_Settings_Click(object sender, EventArgs e)
        {
            Form_Settings form_Settings = new Form_Settings();
            DialogResult dialogResult = form_Settings.ShowDialog();
            if (dialogResult != DialogResult.OK) return;

            // 1. Backup
            Backup.Set_Value_Backup_on_Start(form_Settings.ChB_Backup_on_Start.Checked);

            // 2. Is_Colorize_deleted_items
            // save new deleted_elements visualisation into object property
            dgv_Visualisator.deleted_Entities_Visuaisator.Is_Colorize_deleted_items = form_Settings.ChB_Show_Deleted_Entities.Checked;
            // save new deleted_elements visualisation to INI file
            dgv_Visualisator.deleted_Entities_Visuaisator.Write_Value_isShow_Deleted_to_INI_File();

            // 3. Set_Value_Delete_Forever
            CRUD_Item_Determinator.Set_Value_Delete_Forever(form_Settings.ChB_Delete_Forever.Checked);

            last_DGV_Update_Operation();
        }
        void show_arts_by_langue(object sender, EventArgs e)
        {
            List<Art_and_Author> arts = Queries_LinQ.Get_Arts_by_LanguageName(((ToolStripMenuItem)sender).Text);
            // ++ sept 2023
            // Pasted from DGV_Visualisator.Refresh_DGV_for_Item_Type
            // for special projection of selection for languages
            // added for better view in DGV
            dataGridView.Columns.Clear();
            dgv_Visualisator.Assign_SortableBindingList_to_DGV<Art_and_Author>(dataGridView, arts);
            Turn_Off_Current_Menu_Item();
            dgv_Visualisator.Prepare_DGV_For_Type<Art>(dataGridView, StatusProperty);
            //++ colorization of deleted elements 
            List<long> deleted_IDs = CRUD_Item_Determinator.Get_Deleted_Items_IDs<Art>();
            dgv_Visualisator.deleted_Entities_Visuaisator.RunCommand(deleted_IDs, dataGridView);
            //-- colorization of deleted elements
            Turn_On_Current_Menu_Item();
            //-- sept 2023
        }
        void get_My_Books_in_Other_Hands(object sender, EventArgs e)
        {
            last_DGV_Update_Operation = Get_My_Books_in_Other_Hands;
            Get_My_Books_in_Other_Hands();
        }
        void show_books_in_place(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dgv_Visualisator.Assign_SortableBindingList_to_DGV<ViewAllRealBook>(dataGridView, Queries_LinQ.Get_Books_by_Place_Name(((ToolStripMenuItem)sender).Text));
            Turn_Off_Current_Menu_Item();
            Current_Working_Type = typeof(ViewBook);
            ViewBook.Prepare_DGV_Detailed(dataGridView);
            ViewBook.Highlighting(dataGridView);
            Turn_On_Current_Menu_Item();
        }

        private void ToolStripMenuItem__Recommend_Vis_Graphviz_Click(object sender, EventArgs e)
        {
            FORMS.Form_Graphviz form_graphviz = new FORMS.Form_Graphviz();
            var DialogResult = form_graphviz.ShowDialog();

        }


        private void ToolStripMenuItem_File_Delete_DB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                   Localization.Substitute("Warning_BD_Deleting"),
                   Localization.Substitute("Warning"),
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning,
                   MessageBoxDefaultButton.Button2,
                   MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Connection connection = new Connection();
                connection.Drop_BD();
                Application.Restart();

            }
        }
        private void ToolStripMenuItem_Author_Find_Arts_of_Author_Click(object sender, EventArgs e)
        {
            long authorID = dgv_Visualisator.Get_Selected_Entity_ID(dataGridView);
            dataGridView.Columns.Clear();
            dgv_Visualisator.Assign_SortableBindingList_to_DGV<Art_and_Author>(dataGridView, Queries_LinQ.Get_Arts(authorID));
            Turn_Off_Current_Menu_Item();
            dgv_Visualisator.Prepare_DGV_For_Type<Art>(dataGridView, StatusProperty);
            //++ colorization of deleted elements 
            List<long> deleted_IDs = CRUD_Item_Determinator.Get_Deleted_Items_IDs<Art>();
            dgv_Visualisator.deleted_Entities_Visuaisator.RunCommand(deleted_IDs, dataGridView);
            //-- colorization of deleted elements
            Turn_On_Current_Menu_Item();
        }

        private void ToolStripMenuItem_Author__Find_Recommendations_Click(object sender, EventArgs e)
        {
            long authorID = dgv_Visualisator.Get_Selected_Entity_ID(dataGridView);
            Author author = DB_Agent.Get_Author(authorID);
            List<Art_and_Author> arts_of_author = Queries_LinQ.Get_Arts(authorID);
            Read_Recommendations();
            List<Recommend> dt = (List<Recommend>)dataGridView.DataSource;
            dgv_Visualisator.Assign_SortableBindingList_to_DGV<Recommend>(dataGridView, Queries_LinQ.ArtRead_Projection(dt, author, arts_of_author));
        }

        #endregion menu_commands

        #region entities control

        #region Genre
        private void ToolStripMenuItem_Genres_Show_Click(object sender, EventArgs e)
        {
            Read_Genre();
        }
        private void ToolStripMenuItem_Genres_Add_Click(object sender, EventArgs e)
        {
            Create_Genre();
        }
        private void ToolStripMenuItem_Genres_Edit_Click(object sender, EventArgs e)
        {
            Edit_Genre();
        }
        private void ToolStripMenuItem__Genres_Delete_Click(object sender, EventArgs e)
        {
            Delete_Genre();
        }

        private void Erase_Genre(object sender, EventArgs e)
        {
            Erase_Item<Genre>();
        }
        #endregion

        #region Authors
        private void ToolStripMenuItem_Author_Edit_Click(object sender, EventArgs e)
        {
            Edit_Author();
        }
        private void ToolStripMenuItem_Autors_Show_Click(object sender, EventArgs e)
        {
            Read_Authors();
        }
        private void ToolStripMenuItem_Author_Add_Click(object sender, EventArgs e)
        {
            Create_Author();
        }
        private void ToolStripMenuItem_Author_Delete_Click(object sender, EventArgs e)
        {
            Delete_Author();
        }
        private void Erase_Author(object sender, EventArgs e)
        {
            Erase_Item<Author>();
        }
        #endregion

        #region Art
        private void ToolStripMenuItem_Arts_Show_Click(object sender, EventArgs e)
        {
            Read_Arts();
        }
        private void ToolStripMenuItem_Arts_Add_Click(object sender, EventArgs e)
        {
            Create_Art();
        }
        private void ToolStripMenuItem_Arts_Edit_Click(object sender, EventArgs e)
        {
            Edit_Art();
        }
        private void ToolStripMenuItem_Arts_Delete_Click(object sender, EventArgs e)
        {
            Delete_Art();
        }
        private void Erase_Art(object sender, EventArgs e)
        {
            Erase_Item<Art>();



        }
        #endregion

        #region Language
        private void ToolStripMenuItem_Language_Show_Click(object sender, EventArgs e)
        {
            Read_Languages();
        }

        private void ToolStripMenuItem_Language_Add_Click(object sender, EventArgs e)
        {
            Create_Language();
        }
        private void ToolStripMenuItem_Language_Edit_Click(object sender, EventArgs e)
        {
            Edit_Language();
        }
        private void ToolStripMenuItem_Language_Delete_Click(object sender, EventArgs e)
        {
            Delete_Language();
        }
        private void Erase_Language(object sender, EventArgs e)
        {
            Erase_Item<Language>();
        }
        #endregion

        #region Book
        internal void ToolStripMenuItem_Book_Add_Click(object sender, EventArgs e)
        {
            Create_Book();
        }
        internal void ToolStripMenuItem_Book_Show_Click(object sender, EventArgs e)
        {
            Read_Books();
        }
        internal void ToolStripMenuItem__Book_Edit_Click(object sender, EventArgs e)
        {
            Edit_Book();
        }
        internal void ToolStripMenuItem_Books_Delete_Click(object sender, EventArgs e)
        {
            Delete_Book();
        }
        private void Erase_Book(object sender, EventArgs e)
        {
            Erase_Item<Book>();
        }
        #endregion

        #region PubHouse
        private void ToolStripMenuItem_PubHouse_Add_Click(object sender, EventArgs e)
        {
            Create_Item<PublishingHouse>();
        }
        private void ToolStripMenuItem_PubHouse_Show_Click(object sender, EventArgs e)
        {
            Read_PublishingHouses();
        }
        private void ToolStripMenuItem_PubHouse_Edit_Click(object sender, EventArgs e)
        {
            Edit_PublishingHouse();
        }
        private void ToolStripMenuItem_PubHouse_Delete_Click(object sender, EventArgs e)
        {
            Delete_PublishingHouse();
        }
        private void Erase_PublishingHouse(object sender, EventArgs e)
        {
            Erase_Item<PublishingHouse>();
        }
        #endregion

        #region City

        private void ToolStripMenuItem__City_Show_Click(object sender, EventArgs e)
        {
            Read_Cities();
        }
        private void ToolStripMenuItem_City_Add_Click(object sender, EventArgs e)
        {
            Create_City();
        }
        private void ToolStripMenuItem_City_Edit_Click(object sender, EventArgs e)
        {
            Edit_City();
        }
        private void ToolStripMenuItem_City_Delete_Click(object sender, EventArgs e)
        {
            Delete_City();
        }
        private void Erase_City(object sender, EventArgs e)
        {
            Erase_Item<City>();
        }
        #endregion

        #region Book_Format

        private void ToolStripMenuItem_Book_Format_Show_Click(object sender, EventArgs e)
        {
            Read_Book_Formats();
        }

        private void ToolStripMenuItem_Book_Format_Add_Click(object sender, EventArgs e)
        {
            Create_Book_Format();
        }

        private void ToolStripMenuItem_Book_Format_Delete_Click(object sender, EventArgs e)
        {
            Delete_Book_Format();
        }

        private void ToolStripMenuItem_Book_Format_Edit_Click(object sender, EventArgs e)
        {
            Edit_Book_Format();
        }

        private void Erase_BookFormat(object sender, EventArgs e)
        {
            Erase_Item<BookFormat>();
        }
        #endregion Book_Format

        #region Place
        private void ToolStripMenuItem_Places_Show_Click(object sender, EventArgs e)
        {
            Read_Places();
        }

        private void ToolStripMenuItem_Places_Delele_Click(object sender, EventArgs e)
        {
            Delete_Place();
        }

        private void ToolStripMenuItem_Places_Edit_Click(object sender, EventArgs e)
        {
            Edit_Place();
        }

        private void ToolStripMenuItem_Places_Add_Click(object sender, EventArgs e)
        {
            Create_Place();
        }
        private void Erase_Place(object sender, EventArgs e)
        {
            Erase_Item<Place>();
        }

        #endregion Place

        #region People
        private void ToolStripMenuItem_People_Show_Click(object sender, EventArgs e)
        {
            Read_People();
        }

        private void ToolStripMenuItem_People_Add_Click(object sender, EventArgs e)
        {
            Create_Person();
        }

        private void ToolStripMenuItem_People_Edit_Click(object sender, EventArgs e)
        {
            Edit_Person();
        }

        private void ToolStripMenuItem_People_Delete_Click(object sender, EventArgs e)
        {
            Delete_Person();
        }

        private void Erase_Person(object sender, EventArgs e)
        {
            Erase_Item<Person>();
        }
        #endregion People

        #region Actions
        private void ToolStripMenuItem_Actions_Open_Click(object sender, EventArgs e)
        {
            Read_Actions();
        }
        private void ToolStripMenuItem_Actions_Create_Click(object sender, EventArgs e)
        {
            Create_Action();
        }
        private void ToolStripMenuItem_Actions_Edit_Click(object sender, EventArgs e)
        {
            Edit_Action();
        }
        private void ToolStripMenuItem_Actions_Delete_Click(object sender, EventArgs e)
        {
            Delete_Action();
        }
        private void Erase_Action(object sender, EventArgs e)
        {
            Erase_Item<Action>();
        }
        #endregion

        #region Marks
        private void ToolStripMenuItem_Marks_ٍShow_Click(object sender, EventArgs e)
        {
            Read_Marks();
        }

        private void ToolStripMenuItem_Marks_ٍAdd_Click(object sender, EventArgs e)
        {
            Create_Mark();
        }

        private void ToolStripMenuItem_Marks_ٍDelete_Click(object sender, EventArgs e)
        {
            Delete_Mark();
        }

        private void ToolStripMenuItem_Marks_ٍEdit_Click(object sender, EventArgs e)
        {
            Edit_Mark();
        }

        private void Erase_Mark(object sender, EventArgs e)
        {
            Erase_Item<Mark>();
        }
        #endregion Marks

        #region Series
        private void ToolStripMenuItem_Series_Show_Click(object sender, EventArgs e)
        {
            Read_Series();
        }
        private void ToolStripMenuItem_Series_Add_Click(object sender, EventArgs e)
        {
            Create_Series();
        }
        private void ToolStripMenuItem_Series_Edit_Click(object sender, EventArgs e)
        {
            Edit_Series();
        }
        private void ToolStripMenuItem_Series_Delete_Click(object sender, EventArgs e)
        {
            Delete_Series();
        }
        private void Erase_Series(object sender, EventArgs e)
        {
            Erase_Item<Series>();
        }

        #endregion

        #region ArtRead
        private void ToolStripMenuItem__Read_Open_Click(object sender, EventArgs e)
        {
            Read_ArtReads();

        }
        private void ToolStripMenuItem__Read_Add_Click(object sender, EventArgs e)
        {
            Create_ArtRead();
        }

        private void ToolStripMenuItem__Read_Delete_Click(object sender, EventArgs e)
        {
            Delete_ArtRead();
        }

        private void ToolStripMenuItem__Read_Edit_Click(object sender, EventArgs e)
        {
            Edit_ArtRead();
        }

        private void Erase_ArtRead(object sender, EventArgs e)
        {
            Erase_Item<ArtRead>();
        }
        #endregion ArtRead

        #region ArtToRead

        private void ToolStripMenuItem__Recommendation_Add_Click(object sender, EventArgs e)
        {
            Create_Recommendation();
        }

        private void ToolStripMenuItem__Recommendations_Show_Click(object sender, EventArgs e)
        {
            Read_Recommendations();
        }
        private void ToolStripMenuItem__Recommendations_Edit_Click(object sender, EventArgs e)
        {
            Edit_Recommendation();
        }

        private void ToolStripMenuItem__Recommendations_Delete_Click(object sender, EventArgs e)
        {
            Delete_Recommendation();
        }
        private void ToolStripMenuItem__Recommendations_Tree_Click(object sender, EventArgs e)
        {
            FORMS.Form_Recommendation form_Recommendation = new Form_Recommendation();
            var DialogResult = form_Recommendation.ShowDialog();
        }

        private void Erase_Recommendation(object sender, EventArgs e)
        {
            Erase_Item<ArtToRead>();
        }
        #endregion ArtToRead

        #region  SourceToreadAnother
        private void ToolStripMenuItem_SourceToreadAnother_Show_Click(object sender, EventArgs e)
        {
            Read_SourceToreadAnothers();
        }

        private void ToolStripMenuItem_SourceToreadAnother_Create_Click(object sender, EventArgs e)
        {
            Create_SourceToreadAnother();
        }

        private void ToolStripMenuItem_SourceToreadAnother_Edit_Click(object sender, EventArgs e)
        {
            Edit_Item<SourceToreadAnother>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }

        private void ToolStripMenuItem_SourceToreadAnother_Delete_Click(object sender, EventArgs e)
        {
            Delete_SourceToreadAnother();
        }

        private void Erase_SourceToreadAnother(object sender, EventArgs e)
        {
            Erase_Item<SourceToreadAnother>();
        }
        #endregion SourceToreadAnother

        #region Location
        private void ToolStripMenuItem_Location_Show_Click(object sender, EventArgs e)
        {
            Read_Locations();
        }

        #endregion

        #region Bibliography
        private void ToolStripMenuItem__Bibliography_Show_Click(object sender, EventArgs e)
        {

        }
        private void ToolStripMenuItem__Biblography_ِAdd_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem__Bibliography_Edit_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem__Bibliography_Delete_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #endregion entities control

        #region click
        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (current_Working_Type == typeof(Place)) ;
            else if (current_Working_Type == typeof(Language)) ToolStripMenuItem_Language_Edit_Click(sender, e);
            else if (current_Working_Type == typeof(Author)) Edit_Author();
            else if (current_Working_Type == typeof(Action)) ToolStripMenuItem_Actions_Edit_Click(sender, e);
            else if (current_Working_Type == typeof(Series)) ToolStripMenuItem_Series_Edit_Click(sender, e);
            else if (current_Working_Type == typeof(PublishingHouse)) ToolStripMenuItem_PubHouse_Edit_Click(sender, e);
            else if (current_Working_Type == typeof(City)) Edit_City();
            else if (current_Working_Type == typeof(ViewBook)) Edit_Book();
            else if (current_Working_Type == typeof(Art)) ToolStripMenuItem_Arts_Edit_Click(sender, e);
            else if (current_Working_Type == typeof(Genre)) ToolStripMenuItem_Genres_Edit_Click(sender, e);
            else if (current_Working_Type == typeof(ViewHasRead)) ToolStripMenuItem__Read_Edit_Click(sender, e);
        }
        #endregion click

        #region enable_disable_menu_items
        private void Turn_Off_Current_Menu_Item()
        {
            Turn_Menu_Item(false);
        }
        private void Turn_On_Current_Menu_Item()
        {
            Turn_Menu_Item(Is_DGV_Has_Any_Row());
        }
        private void Turn_Menu_Item(bool state)
        {

            if (current_Working_Type == typeof(Language))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Language_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Language_Delete, state);
            }
            else if (current_Working_Type == typeof(Author))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Author_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Author_Delete, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Author_Find_Arts_of_Author, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Author__Find_Recommendations, state);

            }
            else if (current_Working_Type == typeof(Action))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Actions_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Actions_Delete, state);
            }
            else if (current_Working_Type == typeof(Series))
            {

                Turn_On_Off_Menu_Item(ToolStripMenuItem_Series_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Series_Delete, state);
            }
            else if (current_Working_Type == typeof(PublishingHouse))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_PubHouse_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_PubHouse_Delete, state);
            }
            else if (current_Working_Type == typeof(City))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_City_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_City_Delete, state);
            }
            else if (current_Working_Type == typeof(ViewBook))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem__Book_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Books_Delete, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Book_Find, state);
            }
            else if (current_Working_Type == typeof(Art))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Arts_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Arts_Delete, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Arts_Add_to_HaveRead, state);

            }
            else if (current_Working_Type == typeof(Genre))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Genres_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem__Genres_Delete, state);
            }
            else if (current_Working_Type == typeof(ViewHasRead))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem__Read_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem__Read_Delete, state);

            }
            else if (current_Working_Type == typeof(Mark))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Mark_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Marks_Delete, state);
            }
            else if (current_Working_Type == typeof(BookFormat))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Book_Format_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Book_Format_Delete, state);
            }

            else if (current_Working_Type == typeof(Place))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Places_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_Places_Delele, state);
            }
            else if (current_Working_Type == typeof(Person))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_People_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_People_Delete, state);
            }
            else if (current_Working_Type == typeof(ArtToRead))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem__Recommendations_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem__Recommendations_Delete, state);
            }
            else if (current_Working_Type == typeof(SourceToreadAnother))
            {
                Turn_On_Off_Menu_Item(ToolStripMenuItem_SourceToreadAnother_Edit, state);
                Turn_On_Off_Menu_Item(ToolStripMenuItem_SourceToreadAnother_Delete, state);
            }
        }

        private void Turn_On_Off_Menu_Item(ToolStripMenuItem menu_item, bool state, ToolStripMenuItem toolStripMenuItem = null)
        {
            menu_item.Enabled = state;
            if (toolStripMenuItem is not null)
                toolStripMenuItem.Visible = state;
        }

        #endregion enable_disable_menu_items


        #region general CRUD
        private void Create_Item<T>() where T : new()
        {
            long _id = CRUD_Item_Determinator.Create_Item<T>();
            if (_id > 0)
            {
                //++ обработка особого случая отображения Book
                Type type = typeof(T);
                if (type == typeof(Book))
                    dgv_Visualisator.Refresh_DGV_for_Item_Type<ViewBook>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
                else if (type == typeof(ArtRead))
                    Read_ArtReads();
                //-- обработка особого случая отображения Book
                else dgv_Visualisator.Refresh_DGV_for_Item_Type<T>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
                General_Manipulations.Show_Row(dataGridView, _id.ToString(), "Id");
            }
        }
        private void Edit_Item<T>(long id) where T : new()
        {
            long _id = CRUD_Item_Determinator.Edit_Item_by_ID<T>(id);
            if (_id > 0)
            {
                dgv_Visualisator.Refresh_DGV_for_Item_Type<T>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
                General_Manipulations.Show_Row(dataGridView, _id.ToString(), "Id");
            }
        }
        private void Delete_Item<T>() where T : new()
        {
            long id = CRUD_Item_Determinator.Delete_Item_by_ID<T>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
            if (id > 0)
            {
                Type type = typeof(T);
                if (type == typeof(ArtRead))
                {
                    Read_ArtReads();
                }
                else
                    dgv_Visualisator.Refresh_DGV_for_Item_Type<T>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
                General_Manipulations.Show_Row(dataGridView, id.ToString(), "Id");
            }
        }

        private void Erase_Item<T>()
        {
            long id = CRUD_Item_Determinator.Erase_Item_by_ID<T>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
            last_DGV_Update_Operation();
        }
        #endregion general CRUD

        #region CRUD

        #region book CRUD
        public void Create_Book()
        {
            Create_Item<Book>();
        }
        private void Read_Books()
        {
            last_DGV_Update_Operation = Read_Books;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<ViewBook>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        public void Edit_Book()
        {
            Edit_Item<ViewBook>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_Book()
        {
            Delete_Item<ViewBook>();
        }
        #endregion

        #region author CRUD
        private void Create_Author()
        {
            Create_Item<Author>();
        }
        private void Read_Authors()
        {
            last_DGV_Update_Operation = Read_Authors;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<Author>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_Author()
        {
            Edit_Item<Author>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_Author()
        {
            Delete_Item<Author>();
        }
        #endregion

        #region city CRUD
        private void Create_City()
        {
            Create_Item<City>();
        }
        private void Read_Cities()
        {
            last_DGV_Update_Operation = Read_Cities;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<City>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_City()
        {
            Edit_Item<City>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_City()
        {
            Delete_Item<City>();
        }
        #endregion

        #region genre CRUD
        private void Create_Genre()
        {
            Create_Item<Genre>();
        }
        private void Read_Genre()
        {
            last_DGV_Update_Operation = Read_Genre;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<Genre>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_Genre()
        {
            Edit_Item<Genre>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_Genre()
        {
            Delete_Item<Genre>();
        }
        #endregion

        #region art CRUD
        private void Create_Art()
        {
            Create_Item<Art>();
        }
        private void Read_Arts()
        {
            last_DGV_Update_Operation = Read_Arts;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<Art>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_Art()
        {
            Edit_Item<Art>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_Art()
        {
            Delete_Item<Art>();
        }
        #endregion

        #region language CRUD
        private void Create_Language()
        {
            Create_Item<Language>();
        }
        private void Read_Languages()
        {
            last_DGV_Update_Operation = Read_Languages;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<Language>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_Language()
        {
            Edit_Item<Language>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_Language()
        {
            Delete_Item<Language>();
        }
        #endregion

        #region marks CRUD
        private void Create_Mark()
        {
            Create_Item<Mark>();
        }
        private void Read_Marks()
        {
            last_DGV_Update_Operation = Read_Marks;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<Mark>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_Mark()
        {
            Edit_Item<Mark>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_Mark()
        {
            Delete_Item<Mark>();
        }
        #endregion marks CRUD

        #region PublishingHouse CRUD
        private void Create_PublishingHouse()
        {
            Create_Item<PublishingHouse>();
        }
        private void Read_PublishingHouses()
        {
            last_DGV_Update_Operation = Read_PublishingHouses;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<PublishingHouse>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_PublishingHouse()
        {
            Edit_Item<PublishingHouse>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_PublishingHouse()
        {
            Delete_Item<PublishingHouse>();
        }
        #endregion

        #region Series CRUD
        private void Create_Series()
        {
            Create_Item<Series>();
        }
        private void Read_Series()
        {
            last_DGV_Update_Operation = Read_Series;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<Series>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }

        private void Edit_Series()
        {
            Edit_Item<Series>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));

        }
        private void Delete_Series()
        {
            Delete_Item<Series>();
        }
        #endregion

        #region Action CRUD
        private void Create_Action()
        {
            Create_Item<Action>();
        }
        private void Read_Actions()
        {
            last_DGV_Update_Operation = Read_Actions;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<Action>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_Action()
        {
            Edit_Item<Action>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_Action()
        {
            Delete_Item<Action>();
        }

        #endregion Action CRUD

        #region Book_Format CRUD
        private void Create_Book_Format()
        {
            Create_Item<BookFormat>();
        }
        private void Read_Book_Formats()
        {
            last_DGV_Update_Operation = Read_Book_Formats;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<BookFormat>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_Book_Format()
        {
            Edit_Item<BookFormat>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_Book_Format()
        {
            Delete_Item<BookFormat>();
        }
        #endregion Book_Format CRUD

        #region Place CRUD
        private void Create_Place()
        {
            Create_Item<Place>();
        }
        private void Read_Places()
        {
            last_DGV_Update_Operation = Read_Places;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<Place>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_Place()
        {
            Edit_Item<Place>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_Place()
        {
            Delete_Item<Place>();
        }
        #endregion Place CRUD

        #region People CRUD
        private void Create_Person()
        {
            Create_Item<Person>();
        }
        private void Read_People()
        {
            last_DGV_Update_Operation = Read_People;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<Person>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_Person()
        {
            Edit_Item<Person>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_Person()
        {
            Delete_Item<Person>();
        }
        #endregion People CRUD

        #region ArtRead CRUD
        private void Create_ArtRead()
        {
            Create_Item<ArtRead>();
        }
        private void Read_ArtReads()
        {
            last_DGV_Update_Operation = Read_ArtReads;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<ViewHasRead>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_ArtRead()
        {
            Edit_Item<ArtRead>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_ArtRead()
        {
            Delete_Item<ArtRead>();
        }
        #endregion ArtRead CRUD

        #region Recommendation CRUD
        private void Create_Recommendation()
        {
            var id = ArtToRead.Add_Recommendation(sources_saved_positions);
            if (id > 0)
            {
                Read_Recommendations();
                General_Manipulations.Show_Row(dataGridView, id.ToString(), "Id");
            }
        }
        private void Read_Recommendations()
        {
            last_DGV_Update_Operation = Read_Recommendations;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<ArtToRead>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_Recommendation()
        {
            Edit_Item<ArtToRead>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_Recommendation()
        {
            Delete_Item<ArtToRead>();
        }



        #endregion Recommendation CRUD

        #region SourceToreadAnother CRUD
        private void Create_SourceToreadAnother()
        {
            Create_Item<SourceToreadAnother>();
        }
        private void Read_SourceToreadAnothers()
        {
            last_DGV_Update_Operation = Read_SourceToreadAnothers;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<SourceToreadAnother>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_SourceToreadAnother()
        {
            Edit_Item<SourceToreadAnother>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
        }
        private void Delete_SourceToreadAnother()
        {
            Delete_Item<SourceToreadAnother>();
        }
        #endregion SourceToreadAnother CRUD

        #region Location CRUD
        private void Read_Locations()
        {
            last_DGV_Update_Operation = Read_Locations;
            dgv_Visualisator.Refresh_DGV_for_Item_Type<Location>(dataGridView, Turn_Off, Turn_ON, StatusProperty);

        }


        #endregion Location CRUD


        #region Bibliography CRUD

        private void Create_Bibliography()
        {
            Create_Item<Bibliography>();
        }
        private void Read_Bibliography()
        {
        }
        private void Edit_Read_Bibliography()
        {
            
        }
        private void Delete_Read_Bibliography()
        {
           
        }

        #endregion Bibliography CRUD

#endregion CRUD

        #region Localosation

        public List<ToolStripMenuItem> dynamic_created_controls = new List<ToolStripMenuItem>();

        private void ToolStripMenuItem_UI_Language_Changing_Click(object sender, EventArgs e)
        {
            Localization.Change_Language(this, sender.ToString(), ToolStripMenuItem_UI_Language);
            Localization.Update_Dynamic_Created_Controls(dynamic_created_controls);
            Update_Context_Menu();
            Updade_DGV_Title();
        }


        private void Initial_Langues_Menu_Load()
        {
            Localization.Initial_Langues_Form_Menu_Load(ToolStripMenuItem_UI_Language);
        }
        private void Add_for_Dynamic_Localization(ToolStripMenuItem control)
        {
            dynamic_created_controls.Add(control);
        }
        private void Updade_DGV_Title()
        {// reflection and generic
            if (StatusProperty is not null)
            {
                Type type = typeof(DGV_Visualisator);
                MethodInfo methodInfo = type.GetMethod("Prepare_DGV_For_Type");
                object classInstance = Activator.CreateInstance(type, null);
                var meth_ref = methodInfo.MakeGenericMethod(current_Working_Type);
                meth_ref.Invoke(classInstance, new object[] { dataGridView, StatusProperty });
            }
        }

        #endregion Localosation

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            Form_About form_About = new Form_About();
            form_About.ShowDialog();
        }

        private void ToolStripMenuItem_File_Open_Backup_Folder_Click(object sender, EventArgs e)
        {
            Backup.Open_Backup_Folder_in_Explorer();
        }

        private void Get_My_Books_in_Other_Hands()
        {
            last_DGV_Update_Operation = Get_My_Books_in_Other_Hands;
            //      dgv_Visualisator.Refresh_DGV_for_Item_Type<ViewMyBooksInOtherHand>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
            dataGridView.Columns.Clear();
            dgv_Visualisator.Assign_SortableBindingList_to_DGV<ViewMyBooksInOtherHand>(dataGridView, Queries_from_Views.Get_My_Books_in_Other_Hands());
            Turn_Off_Current_Menu_Item();
            dgv_Visualisator.Prepare_DGV_For_Type<ViewMyBooksInOtherHand>(dataGridView, StatusProperty);
            Current_Working_Type = typeof(ViewBook);
            Turn_On_Current_Menu_Item();
        }

        private void dataGridView_Sorted(object sender, EventArgs e)
        {
            Type type = typeof(DGV_Visualisator);
            MethodInfo methodInfo = type.GetMethod("Highlighting");
            object classInstance = Activator.CreateInstance(type, null);
            var meth_ref = methodInfo.MakeGenericMethod(current_Working_Type);
            meth_ref.Invoke(classInstance, new object[] { dataGridView });
        }

    }
}

