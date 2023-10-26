using lib_postgres.CRUD;
using lib_postgres.FORMS;
using lib_postgres.VIEW.COMBOBOX;
using lib_postgres.VIEW.SPEC_ENTITIES_VIEWS;

namespace lib_postgres
{
    public partial class ArtRead : ICan_Erase_by_ID, ICan_Create_Item
    {//it's ViewHasRead visually
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.ArtRead element = DB_Agent.Get_ArtRead(id);
            DB_Agent.db.ArtReads.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }
        public static long Create_Item()
        {
            ArtRead element = DB_Agent.Get_First_Deleted_Entity_or_New<ArtRead>(DB_Agent.Get_ArtReads());
            Form_ArtRead form = new Form_ArtRead();
            {
                ComboBox_Helper.CB_reload_for_Special_Types<Structures.Short_Art>(form.CB_Art);
                ComboBox_Helper.CB_reload<BookFormat>(form.CB_BookFormat, 2);//2 is digital format. Sorry about magic constant
            }
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult != DialogResult.OK) return -1;
            bool is_new_element = (element.Id == 0) ? true : false;
            element = Save_ArtRead(element, form, is_new_element);
            return element.Id;
        }

        private static ArtRead Save_ArtRead(ArtRead artRead, Form_ArtRead form, bool is_new_ArtRead)
        {
            artRead.ArtId = (System.Int64)form.CB_Art.SelectedValue;
            artRead.MarkId = form.CB_Mark.SelectedValue is null ? null : (System.Int64)form.CB_Mark.SelectedValue;
            if (form.CB_Langue.SelectedValue is not null)
                artRead.ReadLanguageId = (System.Int64)form.CB_Langue.SelectedValue;

            artRead.BookFormatId = form.CB_BookFormat.SelectedValue is null ? null : (System.Int64)form.CB_BookFormat.SelectedValue;
            artRead.Comment = General_Manipulations.Compare_String_Values(artRead.Comment, form.TB_Comment.Text);
            //if (form.TB_Comment.Text != "") artRead.Comment = form.TB_Comment.Text;
            artRead.Date = DateOnly.FromDateTime(form.dateTimePicker.Value.Date);
            artRead.BookId = form.ChB_PaperBook.Checked ? (System.Int64)form.CB_PaperBook.SelectedValue : null;
            if (is_new_ArtRead) DB_Agent.ArtRead_Add(artRead);
            else
            {
                artRead.IsDeleted = false;
                DB_Agent.db.SaveChanges();
            }
            return artRead;
        }
        public static long Edit_Item_by_ID(long id)
        {
            lib_postgres.ArtRead artRead = DB_Agent.Get_ArtRead(id);
            Form_ArtRead form = new Form_ArtRead();
            form.CB_Art.SelectedValue = artRead.ArtId;
            if (artRead.Date is not null)
            {
                DateTime d = new DateTime(artRead.Date.Value.Year, artRead.Date.Value.Month, artRead.Date.Value.Day);
                form.dateTimePicker.Value = d;
            }
            form.CB_BookFormat.SelectedValue = artRead.BookFormatId ?? 0;
            form.CB_Langue.SelectedValue = artRead.ReadLanguageId ?? 0;
            form.CB_Mark.SelectedValue = artRead.MarkId ?? 0;
            form.TB_Comment.Text = artRead.Comment;
            form.ChB_PaperBook.Checked = artRead.BookId.HasValue;
            form.CB_PaperBook.SelectedValue = artRead.BookId ?? 0;
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult != DialogResult.OK) return -1;
            artRead = Save_ArtRead(artRead, form, false);
            return artRead.Id;
        }

        public static long Delete_Item_by_ID(long id)
        {
            ArtRead item = DB_Agent.Get_ArtRead(id);
            if (item.IsDeleted.HasValue)
                item.IsDeleted = !item.IsDeleted;
            else
                item.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return item.Id;
        }
        public static long Create_Item_by_Art(long IDart)
        {
            ArtRead element = DB_Agent.Get_First_Deleted_Entity_or_New<ArtRead>(DB_Agent.Get_ArtReads());
            Form_ArtRead form = new Form_ArtRead();
            {
                ComboBox_Helper.CB_reload_for_Special_Types<Structures.Short_Art>(form.CB_Art, IDart);
                ComboBox_Helper.CB_reload<BookFormat>(form.CB_BookFormat, 2);//magic 
            }
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult != DialogResult.OK) return -1;
            bool is_new_element = (element.Id == 0) ? true : false;
            element = Save_ArtRead(element, form, is_new_element);
            return element.Id;
        }

    }
}
