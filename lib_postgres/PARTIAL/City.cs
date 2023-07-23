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
            else return -1;
        }
        public static long Edit_City(DataGridView dataGridView)
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
                    return 0;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
                return element.Id;
            }
            else return -1;
        }

        public static long Delete_Item_by_ID(long item_ID)
        {
            lib_postgres.City city = DB_Agent.Get_City(item_ID);
            if (city.IsDeleted.HasValue)
                city.IsDeleted = !city.IsDeleted;
            else
                city.IsDeleted = true;
            return city.Id;
        }

        public static List<lib_postgres.City> Get_Deleted_Cities()
        {
            List< lib_postgres.City > cities = DB_Agent.Get_Cities();
            List<lib_postgres.City> deleted_cities = (from city in cities
                                         where city.IsDeleted is true
                                      select city).ToList();
            return deleted_cities;
        }

        public static List<long> Get_Deleted_Cities_IDs()
        {
            List<lib_postgres.City> deleted_cities = Get_Deleted_Cities();
            List<long> del_cities_id = (from city in deleted_cities
                                        select city.Id).ToList(); ;
            return del_cities_id;
        }
    }
}