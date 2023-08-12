using lib_postgres.CODE;
using lib_postgres.CODE.VIEW.DELITEMS;
using lib_postgres.FORMS;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace lib_postgres
{
    public partial class Form_Main : Form
    {
        private static Type? gridViewItemType;
        public Main_Form_Status_Update StatusProperty { get; set; } = new Main_Form_Status_Update();
        const string Caption = "Lib.";
        public Dictionary<string, long> sources_saved_positions = new Dictionary<string, long>()
            {
                { "art", 1      },
                { "author", 1   },
                { "another", 1  },
            };

        DeletedEntities DelItemsColorization;
        bool is_Colorize_del_items;
        public Form_Main()
        {
            InitializeComponent();
            Binding_Elements();
            main_menu_generation();
            Backup_on_Start();
            Colorization_Prepare();
        }

        private void Colorization_Prepare()
        {
            DelItemsColorization = new DeletedEntities();
            DelItemsColorization.SetCommand(true, new DeletedItemsColorizator());
            DelItemsColorization.SetCommand(false, new NothingDo());
            is_Colorize_del_items = DeletedEntities.is_Show_Deleted_Items();
        }
        private void Backup_on_Start()
        {
            Backup.Backup_on_Start();
        }

        private void BackupBD()
        {
            Backup.BackupBD();
        }

        private long Get_Selected_Entity_ID()
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            return id;
        }


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

        private void cmi_item_add_art_to_read_Click(object sender, EventArgs e)
        {
            if (gridViewItemType == typeof(Art))
            {
                int index = dataGridView.SelectedRows[0].Index;
                long id_art = (long)dataGridView.Rows[index].Cells["Id"].Value;
                var id = PARTIAL.ArtRead.Add_ArtRead(id_art);
                if (id > 0)
                {
                    ToolStripMenuItem__Read_Open_Click(sender, e);
                    General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
                }
            }
        }
        #endregion
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
        #region main_menu
        private void main_menu_generation()
        {
            ToolStripMenuItem newItem = new ToolStripMenuItem("Где книги");
            ToolStripMenuItem_Books.DropDownItems.Add(newItem);
            var places = DB_Agent.Get_Places();
            foreach (var place in places)
            {
                ToolStripMenuItem place_item = new ToolStripMenuItem(place.Name);
                newItem.DropDownItems.Add(place_item);
                place_item.Click += show_books_in_place;
            }

            newItem = new ToolStripMenuItem("У кого мои книги");
            ToolStripMenuItem_Books.DropDownItems.Add(newItem);
            newItem.Click += get_My_Books_in_Other_Hands;


            newItem = new ToolStripMenuItem("Произведения по языкам");
            menuStrip1.Items.Add(newItem);
            var languages = DB_Agent.Get_Languages();
            var arts = DB_Agent.Get_Arts();
            foreach (var language in languages)
            {
                ToolStripMenuItem language_item = new ToolStripMenuItem(language.Name);
                newItem.DropDownItems.Add(language_item);
                language_item.Click += show_arts_by_langue;
            }



        }

        //для main_menu_generation
        void show_books_in_place(object sender, EventArgs e)
        {
            dataGridView.DataSource = Queries_LinQ.Get_Books_by_Place_Name(((ToolStripMenuItem)sender).Text);
        }

        //для main_menu_generation
        void show_arts_by_langue(object sender, EventArgs e)
        {
            var Get_Languages = DB_Agent.Get_Languages();
            var arts = DB_Agent.Get_Arts();
            var items = (
                         from a in arts
                         where a.OrigLanguage ==
                        (from l in Get_Languages
                         where l.Name == ((ToolStripMenuItem)sender).Text
                         select l).First().Id
                         select a).ToList();
            dataGridView.DataSource = items;
        }

        void get_My_Books_in_Other_Hands(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.DataSource = Queries_from_Views.Get_My_Books_in_Other_Hands();
            Turn_Off_Current_Menu_Item();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<ViewMyBooksInOtherHand>(dataGridView, StatusProperty);
            Turn_On_Current_Menu_Item();
        }

        #endregion

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
            Refresh_DGV_for_Item_Type<Author>();

        }

        private void ToolStripMenuItem_Author_Add_Click(object sender, EventArgs e)
        {
            Create_Author();
        }
        #endregion

        #region Art

        private void ToolStripMenuItem_Arts_Show_Click(object sender, EventArgs e)
        {
            Refresh_DGV_for_Item_Type<Art>();
        }
        private void ToolStripMenuItem_Arts_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Art.Add_Art();
            if (id > 0)
            {
                Refresh_DGV_for_Item_Type<Art>();
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");//ToString() - костыль, переписать всё для id
            }
        }

        private void ToolStripMenuItem_Arts_Edit_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Art.Edit_Art(dataGridView);
            if (id > 0)
            {
                Refresh_DGV_for_Item_Type<Art>();
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");//ToString() - костыль, переписать всё для id
            }
        }

        #endregion

        #region Language
        private void ToolStripMenuItem_Language_Show_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.DataSource = DB_Agent.Get_Languages();
            Turn_Off_Current_Menu_Item();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Language>(dataGridView, StatusProperty);
            Turn_On_Current_Menu_Item();
        }

        private void ToolStripMenuItem_Language_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Language.Add_Language();
            if (id > 0)
            {
                ToolStripMenuItem_Language_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }
        private void ToolStripMenuItem_Language_Edit_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Language.Edit_Language(dataGridView);
            if (id > 0)
            {
                ToolStripMenuItem_Language_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }

        #endregion

        #region Book
        private void ToolStripMenuItem_Book_Add_Click(object sender, EventArgs e)
        {
            Create_Book();
        }
        private void ToolStripMenuItem_Book_Show_Click(object sender, EventArgs e)
        {
            Refresh_DGV_for_Item_Type<ViewBook>();
        }

        private void ToolStripMenuItem__Book_Edit_Click(object sender, EventArgs e)
        {
            Edit_Book();
        }

        #endregion


        #region PubHouse


        private void ToolStripMenuItem_PubHouse_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.PublishingHouse.Add_PubHouse();
            if (id > 0)
            {
                ToolStripMenuItem_PubHouse_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_PubHouse_Show_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.DataSource = DB_Agent.Get_Publishing_Houses();
            Turn_Off_Current_Menu_Item();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<PublishingHouse>(dataGridView, StatusProperty);
            Turn_On_Current_Menu_Item();
        }

        private void ToolStripMenuItem_PubHouse_Edit_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.PublishingHouse.Edit_PubHouse(dataGridView);
            if (id > 0)
            {
                ToolStripMenuItem_PubHouse_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }
        #endregion

        #region City

        private void ToolStripMenuItem__City_Show_Click(object sender, EventArgs e)
        {
            Refresh_DGV_for_Item_Type<City>();
        }

        private void ToolStripMenuItem_City_Add_Click(object sender, EventArgs e)
        {
            Create_City();
        }

        private void ToolStripMenuItem_City_Edit_Click(object sender, EventArgs e)
        {
            Edit_City();
        }
        #endregion

        #region Actions
        private void ToolStripMenuItem_Actions_Open_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.DataSource = DB_Agent.Get_Actions();
            Turn_Off_Current_Menu_Item();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Action>(dataGridView, StatusProperty);
            Turn_On_Current_Menu_Item();
        }

        private void ToolStripMenuItem_Actions_Create_Click(object sender, EventArgs e)
        {
            long action_id = PARTIAL.Action.Add_Action();
            if (action_id > 0)
            {
                ToolStripMenuItem_Actions_Open_Click(sender, e);
                General_Manipulations.show_row(dataGridView, action_id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_Actions_Edit_Click(object sender, EventArgs e)
        {
            long action_id = PARTIAL.Action.Edit_Action(dataGridView);
            if (action_id > 0)
            {
                ToolStripMenuItem_Actions_Open_Click(sender, e);
                General_Manipulations.show_row(dataGridView, action_id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_Location_Show_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = CODE.Queries_LinQ.Get_Locations();
        }
        #endregion

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


        #region Read

        private void ToolStripMenuItem__Read_Open_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.DataSource = DB_Agent.Get_ViewHasReads();
            Turn_Off_Current_Menu_Item();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<ViewHasRead>(dataGridView, StatusProperty);
            Turn_On_Current_Menu_Item();
            Colorise_DGV();
        }

        private void Colorise_DGV()
        {
            var formats = DB_Agent.Get_BookFormats();
            var marks = DB_Agent.Get_Marks();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var format_color_id = (from f in formats
                                       where f.Name == row.Cells["Формат"].Value.ToString()
                                       select f.Id).First();
                row.DefaultCellStyle.BackColor = lib_postgres.CODE.Data.format_colors[format_color_id];
                var mark_color_id = (from m in marks
                                     where m.Name == row.Cells["Оценка"].Value.ToString()
                                     select m.Id).First();
                if (mark_color_id < 4 || mark_color_id > 6)
                    row.Cells["Оценка"].Style.BackColor = lib_postgres.CODE.Data.marks_colors[mark_color_id];
            }

        }

        private void ToolStripMenuItem__Read_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.ArtRead.Add_ArtRead();
            if (id > 0)
            {
                ToolStripMenuItem__Read_Open_Click(sender, e);
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem__Read_Edit_Click(object sender, EventArgs e)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            id = PARTIAL.ArtRead.Edit_ArtRead(id);
            if (id > 0)
            {
                ToolStripMenuItem__Read_Open_Click(sender, e);
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }
        #endregion

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridViewItemType == typeof(Place)) ;
            else if (gridViewItemType == typeof(Language)) ToolStripMenuItem_Language_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(Author))    Edit_Author();
            else if (gridViewItemType == typeof(Action)) ToolStripMenuItem_Actions_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(Series)) ToolStripMenuItem_Series_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(PublishingHouse)) ToolStripMenuItem_PubHouse_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(City))      Edit_City();
            else if (gridViewItemType == typeof(ViewBook))  Edit_Book();
            else if (gridViewItemType == typeof(Art)) ToolStripMenuItem_Arts_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(Genre)) ToolStripMenuItem_Genres_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(ViewHasRead)) ToolStripMenuItem__Read_Edit_Click(sender, e);
        }


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
            if (gridViewItemType == typeof(Place)) ;
            else if (gridViewItemType == typeof(Language)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Language_Edit, state);
            else if (gridViewItemType == typeof(Author)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Author_Edit, state);
            else if (gridViewItemType == typeof(Action)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Actions_Edit, state);
            else if (gridViewItemType == typeof(Series)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Series_Edit, state);
            else if (gridViewItemType == typeof(PublishingHouse)) Turn_On_Off_Menu_Item(ToolStripMenuItem_PubHouse_Edit, state);
            else if (gridViewItemType == typeof(City)) Turn_On_Off_Menu_Item(ToolStripMenuItem_City_Edit, state);
            else if (gridViewItemType == typeof(ViewBook)) Turn_On_Off_Menu_Item(ToolStripMenuItem__Book_Edit, state, cmi_item_find_book);
            else if (gridViewItemType == typeof(Art)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Arts_Edit, state, cmi_item_add_art_to_read); //ToolStripMenuItem_Book_Add
            else if (gridViewItemType == typeof(Genre)) Turn_On_Off_Menu_Item(ToolStripMenuItem_Genres_Edit, state);
            else if (gridViewItemType == typeof(ViewHasRead)) Turn_On_Off_Menu_Item(ToolStripMenuItem__Read_Edit, state);
        }

        private void Turn_On_Off_Menu_Item(ToolStripMenuItem menu_item, bool state, ToolStripMenuItem toolStripMenuItem = null)
        {
            menu_item.Enabled = state;
            if (toolStripMenuItem is not null)
                toolStripMenuItem.Visible = state;
        }

        #endregion

        private void ToolStripMenuItem__Recommendation_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.ArtToRead.Add_Recommendation(sources_saved_positions);
            if (id > 0)
            {
                ToolStripMenuItem__Recommendations_Show_Click(sender, e);
                //   General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem__Recommendations_Show_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = CODE.Queries_LinQ.Get_Recommendations();
        }

        private void ToolStripMenuItem__Recommendations_Tree_Click(object sender, EventArgs e)
        {
            FORMS.Form_Recommendation form_Recommendation = new Form_Recommendation();
            var DialogResult = form_Recommendation.ShowDialog();
        }

        private void ToolStripMenuItem_File_BackupBD_Click(object sender, EventArgs e)
        {
            BackupBD();
        }

        private void ToolStripMenuItem_File_Open_Settings_Click(object sender, EventArgs e)
        {

            Form_Settings form_Settings = new Form_Settings();
            DialogResult dialogResult = form_Settings.ShowDialog();
            if (dialogResult != DialogResult.OK) return;

            Backup.Set_Value_Backup_on_Start(form_Settings.ChB_Backup_on_Start.Checked);

            DeletedEntities.Set_Value_Show_Deleted(form_Settings.ChB_Show_Deleted_Entities.Checked);
            is_Colorize_del_items = form_Settings.ChB_Show_Deleted_Entities.Checked;
            if (gridViewItemType == typeof(ViewBook))
                Refresh_DGV_for_Item_Type<ViewBook>();
        }

        private void ToolStripMenuItem_Books_Delete_Click(object sender, EventArgs e)
        {
            Delete_Book();
        }


        private void Form_Main_Shown(object sender, EventArgs e)
        {
            Refresh_DGV_for_Item_Type<ViewBook>();
        }

        private void ToolStripMenuItem_Arts_Delete_Click(object sender, EventArgs e)
        {
            Delete_Item<Art>();
        }

        private void ToolStripMenuItem_City_Delete_Click(object sender, EventArgs e)
        {
            Delete_City();
        }

        private void ToolStripMenuItem_Author_Delete_Click(object sender, EventArgs e)
        {
            Delete_Author();
        }

        private void Refresh_DGV_for_Item_Type<T>()
        {
            dataGridView.Columns.Clear();
            dataGridView.DataSource = CODE.CRUD.CRUD_Item_Determinator.Get_All_Items_List_by_Type<T>();
            Turn_Off_Current_Menu_Item();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<T>(dataGridView, StatusProperty);
            List<long> deleted_IDs = CODE.CRUD.CRUD_Item_Determinator.Get_Deleted_Items_IDs<T>();
            DelItemsColorization.RunCommand(is_Colorize_del_items, deleted_IDs, dataGridView);
            Turn_On_Current_Menu_Item();
        }

        #region general CRUD
        private void Create_Item<T>()
        {
            long _id = CODE.CRUD.CRUD_Item_Determinator.Create_Item<T>();
            if (_id > 0)
            {
                Refresh_DGV_for_Item_Type<T>();
                General_Manipulations.show_row(dataGridView, _id.ToString(), "Id");
            }
        }
        private void Edit_Item<T>(long id)
        {
            long _id = CODE.CRUD.CRUD_Item_Determinator.Edit_Item_by_ID<T>(id);
            if (_id > 0)
            {
                Refresh_DGV_for_Item_Type<T>();
                General_Manipulations.show_row(dataGridView, _id.ToString(), "Id");
            }
        }
        private void Delete_Item<T>()
        {
            long id = CODE.CRUD.CRUD_Item_Determinator.Delete_Item_by_ID<T>(Get_Selected_Entity_ID());
            if (id > 0)
            {
                Refresh_DGV_for_Item_Type<T>();
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }
        #endregion general CRUD

        #region CRUD

        #region book CRUD
        private void Create_Book()
        {
          //  Create_Item<ViewBook>(Queries_from_Views.Get_Books());
            long book_id = PARTIAL.Book.Create_Book();
            if (book_id > 0)
            {
                Refresh_DGV_for_Item_Type<ViewBook>();
                General_Manipulations.show_row(dataGridView, book_id.ToString(), "Id");
            }
        }
        private void Edit_Book()
        {
            Edit_Item<ViewBook>(Get_Selected_Entity_ID());
        }

        private void Delete_Book()
        {
            Delete_Item<ViewBook>();
        }
        #endregion

        #region author CRUD
        private void Create_Author()
        {
            var id = PARTIAL.Author.Add_Author();
            if (id > 0)
            {
                Refresh_DGV_for_Item_Type<Author>();
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }

        private void Edit_Author()
        {
            Edit_Item<Author>(Get_Selected_Entity_ID());
        }

        private void Delete_Author()
        {
            Delete_Item<Author>();
        }
        #endregion

        #region city CRUD
        private void Create_City()
        {
            var id = PARTIAL.City.Add_City();
            if (id > 0)
            {
                Refresh_DGV_for_Item_Type<City>();
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
        }
        private void Edit_City()
        {
            var id = PARTIAL.City.Edit_City(dataGridView);
            if (id > 0)
            {
                Refresh_DGV_for_Item_Type<City>();
                General_Manipulations.show_row(dataGridView, id.ToString(), "Id");
            }
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
            Refresh_DGV_for_Item_Type<Genre>();
        }

        private void Edit_Genre()
        {
            Edit_Item<Genre>(Get_Selected_Entity_ID());
        }
        private void Delete_Genre()
        {
            Delete_Item<Genre>();
        }
        #endregion

        #region art CRUD
        private void Create_Art()
        {

        }
        private void Edit_Art()
        {

        }
        private void Delete_Art()
        {

        }
        #endregion

        #region language CRUD
        private void Create_Language()
        {

        }
        private void Edit_Language()
        {

        }
        private void Delete_Language()
        {

        }
        #endregion

        #region PublishingHouse CRUD
        private void Create_PublishingHouse()
        {

        }
        private void Edit_PublishingHouse()
        {

        }
        private void Delete_PublishingHouse()
        {

        }
        #endregion

        #region Series CRUD
        private void Create_Series()
        {
            Create_Item<Series>();
        }
        private void Read_Series()
        {
                Refresh_DGV_for_Item_Type<Series>();
        }

        private void Edit_Series()
        {
            Edit_Item<Series>(Get_Selected_Entity_ID());

        }
        private void Delete_Series()
        {
            Delete_Item<Series>();
        }
        #endregion

        #endregion CRUD



 
    }
}
