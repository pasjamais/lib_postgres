namespace lib_postgres
{
    public partial class City : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__City_Show.Text", "ToolStripMenuItem__City_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_City_Add.Text", "ToolStripMenuItem_City_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_City_Edit.Text", "ToolStripMenuItem_City_Edit_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_City_Delete.Text", "ToolStripMenuItem_City_Delete_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Erase_Entity_Forever("Erase_City", "Erase_City"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}