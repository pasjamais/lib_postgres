using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_postgres.CODE;
using lib_postgres.FORMS;

namespace lib_postgres.PARTIAL
{
    public partial class Art
    {
        public static long Add_Art()
        {
            Form_Art form_Art = new Form_Art();
            var DialogResult = form_Art.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                if (form_Art.tb_Name.Text == "")
                {
                    General_Manipulations.simple_message("Не указано названия");
                    return -1;
                }
                else
                if ((form_Art.selected_Autors == null) || (form_Art.selected_Autors.Count == 0))
                {
                    General_Manipulations.simple_message("Не указано ни одного автора");
                    return -1;
                }
                else
                {
                    lib_postgres.Art art = new lib_postgres.Art();
                    art.Name = form_Art.tb_Name.Text;
                    art.Genre = (long)form_Art.CB_Genre.SelectedValue;
                    art.OrigLanguage = (System.Int64)form_Art.CB_Langue.SelectedValue;
                    if (form_Art.TB_YearCreation.Text != "")
                    {
                        int x = 0;
                        Int32.TryParse(form_Art.TB_YearCreation.Text, out x);
                        if (x > 0)
                            art.WritingYear = new DateOnly(x, 1, 1);
                    }
                    DB_Agent.db.Arts.Add(art);
                    DB_Agent.db.SaveChanges();
                    foreach (lib_postgres.Author author in form_Art.selected_Autors)
                    {
                        lib_postgres.AuthorArt authorArt = new lib_postgres.AuthorArt();
                        authorArt.Author = author.Id;
                        authorArt.Art = art.Id;
                        DB_Agent.db.AuthorArts.Add(authorArt);
                        DB_Agent.db.SaveChanges();
                    }
                    return art.Id;
                }
            }
            else return -1;
        }

        public static void Edit_Art(DataGridView dataGridView)
        {
            // загрузка в форму
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            lib_postgres.Art art = DB_Agent.Get_Art(id);
            var all_auteurs_arts = DB_Agent.Get_AuthorArts();
            var all_auteurs = DB_Agent.Get_Authors();
            var selected_auteurs = (from aut_art in all_auteurs_arts
                                    from aut in all_auteurs
                                    where aut_art.Art == art.Id && aut_art.Author == aut.Id
                                    select aut).ToList();

            var selected_auteurs_old = new List<lib_postgres.Author?>(selected_auteurs);

            lib_postgres.Form_Art form_Art = new lib_postgres.Form_Art(selected_auteurs);

            if (art.Name != null) form_Art.tb_Name.Text = art.Name;
            if (art.Genre != null) form_Art.CB_Genre.SelectedValue = art.Genre;
            if (art.OrigLanguage != null) form_Art.CB_Langue.SelectedValue = art.OrigLanguage;
            if (art.WritingYear != null) form_Art.TB_YearCreation.Text = art.WritingYear.Value.Year.ToString();

            DialogResult dialog_result = form_Art.ShowDialog();
            if (dialog_result != DialogResult.OK) return;

            // проверка на изменение введённых данных
            if (form_Art.tb_Name.Text == "")
            {
                General_Manipulations.simple_message("Не указано названия");
                return;
            }
            else
                if (art.Name != form_Art.tb_Name.Text) art.Name = form_Art.tb_Name.Text;


            if (form_Art.CB_Genre.SelectedValue != null)
                if (art.Genre != (long)form_Art.CB_Genre.SelectedValue) art.Genre = (long)form_Art.CB_Genre.SelectedValue;

            if (art.OrigLanguage != (System.Int64)form_Art.CB_Langue.SelectedValue) art.OrigLanguage = (System.Int64)form_Art.CB_Langue.SelectedValue;
            art.WritingYear = General_Manipulations.compare_data_values(art.WritingYear, form_Art.TB_YearCreation.Text);
            

            DB_Agent.db.SaveChanges();

            // авторов не перезаписывает
            /* //  if (    (!form_Art.selected_Autors.Any()) && 
             //        (!selected_auteurs.Any())           )

             //// Допилить -- не удалять старые и писать новые, тратя первичный ключ, а аккуратно заменять
             if (selected_auteurs_old.Any())
                 foreach (Author author in selected_auteurs_old)
                 {
                     //delete
                 }


             foreach (Author author in form_Art.selected_Autors)
             {//add
                 AuthorArt authorArt = new AuthorArt();
                 authorArt.Author = author.Id;
                 authorArt.Art = art.Id;
                 DB_Agent.db.AuthorArts.Add(authorArt);
                 //      DB_Agent.db.SaveChanges();
             }

             // DB_Agent.db.SaveChanges();*/

            dataGridView.DataSource = DB_Agent.Get_Arts();
            General_Manipulations.show_row(dataGridView, art.Id.ToString(), "Id");
        }
    }
}
