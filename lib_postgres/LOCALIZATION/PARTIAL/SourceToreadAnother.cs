﻿using lib_postgres.LOCALIZATION;

namespace lib_postgres
{
    public partial class SourceToreadAnother : IProvide_Localized_Form_and_Label_text_for_Simple_Form
    {
        public static string[] Get_Local_Captions_for_Simple_Form()
        {
            string[] result = new string[3];
            result[0] = Localization.Substitute("Add_another_source");
            result[1] = Localization.Substitute("Appellation");
            result[2] = Localization.Substitute("Another_source_already_exists");
            return result;
        }
    }
}

