namespace lib_postgres
{
    public partial class PublishingHouse : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_PubHouse_Show.Text", "ToolStripMenuItem_PubHouse_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_PubHouse_Add.Text", "ToolStripMenuItem_PubHouse_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_PubHouse_Edit.Text", "ToolStripMenuItem_PubHouse_Edit_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_PubHouse_Delete.Text", "ToolStripMenuItem_PubHouse_Delete_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Erase_Entity_Forever("Erase_PublishingHouse", "Erase_PublishingHouse"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}
