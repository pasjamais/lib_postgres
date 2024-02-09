using lib_postgres.CRUD;
using lib_postgres.FORMS;

namespace lib_postgres
{
    public partial class ArtToRead : ICan_Erase_by_ID
    {
        public static long Erase_Item_by_ID(long id)
        {
            ArtToRead element = DB_Agent.Get_ArtToRead(id);
            DB_Agent.db.ArtToReads.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }
        public static long Add_Recommendation(Dictionary<string, long> sources_saved_positions)
        {
            Form_Art_To_Read form = new Form_Art_To_Read(sources_saved_positions);
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.Abort) return -2;
            else if (dialogResult != DialogResult.OK) return -1;

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
            item.Date = DateOnly.FromDateTime(form.dateTimePicker.Value.Date);
            item.Comment = form.TB_Comment.Text;
            Get_Sources_and_Recommendations_from_Form(item, form, sources_saved_positions);
        }
        public static void Get_Sources_and_Recommendations_from_Form(ArtToRead item, Form_Art_To_Read form, Dictionary<string, long> sources_saved_positions)
        {
            //++ space of recommendation determination
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

        public static void Get_Sources_and_Recommendations_from_Form(ArtToRead item, Form_Art_To_Read form)
        {
            //++ space of recommendation determination
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
            //-- space of recommendation determination

            //++ space of source determination
            if ((string)form.selectedrb_source.Tag == "Art")
            {
                if (form.CB_Source_Art.SelectedValue != null)
                    item.SourceArtId = (long)form.CB_Source_Art.SelectedValue;
            }
            else if ((string)form.selectedrb_source.Tag == "Author")
            {
                if (form.CB_Source_Author.SelectedValue != null)
                    item.SourceAuthorId = (long)form.CB_Source_Author.SelectedValue;
            }
            else if ((string)form.selectedrb_source.Tag == "SourceToreadAnother")
            {
                if (form.CB_Source_Another.SelectedValue != null)
                    item.SourceAnotherId = (long)form.CB_Source_Another.SelectedValue;
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
            Form_Art_To_Read form = new Form_Art_To_Read(item);
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
        public static long Get_Already_Existing_Recommendation_ID(ArtToRead item)
        {
            List<ArtToRead> all_recommendations = DB_Agent.Get_Recommendations();
            ArtToRead found_element = (from rec in all_recommendations
                          where rec.SourceArtId == item.SourceArtId
                             && rec.SourceAuthorId == item.SourceAuthorId
                             && rec.SourceAnotherId == item.SourceAnotherId
                             && rec.ToreadArtId  == item.ToreadArtId
                             && rec.ToreadAuthorId == item.ToreadAuthorId
                          select rec).FirstOrDefault();
            if (found_element != null) return found_element.Id;
            else return 0;
        }
    }
}
