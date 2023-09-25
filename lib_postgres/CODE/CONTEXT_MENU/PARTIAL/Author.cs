namespace lib_postgres
{
    public partial class Author : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Authors_Show.Text", "ToolStripMenuItem_Autors_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Author_Add.Text", "ToolStripMenuItem_Author_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Author_Edit.Text", "ToolStripMenuItem_Author_Edit_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Author_Delete.Text", "ToolStripMenuItem_Author_Delete_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Erase_Entity_Forever("Erase_Author", "Erase_Author"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}
