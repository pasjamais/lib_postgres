using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class Language
    {
        public static long Add_Language()
        {
            var new_name = General_Manipulations.simple_element_add("Добавить язык", "Наименование:");
            if (new_name != "")
            {
                if (DB_Agent.db.Languages.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Язык уже существует");
                    return 0;
                }
                else
                {
                    lib_postgres.Language element = new lib_postgres.Language();
                    element.Name = new_name;
                    DB_Agent.db.Languages.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return 0;
        }
        public static void Edit_Language(DataGridView dataGridView)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            lib_postgres.Language element = DB_Agent.Get_Language(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить язык", "Новое наименование:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Languages.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Язык уже существует");
                    return;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
            }
            dataGridView.DataSource = DB_Agent.Get_Languages();
            General_Manipulations.show_row(dataGridView, element.Name, "Name");



        }
    }
}
