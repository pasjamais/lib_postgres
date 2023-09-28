using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;
using lib_postgres.VIEW.COMBOBOX;

namespace lib_postgres
{
    public partial class City : ICan_Erase_by_ID, IGet_All_Elements_of_This_Type, IHas_field_ID,
                                IHas_field_IsDeleted, IHas_field_Name, ICan_Create_Item
    {
        public static DB_Agent.write_item_to_BD creation_method;
        static string form_caption = Localization.Substitute("Edit_city");
        static string label_caption = Localization.Substitute("Appellation");
        static string deja_exists_caption = Localization.Substitute("City_already_exists");
        static string edit_element_name = Localization.Substitute("Edit_city");
        static string new_element_name = Localization.Substitute("New_appellation");
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.City element = DB_Agent.Get_City(id);
            DB_Agent.db.Cities.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }
          public static dynamic Get_All_Elements_of_This_Type()
        {
            return DB_Agent.Get_Cities();
        }

        public static long Create_Item()
        {
            City element = DB_Agent.Get_First_Deleted_Entity_or_New<City>(DB_Agent.Get_Cities());

            creation_method = delegate (object obj)
            {
                DB_Agent.City_Add(element);
            };

            return DB_Agent.Create_Item<City>(element,
                                                            DB_Agent.Get_Cities(),
                                                            creation_method);
        }
        public static long Edit_Item_by_ID(long id)
        {
            lib_postgres.City element = DB_Agent.Get_City(id);
            var new_name = General_Manipulations.simple_element_modify(edit_element_name, new_element_name, element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Cities.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message(deja_exists_caption);
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
    }
}
