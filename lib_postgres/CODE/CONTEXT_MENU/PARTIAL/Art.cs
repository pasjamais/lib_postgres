

namespace lib_postgres
{
    public partial class Art : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Arts_Show.Text", "ToolStripMenuItem_Arts_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Arts_Add.Text", "ToolStripMenuItem_Arts_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Arts_Edit.Text", "ToolStripMenuItem_Arts_Edit_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Arts_Delete.Text", "ToolStripMenuItem_Arts_Delete_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Erase_Entity_Forever("Erase_Art", "Erase_Art"));
            items.Add(new ToolStripSeparator());
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Arts_Add_to_HaveRead.Text", "cmi_item_add_art_to_read_Click"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}
