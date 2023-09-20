namespace lib_postgres
{
    public partial class Genre : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Genres_Show.Text", "ToolStripMenuItem_Genres_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenauItem_Genres_Add.Text", "ToolStripMenuItem_Genres_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Genres_Edit.Text", "ToolStripMenuItem_Genres_Edit_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__Genres_Delete.Text", "ToolStripMenuItem__Genres_Delete_Click"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}
