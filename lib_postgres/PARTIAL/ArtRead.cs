using lib_postgres.CODE.CRUD;
using lib_postgres.FORMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lib_postgres
{
    public partial class ArtRead : ICan_Create_Item, IHas_field_IsDeleted
    {
        public static long Create_Item()
        {
            ArtRead element = DB_Agent.Get_First_Deleted_Entity_or_New<ArtRead >(DB_Agent.Get_ArtReads());
            Form_ArtRead form = new Form_ArtRead();
            {
                General_Manipulations.CB_reload<Structures.Short_Art>(form.CB_Art, 1);
                General_Manipulations.CB_reload<BookFormat>(form.CB_BookFormat, 2);//2- электронный формат
            }
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult != DialogResult.OK) return -1;
            bool is_new_element = (element.Id ==0) ? true : false;
            element = Save_ArtRead(element, form, is_new_element);
            return element.Id;
        }

        private static ArtRead Save_ArtRead (ArtRead artRead, Form_ArtRead form, bool is_new_ArtRead)
        {
            artRead.ArtId = (System.Int64)form.CB_Art.SelectedValue;
            artRead.MarkId = (System.Int64)form.CB_Mark.SelectedValue;
            if (form.CB_Langue.SelectedValue is not null)
                artRead.ReadLanguageId = (System.Int64)form.CB_Langue.SelectedValue;
            artRead.BookFormatId = (System.Int64)form.CB_BookFormat.SelectedValue;
            if (form.TB_Comment.Text != "") artRead.Comment = form.TB_Comment.Text;
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
        public static long Edit_ArtRead(long id)
        {
            lib_postgres.ArtRead artRead = DB_Agent.Get_ArtRead(id);
            Form_ArtRead form = new Form_ArtRead();
            form.CB_Art.SelectedValue = artRead.ArtId;
            if (artRead.Date is not null)
            {
                DateTime d = new DateTime(artRead.Date.Value.Year, artRead.Date.Value.Month, artRead.Date.Value.Day);
                form.dateTimePicker.Value = d;
            }
            form.CB_BookFormat.SelectedValue = artRead.BookFormatId;
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
        public static List<ArtRead> Get_Deleted_Items()
        {
            List<ArtRead> items = DB_Agent.Get_ArtReads();
            List<ArtRead> deleted_items = (from item in items
                                          where item.IsDeleted is true
                                          select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<ArtRead> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); ;
            return deleted_items_IDs;
        }
    }
}
