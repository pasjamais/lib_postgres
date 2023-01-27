using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class Author
    {
        public static void Add_Author(DataGridView dataGridView)
        {
            dataGridView.DataSource = DB_Agent.Get_Authors();
            var new_name = General_Manipulations.simple_element_add("Добавить автора", "ФИО:");
            if (new_name != "")
            {
                if (DB_Agent.db.Authors.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Автор уже существует");
                    return;
                }
                lib_postgres.Author element = new lib_postgres.Author();
                element.Name = new_name;
                DB_Agent.db.Authors.Add(element);
                DB_Agent.db.SaveChanges();
                dataGridView.DataSource = DB_Agent.Get_Authors();
                General_Manipulations.show_row(dataGridView, element.Id.ToString(), "Id");
            }
        }
        public static void Edit_Author(DataGridView dataGridView)
        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            lib_postgres.Author element = DB_Agent.Get_Author(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить автора", "Новое имя:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Authors.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Автор уже существует");
                    return;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
            }
            dataGridView.DataSource = DB_Agent.Get_Authors();
            General_Manipulations.show_row(dataGridView, element.Name, "Name");
        }
    }
}
