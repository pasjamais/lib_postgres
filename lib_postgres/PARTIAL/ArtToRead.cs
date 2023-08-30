using lib_postgres.CODE.CRUD;
using lib_postgres.FORMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lib_postgres
{
    public partial class ArtToRead : IHas_field_IsDeleted
    {
        public static long Add_Recommendation(Dictionary<string, long> sources_saved_positions)
        {
            Form_Art_To_Read form = new Form_Art_To_Read(sources_saved_positions);
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult != DialogResult.OK) return -1;
            
            ArtToRead item = DB_Agent.Get_First_Deleted_Entity_or_New<ArtToRead>(DB_Agent.Get_Recommendations());
            bool is_new_element = (item.Id == 0) ? true : false;

            if (!is_new_element)
            {
                item.Date = null;
                item.Comment = "";
                item.ToreadArtId = null;
                item.ToreadAuthorId = null;
                item.SourceAnotherId = null;
                item.SourceAuthorId = null;
                item.SourceArtId = null;
            }

            item.Date = DateOnly.FromDateTime(form.dateTimePicker.Value.Date);
            item.Comment = form.TB_Comment.Text;
            if ((bool)form.selectedrb_toread.Tag)
            {//+art
                if (form.CB_Toread_Art.SelectedValue != null)
                    item.ToreadArtId = (long)form.CB_Toread_Art.SelectedValue;
            }
            else
            {//+author
                if (form.CB_Toread_Author.SelectedValue != null)
                    item.ToreadAuthorId = (long)form.CB_Toread_Author.SelectedValue;
            }
            if ((string)form.selectedrb_source.Tag == "Art")
            {
                if (form.CB_Source_Art.SelectedValue != null)
                {
                    item.SourceArtId = (long)form.CB_Source_Art.SelectedValue;
                    sources_saved_positions["art"] = (long)form.CB_Source_Art.SelectedValue;
                }
                   
            }
            else if ((string)form.selectedrb_source.Tag == "Author")
            {
                if (form.CB_Source_Author.SelectedValue != null)
                {
                    item.SourceAuthorId = (long)form.CB_Source_Author.SelectedValue;
                    sources_saved_positions["author"] = (long)form.CB_Source_Author.SelectedValue;
                }
                    
            }
            else if ((string)form.selectedrb_source.Tag == "SourceToreadAnother")
            {
                if (form.CB_Source_Another.SelectedValue != null)
                {
                    item.SourceAnotherId = (long)form.CB_Source_Another.SelectedValue;
                    sources_saved_positions["another"] = (long)form.CB_Source_Another.SelectedValue;
                }
                    
            }
            //check if rewrite deleted element
            if (item.Id == 0) DB_Agent.Recommendation_Add(item);
            else
            {
                item.IsDeleted = false;
                DB_Agent.db.SaveChanges();
            }
            return item.Id;
        }

        public static long Edit_Item_by_ID(long id)
        {
            ArtToRead item = DB_Agent.Get_ArtToRead(id);
            Form_Art_To_Read form = new Form_Art_To_Read();
            if (item.Date is not null)
            {
                DateTime d = new DateTime(item.Date.Value.Year, item.Date.Value.Month, item.Date.Value.Day);
                form.dateTimePicker.Value = d;
            }
            if (item.Comment != null) form.TB_Comment.Text = item.Comment;
            if (item.ToreadArtId != null)
            { form.CB_Toread_Art.SelectedValue = item.ToreadArtId;
                form.RB_Toread_Art.Checked = true;
            }
            if (item.ToreadAuthorId != null) form.CB_Toread_Author.SelectedValue = item.ToreadAuthorId;
            if (item.SourceAnotherId != null) form.CB_Source_Another.SelectedValue = item.SourceAnotherId;
            if (item.SourceAuthorId != null)form.CB_Source_Author.SelectedValue = item.SourceAuthorId;
            if (item.SourceArtId != null)form.CB_Source_Art.SelectedValue = item.SourceArtId;

            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult != DialogResult.OK) return -1;
            
            /*
            
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

            Person element = DB_Agent.Get_Person(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить лицо", "Новое имя:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.PublishingHouses.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Лицо уже существует");
                    return 0;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
                return element.Id;
            }*/
             return -1;
        }
        public static long Delete_Item_by_ID(long id)
        {
            ArtToRead item = DB_Agent.Get_ArtToRead(id);
            if (item.IsDeleted.HasValue)
                item.IsDeleted = !item.IsDeleted;
            else
                item.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return item.Id;
        }

        public static List<ArtToRead> Get_Deleted_Items()
        {
            List<ArtToRead> items = DB_Agent.Get_Recommendations();
            List<ArtToRead> deleted_items = (from item in items
                                           where item.IsDeleted is true
                                           select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<ArtToRead> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); ;
            return deleted_items_IDs;
        }
    }
}
