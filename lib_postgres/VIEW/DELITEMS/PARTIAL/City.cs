using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;

namespace lib_postgres
{
    public partial class City : IHas_field_ID 
    {
        public static List<City> Get_Deleted_Cities()
        {
            List< City > cities = DB_Agent.Get_Cities();
            List<City> deleted_cities = (from city in cities
                                         where city.IsDeleted is true
                                      select city).ToList();
            return deleted_cities;
        }

        public static List<long> Get_Deleted_Items_IDs()
        {
            List<City> deleted_cities = Get_Deleted_Cities();
            List<long> del_cities_id = (from city in deleted_cities
                                        select city.Id).ToList(); 
            return del_cities_id;
        }
     }
}