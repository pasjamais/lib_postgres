using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class Action
    {

        public static long Add_Action()
        {
            FORMS.Form_Action form_Action = new lib_postgres.FORMS.Form_Action();


            var DialogResult = form_Action.ShowDialog();
            if (DialogResult != DialogResult.OK) return -1;
            else if ((form_Action.action_books != null) && (form_Action.action_books.Count > 0))
            {
                lib_postgres.Action action = new lib_postgres.Action();
                action.Date = DateOnly.FromDateTime(form_Action.dateTimePicker.Value.Date); // interesting
                action.Comment = form_Action.TB_Comment.Text;
                if (form_Action.CB_Place.SelectedValue != null)
                    action.Place = (long)form_Action.CB_Place.SelectedValue;
                if (form_Action.CB_Action_Type.SelectedValue != null)
                    action.ActionType = (long)form_Action.CB_Action_Type.SelectedValue;
                DB_Agent.db.Actions.Add(action);
                DB_Agent.db.SaveChanges();
                foreach (lib_postgres.Book1 book1 in form_Action.action_books)
                {
                    Location location = new Location();
                    location.Operation = true;
                    location.Book = book1.Id;
                    location.Place = action.Place;
                    location.Owner = 1;
                    location.Comment = null;
                    location.Action = action.Id;
                    DB_Agent.db.Locations.Add(location);
                    DB_Agent.db.SaveChanges();
                }
                return action.Id;
            }
            else return -1;
        }
        public static void Edit_Action(DataGridView dataGridView)

        {
            int index = dataGridView.SelectedRows[0].Index;
            long id = (long)dataGridView.Rows[index].Cells["Id"].Value;
            lib_postgres.Action action = DB_Agent.Get_Action(id);

                        var all_locations = DB_Agent.Get_Locations();
            var action_books_Ids = (from loc in all_locations
                                where loc.Action == id 
                                    select loc.Book).ToList();

            var all_books = DB_Agent.Get_Books_Special_View();

            var action_books = (from x in all_books
                         where action_books_Ids.Contains(x.Id)
                         select x).ToList() ;
            
            FORMS.Form_Action form_Action = new lib_postgres.FORMS.Form_Action();
             


            BindingSource source_action_books = new BindingSource();
            BindingSource source_all_books = new BindingSource();
            source_action_books.DataSource = action_books;
            form_Action.DGV_ActionBooks.DataSource =(source_action_books);
            form_Action.DGV_ActionBooks.Refresh();

            source_all_books.DataSource = all_books;
            form_Action.DGV_AllBooks.DataSource = (source_all_books);
            form_Action.DGV_ActionBooks.Refresh();

            form_Action.action_books = action_books;


            if (action.Place != null) form_Action.CB_Place.SelectedValue = action.Place;
            if (action.ActionType != null) form_Action.CB_Action_Type.SelectedValue = action.ActionType;
            if (action.Comment != null) form_Action.TB_Comment.Text = action.Comment;

            if (action.Date is not null)
            {
                DateTime d = new DateTime(action.Date.Value.Year, action.Date.Value.Month, action.Date.Value.Day);
                form_Action.dateTimePicker.Value = d;
            }
            var DialogResult = form_Action.ShowDialog();
           //if (DialogResult != DialogResult.OK) return -1;


     
           



        }
    }
}
