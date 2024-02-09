﻿using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;

namespace lib_postgres
{
    public partial class SourceToreadAnother
    {
        public static void Prepare_DGV(DataGridView DGV)
        {
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            DGV.Columns[0].HeaderText = "Id";
            DGV.Columns[1].HeaderText = Localization.Substitute("Appellation");
            for (int i = 2; i < DGV.ColumnCount; i++)
                DGV.Columns[i].Visible = false;
            DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
            DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public static dynamic Prepare_View()
        {
            return DB_Agent.Get_Another_Sources();
        }
        public static string Get_Caption()
        {
            return Localization.Substitute("another_source_list");
        }
    }
}