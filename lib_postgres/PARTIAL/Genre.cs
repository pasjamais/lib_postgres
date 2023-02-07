using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class Genre
    {
        public static long Add_Genre()
        {
            var new_name = General_Manipulations.simple_element_add("Добавить жанр", "Наименование:");
            if (new_name != "")
            {
                if (DB_Agent.db.Genres.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Жанр уже существует");
                    return 0;
                }
                else
                {
                    lib_postgres.Genre element = new lib_postgres.Genre();
                    element.Name = new_name;
                    DB_Agent.db.Genres.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return -1;
        }
        public static long Edit_Genre(DataGridView dataGridView)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            lib_postgres.Genre element = DB_Agent.Get_Genre(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить жанр", "Новое название:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Genres.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Жанр уже существует");
                    return 0;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
                return element.Id;
            }
            else return -1;
        }

    }
}
