namespace lib_postgres
{
    public partial class Action : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Actions_Open.Text", "ToolStripMenuItem_Actions_Open_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Actions_Create.Text", "ToolStripMenuItem_Actions_Create_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Actions_Edit.Text", "ToolStripMenuItem_Actions_Edit_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Actions_Delete.Text", "ToolStripMenuItem_Actions_Delete_Click"));
            items.Add(new ToolStripSeparator());
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Location_Show.Text", "ToolStripMenuItem_Location_Show_Click"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}
