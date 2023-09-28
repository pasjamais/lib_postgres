using lib_postgres.VIEW.CONTEXT_MENU;

namespace lib_postgres
{
    public partial class Place : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Places_Show.Text", "ToolStripMenuItem_Places_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Places_Add.Text", "ToolStripMenuItem_Places_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Places_Edit.Text", "ToolStripMenuItem_Places_Edit_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Places_Delele.Text", "ToolStripMenuItem_Places_Delele_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Erase_Entity_Forever("Erase_Place", "Erase_Place"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}
