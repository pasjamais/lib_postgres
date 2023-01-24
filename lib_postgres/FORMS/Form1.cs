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
            dataGridView1.DataSource = DB_Agent.Get_Books();
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
                             Год_написания = art.year_orig.HasValue  ? art.year_orig.Value.Year.ToString() : "",
                             Язык_оригинала = lan_orig.Name ?? ""
                         }).ToList();
            dataGridView1.DataSource = CODE.Code_Queries.Get_Arts();

        }

        private void ToolStripMenuItem_Authors_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Authors();
        }

        private void ToolStripMenuItem_Genres_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Genres();
        }

        private void ToolStripMenuItem_Author_Add_Click(object sender, EventArgs e)
        {
            General_Manipulations.Add_Author(dataGridView1);
        }

        private void ToolStripMenuItem_Genres_Add_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Genres();
            var id = General_Manipulations.Add_Genre();
            dataGridView1.DataSource = DB_Agent.Get_Genres();
            General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
        }

        private void ToolStripMenuItem_Arts_Add_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Arts();
            Form_Art form_Art = new Form_Art();
            DialogResult = form_Art.ShowDialog();
            if (DialogResult != DialogResult.OK) return;
            Art art = new Art();
            art.Name = form_Art.tb_Name.Text;
            if (form_Art.CB_Genre.SelectedValue != null)
                art.Genre = (long)form_Art.CB_Genre.SelectedValue;
            art.OrigLanguage = (System.Int64)form_Art.CB_Langue.SelectedValue;
            if (form_Art.TB_YearCreation.Text != "")
            {
                int x = 0;
                Int32.TryParse(form_Art.TB_YearCreation.Text, out x);
                art.WritingYear = new DateOnly(x, 1, 1);

            }
            DB_Agent.db.Arts.Add(art);
            DB_Agent.db.SaveChanges();
            if ((form_Art.selected_Autors != null) && (form_Art.selected_Autors.Count > 0))
                foreach (Author author in form_Art.selected_Autors)
                {
                    AuthorArt authorArt = new AuthorArt();
                    authorArt.Author = author.Id;
                    authorArt.Art = art.Id;
                    DB_Agent.db.AuthorArts.Add(authorArt);
                    DB_Agent.db.SaveChanges();
                }
            dataGridView1.DataSource = DB_Agent.Get_Arts();
            General_Manipulations.show_row(dataGridView1, art.Id.ToString(), "Id");//ToString() - костыль, переписать всё для id
        }

        private void ToolStripMenuItem_Arts_Edit_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            long id = (long)dataGridView1.Rows[index].Cells["Id"].Value;
            Art art = DB_Agent.Get_Art(id);
            var all_auteurs_arts = DB_Agent.Get_AuthorArts();
            var all_auteurs = DB_Agent.Get_Authors();
            var selected_auteurs = (from aut_art in all_auteurs_arts
                                    from aut in all_auteurs
                                    where aut_art.Art == art.Id && aut_art.Author == aut.Id
                                    select aut).ToList();

            var selected_auteurs_old = new List<Author?>(selected_auteurs);

            Form_Art form_Art = new Form_Art(selected_auteurs);

            form_Art.tb_Name.Text = art.Name;
            if (art.Genre != null)
                form_Art.CB_Genre.SelectedValue = art.Genre;
            if (art.OrigLanguage != null)
                form_Art.CB_Langue.SelectedValue = art.OrigLanguage;
            if (art.WritingYear != null)
                form_Art.TB_YearCreation.Text = art.WritingYear.Value.Year.ToString() ;

            DialogResult = form_Art.ShowDialog();
            if (DialogResult != DialogResult.OK) return;

            art.Name = form_Art.tb_Name.Text;
            if (form_Art.CB_Genre.SelectedValue != null)
            art.Genre = (long)form_Art.CB_Genre.SelectedValue;
            art.OrigLanguage = (System.Int64)form_Art.CB_Langue.SelectedValue;

            
            if (form_Art.TB_YearCreation.Text != "")
            {
                int x = 0;
                Int32.TryParse(form_Art.TB_YearCreation.Text, out x);
                art.WritingYear = new DateOnly(x, 1, 1);

            }
            DB_Agent.db.SaveChanges();

            //  if (    (!form_Art.selected_Autors.Any()) && 
            //        (!selected_auteurs.Any())           )

            //// Допилить -- не удалять старые и писать новые, тратя первичный ключ, а аккуратно заменять
            if (selected_auteurs_old.Any() )
            foreach (Author author in selected_auteurs_old)
            {
                //delete
            }


            foreach (Author author in form_Art.selected_Autors)
                {//add
                    AuthorArt authorArt = new AuthorArt();
                    authorArt.Author = author.Id;
                    authorArt.Art = art.Id;
                    DB_Agent.db.AuthorArts.Add(authorArt);
              //      DB_Agent.db.SaveChanges();
                }

           // DB_Agent.db.SaveChanges();

            dataGridView1.DataSource = DB_Agent.Get_Arts();
            General_Manipulations.show_row(dataGridView1, art.Id.ToString(), "Id");
        }


        private void ToolStripMenuItem_Language_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Languages();
        }

        private void ToolStripMenuItem_Language_Add_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Languages();
            var id = General_Manipulations.Add_Language();
            dataGridView1.DataSource = DB_Agent.Get_Languages();
            General_Manipulations.show_row(dataGridView1, id.ToString(), "Id");
        }


        private void ToolStripMenuItem_Book_Add_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = DB_Agent.Get_Books();
            Form_Book formBook = new Form_Book();
            DialogResult = formBook.ShowDialog();
            if (DialogResult != DialogResult.OK) return;
            Book book = new Book();

            book.IdArt = (System.Int64)formBook.CB_Art.SelectedValue;

            if (formBook.ChB_Publishing_House.Checked) book.IdPublishingHouse = (System.Int64)formBook.CB_Publishing_House.SelectedValue;
            if (formBook.ChB_City.Checked) book.IdCity = (System.Int64)formBook.CB_City.SelectedValue;
            if (formBook.ChB_Language.Checked) book.IdLanguage = (System.Int64)formBook.CB_Book_Language.SelectedValue;
            if (formBook.ChB_Series.Checked) book.IdSeries = (System.Int64)formBook.CB_Series.SelectedValue;
            int x = 0;
            if (formBook.TB_Publication_Year.Text != "")
            {
                Int32.TryParse(formBook.TB_Publication_Year.Text, out x);
                book.PublicationYear = new DateOnly(x, 1, 1);
            }

            book.HasJacket = formBook.CB_Jacket.Checked;
            book.IsArtBook = formBook.CB_Art_Book.Checked;

            if (formBook.TB_Pages.Text != "")
            {
                Int32.TryParse(formBook.TB_Pages.Text, out x);
                book.Pages = x;
            }

            if (formBook.TB_Comment.Text != "") book.Comment = formBook.TB_Comment.Text;
            if (formBook.TB_Notes.Text != "") book.Notes = formBook.TB_Notes.Text;
            if (formBook.TB_Code.Text != "") book.Code = formBook.TB_Code.Text;
            if (formBook.TB_Family_Notes.Text != "")
                book.FamilyNotes = formBook.TB_Family_Notes.Text;
            DB_Agent.Book_Add(book);
            dataGridView1.DataSource = DB_Agent.Get_Books();
            General_Manipulations.show_row(dataGridView1, book.Id.ToString(), "Id");
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
            General_Manipulations.Edit_Language(dataGridView1);
        }


        private void ToolStripMenuItem_Book_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Books();
        }

        private void ToolStripMenuItem_Author_Edit_Click(object sender, EventArgs e)
        {
            General_Manipulations.Edit_Author(dataGridView1);
        }

        private void ToolStripMenuItem_PubHouse_Add_Click(object sender, EventArgs e)
        {
            General_Manipulations.Add_PubHouse(dataGridView1);
        }

        private void ToolStripMenuItem_PubHouse_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Publishing_Houses();
        }

        private void ToolStripMenuItem_PubHouse_Edit_Click(object sender, EventArgs e)
        {
            General_Manipulations.Edit_PubHouse(dataGridView1);
        }

        private void ToolStripMenuItem_Genres_Edit_Click(object sender, EventArgs e)
        {
            General_Manipulations.Edit_Genre(dataGridView1);
        }

        private void ToolStripMenuItem__City_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Cities();
        }

        private void ToolStripMenuItem_City_Add_Click(object sender, EventArgs e)
        {
            General_Manipulations.Add_City(dataGridView1);
        }

        private void ToolStripMenuItem_City_Edit_Click(object sender, EventArgs e)
        {
            General_Manipulations.Edit_City(dataGridView1);
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
            formBook.ChB_Pages.Checked = book.PublicationYear.HasValue;
            if (book.PublicationYear != null)
                formBook.TB_Publication_Year.Text = book.PublicationYear.Value.Year.ToString();

            formBook.CB_Jacket.Checked = book.HasJacket.HasValue && book.HasJacket.Value;
            formBook.CB_Art_Book.Checked= book.IsArtBook.HasValue && book.IsArtBook.Value;
            if (book.Pages != null)
                formBook.TB_Pages.Text = book.Pages.ToString();
            formBook.TB_Comment.Text = book.Comment ?? "";
            formBook.TB_Notes.Text = book.Notes ?? "";
            formBook.TB_Code.Text = book.Code ?? "";
            formBook.TB_Family_Notes.Text = book.FamilyNotes ?? "";

            DialogResult = formBook.ShowDialog();
            if (DialogResult != DialogResult.OK) return;

            book.IdArt = (System.Int64)formBook.CB_Art.SelectedValue;

            if (formBook.ChB_Publishing_House.Checked) book.IdPublishingHouse = (System.Int64)formBook.CB_Publishing_House.SelectedValue;
            if (formBook.ChB_City.Checked) book.IdCity = (System.Int64)formBook.CB_City.SelectedValue;
            if (formBook.ChB_Language.Checked) book.IdLanguage = (System.Int64)formBook.CB_Book_Language.SelectedValue;
            if (formBook.ChB_Series.Checked) book.IdSeries = (System.Int64)formBook.CB_Series.SelectedValue;
            int x = 0;
            if (formBook.TB_Publication_Year.Text != "")
            {
                Int32.TryParse(formBook.TB_Publication_Year.Text, out x);
                book.PublicationYear = new DateOnly(x, 1, 1);
            }

            book.HasJacket = formBook.CB_Jacket.Checked;
            book.IsArtBook = formBook.CB_Art_Book.Checked;

            if (formBook.TB_Pages.Text != "")
            {
                Int32.TryParse(formBook.TB_Pages.Text, out x);
                book.Pages = x;
            }

            if (formBook.TB_Comment.Text != "") book.Comment = formBook.TB_Comment.Text;
            if (formBook.TB_Notes.Text != "") book.Notes = formBook.TB_Notes.Text;
            if (formBook.TB_Code.Text != "") book.Code = formBook.TB_Code.Text;
            if (formBook.TB_Family_Notes.Text != "")
                book.FamilyNotes = formBook.TB_Family_Notes.Text;
            DB_Agent.db.SaveChanges();
            dataGridView1.DataSource = DB_Agent.Get_Books();
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

        private void ToolStripMenuItem_Catalogues_Click(object sender, EventArgs e)
        {

        }

        private void фToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CODE.Code_Queries.Get_Action_and_Books(2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General_Manipulations.Edit_Action(dataGridView1);
        }

        private void ToolStripMenuItem_Action_Edit_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Agent.Get_Books();
            CODE.Code_Queries.Show_Actions(dataGridView1);
            lib_postgres.FORMS.Form_Action form_Action = new Form_Action();
            var DialogResult = form_Action.ShowDialog();
            if (DialogResult != DialogResult.OK);
            if ((form_Action.action_books != null) && (form_Action.action_books.Count > 0))
            {
                Action action = new Action();
                //  action.Date = (System.DateOnly)form_Action.dateTimePicker.Value.ToUniversalTime();
                action.Comment = form_Action.TB_Comment.Text;
                if (form_Action.CB_Place.SelectedValue != null)
                    action.Place = (long)form_Action.CB_Place.SelectedValue;
                if (form_Action.CB_Action_Type.SelectedValue != null)
                    action.ActionType = (long)form_Action.CB_Action_Type.SelectedValue;
                DB_Agent.db.Actions.Add(action);
                DB_Agent.db.SaveChanges();
                foreach (Book book in form_Action.action_books)
                {
                    Location location = new Location();
                    location.Operation = true;
                    location.Book = book.Id;
                    location.Place = action.Place;
                    location.Owner = 1;
                    location.Comment = null;
                    location.Action = action.Id;
                    DB_Agent.db.Locations.Add(location);
                    DB_Agent.db.SaveChanges();
                }

            }

               
            dataGridView1.DataSource = DB_Agent.Get_Actions();
           
        }

        private void ToolStripMenuItem_Actions_Click(object sender, EventArgs e)
        {
            CODE.Code_Queries.Show_Actions(dataGridView1);
        }
    }
}