using lib_postgres.VIEW.DELITEMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static lib_postgres.VIEW.SPEC_ENTITIES_VIEWS.Structures;
using lib_postgres.LOCALIZATION;

namespace lib_postgres
{
    public class General_Manipulations
    {
        public static void Show_Row(DataGridView DGV, String string_to_find, String cell_name)
        {
            int rowIndex = -1;
            DGV.Refresh();
            DataGridViewRow row = DGV.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells[cell_name].Value.ToString().Equals(string_to_find))
                .FirstOrDefault();
            if (row is not null)
                rowIndex = row.Index;
            DGV.ClearSelection();
            if (rowIndex > 0)
            {
                DGV.Rows[rowIndex].Selected = true;
                DGV.FirstDisplayedScrollingRowIndex = rowIndex;
            }
     
        }
        public static void Simple_Message(String message)
        {
            MessageBox.Show(message,
                    Localization.Substitute("Message"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
        }

        public static string Simple_Element_Modify(string caption, string label, string name)
        {
            Form_Simple_Element form_element = new Form_Simple_Element(caption, label);
            form_element.tb_Name.Text = name;
            var DialogResult = form_element.ShowDialog();
            if (DialogResult != DialogResult.OK || form_element.tb_Name.Text == name)
                return "";
            else if (form_element.tb_Name.Text == "")
            {
                General_Manipulations.Simple_Message(Localization.Substitute("Value_cannot_be_ empty"));
                return "";
            }
            else
                return form_element.tb_Name.Text;
        }

        public static string Simple_Element_Add(string caption, string label)
        {
            Form_Simple_Element form_element = new Form_Simple_Element(caption, label);
            var DialogResult = form_element.ShowDialog();
            if (DialogResult != DialogResult.OK)
                return "";
            else if (form_element.tb_Name.Text == "")
            {
                General_Manipulations.Simple_Message(Localization.Substitute("Value_cannot_be_ empty"));
                return "";
            }
            else
                return form_element.tb_Name.Text;
        }
     
        #region Traitement of data
        public static string? Compare_String_Values(string? old_string, string new_string)
        {
            bool A = old_string is not null;
            bool B = new_string != "";
            if (!A && B)
                return new_string;
            else if (A && !B)
                return null;
            else if (A && B)
                if (old_string != new_string)
                    return new_string;
                else
                    return old_string; // нужно что-то возвращать, так пусть будет исходное значение
            else //!A && !B
                return null; // Хотя и перезапись
        }

        public static long? Compare_Logic_Values(long? old_value, object? new_value, bool checked_in_form)
        {
            if (!checked_in_form) return null;
            else
                if (new_value is null ) return null;
                else return (System.Int64)new_value;
        }

        public static DateOnly? Compare_Date_Values(DateOnly? d, string? t)
        {
            if (t != "")
            {
                int x = 0;
                Int32.TryParse(t, out x);
                return new DateOnly(x, 1, 1);

            }
            else
                return null;
        }

        public static int? Get_Number_from_String(string? str)
        {
            int x = 0;

            if (str is not null && str != "")
            {
                Int32.TryParse(str, out x);
                return x;
            }
            else return null;
        }

        #endregion


    }

}
