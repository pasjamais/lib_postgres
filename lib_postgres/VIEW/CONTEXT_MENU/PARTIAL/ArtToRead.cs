using lib_postgres.VIEW.CONTEXT_MENU;

namespace lib_postgres
{
    public partial class ArtToRead : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__Recommendations_Show.Text", "ToolStripMenuItem__Recommendations_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__Recommendations_ِAdd.Text", "ToolStripMenuItem__Recommendation_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__Recommendations_Edit.Text", "ToolStripMenuItem__Recommendations_Edit_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__Recommendations_Delete.Text", "ToolStripMenuItem__Recommendations_Delete_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Erase_Entity_Forever("Erase_Recommendation", "Erase_Recommendation"));
            items.Add(new ToolStripSeparator());
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__Recommend_Vis_Graphviz.Text", "ToolStripMenuItem__Recommend_Vis_Graphviz_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("toolStripMenuItem_Recomm_Tree.Text", "ToolStripMenuItem__Recommendations_Tree_Click"));

            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}
