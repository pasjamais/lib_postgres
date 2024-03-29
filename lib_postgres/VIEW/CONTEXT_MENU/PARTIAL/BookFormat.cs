﻿using lib_postgres.VIEW.CONTEXT_MENU;

namespace lib_postgres
{
    public partial class BookFormat : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Book_Format_Show.Text", "ToolStripMenuItem_Book_Format_Show_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Book_Format_Add.Text", "ToolStripMenuItem_Book_Format_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Book_Format_Edit.Text", "ToolStripMenuItem_Book_Format_Edit_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem_Book_Format_Delete.Text", "ToolStripMenuItem_Book_Format_Delete_Click", Form_Main.Is_DGV_Has_rows));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Erase_Entity_Forever("Erase_BookFormat", "Erase_BookFormat"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}
