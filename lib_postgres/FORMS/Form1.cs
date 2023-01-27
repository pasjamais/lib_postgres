using lib_postgres.FORMS;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Npgsql;



namespace lib_postgres
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = DB_Agent.Get_Books_Special_View();
            main_menu_generation();
        }

        private void main_menu_generation()
        {
            ToolStripMenuItem newItem = new ToolStripMenuItem("Где книги");
            menuStrip1.Items.Add(newItem);
            var places = DB_Agent.Get_Places();
            foreach (var place in places)
            {
                ToolStripMenuItem place_item = new ToolStripMenuItem(place.Name);
                newItem.DropDownItems.Add(place_item);
                place_item.Click += show_books_in_place;
            }

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

            // название и авторы
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
            // всё остальное
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
                             Размещение = pla.Name ?? "",
                             book_id = boo.Id.ToString() ?? "",
                             Название = art.art_name ?? "",
                             Автор_ы = art.authors_concat ?? "",
                             Жанр = gen.Name ?? "",
                             Год_издания = boo.PublicationYear.Value.Year.ToString() ?? "",
                             Издательство = pub.Name ?? "",
                             Город = cit.Name ?? "",
                             Страниц = boo.Pages.ToString() ?? "",
                             Шифр = boo.Code ?? "",
                             Язык_издания = lan_boo.Name ?? "",
                             Язык_оригинала = lan_orig.Name ?? ""
                         }).ToList();
            dataGridView1.DataSource = items;
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
            dataGridView1.DataSource = items;
        }
        private void ToolStripMenuItem_Arts_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Arts();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Art>(dataGridView1);


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

            // название и авторы
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
                                    year_orig = g.Key.art.WritingYear,
                                    authors_concat = String.Join(",", g.Select(x => x.Name))
                                }).ToList();
            var items = (from art in arts_authors
                         join gen in genres on art.art_genre equals gen.Id
                         join lan_orig in languages on art.lan_orig equals lan_orig.Id
                         select new
                         {
                             Id = art.art_id,
                             Название = art.art_name ?? "",
                             Автор_ы = art.authors_concat ?? "",
                             Жанр = gen.Name ?? "",
                             Год_написания = art.year_orig.HasValue ? art.year_orig.Value.Year.ToString() : "",
                             Язык_оригинала = lan_orig.Name ?? ""
                         }).ToList();
            dataGridView1.DataSource = CODE.Code_Queries.Get_Arts();

        }

        private void ToolStripMenuItem_Autors_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DB_Agent.Get_Authors();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Author>(dataGridView1);
        }

        private void ToolStripMenuItem_Genres_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DB_Agent.Get_Genres();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Genre>(dataGridView1);
        }

        private void ToolStripMenuItem_Author_Add_Click(object sender, EventArgs e)
        {
            PARTIAL.Author.Add_Author(dataGridView1);
        }

        private void ToolStripMenuItem_Genres_Add_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Genres();
            var id = PARTIAL.Genre.Add_Genre();
            if (id != 0)
            {
                dataGridView1.DataSource = DB_Agent.Get_Genres();
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }

        }

        private void ToolStripMenuItem_Arts_Add_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = DB_Agent.Get_Arts();
            var id = PARTIAL.Art.Add_Art();
            if (id > 0)
            {
                dataGridView1.DataSource = DB_Agent.Get_Arts();
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");//ToString() - костыль, переписать всё для id
            }
            DialogResult = DialogResult.None;
        }

        private void ToolStripMenuItem_Arts_Edit_Click(object sender, EventArgs e)
        {
            PARTIAL.Art.Edit_Art(dataGridView1);
        }


        private void ToolStripMenuItem_Language_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();// необязательно
            dataGridView1.DataSource = DB_Agent.Get_Languages();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Language>(dataGridView1);
        }

        private void ToolStripMenuItem_Language_Add_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Languages();
            var id = PARTIAL.Language.Add_Language();
            if (id != 0)
            {
                dataGridView1.DataSource = DB_Agent.Get_Languages();
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }


        private void ToolStripMenuItem_Book_Add_Click(object sender, EventArgs e)
        {
            long book_id = PARTIAL.Book.Add_Book();
            if (book_id != -1)
            {
                dataGridView1.DataSource = DB_Agent.Get_Books_Special_View();
                dataGridView1.Refresh();
                General_Manipulations.show_row(dataGridView1, book_id.ToString(), "Id");
            }
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {////////////////test
            var Get_Languages = DB_Agent.Get_Languages();
            var authors = DB_Agent.Get_Authors();
            var authors_arts = DB_Agent.Get_AuthorArts();// GroupBy(x => x.Art)
            var arts = DB_Agent.Get_Arts();
            var locations = DB_Agent.Get_Locations();
            var books = DB_Agent.Get_Real_Books();
            var items = (from art in arts
                         join aa in authors_arts on art.Id equals aa.Art
                         join aut in authors on aa.Author equals aut.Id
                         group aut by new { art.Name } into g
                         select new
                         {
                             g.Key.Name,
                             Автор_ы = String.Join(",", g.Select(x => x.Name))
                         }).ToList(); ;
            dataGridView1.DataSource = items;
        }


        private void ToolStripMenuItem_Language_Edit_Click(object sender, EventArgs e)
        {
            PARTIAL.Language.Edit_Language(dataGridView1);
        }


        private void ToolStripMenuItem_Book_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Books_Special_View();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Book>(dataGridView1);
        }

        private void ToolStripMenuItem_Author_Edit_Click(object sender, EventArgs e)
        {
            PARTIAL.Author.Edit_Author(dataGridView1);
        }

        private void ToolStripMenuItem_PubHouse_Add_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Publishing_Houses();
            var id = PARTIAL.PublishingHouse.Add_PubHouse(); 
            if (id != 0)
            {
                dataGridView1.DataSource = DB_Agent.Get_Publishing_Houses();
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_PubHouse_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Publishing_Houses();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<PublishingHouse>(dataGridView1);

        }

        private void ToolStripMenuItem_PubHouse_Edit_Click(object sender, EventArgs e)
        {
            PARTIAL.PublishingHouse.Edit_PubHouse(dataGridView1);
        }

        private void ToolStripMenuItem_Genres_Edit_Click(object sender, EventArgs e)
        {
            PARTIAL.Genre.Edit_Genre(dataGridView1);
        }

        private void ToolStripMenuItem__City_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Cities();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<City>(dataGridView1);
        }

        private void ToolStripMenuItem_City_Add_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Cities();
            var id = PARTIAL.City.Add_City();
            if (id != 0)
            {
                dataGridView1.DataSource = DB_Agent.Get_Cities();
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_City_Edit_Click(object sender, EventArgs e)
        {
            PARTIAL.City.Edit_City(dataGridView1);
        }

        private void ToolStripMenuItem__Book_Edit_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            long id = (long)dataGridView1.Rows[index].Cells["Id"].Value;
            Book book = DB_Agent.Get_Book(id);
            Form_Book formBook = new Form_Book();
            formBook.CB_Art.SelectedValue = book.IdArt;
            formBook.CB_Publishing_House.SelectedValue = book.IdPublishingHouse ?? 0;
            formBook.ChB_Publishing_House.Checked = book.IdPublishingHouse.HasValue;
            formBook.CB_City.SelectedValue = book.IdCity ?? 0;
            formBook.ChB_City.Checked = book.IdCity.HasValue;
            formBook.CB_Book_Language.SelectedValue = book.IdLanguage ?? 0;
            formBook.ChB_Language.Checked = book.IdLanguage.HasValue;
            formBook.CB_Series.SelectedValue = book.IdSeries ?? 0;
            formBook.ChB_Series.Checked = book.IdSeries.HasValue;
            if (book.PublicationYear != null)   formBook.TB_Publication_Year.Text = book.PublicationYear.Value.Year.ToString();
            if (book.Pages != null)             formBook.TB_Pages.Text = book.Pages.ToString();
            formBook.CB_Jacket.Checked = book.HasJacket.HasValue && book.HasJacket.Value;
            formBook.CB_Art_Book.Checked = book.IsArtBook.HasValue && book.IsArtBook.Value;
            
            formBook.TB_Comment.Text = book.Comment ?? "";
            formBook.TB_Notes.Text = book.Notes ?? "";
            formBook.TB_Code.Text = book.Code ?? "";
            formBook.TB_Family_Notes.Text = book.FamilyNotes ?? "";

            DialogResult = formBook.ShowDialog();
            if (DialogResult != DialogResult.OK) return;

            if (formBook.CB_Art.SelectedValue != null)
                if (book.IdArt != (System.Int64)formBook.CB_Art.SelectedValue)
            book.IdArt = (System.Int64)formBook.CB_Art.SelectedValue;

            book.IdPublishingHouse = General_Manipulations.compare_values_logic(book.IdPublishingHouse, formBook.CB_Publishing_House.SelectedValue, formBook.ChB_Publishing_House.Checked);
            book.IdCity     = General_Manipulations.compare_values_logic(book.IdCity, formBook.CB_City.SelectedValue, formBook.ChB_City.Checked);
            book.IdLanguage = General_Manipulations.compare_values_logic(book.IdLanguage, formBook.CB_Book_Language.SelectedValue, formBook.ChB_Language.Checked);
            book.IdSeries   = General_Manipulations.compare_values_logic(book.IdSeries, formBook.CB_Series.SelectedValue, formBook.ChB_Series.Checked);
            book.PublicationYear = General_Manipulations.compare_data_values(book.PublicationYear, formBook.TB_Publication_Year.Text);
            book.HasJacket  = formBook.CB_Jacket.Checked;
            book.IsArtBook  = formBook.CB_Art_Book.Checked;
            book.Comment    = General_Manipulations.compare_string_values(book.Comment, formBook.TB_Comment.Text);
            book.Notes      = General_Manipulations.compare_string_values(book.Notes, formBook.TB_Notes.Text);
            book.Code       = General_Manipulations.compare_string_values(book.Code, formBook.TB_Code.Text);
            book.FamilyNotes = General_Manipulations.compare_string_values(book.FamilyNotes,formBook.TB_Family_Notes.Text);
            book.Pages = General_Manipulations.Get_Number_from_String(General_Manipulations.compare_string_values(book.Pages.ToString(), formBook.TB_Pages.Text));
            DB_Agent.db.SaveChanges();
            dataGridView1.DataSource = DB_Agent.Get_Books_Special_View();
            General_Manipulations.show_row(dataGridView1, book.Id.ToString(), "Id");
        }

        private void ToolStripMenuItem_Actions_Show_Click(object sender, EventArgs e)
        {
            CODE.Code_Queries.Show_Actions(dataGridView1);

        }



        private void ToolStripMenuItem_Location_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CODE.Code_Queries.Get_Locations();
        }



        private void фToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CODE.Code_Queries.Get_Action_and_Books(2);
        }


        private void ToolStripMenuItem_Actions_Open_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Actions();
        }

        private void ToolStripMenuItem_Actions_Create_Click(object sender, EventArgs e)
        {
            CODE.Code_Queries.Show_Actions(dataGridView1);
            long action_id = PARTIAL.Action.Add_Action();
            if (action_id > 0)
            {
                 CODE.Code_Queries.Show_Actions(dataGridView1);
                dataGridView1.Refresh();
                General_Manipulations.show_row(dataGridView1, action_id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_Series_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Series();
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Series>(dataGridView1);
        }

        private void ToolStripMenuItem_Series_Add_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Series();
            var id = PARTIAL.Series.Add_Serie();
            if (id != 0)
            {
                dataGridView1.DataSource = DB_Agent.Get_Series();
                General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
            }
        }

        private void ToolStripMenuItem_Series_Edit_Click(object sender, EventArgs e)
        {
            PARTIAL.Series.Edit_Serie(dataGridView1);
        }

        private void ToolStripMenuItem_Actions_Edit_Click(object sender, EventArgs e)
        {
            PARTIAL.Action.Edit_Action(dataGridView1);
        }
    }
}