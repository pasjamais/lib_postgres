using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class City
    {
        public static long Add_City()
        {
            var new_name = General_Manipulations.simple_element_add("Добавить город", "Название:");
            if (new_name != "")
            {
                if (DB_Agent.db.Cities.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Город уже существует");
                    return 0;
                }
                else
                {
                    lib_postgres.City element = new lib_postgres.City();
                    element.Name = new_name;
                    DB_Agent.db.Cities.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return 0;
        }
        public static void Edit_City(DataGridView dataGridView)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            lib_postgres.City element = DB_Agent.Get_City(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить город", "Новое название:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Cities.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Город уже существует");
                    return;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
            }
            dataGridView.DataSource = DB_Agent.Get_Cities();
            General_Manipulations.show_row(dataGridView, element.Id.ToString(), "Id");
        }
    }
}