namespace lib_postgres
{
    public partial class Series : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Series_Show.Text", "ToolStripMenuItem_Series_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Series_Add.Text", "ToolStripMenuItem_Series_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Series_Edit.Text", "ToolStripMenuItem_Series_Edit_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Series_Delete.Text", "ToolStripMenuItem_Series_Delete_Click"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}