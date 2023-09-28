using lib_postgres.VIEW.CONTEXT_MENU;

namespace lib_postgres
{
    public partial class ViewBook : IContextMenuPreparation
    { 
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            // working with List (not array) because it's more simple to manipulate with elements
            List <ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Book_Show.Text", "ToolStripMenuItem_Book_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Book_Add.Text", "ToolStripMenuItem_Book_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__Book_Edit.Text", "ToolStripMenuItem__Book_Edit_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Books_Delete.Text", "ToolStripMenuItem_Books_Delete_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Erase_Entity_Forever("Erase_Book", "Erase_Book"));
            items.Add(new ToolStripSeparator());
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Book_Find.Text", "Cmi_item_find_book_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Added_Resource("Who_has_my_books", "get_My_Books_in_Other_Hands"));
            //then converting it to array
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }


    }
}
