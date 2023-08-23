using lib_postgres.CODE;
using lib_postgres.FORMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class Action
    {

        public static long Create_Item()
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
                Save_Books_in_Action(form_Action.action_books, action, true);
                return action.Id;
            }
            else return -1;
        }


        private static bool Get_Operation(long? operation)
        {
            if (operation != null)
                if (operation == 1 || operation == 3 || operation == 5)
                return true;
                else if (operation == 2 || operation == 4)
                return false;
            else return false;
            else return false;
        }
        private static void Save_Books_in_Action(List<ViewBook> action_books, lib_postgres.Action action, bool is_new_action)
        {
            foreach (lib_postgres.ViewBook viewBook in action_books)
            {
                Location location = is_new_action ? new Location() :
                    DB_Agent.Get_Location(DB_Agent.Get_Location_Id_by_Action_Id_and_Book_Id(action.Id, viewBook.Id));
                if (action.ActionType == 2) location.Owner = null;
                    else location.Owner = 1;
                if (Get_Operation(action.ActionType)) location.Place = action.Place;
                else location.Place = null;
                //!!! В Action хранится Place указанный пользователем в форме, а в Location - действительное расположение, в т. ч. null
                location.Operation = Get_Operation(action.ActionType);
                location.Comment = action.Comment;
                if (is_new_action)
                {
                    location.Book = viewBook.Id;
                    location.Action = action.Id;
                    DB_Agent.db.Locations.Add(location);
                }
                DB_Agent.db.SaveChanges();
            }
        }
      
    public static long Edit_Item_by_ID(long id)
        {
            lib_postgres.Action action = DB_Agent.Get_Action(id);
            // prepare action
            var all_locations = DB_Agent.Get_Locations();
            var action_books_Ids = (from loc in all_locations
                                where loc.Action == id 
                                    select loc.Book).ToList();
            var all_books = Queries_from_Views.Get_Books();
            var action_books = (from x in all_books
                         where action_books_Ids.Contains(x.Id)
                         select x).ToList() ;
            FORMS.Form_Action form_Action = new lib_postgres.FORMS.Form_Action();
            BindingSource source_action_books   = new BindingSource();
            BindingSource source_all_books      = new BindingSource();

            source_action_books.DataSource = action_books;
            form_Action.DGV_ActionBooks.DataSource = source_action_books;
            form_Action.DGV_ActionBooks.Refresh();

            source_all_books.DataSource         = all_books;
            form_Action.DGV_AllBooks.DataSource = source_all_books;
            form_Action.DGV_AllBooks.Refresh();

            form_Action.action_books = action_books;
            if (action.Place        != null) form_Action.CB_Place.SelectedValue = action.Place;
            if (action.ActionType   != null) form_Action.CB_Action_Type.SelectedValue = action.ActionType;
            if (action.Comment      != null) form_Action.TB_Comment.Text = action.Comment;

            if (action.Date is not null)
            {
                DateTime d = new DateTime(action.Date.Value.Year, action.Date.Value.Month, action.Date.Value.Day);
                form_Action.dateTimePicker.Value = d;
            }
            var DialogResult = form_Action.ShowDialog();
            if (DialogResult != DialogResult.OK) return -1;
            // check if changed
            if (form_Action.CB_Place.SelectedValue != null)
                if (action.Place != (System.Int64)form_Action.CB_Place.SelectedValue)
                    action.Place = (System.Int64)form_Action.CB_Place.SelectedValue;

            if (form_Action.CB_Action_Type.SelectedValue != null)
                if (action.ActionType != (System.Int64)form_Action.CB_Action_Type.SelectedValue)
                    action.ActionType = (System.Int64)form_Action.CB_Action_Type.SelectedValue;

                        action.Comment = General_Manipulations.compare_string_values(action.Comment, form_Action.TB_Comment.Text);
            action.Date = DateOnly.FromDateTime(form_Action.dateTimePicker.Value.Date);
            DB_Agent.db.SaveChanges();
            Save_Books_in_Action(form_Action.action_books, action, false);  
            return action.Id;


        }

        public static List<lib_postgres.Action> Get_Deleted_Items()
        {
            List<lib_postgres.Action> items = DB_Agent.Get_Actions();
            List<lib_postgres.Action> deleted_items = (from item in items
                                                                where item.IsDeleted is true
                                                                select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<lib_postgres.Action> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); ;
            return deleted_items_IDs;
        }
        public static long Delete_Item_by_ID(long id)
        {
            lib_postgres.Action item = DB_Agent.Get_Action(id);
            if (item.IsDeleted.HasValue)
                item.IsDeleted = !item.IsDeleted;
            else
                item.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return item.Id;
        }
    }
}
