using lib_postgres.CRUD;
using lib_postgres.FORMS;
using lib_postgres.QUERIES;

namespace lib_postgres
{
    public partial class Action : ICan_Erase_by_ID, ICan_Create_Item
    {
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.Action element = DB_Agent.Get_Action(id);
            DB_Agent.db.Actions.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }
        public static long Create_Item()
        {
            Form_Action form_Action = new Form_Action();
            var DialogResult = form_Action.ShowDialog();
            if (DialogResult != DialogResult.OK) return -1;

            Action action = DB_Agent.Get_First_Deleted_Entity_or_New<Action>(DB_Agent.Get_Actions());

            //++ transaction section
            using (var dbContextTransaction = DB_Agent.db.Database.BeginTransaction())
            {
                try
                {
                    bool is_new_element = Reset_Element_If_Not_New(action);
                    Save_Element_from_Form(action, form_Action);

                    if (is_new_element) DB_Agent.Add_Action(action);
                    else action.IsDeleted = false;
                    Add_New_Books_to_Action(form_Action.action_books, action);

                    DB_Agent.Save_Changes();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
            //-- transaction section
            return action.Id;
        }

        public static bool Reset_Element_If_Not_New(Action element)
        {
            bool is_new_element = (element.Id == 0) ? true : false;
            if (!is_new_element)
            {
                element.Date = null;
                element.Name = null;
                element.Comment = null;
                element.Place = null;
                element.ActionType = null;
                if (element.Locations.Count > 0)
                {
                    foreach (Location record in element.Locations)
                    {// using navigation properties! 
                     //does the use of navigation properties violate SOLID?.. 
                        record.IsDeleted = true;
                        record.Operation = null;
                        record.Book = null;
                        record.Place = null;
                        record.Owner = null;
                        record.Comment = null;
                        record.Action = null;
                    }
                }
            }
            return is_new_element;
        }
        private static void Save_Element_from_Form(Action element, Form_Action form)
        {
            Fill_Element_Without_Books(element, form);
        }

        public static void Fill_Element_Without_Books(Action element, Form_Action form)
        {
            element.Date = DateOnly.FromDateTime(form.dateTimePicker.Value.Date); // interesting
            element.Comment = form.TB_Comment.Text;
            if (form.CB_Place.SelectedValue != null)
                element.Place = (long)form.CB_Place.SelectedValue;
            if (form.CB_Action_Type.SelectedValue != null)
                element.ActionType = (long)form.CB_Action_Type.SelectedValue;
        }

        private static void Add_New_Books_to_Action(List<ViewBook> action_books, Action action)
        {
            foreach (ViewBook viewBook in action_books)
            {
                Location location = DB_Agent.Get_First_Deleted_Entity_or_New<Location>(DB_Agent.Get_Locations());
                bool is_new_location = Location.Reset_Element_if_not_New(location); //redundancy in fact, for super sure

                Location.Update_Location_with_Action_values_and_BookID(location, action, viewBook.Id);

                if (is_new_location) DB_Agent.Add_Location(location);
                else location.IsDeleted = false;
            }
        }

        public static long Edit_Item_by_ID(long id)
        {
            lib_postgres.Action action = DB_Agent.Get_Action(id);
            //++ preparation
            List<Location> all_locations = DB_Agent.Get_Locations();
            List<long?> action_books_Ids = (from loc in all_locations
                                            where loc.Action == id
                                            select loc.Book).ToList();
            List<ViewBook> all_books = Queries_from_Views.Get_Books();
            List<ViewBook> action_books = (from x in all_books
                                           where action_books_Ids.Contains(x.Id)
                                           select x).ToList();

            List<ViewBook> action_books_before_modification = new List<ViewBook>(action_books);
            //-- preparation

            Form_Action form_Action = new Form_Action();

            Load_Element_in_Form(action, form_Action, all_books, action_books);

            DialogResult dialog_result = form_Action.ShowDialog();
            if (dialog_result != DialogResult.OK) return -1;

            Load_Modifications_to_Action_from_Form_without_Authors(action, form_Action);

            List<ViewBook> same_books_in_action = action_books_before_modification.Intersect(form_Action.action_books).ToList(); ;
            List<ViewBook> deleted_books_from_action = action_books_before_modification.Except(same_books_in_action).ToList();
            List<ViewBook> new_books_in_action = form_Action.action_books.Except(same_books_in_action).ToList();

            //++ transaction section
            using (var dbContextTransaction = DB_Agent.db.Database.BeginTransaction())
            {
                try
                {
                    Remove_Books_from_Action(action, deleted_books_from_action);
                    Actualize_Existings_Books(action, same_books_in_action);
                    Add_New_Books_to_Action(new_books_in_action, action);

                    DB_Agent.Save_Changes();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
            //-- transaction section
            return action.Id;
        }

        private static void Remove_Books_from_Action(Action action, List<ViewBook> deleted_books)
        {
            foreach (ViewBook book in deleted_books)
            {
                Location record = DB_Agent.Get_Location_by_Action_Id_and_Book_Id(action.Id, book.Id);
                Location.Reset_Element(record);
                Location.Delete_Element(record);
            }
        }

        private static void Actualize_Existings_Books(Action action, List<ViewBook> existiting_boooks)
        {
            foreach (ViewBook viewBook in existiting_boooks)
            {
                Location location = DB_Agent.Get_Location_by_Action_Id_and_Book_Id(action.Id, viewBook.Id);
                Location.Update_Location_with_Action_values_and_BookID(location, action, viewBook.Id);
            }
        }

        private static void Load_Modifications_to_Action_from_Form_without_Authors(Action action, Form_Action form_Action)
        {
            if (form_Action.CB_Place.SelectedValue != null)
                if (action.Place != (System.Int64)form_Action.CB_Place.SelectedValue)
                    action.Place = (System.Int64)form_Action.CB_Place.SelectedValue;

            if (form_Action.CB_Action_Type.SelectedValue != null)
                if (action.ActionType != (System.Int64)form_Action.CB_Action_Type.SelectedValue)
                    action.ActionType = (System.Int64)form_Action.CB_Action_Type.SelectedValue;

            action.Comment = General_Manipulations.compare_string_values(action.Comment, form_Action.TB_Comment.Text);

            action.Date = DateOnly.FromDateTime(form_Action.dateTimePicker.Value.Date);
        }


        private static void Load_Element_in_Form(Action action, Form_Action form_Action,
                                                   List<ViewBook> all_books,
                                                   List<ViewBook> action_books
                                                   )
        {
            // loading authors
            BindingSource source_action_books = new BindingSource();
            source_action_books.DataSource = action_books;
            form_Action.DGV_ActionBooks.DataSource = source_action_books;
            form_Action.DGV_ActionBooks.Refresh();

            BindingSource source_all_books = new BindingSource();
            source_all_books.DataSource = all_books;
            form_Action.DGV_AllBooks.DataSource = source_all_books;
            form_Action.DGV_AllBooks.Refresh();

            // loading current authors
            form_Action.action_books = action_books;

            // loading remaining action content
            if (action.Place != null) form_Action.CB_Place.SelectedValue = action.Place;
            if (action.ActionType != null) form_Action.CB_Action_Type.SelectedValue = action.ActionType;
            if (action.Comment != null) form_Action.TB_Comment.Text = action.Comment;
            if (action.Date is not null)
            {
                DateTime d = new DateTime(action.Date.Value.Year, action.Date.Value.Month, action.Date.Value.Day);
                form_Action.dateTimePicker.Value = d;
            }
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
