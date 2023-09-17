namespace lib_postgres
{
    public partial class Series : IProvide_Localized_Form_and_Label_text_for_Simple_Form
    {
        public static string[] Get_Local_Captions_for_Simple_Form()
        {
            string[] result = new string[3];
            result[0] = Localization.Substitute("Add_series");
            result[1] = Localization.Substitute("Appellation");
            result[2] = Localization.Substitute("Series_already_exist");
            return result;
        }
    }
}
