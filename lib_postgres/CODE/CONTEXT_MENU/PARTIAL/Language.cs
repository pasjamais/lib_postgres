namespace lib_postgres
{
    public partial class Language : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Language_Show.Text", "ToolStripMenuItem_Language_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Language_Add.Text", "ToolStripMenuItem_Language_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Language_Edit.Text", "ToolStripMenuItem_Language_Edit_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Language_Delete.Text", "ToolStripMenuItem_Language_Delete_Click"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}