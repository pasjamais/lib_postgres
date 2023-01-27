using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class Series
    {

        public static long Add_Serie()
        {
            var new_name = General_Manipulations.simple_element_add("Добавить серию книг", "Название:");
            if (new_name != "")
            {
                if (DB_Agent.db.Series.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Серия уже существует");
                    return 0;
                }
                else
                {
                    lib_postgres.Series element = new lib_postgres.Series();
                    element.Name = new_name;
                    DB_Agent.db.Series.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return 0;
        }

        public static void Edit_Serie(DataGridView dataGridView)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            lib_postgres.Series element = DB_Agent.Get_Serie(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить серию", "Новое название:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Series.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Серия уже существует");
                    return;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
            }
            dataGridView.DataSource = DB_Agent.Get_Series();
            General_Manipulations.show_row(dataGridView, element.Id.ToString(), "Id");
        }
    }
}
