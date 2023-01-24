using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace lib_postgres
{
    public class General_Manipulations
    {
        public static void show_row(DataGridView DGV, String string_to_find, String cell_name)
        {
            int rowIndex = -1;
            DGV.Refresh();
            DataGridViewRow row = DGV.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells[cell_name].Value.ToString().Equals(string_to_find))
                .First();
            rowIndex = row.Index;
            DGV.ClearSelection();
            DGV.Rows[rowIndex].Selected = true;
            DGV.FirstDisplayedScrollingRowIndex = rowIndex;
        }
        public static void simple_message(String message)
        {
            MessageBox.Show(message,
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
        }
                 // ++ тут безобразие, не знаю как исправить
        public static object Bind_List_to_DGV(List<Author> list)
        {
            BindingSource source = new BindingSource();
            source.DataSource = list;
            return source;
        }
        public static object Bind_List_to_DGV(List<Book1> list)
        {
            BindingSource source = new BindingSource();
            source.DataSource = list;
            return source;
        }
        public static object Bind_List_to_DGV(List<Book> list)
        {
            BindingSource source = new BindingSource();
            source.DataSource = list;
            return source;
        }
                                    // --
        public static string simple_element_modify(string caption, string label, string name)
        {
            Form_Simple_Element form_element = new Form_Simple_Element(caption, label);
            form_element.tb_Name.Text = name;
            var DialogResult = form_element.ShowDialog();
            if (DialogResult != DialogResult.OK || form_element.tb_Name.Text == name)
                return "";
            else if (form_element.tb_Name.Text == "")
            {
                General_Manipulations.simple_message("Значение не может быть пустым");
                return "";
            }
            else
                return form_element.tb_Name.Text;
        }

        public static string simple_element_add(string caption, string label)
        {
            Form_Simple_Element form_element = new Form_Simple_Element(caption, label);
            var DialogResult = form_element.ShowDialog();
            if (DialogResult != DialogResult.OK)
                return "";
            else if (form_element.tb_Name.Text == "")
            {
                General_Manipulations.simple_message("Значение не может быть пустым");
                return "";
            }
            else
                return form_element.tb_Name.Text;
        }

        public static long Add_Genre()
        {
            var new_name = simple_element_add("Добавить жанр", "Наименование:");
            if (new_name != "")
            {
                if (DB_Agent.db.Genres.ToList().Exists(e => e.Name == new_name))
                {
                    simple_message("Жанр уже существует");
                    return 0;
                }
                else
                {
                    Genre element = new Genre();
                    element.Name = new_name;
                    DB_Agent.db.Genres.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return 0;
        }

        public static long Add_Language()
        {
            var new_name = General_Manipulations.simple_element_add("Добавить язык", "Наименование:");
            if (new_name != "")
            {
                if (DB_Agent.db.Languages.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Язык уже существует");
                    return 0;
                }
                else
                {
                    Language element = new Language();
                    element.Name = new_name;
                    DB_Agent.db.Languages.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return 0;
        }

        public static void Edit_Author(DataGridView dataGridView)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            Author element = DB_Agent.Get_Author(id);
            var new_name = simple_element_modify("Изменить автора", "Новое имя:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Authors.ToList().Exists(e => e.Name == new_name))
                {
                    simple_message("Автор уже существует");
                    return;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
            }
            dataGridView.DataSource = DB_Agent.Get_Authors();
            show_row(dataGridView, element.Name, "Name");
        }

        public static void Add_PubHouse(DataGridView dataGridView)
        {
            dataGridView.DataSource = DB_Agent.Get_Publishing_Houses();
            var new_name = simple_element_add("Добавить издательство", "Название:");
            if (new_name != "")
            {
                if (DB_Agent.db.PublishingHouses.ToList().Exists(e => e.Name == new_name))
                {
                    simple_message("Издательство уже существует");
                    return;
                }
                PublishingHouse element = new PublishingHouse();
                element.Name = new_name;
                DB_Agent.db.PublishingHouses.Add(element);
                DB_Agent.db.SaveChanges();
                dataGridView.DataSource = DB_Agent.Get_Publishing_Houses();
                show_row(dataGridView, element.Name, "Name");
            }
        }

        public static void Edit_PubHouse(DataGridView dataGridView)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            PublishingHouse element = DB_Agent.Get_Publishing_House(id);
            var new_name = simple_element_modify("Изменить издательство", "Новое название:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.PublishingHouses.ToList().Exists(e => e.Name == new_name))
                {
                    simple_message("Издательство уже существует");
                    return;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
            }
            dataGridView.DataSource = DB_Agent.Get_Publishing_Houses();
            show_row(dataGridView, element.Id.ToString(), "Id");
        }

        public static void Edit_Genre(DataGridView dataGridView)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            Genre element = DB_Agent.Get_Genre(id);
            var new_name = simple_element_modify("Изменить жанр", "Новое название:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Genres.ToList().Exists(e => e.Name == new_name))
                {
                    simple_message("Жанр уже существует");
                    return;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
            }
            dataGridView.DataSource = DB_Agent.Get_Genres();
            show_row(dataGridView, element.Id.ToString(), "Id");
        }

        public static void Add_City(DataGridView dataGridView)
        {
            dataGridView.DataSource = DB_Agent.Get_Cities();
            var new_name = simple_element_add("Добавить город", "Название:");
            if (new_name != "")
            {
                if (DB_Agent.db.Cities.ToList().Exists(e => e.Name == new_name))
                {
                    simple_message("Город уже существует");
                    return;
                }
                City element = new City();
                element.Name = new_name;
                DB_Agent.db.Cities.Add(element);
                DB_Agent.db.SaveChanges();
                dataGridView.DataSource = DB_Agent.Get_Cities();
                show_row(dataGridView, element.Id.ToString(), "Id");
            }
        }

        public static void Edit_City(DataGridView dataGridView)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            City element = DB_Agent.Get_City(id);
            var new_name = simple_element_modify("Изменить город", "Новое название:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Cities.ToList().Exists(e => e.Name == new_name))
                {
                    simple_message("Город уже существует");
                    return;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
            }
            dataGridView.DataSource = DB_Agent.Get_Cities();
            show_row(dataGridView, element.Id.ToString(), "Id");
        }

        public static void Edit_Language(DataGridView dataGridView)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            Language element = DB_Agent.Get_Language(id);
            var new_name = simple_element_modify("Изменить язык", "Новое наименование:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Languages.ToList().Exists(e => e.Name == new_name))
                {
                    simple_message("Язык уже существует");
                    return;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
            }
            dataGridView.DataSource = DB_Agent.Get_Languages();
            show_row(dataGridView, element.Name, "Name");
        }

        public static void Add_Author(DataGridView dataGridView)
        {
            dataGridView.DataSource = DB_Agent.Get_Authors();
            var new_name = simple_element_add("Добавить автора", "ФИО:");
            if (new_name != "")
            {
                if (DB_Agent.db.Authors.ToList().Exists(e => e.Name == new_name))
                {
                    simple_message("Автор уже существует");
                    return;
                }
                Author element = new Author();
                element.Name = new_name;
                DB_Agent.db.Authors.Add(element);
                DB_Agent.db.SaveChanges();
                dataGridView.DataSource = DB_Agent.Get_Authors();
                show_row(dataGridView, element.Id.ToString(), "Id");
            }
        }


        public static long Add_Art()
        {
            Form_Art form_Art = new Form_Art();
            var DialogResult = form_Art.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                Art art = new Art();
                art.Name = form_Art.tb_Name.Text;
                art.Genre = (long)form_Art.CB_Genre.SelectedValue;
                art.OrigLanguage = (System.Int64)form_Art.CB_Langue.SelectedValue;
                if (form_Art.TB_YearCreation.Text != "")
                {
                    int x = 0;
                    Int32.TryParse(form_Art.TB_YearCreation.Text, out x);
                    if (x>0)
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
                return art.Id;
            }
            else return -1;
        }


        public static long Add_Book()
        {
            

            Form_Book formBook = new Form_Book();
            DialogResult dialogResult = formBook.ShowDialog();
            if (dialogResult != DialogResult.OK) return -1;
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
                if (formBook.TB_Notes.Text != "")   book.Notes = formBook.TB_Notes.Text;
                if (formBook.TB_Code.Text != "")    book.Code = formBook.TB_Code.Text;
                if (formBook.TB_Family_Notes.Text != "")
                    book.FamilyNotes = formBook.TB_Family_Notes.Text;
                DB_Agent.Book_Add(book);
                return book.Id;
        }
        public static void Edit_Action(DataGridView dataGridView)

        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            Action action = DB_Agent.Get_Action(id);
            FORMS.Form_Action action_form = new FORMS.Form_Action();

            dataGridView.DataSource = DB_Agent.Get_Actions();
            show_row(dataGridView, action.Comment, "Comment");
        }


    }
}
