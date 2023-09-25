namespace lib_postgres
{
    public partial class Mark : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Marks_Show.Text", "ToolStripMenuItem_Marks_ٍShow_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Marks_Add.Text", "ToolStripMenuItem_Marks_ٍAdd_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Mark_Edit.Text", "ToolStripMenuItem_Marks_ٍEdit_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Marks_Delete.Text", "ToolStripMenuItem_Marks_ٍDelete_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Erase_Entity_Forever("Erase_Mark", "Erase_Mark"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}
