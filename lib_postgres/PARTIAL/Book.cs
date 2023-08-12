using lib_postgres.CODE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class Book 
    {
        public static long Create_Book()
        {
            lib_postgres.Book book = DB_Agent.Get_First_Deleted_Entity_or_New<lib_postgres.Book>(DB_Agent.Get_Books());
            Form_Book formBook = new Form_Book();
            DialogResult dialogResult = formBook.ShowDialog();
            if (dialogResult != DialogResult.OK) return -1;
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
            book.Pages = General_Manipulations.Get_Number_from_String(formBook.TB_Pages.Text);
            if (formBook.TB_Comment.Text != "") book.Comment = formBook.TB_Comment.Text;
            if (formBook.TB_Notes.Text != "") book.Notes = formBook.TB_Notes.Text;
            if (formBook.TB_Code.Text != "") book.Code = formBook.TB_Code.Text;
            if (formBook.TB_Family_Notes.Text != "") book.FamilyNotes = formBook.TB_Family_Notes.Text;

            if (book.Id == 0)
            {
                DB_Agent.Book_Add(book);
            }
            else
            {
                book.IsDeleted = false;
                DB_Agent.Save_Changes();
            }
            return book.Id;
        }

        public static long Edit_Book(long id)
        {
            lib_postgres.Book book = DB_Agent.Get_Book(id);
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
            if (book.PublicationYear != null) formBook.TB_Publication_Year.Text = book.PublicationYear.Value.Year.ToString();
            if (book.Pages != null) formBook.TB_Pages.Text = book.Pages.ToString();
            formBook.CB_Jacket.Checked = book.HasJacket.HasValue && book.HasJacket.Value;
            formBook.CB_Art_Book.Checked = book.IsArtBook.HasValue && book.IsArtBook.Value;

            formBook.TB_Comment.Text = book.Comment ?? "";
            formBook.TB_Notes.Text = book.Notes ?? "";
            formBook.TB_Code.Text = book.Code ?? "";
            formBook.TB_Family_Notes.Text = book.FamilyNotes ?? "";

            DialogResult dialog_result = formBook.ShowDialog();
            if (dialog_result != DialogResult.OK) return -1;
            // check if changed
            if (formBook.CB_Art.SelectedValue != null)
                if (book.IdArt != (System.Int64)formBook.CB_Art.SelectedValue)
                    book.IdArt = (System.Int64)formBook.CB_Art.SelectedValue;
            book.IdPublishingHouse = General_Manipulations.compare_values_logic(book.IdPublishingHouse, formBook.CB_Publishing_House.SelectedValue, formBook.ChB_Publishing_House.Checked);
            book.IdCity = General_Manipulations.compare_values_logic(book.IdCity, formBook.CB_City.SelectedValue, formBook.ChB_City.Checked);
            book.IdLanguage = General_Manipulations.compare_values_logic(book.IdLanguage, formBook.CB_Book_Language.SelectedValue, formBook.ChB_Language.Checked);
            book.IdSeries = General_Manipulations.compare_values_logic(book.IdSeries, formBook.CB_Series.SelectedValue, formBook.ChB_Series.Checked);
            book.PublicationYear = General_Manipulations.compare_data_values(book.PublicationYear, formBook.TB_Publication_Year.Text);
            book.HasJacket = formBook.CB_Jacket.Checked;
            book.IsArtBook = formBook.CB_Art_Book.Checked;
            book.Comment = General_Manipulations.compare_string_values(book.Comment, formBook.TB_Comment.Text);
            book.Notes = General_Manipulations.compare_string_values(book.Notes, formBook.TB_Notes.Text);
            book.Code = General_Manipulations.compare_string_values(book.Code, formBook.TB_Code.Text);
            book.FamilyNotes = General_Manipulations.compare_string_values(book.FamilyNotes, formBook.TB_Family_Notes.Text);
            book.Pages = General_Manipulations.Get_Number_from_String(General_Manipulations.compare_string_values(book.Pages.ToString(), formBook.TB_Pages.Text));
            DB_Agent.db.SaveChanges();
            return book.Id;
        }

        public static long Delete_Item_by_ID(long id)
        {
            lib_postgres.Book book = DB_Agent.Get_Book(id);
            if (book.IsDeleted.HasValue)
                book.IsDeleted = !book.IsDeleted;
            else
                book.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return book.Id;
        }
    }
}
