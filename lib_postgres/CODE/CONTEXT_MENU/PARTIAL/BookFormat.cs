namespace lib_postgres
{
    public partial class BookFormat : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Book_Format_Show.Text", "ToolStripMenuItem_Book_Format_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Book_Format_Add.Text", "ToolStripMenuItem_Book_Format_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Book_Format_Edit.Text", "ToolStripMenuItem_Book_Format_Edit_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Book_Format_Delete.Text", "ToolStripMenuItem_Book_Format_Delete_Click"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}
