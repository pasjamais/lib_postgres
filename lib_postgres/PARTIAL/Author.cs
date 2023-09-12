using lib_postgres.CODE.CRUD;
using lib_postgres.CODE.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class Author : IHas_field_IsDeleted, IHas_field_ID, IHas_field_Name, ICan_Create_Item 
    {
        public static DB_Agent.write_item_to_BD creation_method;

        static string form_caption = Localization.Substitute("Add_author");
        static string label_caption = Localization.Substitute("Person_short_name");
        static string deja_exists_caption = Localization.Substitute("Author_alredy_exists");
        static string edit_element_name = Localization.Substitute("Edit_author_name");
        static string new_element_name = Localization.Substitute("New_name");

        public static long Create_Item()
        {


            Author element = DB_Agent.Get_First_Deleted_Entity_or_New<Author>(DB_Agent.Get_Authors());

            creation_method = delegate (object obj)
            {
                DB_Agent.Author_Add(element);
            };

            return DB_Agent.Create_Item<Author>(element,
                                                          DB_Agent.Get_Authors(),
                                                          form_caption,
                                                          label_caption,
                                                          deja_exists_caption,
                                                          creation_method);

        }
        public static long Edit_Author(long id)
        {
            lib_postgres.Author element = DB_Agent.Get_Author(id);
            var new_name = General_Manipulations.simple_element_modify(edit_element_name, new_element_name, element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Authors.ToList().Exists(e => e.Name == new_name))
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

        public static void Prepare_DGV(DataGridView DGV)
        {
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            DGV.Columns[0].HeaderText = "Id"; DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
            DGV.Columns[1].HeaderText = Localization.Substitute("Author"); DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
            for (int i = 2; i < DGV.ColumnCount; i++)
                DGV.Columns[i].Visible = false;
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
