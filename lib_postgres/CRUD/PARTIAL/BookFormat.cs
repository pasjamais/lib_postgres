﻿using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;
using lib_postgres.VIEW.COMBOBOX;

namespace lib_postgres
{
    public partial class BookFormat : ICan_Erase_by_ID, IGet_All_Elements_of_This_Type, 
                                        IHas_field_ID, IHas_field_Name, ICan_Create_Item
    {
        public static DB_Agent.write_item_to_BD creation_method;
        static string form_caption = Localization.Substitute("Edit_format");
        static string label_caption = Localization.Substitute("Appellation");
        static string deja_exists_caption = Localization.Substitute("Format_already_exists");
        static string edit_element_name = Localization.Substitute("Edit_format");
        static string new_element_name = Localization.Substitute("New_appellation");
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.BookFormat element = DB_Agent.Get_BookFormat(id);
            DB_Agent.db.BookFormats.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }

        public static dynamic Get_All_Elements_of_This_Type()
        {
            return DB_Agent.Get_BookFormats();
        }

        public static long Create_Item()
        {
            BookFormat element = DB_Agent.Get_First_Deleted_Entity_or_New<BookFormat>(DB_Agent.Get_BookFormats());

            creation_method = delegate (object obj)
            {
                DB_Agent.Add_BookFormat(element);
            };

            return DB_Agent.Create_Item<BookFormat>(element,
                                                            DB_Agent.Get_BookFormats(),
                                                            creation_method);
        }
        public static long Edit_Item_by_ID(long id)
        {
            BookFormat element = DB_Agent.Get_BookFormat(id);
            var new_name = General_Manipulations.Simple_Element_Modify(edit_element_name, new_element_name, element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.BookFormats.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.Simple_Message(deja_exists_caption);
                    return 0;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
                return element.Id;
            }
            else return -1;
        }
        public static long Delete_Item_by_ID(long id)
        {
            BookFormat item = DB_Agent.Get_BookFormat(id);
            if (item.IsDeleted.HasValue)
                item.IsDeleted = !item.IsDeleted;
            else
                item.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return item.Id;
        }
    }
}
