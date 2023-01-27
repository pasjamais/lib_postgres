using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.CODE
{
    public class Form_Element_DGV
    {
        public static void Prepare_DGV_For_Type<T>(DataGridView DGV)
        {

            Type type = typeof(T);
            if (type == typeof(Author))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Автор";
                DGV.Columns[2].Visible = false;
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (type == typeof(Language))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Язык";
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[4].Visible = false;
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (type == typeof(Book))
            {

            }
            /*      else if (type == typeof(Art))
                  {
                      DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                      DGV.Columns[0].HeaderText = "Id";
                      DGV.Columns[1].HeaderText = "Язык";
                      DGV.Columns[2].Visible = false;
                      DGV.Columns[3].Visible = false;
                      DGV.Columns[4].Visible = false;
                      DGV.Columns[5].Visible = false;
                      DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.15);
                      DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.85);
                      DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                  }*/
            else if (type == typeof(City))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Город";
                DGV.Columns[2].Visible = false;
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (type == typeof(Series))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Серия";
                DGV.Columns[2].Visible = false;
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (type == typeof(PublishingHouse))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Издательство";
                DGV.Columns[2].Visible = false;
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (type == typeof(Genre))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Жанр";
                DGV.Columns[2].Visible = false;
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
