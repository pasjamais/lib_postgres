using lib_postgres.CODE;
using lib_postgres.FORMS;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using System.Windows.Forms;


namespace lib_postgres
{
    public partial class Form1 : Form
    {
        private static Type? gridViewItemType;
        public Main_Form_Status_Update StatusProperty { get; set; } = new Main_Form_Status_Update();
        const string Caption = "Lib.";
        public Form1()
        {
            InitializeComponent();
            Binding_Elements();
            main_menu_generation();
            ToolStripMenuItem_Book_Show_Click(this, null);
        }

        private void Binding_Elements()
        {
            GridViewItemType = null;
            this.DataBindings.Add("Text", StatusProperty, "Message");
       //     this.DataBindings.Add("ToolStripMenuItem__Book_Edit.Enabled", StatusProperty, "ToolStripMenuItem__Book_Edit");



        }

        public static Type? GridViewItemType
        {
            get { return gridViewItemType; }
            set {
 
                gridViewItemType = value; }
        }
        public override string Text
        {
            get => base.Text;
            set => base.Text = Caption + value;
        }

        private void main_menu_generation()
        {
            ToolStripMenuItem newItem = new ToolStripMenuItem("��� �����");
            menuStrip1.Items.Add(newItem);
            var places = DB_Agent.Get_Places();
            foreach (var place in places)
            {
                ToolStripMenuItem place_item = new ToolStripMenuItem(place.Name);
                newItem.DropDownItems.Add(place_item);
                place_item.Click += show_books_in_place;
            }

            newItem = new ToolStripMenuItem("ViewArt �� ������");
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

        //��� main_menu_generation
        void show_books_in_place(object sender, EventArgs e)
        {
            var places = DB_Agent.Get_Places();
            var authors = DB_Agent.Get_Authors();
            var authors_arts = DB_Agent.Get_AuthorArts();
            var languages = DB_Agent.Get_Languages();
            var arts = DB_Agent.Get_Arts();
            var locations = DB_Agent.Get_Locations();
            var books = DB_Agent.Get_Real_Books();
            var genres = DB_Agent.Get_Genres();
            var pubhouse = DB_Agent.Get_Publishing_Houses();
            var cities = DB_Agent.Get_Cities();

            // �������� � ������
            var arts_authors = (from art in arts
                                join aa in authors_arts on art.Id equals aa.Art
                                join aut in authors on aa.Author equals aut.Id
                                group aut by new { art } into g
                                select new
                                {
                                    art_name = g.Key.art.Name,
                                    art_id = g.Key.art.Id,
                                    art_genre = g.Key.art.Genre,
                                    lan_orig = g.Key.art.OrigLanguage,
                                    authors_concat = String.Join(",", g.Select(x => x.Name))
                                }).ToList();
            // �� ���������
            var items = (from loc in locations
                         join boo in books on loc.Book equals boo.Id
                         join art in arts_authors on boo.IdArt equals art.art_id
                         join pub in pubhouse on boo.IdPublishingHouse equals pub.Id
                         join cit in cities on boo.IdCity equals cit.Id
                         join lan_boo in languages on boo.IdLanguage equals lan_boo.Id
                         join pla in places on loc.Place equals pla.Id
                         join gen in genres on art.art_genre equals gen.Id
                         join lan_orig in languages on art.lan_orig equals lan_orig.Id
                         where pla.Name == ((ToolStripMenuItem)sender).Text
                         select new
                         {
                             ���������� = pla.Name ?? "",
                             book_id = boo.Id.ToString() ?? "",
                             �������� = art.art_name ?? "",
                             �����_� = art.authors_concat ?? "",
                             ���� = gen.Name ?? "",
                             ���_������� = boo.PublicationYear.Value.Year.ToString() ?? "",
                             ������������ = pub.Name ?? "",
                             ����� = cit.Name ?? "",
                             ������� = boo.Pages.ToString() ?? "",
                             ���� = boo.Code ?? "",
                             ����_������� = lan_boo.Name ?? "",
                             ����_��������� = lan_orig.Name ?? ""
                         }).ToList();
            dataGridView1.DataSource = items;
        }

        //��� main_menu_generation
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
            dataGridView1.DataSource = items;
        }
       
        #region Genre
        private void ToolStripMenuItem_Genres_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DB_Agent.Get_Genres();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Genre>(dataGridView1, StatusProperty);
        }
        private void ToolStripMenuItem_Genres_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Genre.Add_Genre();
            if (id > 0)
            {
                ToolStripMenuItem_Genres_Show_Click( sender,  e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }

        }
        private void ToolStripMenuItem_Genres_Edit_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Genre.Edit_Genre(dataGridView1);
            if (id > 0)
            {
                ToolStripMenuItem_Genres_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }
        #endregion

        #region Authors
        private void ToolStripMenuItem_Author_Edit_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Author.Edit_Author(dataGridView1);
            if (id > 0)
            {
                ToolStripMenuItem_Autors_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_Autors_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DB_Agent.Get_Authors();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Author>(dataGridView1, StatusProperty);
        }

