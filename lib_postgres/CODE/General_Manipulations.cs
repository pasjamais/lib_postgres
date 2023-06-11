using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace lib_postgres
{
    public class General_Manipulations
    {
        public static void show_row(DataGridView DGV, String string_to_find, String cell_name)
        {
            int rowIndex = -1;
            DGV.Refresh();
            DataGridViewRow row = DGV.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells[cell_name].Value.ToString().Equals(string_to_find))
                .First();
            rowIndex = row.Index;
            DGV.ClearSelection();
            DGV.Rows[rowIndex].Selected = true;
            DGV.FirstDisplayedScrollingRowIndex = rowIndex;
        }
        public static void simple_message(String message)
        {
            MessageBox.Show(message,
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
        }
        // ++ тут безобразие, не знаю как исправить
        public static object Bind_List_to_DGV(List<Author> list)
        {
            BindingSource source = new BindingSource();
            source.DataSource = list;
            return source;
        }
        public static object Bind_List_to_DGV(List<ViewBook> list)
        {
            BindingSource source = new BindingSource();
            source.DataSource = list;
            return source;
        }
        public static object Bind_List_to_DGV(List<Book> list)
        {
            BindingSource source = new BindingSource();
            source.DataSource = list;
            return source;
        }
        // --
        public static string simple_element_modify(string caption, string label, string name)
        {
            Form_Simple_Element form_element = new Form_Simple_Element(caption, label);
            form_element.tb_Name.Text = name;
            var DialogResult = form_element.ShowDialog();
            if (DialogResult != DialogResult.OK || form_element.tb_Name.Text == name)
                return "";
            else if (form_element.tb_Name.Text == "")
            {
                General_Manipulations.simple_message("Значение не может быть пустым");
                return "";
            }
            else
                return form_element.tb_Name.Text;
        }

        public static string simple_element_add(string caption, string label)
        {
            Form_Simple_Element form_element = new Form_Simple_Element(caption, label);
            var DialogResult = form_element.ShowDialog();
            if (DialogResult != DialogResult.OK)
                return "";
            else if (form_element.tb_Name.Text == "")
            {
                General_Manipulations.simple_message("Значение не может быть пустым");
                return "";
            }
            else
                return form_element.tb_Name.Text;
        }
        #region ComboBox_chargers
        public static void CB_visual_reload<T>(ComboBox CB, int i, List<T> elements)
        {
            CB.DataSource = elements;
            CB.ValueMember = "Id";
            CB.DisplayMember = "Name";
            CB.SelectedIndex = i;
        }

        /// <summary>
        /// Перезагружает содержимое ComboBox и ставит указатель на id
        /// </summary>
        public static void CB_reload<T>(ComboBox CB, long id)
        {
            Type type = typeof(T);
            if (type == typeof(Place))
            {
                var elements = DB_Agent.Get_Places();
                var item = (from q in elements
                            where q.Id == id
                            select q).Take(1).First();
                CB_visual_reload<Place>(CB, elements.IndexOf(item), elements);
            }
            else if (type == typeof(Art))
            {
                var elements = DB_Agent.Get_Arts();
                var item = (from q in elements
                            where q.Id == id
                            select q).Take(1).First();
                CB_visual_reload<Art>(CB, elements.IndexOf(item), elements);
            }
            else if (type == typeof(Series))
            {
                var elements = DB_Agent.Get_Series();
                var item = (from q in elements
                            where q.Id == id
                            select q).Take(1).First();
                CB_visual_reload<Series>(CB, elements.IndexOf(item), elements);
            }
            else if (type == typeof(PublishingHouse))
            {
                var elements = DB_Agent.Get_Publishing_Houses();
                var item = (from q in elements
                            where q.Id == id
                            select q).Take(1).First();
                CB_visual_reload<PublishingHouse>(CB, elements.IndexOf(item), elements);
            }
            else if (type == typeof(City))
            {
                var elements = DB_Agent.Get_Cities();
                var item = (from q in elements
                            where q.Id == id
                            select q).Take(1).First();
                CB_visual_reload<City>(CB, elements.IndexOf(item), elements);
            }
            else if (type == typeof(Language))
            {
                var elements = DB_Agent.Get_Languages();
                var item = (from q in elements
                            where q.Id == id
                            select q).Take(1).First();
                CB_visual_reload<Language>(CB, elements.IndexOf(item), elements);
            }
            else if (type == typeof(ActionType))
            {
                var elements = DB_Agent.Get_ActionTypes();
                var item = (from q in elements
                            where q.Id == id
                            select q).Take(1).First();
                CB_visual_reload<ActionType>(CB, elements.IndexOf(item), elements);
            }
            else if (type == typeof(BookFormat))
            {
                var elements = DB_Agent.Get_BookFormats();
                var item = (from q in elements
                            where q.Id == id
                            select q).Take(1).First();
                CB_visual_reload<BookFormat>(CB, elements.IndexOf(item), elements);
            }
            else if (type == typeof(Mark))
            {
                var elements = DB_Agent.Get_Marks();
                var item = (from q in elements
                            where q.Id == id
                            select q).Take(1).First();
                CB_visual_reload<Mark>(CB, elements.IndexOf(item), elements);
            }
else        if (type == typeof(ViewBook))
            {
                CB.DataSource = CODE.Queries_LinQ.Get_Books_Short();
                CB.ValueMember = "Id";
                CB.DisplayMember = "Name";
                CB.SelectedIndex = 1;
            }
            if (type == typeof(Author))
            {
                var elements = DB_Agent.Get_Authors();
                var item = (from q in elements
                            where q.Id == id
                            select q).Take(1).First();
                CB_visual_reload<Author>(CB, elements.IndexOf(item), elements);
            }
            if (type == typeof(SourceToreadAnother))
            {
                CB.DataSource = DB_Agent.Get_Another_Sources();
                CB.ValueMember = "Id";
                CB.DisplayMember = "Name";
                if ( ((ICollection<T>)CB.DataSource).Count > 0 ) CB.SelectedIndex = 0;// защита от пустого множества
            }
        }
        #endregion


        #region Action
        public static void Edit_Action(DataGridView dataGridView)

        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            Action action = DB_Agent.Get_Action(id);
            FORMS.Form_Action action_form = new FORMS.Form_Action();

            dataGridView.DataSource = DB_Agent.Get_Actions();
            show_row(dataGridView, action.Comment, "Comment");
        }
        #endregion


        #region Traitement of data
        public static string? compare_string_values(string? old_string, string new_string)
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

        public static long? compare_values_logic(long? old_value, object? new_value, bool checked_in_form)
        {
            if (!checked_in_form) return null;
            else
                if (new_value is null ) return null;
                else return (System.Int64)new_value;
        }

        public static DateOnly? compare_data_values(DateOnly? d, string? t)
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
