﻿using lib_postgres.CODE.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class Author : IHas_field_IsDeleted, IHas_field_ID, IHas_field_Name, ICan_Create_Item
    {
        public static DB_Agent.write_item_to_BD creation_method;
        public static long Create_Item()
        {
            Author element = DB_Agent.Get_First_Deleted_Entity_or_New<Author>(DB_Agent.Get_Authors());
            
            creation_method = delegate (object obj)
            {
                DB_Agent.Author_Add(element);
            };

            return DB_Agent.Create_Item <Author>(element,
                                                           DB_Agent.Get_Authors(),
                                                           "Добавить автора",
                                                           "ФИО:",
                                                           "Автор уже существует",
                                                           creation_method);

        }
        public static long Edit_Author(long id)
        {
            lib_postgres.Author element = DB_Agent.Get_Author(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить автора", "Новое имя:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Authors.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Автор уже существует");
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
            lib_postgres.Author item = DB_Agent.Get_Author(id);
            if (item.IsDeleted.HasValue)
                item.IsDeleted = !item.IsDeleted;
            else
                item.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return item.Id;
        }
        /// <summary>
        /// for view
        /// </summary>
        /// <returns></returns>
        public static List<lib_postgres.Author> Get_Deleted_Authors()
        {
            List<lib_postgres.Author> items = DB_Agent.Get_Authors();
            List<lib_postgres.Author> deleted_items = (from item in items
                                                     where item.IsDeleted is true
                                                     select item).ToList();
            return deleted_items;
        }
        /// <summary>
        /// for view
        /// </summary>
        /// <returns></returns>
        public static List<long> Get_Deleted_Authors_IDs()
        {
            List<lib_postgres.Author> deleted_items = Get_Deleted_Authors();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); ;
            return deleted_items_IDs;
        }
    }
}