        private void ToolStripMenuItem_Author_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Author.Add_Author();
            if (id > 0)
            {
                ToolStripMenuItem_Autors_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }
        #endregion

        #region Art

        private void ToolStripMenuItem_Arts_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = CODE.Code_Queries.Get_Arts();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Art>(dataGridView1, StatusProperty);
        }
        private void ToolStripMenuItem_Arts_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Art.Add_Art();
            if (id > 0)
            {
                ToolStripMenuItem_Arts_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");//ToString() - �������, ���������� �� ��� id
            }
        }

        private void ToolStripMenuItem_Arts_Edit_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Art.Edit_Art(dataGridView1);
            if (id > 0)
            {
                ToolStripMenuItem_Arts_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");//ToString() - �������, ���������� �� ��� id
            }
        }

        #endregion

        #region Language
        private void ToolStripMenuItem_Language_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DB_Agent.Get_Languages();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Language>(dataGridView1, StatusProperty);
        }

        private void ToolStripMenuItem_Language_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Language.Add_Language();
            if (id > 0)
            {
                ToolStripMenuItem_Language_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }
        private void ToolStripMenuItem_Language_Edit_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Language.Edit_Language(dataGridView1);
            if (id > 0)
            {
                ToolStripMenuItem_Language_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }

        #endregion

        #region Book
        private void ToolStripMenuItem_Book_Add_Click(object sender, EventArgs e)
        {
            long book_id = PARTIAL.Book.Add_Book();
            if (book_id > 0)
            {
                ToolStripMenuItem_Book_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, book_id.ToString(), "Id");
            }
        }
        private void ToolStripMenuItem_Book_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DB_Agent.Get_Books_Special_View();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<ViewBook>(dataGridView1, StatusProperty);
        }

        private void ToolStripMenuItem__Book_Edit_Click(object sender, EventArgs e)
        {
            long book_id = PARTIAL.Book.Edit_Book(dataGridView1);
            if (book_id > 0)
            {
                ToolStripMenuItem_Book_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, book_id.ToString(), "Id");
            }
        }

        #endregion
        

        #region PubHouse


        private void ToolStripMenuItem_PubHouse_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.PublishingHouse.Add_PubHouse(); 
            if (id > 0)
            {
                ToolStripMenuItem_PubHouse_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_PubHouse_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DB_Agent.Get_Publishing_Houses();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<PublishingHouse>(dataGridView1, StatusProperty);

        }

        private void ToolStripMenuItem_PubHouse_Edit_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.PublishingHouse.Edit_PubHouse(dataGridView1);
            if (id > 0)
            {
                ToolStripMenuItem_PubHouse_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }
        #endregion

        #region City

        private void ToolStripMenuItem__City_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DB_Agent.Get_Cities();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<City>(dataGridView1, StatusProperty);
        }

        private void ToolStripMenuItem_City_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.City.Add_City();
            if (id > 0)
            {
                ToolStripMenuItem__City_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_City_Edit_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.City.Edit_City(dataGridView1);
            if (id > 0)
            {
                ToolStripMenuItem__City_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }
        #endregion

        #region Actions
        private void ToolStripMenuItem_Actions_Open_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DB_Agent.Get_Actions();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Action>(dataGridView1, StatusProperty);
        }

        private void ToolStripMenuItem_Actions_Create_Click(object sender, EventArgs e)
        {
            long action_id = PARTIAL.Action.Add_Action();
            if (action_id > 0)
            {
                ToolStripMenuItem_Actions_Open_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, action_id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_Actions_Edit_Click(object sender, EventArgs e)
        {
            long action_id = PARTIAL.Action.Edit_Action(dataGridView1);
            if (action_id > 0)
            {
                ToolStripMenuItem_Actions_Open_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, action_id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_Location_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CODE.Code_Queries.Get_Locations();
        }
        #endregion

        #region Series

        private void ToolStripMenuItem_Series_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DB_Agent.Get_Series();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Series>(dataGridView1, StatusProperty);
        }

        private void ToolStripMenuItem_Series_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Series.Add_Serie();
            if (id != 0)
            {
                ToolStripMenuItem_Series_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_Series_Edit_Click(object sender, EventArgs e)
        {
            long id = PARTIAL.Series.Edit_Serie(dataGridView1);
            if (id > 0)
            {
                ToolStripMenuItem_Series_Show_Click(sender, e);
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }
        #endregion

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if      (gridViewItemType == typeof(Place)) ;
            else if (gridViewItemType == typeof(Language))  ToolStripMenuItem_Language_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(Author))    ToolStripMenuItem_Author_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(Action))    ToolStripMenuItem_Actions_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(Series))    ToolStripMenuItem_Series_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(PublishingHouse)) ToolStripMenuItem_PubHouse_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(City))      ToolStripMenuItem_City_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(ViewBook))     ToolStripMenuItem__Book_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(Art))       ToolStripMenuItem_Arts_Edit_Click(sender, e);
            else if (gridViewItemType == typeof(Genre))     ToolStripMenuItem_Genres_Edit_Click(sender, e);
        }

    }
}