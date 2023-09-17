using lib_postgres.CODE;
using lib_postgres.CODE.DEPLOY;
using lib_postgres.CODE.VIEW.DELITEMS;
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

namespace lib_postgres
{
    public partial class Form_Main : Form
    {
        private static Type? gridViewItemType;
        public Main_Form_Status_Update StatusProperty { get; set; } = new Main_Form_Status_Update();
        const string Caption = "Lib.";
        public Dictionary<string, long> sources_saved_positions = new Dictionary<string, long>()
            {// for faster preparation recommendation form it remembers  last choise to show it again
                { "art_to_read",    1  },
                { "author_to_read", 1  },
                { "art",    1  },
                { "author", 1  },
                { "another",1  },
            };
        DGV_Visualisator dgv_Visualisator;
        public DGV_Visualisator.Turn_Off_or_ON_Current_Menu_Item Turn_Off;
        public DGV_Visualisator.Turn_Off_or_ON_Current_Menu_Item Turn_ON;

        private Deploy deploy = new Deploy();
        public Form_Main()
        {
            InitializeComponent();
            Binding_Elements();
            main_menu_generation();
            this.dgv_Visualisator = new DGV_Visualisator();
            Turn_Off = delegate () { this.Turn_Off_Current_Menu_Item(); };
            Turn_ON = delegate () { this.Turn_On_Current_Menu_Item(); };
        }

        #region general

        private void Form_Main_Shown(object sender, EventArgs e)
        {
            Type type = typeof(ViewBook);
            GridViewItemType = type;
            Read_Books();
            Turn_On_Current_Menu_Item();

        }

        private void Backup_on_Start()
        {
            Backup.Backup_on_Start();
        }

        private void BackupBD()
        {
            Backup.BackupBD();
        }

        #endregion general 

        #region popup
        private void Cmi_item_find_book_Click(object? sender, EventArgs e)
        {
            if (gridViewItemType == typeof(ViewBook))
            {
                int index = dataGridView.SelectedRows[0].Index;
                long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
                Form_Report form_report = new Form_Report();
                form_report.Text = (string)dataGridView.Rows[index].Cells["Название"].Value + " / " + (string)dataGridView.Rows[index].Cells["АвторЫ"].Value;
                form_report.DGV.DataSource = CODE.Queries_SQL_Direct.Fill_DataTable_by_Query_with_Parameter
                    <long>(DB_Agent.Get_Query(2).Text, ":book_id_parameter", id);
                var DialogResult = form_report.ShowDialog();
                if (DialogResult != DialogResult.OK)
                    return;
            }
        }
        // adding contextly to read-list is temporary out of order
        /*        private void cmi_item_add_art_to_read_Click(object sender, EventArgs e)
                {
                    if (gridViewItemType == typeof(Art))
                    {
                        int index = dataGridView.SelectedRows[0].Index;
                        long id_art = (long)dataGridView.Rows[index].Cells["Id"].Value;
                        var id = ArtRead.Create_Item(id_art);
                        if (id > 0)
                        {
                            ToolStripMenuItem__Read_Open_Click(sender, e);
                            General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
                        }
                    }
                }*/
        #endregion

        #region additional
        private void Binding_Elements()
        {
            GridViewItemType = null;
            this.DataBindings.Add("Text", StatusProperty, "Message");
            //     this.DataBindings.Add("ToolStripMenuItem__Book_Edit.Enabled", StatusProperty, "ToolStripMenuItem__Book_Edit");

        }

