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
            bool is_new_element = reset_element_if_not_new(item);

            Save_Element_from_Form(item, form, sources_saved_positions);
            if (is_new_element) DB_Agent.Recommendation_Add(item);
            else
            {
                item.IsDeleted = false;
                DB_Agent.db.SaveChanges();
            }
            return item.Id;
        }

        public static void Save_Element_from_Form(ArtToRead item, Form_Art_To_Read form, Dictionary<string, long> sources_saved_positions)
        {
            //++ space of recommendation determination
            item.Date = DateOnly.FromDateTime(form.dateTimePicker.Value.Date);
            item.Comment = form.TB_Comment.Text;
            if ((bool)form.selectedrb_toread.Tag)
            {//+art
                if (form.CB_Toread_Art.SelectedValue != null)
                    item.ToreadArtId = (long)form.CB_Toread_Art.SelectedValue;
                if (sources_saved_positions is not null)
                        sources_saved_positions["art_to_read"] = (long)form.CB_Toread_Art.SelectedValue;
            }
            else
            {//+author
                if (form.CB_Toread_Author.SelectedValue != null)
                    item.ToreadAuthorId = (long)form.CB_Toread_Author.SelectedValue;
                if (sources_saved_positions is not null)
                    sources_saved_positions["author_to_read"] = (long)form.CB_Toread_Author.SelectedValue;
            }
            //-- space of recommendation determination

            //++ space of source determination
            if ((string)form.selectedrb_source.Tag == "Art")
            {
                if (form.CB_Source_Art.SelectedValue != null)
                {
                    item.SourceArtId = (long)form.CB_Source_Art.SelectedValue;
                    if (sources_saved_positions is not null)
                        sources_saved_positions["art"] = (long)form.CB_Source_Art.SelectedValue;
                }
            }
            else if ((string)form.selectedrb_source.Tag == "Author")
            {
                if (form.CB_Source_Author.SelectedValue != null)
                {
                    item.SourceAuthorId = (long)form.CB_Source_Author.SelectedValue;
                    if (sources_saved_positions is not null)
                        sources_saved_positions["author"] = (long)form.CB_Source_Author.SelectedValue;
                }
            }
            else if ((string)form.selectedrb_source.Tag == "SourceToreadAnother")
            {
                if (form.CB_Source_Another.SelectedValue != null)
                {
                    item.SourceAnotherId = (long)form.CB_Source_Another.SelectedValue;
                    if (sources_saved_positions is not null)
                        sources_saved_positions["another"] = (long)form.CB_Source_Another.SelectedValue;
                }
            }
            //-- space of source determination
        }

        private static bool reset_element_if_not_new(ArtToRead item)
        {
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
            return is_new_element;
        }

        public Dictionary<string, long> sources_saved_positions = new Dictionary<string, long>()
            {// for faster preparation recommendation form it remembers  last choise to show it again
                { "art_to_read",    1  },
                { "author_to_read", 1  },
                { "art",    1  },
                { "author", 1  },
                { "another",1  },
            };

        public static long Edit_Item_by_ID(long id)
        {
            ArtToRead item = DB_Agent.Get_ArtToRead(id);
            Form_Art_To_Read form = new Form_Art_To_Read();
            Load_Item_in_Form(item, form);
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult != DialogResult.OK) return -1;
            bool is_new_element = reset_element_if_not_new(item);
            Save_Element_from_Form(item, form, item.sources_saved_positions);
            if (is_new_element) DB_Agent.Recommendation_Add(item);
            else
            {
                item.IsDeleted = false;
                DB_Agent.db.SaveChanges();
            }
            return item.Id;
        }

        private static void Load_Item_in_Form(ArtToRead item, Form_Art_To_Read form)
        {
            if (item.Date is not null)
            {
                DateTime d = new DateTime(item.Date.Value.Year, item.Date.Value.Month, item.Date.Value.Day);
                form.dateTimePicker.Value = d;
            }
            if (item.Comment != null) form.TB_Comment.Text = item.Comment;
            if (item.ToreadArtId != null)
            {
                form.CB_Toread_Art.SelectedValue = item.ToreadArtId;
                form.RB_Toread_Art.Checked = true;
                form.selectedrb_toread = form.RB_Toread_Art;
            }
            if (item.ToreadAuthorId != null)
            {
                form.CB_Toread_Author.SelectedValue = item.ToreadAuthorId;
                form.RB_Toread_Author.Checked = true;
                form.selectedrb_toread = form.RB_Toread_Author;
            }
            if (item.SourceAnotherId != null)
            {
                form.CB_Source_Another.SelectedValue = item.SourceAnotherId;
                form.RB_Source_Another.Checked = true;
                form.selectedrb_source = form.RB_Source_Another;
            }
            if (item.SourceAuthorId != null)
            {
                form.CB_Source_Author.SelectedValue = item.SourceAuthorId;
                form.RB_Source_Author.Checked = true;
                form.selectedrb_source = form.RB_Source_Author;
            }
            if (item.SourceArtId != null)
            {
                form.CB_Source_Art.SelectedValue = item.SourceArtId;
                form.RB_Source_Art.Checked = true;
                form.selectedrb_source = form.RB_Source_Art;
            }
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
