﻿namespace lib_postgres
{
    public partial class ViewHasRead : IContextMenuPreparation
    {
        public static ToolStripItem[] ContexctMenu_Prepare()
        {
            List<ToolStripItem> items = new List<ToolStripItem>();
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__Read_Open.Text", "ToolStripMenuItem__Read_Open_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__Read_Add.Text", "ToolStripMenuItem__Read_Add_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__Read_Edit.Text", "ToolStripMenuItem__Read_Edit_Click"));
            items.Add(Context_Menu_Items_Builder.Create_Menu_Item_Using_Form_Resource("ToolStripMenuItem__Read_Delete.Text", "ToolStripMenuItem__Read_Delete_Click"));
            ToolStripItem[] Items = items.ToArray();
            return Items;
        }

    }
}