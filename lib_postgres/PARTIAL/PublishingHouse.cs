using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class PublishingHouse
    {
        public static long Add_PubHouse()
        {
            var new_name = General_Manipulations.simple_element_add("Добавить издательство", "Название:");
            if (new_name != "")
            {
                if (DB_Agent.db.PublishingHouses.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Издательство уже существует");
                    return 0;
                }
                else
                {
                    lib_postgres.PublishingHouse element = new lib_postgres.PublishingHouse();
                    element.Name = new_name;
                    DB_Agent.db.PublishingHouses.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return 0;
        }
        public static void Edit_PubHouse(DataGridView dataGridView)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            lib_postgres.PublishingHouse element = DB_Agent.Get_Publishing_House(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить издательство", "Новое название:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.PublishingHouses.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Издательство уже существует");
                    return;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
            }
            dataGridView.DataSource = DB_Agent.Get_Publishing_Houses();
            General_Manipulations.show_row(dataGridView, element.Id.ToString(), "Id");
        }
    }
}
