using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib_postgres.CODE;
using lib_postgres.CODE.CRUD;
using lib_postgres.FORMS;
using Microsoft.EntityFrameworkCore.Storage;

namespace lib_postgres
{
    public partial class Art : ICan_Create_Item, IHas_field_IsDeleted
    {
        public static long Create_Item()
        {
            Form_Art form_Art = new Form_Art();
            var DialogResult = form_Art.ShowDialog();
            if (DialogResult != DialogResult.OK) return -1;

            Art art = DB_Agent.Get_First_Deleted_Entity_or_New<Art>(DB_Agent.Get_Arts());
            //++ transaction section
            using (var dbContextTransaction = DB_Agent.db.Database.BeginTransaction())
            {
                try
                {
                    bool is_new_element = Reset_Element_If_Not_New(art);
                    Save_Element_from_Form(art, form_Art);

                    if (is_new_element) DB_Agent.Add_Art(art);
                    else art.IsDeleted = false;

                    Save_Authors_of_Art_from_Form(art, form_Art.selected_Autors!);

                    DB_Agent.Save_Changes();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
            //-- transaction section
            return art.Id;
        }

        public static long Edit_Item_by_ID(long id)
        {
            Art art = DB_Agent.Get_Art(id);
            var all_authors_arts = DB_Agent.Get_AuthorArts();
            var all_authors = DB_Agent.Get_Authors();
            var authors_of_this_art = (from aut_art in all_authors_arts
                                       from aut in all_authors
                                       where aut_art.Art == art.Id && aut_art.Author == aut.Id
                                       select aut).ToList();
            Form_Art form_Art = new lib_postgres.Form_Art(authors_of_this_art);
            Load_Item_in_Form(art, form_Art);
            DialogResult dialog_result = form_Art.ShowDialog();
            if (dialog_result != DialogResult.OK) return -1;
            //++ transaction section
            using (var dbContextTransaction = DB_Agent.db.Database.BeginTransaction())
            {
                try
                {
                    Reset_Element_If_Not_New(art);
                    Save_Element_from_Form(art, form_Art);
                    Save_Authors_of_Art_from_Form(art, form_Art.selected_Autors!);

                    DB_Agent.Save_Changes();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
            //-- transaction section
            return art.Id;
        }
        public static void Save_Element_from_Form(Art art, Form_Art form_Art)
        {
            Fill_Element_Without_Authors(art, form_Art);
        }
        public static void Fill_Element_Without_Authors(Art art, Form_Art form_Art)
        {
            art.Name = form_Art.tb_Name.Text;
            if (form_Art.ChB_Genre.Checked) art.Genre = form_Art.CB_Genre.SelectedValue is null ? null : (long)form_Art.CB_Genre.SelectedValue;
            if (form_Art.ChB_Language.Checked) art.OrigLanguage = form_Art.CB_Langue.SelectedValue is null ? null : (System.Int64)form_Art.CB_Langue.SelectedValue;
            if (form_Art.TB_YearCreation.Text != "")
            {
                int x = 0;
                Int32.TryParse(form_Art.TB_YearCreation.Text, out x);
                if (x > 0)
                    art.WritingYear = new DateOnly(x, 1, 1);
            }
        }
        public static void Save_Authors_of_Art_from_Form(Art art, List<Author> selected_Autors)
        {
            foreach (lib_postgres.Author author in selected_Autors)
            {
                AuthorArt authorArt = DB_Agent.Get_First_Deleted_Entity_or_New<AuthorArt>(DB_Agent.Get_AuthorArts());
                bool is_new_authorArt = AuthorArt.Reset_Element_if_not_New(authorArt);
                authorArt.Author = author.Id;
                authorArt.Art = art.Id;
                if (is_new_authorArt) DB_Agent.Add_AuthorArt(authorArt);
                    else authorArt.IsDeleted = false;
            }
        }

        public static bool Reset_Element_If_Not_New(Art item)
        {
            bool is_new_element = (item.Id == 0) ? true : false;
            if (!is_new_element)
            {
                item.Name = "";
                item.WritingYear = null;
                item.Genre = null;
                item.OrigLanguage = null;
                if (item.AuthorArts.Count > 0)
                {
                    foreach (AuthorArt record in item.AuthorArts)
                    {// using navigation properties!
                        record.Art = null;
                        record.Author = null;
                        record.IsDeleted = true;
                    }
                }
            }
            return is_new_element;
        }

        private static void Load_Item_in_Form(Art art, Form_Art form_Art)
        {
            if (art.Name != null) form_Art.tb_Name.Text = art.Name;
            form_Art.ChB_Genre.Checked = art.Genre.HasValue;
            form_Art.CB_Genre.SelectedValue = art.Genre ?? 0;
            form_Art.ChB_Language.Checked = art.OrigLanguage.HasValue;
            form_Art.CB_Langue.SelectedValue = art.OrigLanguage ?? 0;
            if (art.WritingYear != null) form_Art.TB_YearCreation.Text = art.WritingYear.Value.Year.ToString();
        }

        public static long Delete_Item_by_ID(long id)
        {
            lib_postgres.Art art = DB_Agent.Get_Art(id);
            if (art.IsDeleted.HasValue)
                art.IsDeleted = !art.IsDeleted;
            else
                art.IsDeleted = true;
            return art.Id;
        }
        public static List<lib_postgres.Art> Get_Deleted_Arts()
        {
            List<lib_postgres.Art> arts = DB_Agent.Get_Arts();
            List<lib_postgres.Art> deleted_arts = (from art in arts
                                                   where art.IsDeleted is true
                                                   select art).ToList();
            return deleted_arts;
        }

        public static List<long> Get_Deleted_Arts_IDs()
        {
            List<lib_postgres.Art> deleted_arts = Get_Deleted_Arts();
            List<long> del_arts_id = (from art in deleted_arts
                                      select art.Id).ToList(); ;
            return del_arts_id;
        }
    }
}
