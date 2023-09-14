namespace lib_postgres
{
    public partial class Author : IProvide_Localized_Form_and_Label_text_for_Simple_Form
    {
        public static string[] Get_Local_Captions_for_Simple_Form()
        {
            string[] result = new string[3];
            result[0] = Localization.Substitute("Add_author");
            result[1] = Localization.Substitute("Person_short_name");
            result[2] = Localization.Substitute("Author_alredy_exists");
            return result;
        }
    }
}
