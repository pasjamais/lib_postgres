namespace lib_postgres
{
    public partial class Person : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_People_Show.Text", "ToolStripMenuItem_People_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_People_Add.Text", "ToolStripMenuItem_People_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_People_Edit.Text", "ToolStripMenuItem_People_Edit_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_People_Delete.Text", "ToolStripMenuItem_People_Delete_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Erase_Entity_Forever("Erase_Person", "Erase_Person"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}

