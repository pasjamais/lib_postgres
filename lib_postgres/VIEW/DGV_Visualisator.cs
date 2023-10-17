using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_postgres.FORMS;
using System.Windows.Forms;
using static lib_postgres.CRUD.DB_Agent;
using Microsoft.VisualBasic.Logging;
using lib_postgres.CRUD;
using lib_postgres.VIEW.DELITEMS;
using lib_postgres.LOCALIZATION;
using lib_postgres.QUERIES;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using static lib_postgres.VIEW.SPEC_ENTITIES_VIEWS.Structures;
using lib_postgres.VIEW.SPEC_ENTITIES_VIEWS;

namespace lib_postgres.VIEW
{
    public class DGV_Visualisator
    {
        public Deleted_Entities_Visuaisator deleted_Entities_Visuaisator;
        public delegate void Turn_Off_or_ON_Current_Menu_Item();
        public DGV_Visualisator()
        {
            deleted_Entities_Visuaisator = new Deleted_Entities_Visuaisator();
        }

        public void Prepare_DGV_For_Type<T>(DataGridView DGV, Main_Form_Status_Update? StatusProperty = null)
        {
            Type type = typeof(T);
            Form_Main form = Form_Main.GetInstance();
            if (StatusProperty is not null)
            {

                if (type == typeof(ArtRead))              // special
                    form.Current_Working_Type = typeof(ViewHasRead);
                else
                    form.Current_Working_Type = type;
                StatusProperty.Message = Get_Caption<T>();
                if (type == typeof(ViewBook))
                {
                    StatusProperty.ToolStripMenuItem__Book_Edit = true;
                }
            }
            if (type == typeof(ViewHasRead) || type == typeof(ArtRead))  // special
            {
                Prepare_DGV<ArtRead>(DGV);    
            }
            else 
                Prepare_DGV<T>(DGV);
            for (int i = 0; i < DGV.ColumnCount; i++) ///for sorting by clicking oh table header
                DGV.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        public void Refresh_DGV_for_Item_Type<T>(DataGridView DGV,
                                                 Turn_Off_or_ON_Current_Menu_Item Turn_Off_Current_Menu_Item,
                                                 Turn_Off_or_ON_Current_Menu_Item Turn_On_Current_Menu_Item,
                                                 Main_Form_Status_Update? StatusProperty = null)
                  where T : new()
        {
            DGV.Columns.Clear();
            Assign_to_DGV_According_Type<T>(DGV);
            Turn_Off_Current_Menu_Item();
            Prepare_DGV_For_Type<T>(DGV, StatusProperty);
            Highlighting<T>(DGV);
            Turn_On_Current_Menu_Item();
        }

        public long Get_Selected_Entity_ID(DataGridView DGV)
        {
            int index = DGV.SelectedRows[0].Index;
            long id = (long)DGV.Rows[index].Cells["Id"].Value;
            return id;
        }


        //for sorting by clicking oh table header
        public void Assign_SortableBindingList_to_DGV<T>(DataGridView dgv, List<T> elements_to_show) 
        {
            dgv.DataSource = new SortableBindingList<T>(elements_to_show);
        }

        public void Prepare_DGV<T>(DataGridView DGV)
        {
            string methodName = "Prepare_DGV";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                type.GetMethod(methodName).Invoke(null, new object[] { DGV });
        }
        public string Get_Caption<T>()
        {
            string methodName = "Get_Caption";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                return type.GetMethod(methodName).Invoke(null, new object[] { }).ToString();
            else return "";
        }

        // adapter for some view not corresponding to basic type (for sorting in DGV)
        private void Assign_to_DGV_According_Type<T>(DataGridView DGV) where T : new()
        {
            Type type = typeof(T);
            if (type == typeof(Action))
                Assign_SortableBindingList_to_DGV<View_Action>(DGV, CRUD_Item_Determinator.Prepare_View<T>());
            else if (type == typeof(Art))
                Assign_SortableBindingList_to_DGV<Art_and_Author>(DGV, CRUD_Item_Determinator.Prepare_View<T>());
            else if (type == typeof(ArtToRead))
                Assign_SortableBindingList_to_DGV<Recommend>(DGV, CRUD_Item_Determinator.Prepare_View<T>());
            else if (type == typeof(Location))
                Assign_SortableBindingList_to_DGV<Location_Record>(DGV, CRUD_Item_Determinator.Prepare_View<T>());
            else if (type == typeof(ArtRead))
                Assign_SortableBindingList_to_DGV<ViewHasRead>(DGV, CRUD_Item_Determinator.Prepare_View<T>());
            else
                Assign_SortableBindingList_to_DGV<T>(DGV, (List<T>)CRUD_Item_Determinator.Prepare_View<T>());
        }

        private void  Deleted_Items_DGV_Colorization<T>(DataGridView DGV)
        {  
            List<long> deleted_IDs = CRUD_Item_Determinator.Get_Deleted_Items_IDs<T>();
            deleted_Entities_Visuaisator.RunCommand(deleted_IDs, DGV);
        }
        public void Special_Highlighting<T>(DataGridView DGV)
        {
            string methodName = "Highlighting";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                type.GetMethod(methodName).Invoke(null, new object[] { DGV });
        }
        public void Highlighting<T>(DataGridView DGV)
        {
            Special_Highlighting<T>(DGV);
            Deleted_Items_DGV_Colorization<T>(DGV);
        }

    }
    
}