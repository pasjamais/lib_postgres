namespace lib_postgres
{
    public partial class SourceToreadAnother : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_SourceToreadAnother_Show.Text", "ToolStripMenuItem_SourceToreadAnother_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_SourceToreadAnother_Create.Text", "ToolStripMenuItem_SourceToreadAnother_Create_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_SourceToreadAnother_Edit.Text", "ToolStripMenuItem_SourceToreadAnother_Edit_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_SourceToreadAnother_Delete.Text", "ToolStripMenuItem_SourceToreadAnother_Delete_Click"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}
