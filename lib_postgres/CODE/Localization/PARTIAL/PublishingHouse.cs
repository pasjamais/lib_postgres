namespace lib_postgres
{
    public partial class PublishingHouse : IProvide_Localized_Form_and_Label_text_for_Simple_Form
    {
        public static string[] Get_Local_Captions_for_Simple_Form()
        {
            string[] result = new string[2];
            result[0] = Localization.Substitute("Add_pubhouse");
            result[1] = Localization.Substitute("Appellation");
            return result;
        }
    }
}
