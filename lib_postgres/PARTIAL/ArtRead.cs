using lib_postgres.FORMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class ArtRead
    {
        public static long Add_ArtRead()
        {
            Form_ArtRead form = new Form_ArtRead();
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult != DialogResult.OK) return -1;
            lib_postgres.ArtRead artRead = new lib_postgres.ArtRead();

            artRead.ArtId = (System.Int64)form.CB_Art.SelectedValue;
            artRead.MarkId = (System.Int64)form.CB_Mark.SelectedValue;
            artRead.BookFormatId = (System.Int64)form.CB_BookFormat.SelectedValue;
            if (form.TB_Comment.Text != "") artRead.Comment = form.TB_Comment.Text;
            artRead.Date = DateOnly.FromDateTime(form.dateTimePicker.Value.Date);
            if (form.ChB_PaperBook.Checked && form.ChB_PaperBook.Enabled)
                artRead.BookId = (System.Int64)form.CB_PaperBook.SelectedValue;
            DB_Agent.ArtRead_Add(artRead);
            return artRead.Id;
        }

    }
}
