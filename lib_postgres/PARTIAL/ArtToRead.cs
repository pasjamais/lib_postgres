using lib_postgres.FORMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class ArtToRead
    {
        public static long Add_Recommendation(Dictionary<string, long> sources_saved_positions)
        {
            Form_Art_To_Read form = new Form_Art_To_Read(sources_saved_positions);
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult != DialogResult.OK) return -1;
            lib_postgres.ArtToRead item = new lib_postgres.ArtToRead();
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
            DB_Agent.Recommendation_Add(item);
            return item.Id;
        }

        public static long Edit_Recommendation(long id)
        {
            return 0;
        }
    }
}
