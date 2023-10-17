using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;

namespace lib_postgres
{
    public partial class ViewHasRead
    {
        public static string Get_Caption()
        {
            return ArtRead.Get_Caption();
        }
        public static List<ViewHasRead> Prepare_View()
        {
            return ArtRead.Prepare_View();
        }
        public static void Highlighting(DataGridView DGV)
        {
            ArtRead.Highlighting(DGV);
        }
    }
}
