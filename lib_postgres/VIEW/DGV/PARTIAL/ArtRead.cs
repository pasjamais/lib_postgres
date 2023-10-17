using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;
using lib_postgres.QUERIES;
using lib_postgres.VIEW;

namespace lib_postgres
{
    public partial class ArtRead
    {
        public static void Prepare_DGV(DataGridView DGV)
        {
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.Columns[0].HeaderText = "Id";
            DGV.Columns[1].HeaderText = Localization.Substitute("Date");
            DGV.Columns[2].HeaderText = Localization.Substitute("Author_s");
            DGV.Columns[3].HeaderText = Localization.Substitute("Appellation");
            DGV.Columns[4].HeaderText = Localization.Substitute("Genre");
            DGV.Columns[5].HeaderText = Localization.Substitute("Langue_original");
            DGV.Columns[6].HeaderText = Localization.Substitute("Notice");
            DGV.Columns[7].HeaderText = Localization.Substitute("Mark");
            DGV.Columns[8].HeaderText = Localization.Substitute("Format");
        }
        public static List<ViewHasRead> Prepare_View()
        {
            return DB_Agent.Get_ViewHasReads();
               // DB_Agent.Get_ArtReads();
        }
        public static string Get_Caption()
        {
            return Localization.Substitute("Read_list");
        }

        private static void Colorise_DGV(DataGridView DGV)
        {
            var formats = DB_Agent.Get_BookFormats();
            var marks = DB_Agent.Get_Marks();
            foreach (DataGridViewRow row in DGV.Rows)
            {
                var format_color_id = (from f in formats
                                       where row.Cells["Формат"].Value is not null
                                       where f.Name == row.Cells["Формат"].Value.ToString()
                                       select f.Id).FirstOrDefault();
                if (Data.format_colors.ContainsKey(format_color_id))
                    row.DefaultCellStyle.BackColor = Data.format_colors[format_color_id];
                var mark_color_id = (from m in marks
                                     where row.Cells["Оценка"].Value is not null
                                     where m.Name == row.Cells["Оценка"].Value.ToString()
                                     select m.Id).FirstOrDefault();
                if (Data.marks_colors.ContainsKey(mark_color_id))
                    if (mark_color_id < 4 || mark_color_id > 6)
                        row.Cells["Оценка"].Style.BackColor = Data.marks_colors[mark_color_id];
            }
        }
        public static void Highlighting(DataGridView DGV)
        {
            Colorise_DGV(DGV);
        }
    }
}