        public static Type? GridViewItemType
        {
            get { return gridViewItemType; }
            set
            {
                gridViewItemType = value;
            }
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
            newItem.GetHashCode();
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
        }
        private void ToolStripMenuItem_File_Open_Settings_Click(object sender, EventArgs e)
        {
            Form_Settings form_Settings = new Form_Settings();
            DialogResult dialogResult = form_Settings.ShowDialog();
            if (dialogResult != DialogResult.OK) return;

            Backup.Set_Value_Backup_on_Start(form_Settings.ChB_Backup_on_Start.Checked);
            // save new deleted_elements visualisation into object property
            dgv_Visualisator.deleted_Entities_Visuaisator.Is_Colorize_deleted_items = form_Settings.ChB_Show_Deleted_Entities.Checked;
            // save new deleted_elements visualisation to INI file
            dgv_Visualisator.deleted_Entities_Visuaisator.Write_Value_isShow_Deleted_to_INI_File();

            if (gridViewItemType == typeof(ViewBook))
                dgv_Visualisator.Refresh_DGV_for_Item_Type<ViewBook>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        void show_arts_by_langue(object sender, EventArgs e)
        {
            List<Art_and_Author> arts = CODE.Queries_LinQ.Get_Arts_by_LanguageName(((ToolStripMenuItem)sender).Text);
            // ++ sept 2023
            // Pasted from DGV_Visualisator.Refresh_DGV_for_Item_Type
            // for special projection of selection for languages
            // added for better view in DGV
            dataGridView.Columns.Clear();
            dataGridView.DataSource = arts;
            Turn_Off_Current_Menu_Item();
            dgv_Visualisator.Prepare_DGV_For_Type<Art>(dataGridView, StatusProperty);
            //++ colorization of deleted elements 
            List<long> deleted_IDs = CODE.CRUD.CRUD_Item_Determinator.Get_Deleted_Items_IDs<Art>();
            dgv_Visualisator.deleted_Entities_Visuaisator.RunCommand(deleted_IDs, dataGridView);
            //-- colorization of deleted elements
            Turn_On_Current_Menu_Item();
            //-- sept 2023
        }
        void get_My_Books_in_Other_Hands(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.DataSource = Queries_from_Views.Get_My_Books_in_Other_Hands();
            Turn_Off_Current_Menu_Item();
            dgv_Visualisator.Prepare_DGV_For_Type<ViewMyBooksInOtherHand>(dataGridView, StatusProperty);
            Turn_On_Current_Menu_Item();
        }
        void show_books_in_place(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.DataSource = Queries_LinQ.Get_Books_by_Place_Name(((ToolStripMenuItem)sender).Text);
            dgv_Visualisator.Refresh_DGV_for_Get_Books_by_Place_Name(dataGridView);
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
        #endregion

        #region Book
        private void ToolStripMenuItem_Book_Add_Click(object sender, EventArgs e)
        {
            Create_Book();
        }
        private void ToolStripMenuItem_Book_Show_Click(object sender, EventArgs e)
        {
            Read_Books();
        }
        private void ToolStripMenuItem__Book_Edit_Click(object sender, EventArgs e)
        {
            Edit_Book();
        }
        private void ToolStripMenuItem_Books_Delete_Click(object sender, EventArgs e)
        {
            Delete_Book();
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
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            id = ArtRead.Edit_ArtRead(id);
            if (id > 0)
            {
                ToolStripMenuItem__Read_Open_Click(sender, e);
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }
        #endregion ArtRead

        #region recommendations

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

        #endregion recommendations

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
        #endregion SourceToreadAnother

        #region Location
        private void ToolStripMenuItem_Location_Show_Click(object sender, EventArgs e)
        {
            Read_Locations();
        }

        #endregion

        #endregion entities control

        #region click
        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridViewItemType == typeof(Place)) ;
            else if (gridViewItemType == typeof(Language)) ToolStripMenuItem_Language_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(Author)) Edit_Author();
            else if (gridViewItemType == typeof(Action)) ToolStripMenuItem_Actions_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(Series)) ToolStripMenuItem_Series_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(PublishingHouse)) ToolStripMenuItem_PubHouse_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(City)) Edit_City();
            else if (gridViewItemType == typeof(ViewBook)) Edit_Book();
            else if (gridViewItemType == typeof(Art)) ToolStripMenuItem_Arts_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(Genre)) ToolStripMenuItem_Genres_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(ViewHasRead)) ToolStripMenuItem__Read_Edit_Click(sender, e);
        }
        #endregion click

        #region enable_disable_menu_items
        private void Turn_Off_Current_Menu_Item()
        {
            Turn_Menu_Item(false);
        }
        private void Turn_On_Current_Menu_Item()
        {
            Turn_Menu_Item(true);
        }
        private void Turn_Menu_Item(bool state)
        {

            if (gridViewItemType == typeof(Language)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Language_Edit, state);
            else if (gridViewItemType == typeof(Author)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Author_Edit, state);
            else if (gridViewItemType == typeof(Action)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Actions_Edit, state);
            else if (gridViewItemType == typeof(Series)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Series_Edit, state);
            else if (gridViewItemType == typeof(PublishingHouse)) Turn_On_Off_Menu_Item(ToolStripMenuItem_PubHouse_Edit, state);
            else if (gridViewItemType == typeof(City)) Turn_On_Off_Menu_Item(ToolStripMenuItem_City_Edit, state);
            else if (gridViewItemType == typeof(ViewBook)) Turn_On_Off_Menu_Item(ToolStripMenuItem__Book_Edit, state, cmi_item_find_book);
            else if (gridViewItemType == typeof(Art)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Arts_Edit, state, cmi_item_add_art_to_read); //ToolStripMenuItem_Book_Add
            else if (gridViewItemType == typeof(Genre)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Genres_Edit, state);
            else if (gridViewItemType == typeof(ViewHasRead)) Turn_On_Off_Menu_Item(ToolStripMenuItem__Read_Edit, state);
            else if (gridViewItemType == typeof(Mark)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Marks_ٍEdit, state);
            else if (gridViewItemType == typeof(BookFormat)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Book_Format_Edit, state);
            else if (gridViewItemType == typeof(Place)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Places_Edit, state);
            else if (gridViewItemType == typeof(Person)) Turn_On_Off_Menu_Item(ToolStripMenuItem_People_Edit, state);
            else if (gridViewItemType == typeof(ArtToRead)) Turn_On_Off_Menu_Item(ToolStripMenuItem__Recommendations_Edit, state);
            else if (gridViewItemType == typeof(SourceToreadAnother)) Turn_On_Off_Menu_Item(ToolStripMenuItem_SourceToreadAnother_Edit, state);
        }

        private void Turn_On_Off_Menu_Item(ToolStripMenuItem menu_item, bool state, ToolStripMenuItem toolStripMenuItem = null)
        {
            menu_item.Enabled = state;
            if (toolStripMenuItem is not null)
                toolStripMenuItem.Visible = state;
        }

        #endregion enable_disable_menu_items


        #region general CRUD
        private void Create_Item<T>()
        {
            long _id = CODE.CRUD.CRUD_Item_Determinator.Create_Item<T>();
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
                General_Manipulations.show_row(dataGridView, _id.ToString(), "Id");
            }
        }
        private void Edit_Item<T>(long id)
        {
            long _id = CODE.CRUD.CRUD_Item_Determinator.Edit_Item_by_ID<T>(id);
            if (_id > 0)
            {
                dgv_Visualisator.Refresh_DGV_for_Item_Type<T>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
                General_Manipulations.show_row(dataGridView, _id.ToString(), "Id");
            }
        }
        private void Delete_Item<T>()
        {
            long id = CODE.CRUD.CRUD_Item_Determinator.Delete_Item_by_ID<T>(dgv_Visualisator.Get_Selected_Entity_ID(dataGridView));
            if (id > 0)
            {
                Type type = typeof(T);
                if (type == typeof(ArtRead))
                {
                    Read_ArtReads();
                }
                else
                    dgv_Visualisator.Refresh_DGV_for_Item_Type<T>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }
        #endregion general CRUD

        #region CRUD

        #region book CRUD
        private void Create_Book()
        {
            Create_Item<Book>();
        }
        private void Read_Books()
        {
            dgv_Visualisator.Refresh_DGV_for_Item_Type<ViewBook>(dataGridView, Turn_Off, Turn_ON, StatusProperty);
        }
        private void Edit_Book()
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
            dataGridView.Columns.Clear();
            dataGridView.DataSource = DB_Agent.Get_ViewHasReads();
            Turn_Off_Current_Menu_Item();
            dgv_Visualisator.Prepare_DGV_For_Type<ViewHasRead>(dataGridView, StatusProperty);
            Turn_On_Current_Menu_Item();
            dgv_Visualisator.Colorise_DGV(dataGridView);
            List<long> deleted_IDs = CODE.CRUD.CRUD_Item_Determinator.Get_Deleted_Items_IDs<ArtRead>();
            dgv_Visualisator.deleted_Entities_Visuaisator.RunCommand(deleted_IDs, dataGridView);
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
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }
        private void Read_Recommendations()
        {
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
            dgv_Visualisator.Refresh_DGV_for_Item_Type<Location>(dataGridView, Turn_Off, Turn_ON, StatusProperty);

        }


        #endregion Location CRUD

        #endregion CRUD

        private void ToolStripMenuItem__Recommend_Vis_Graphviz_Click(object sender, EventArgs e)
        {
            FORMS.Form_Graphviz form_graphviz = new lib_postgres.FORMS.Form_Graphviz();
            var DialogResult = form_graphviz.ShowDialog();

        }

        #region Localosation

        public List<ToolStripMenuItem> dynamic_created_controls = new List<ToolStripMenuItem>();

        private void ToolStripMenuItem_UI_Language_Changing_Click(object sender, EventArgs e)
        {
            Localization.Change_Language(this, sender.ToString(), ToolStripMenuItem_UI_Language);
            Localization.Update_Dynamic_Created_Controls(dynamic_created_controls);
        }
         
        private void Initial_Langues_Menu_Load()
        {
            Localization.Initial_Langues_Form_Menu_Load(ToolStripMenuItem_UI_Language);
        }
        private void Add_for_Dynamic_Localization(ToolStripMenuItem control)
        {
            dynamic_created_controls.Add(control);
        }


        #endregion Localosation
        private void ToolStripMenuItem_File_Delete_DB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                   "Вы действительно хотите безвозвратно удалить базу даннаых?" +
                   "После этого работа с программой будет завершена",
                   "Предупреждение",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning,
                   MessageBoxDefaultButton.Button2,
                   MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Deploy.Drop_BD();
                Application.Restart();

            }



        }
    }
}

