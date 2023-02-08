using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_postgres.FORMS;
using System.Windows.Forms;

namespace lib_postgres.CODE
{
    public class Form_Element_DGV
    {
        public static void Prepare_DGV_For_Type<T>(DataGridView DGV, Main_Form_Status_Update? StatusProperty = null)
        {
           // return;
            Type type = typeof(T);
            if (StatusProperty is not null) Form1.GridViewItemType = type;
            if (type == typeof(Action))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id"; DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].Visible = false;//name
                DGV.Columns[2].HeaderText = "Дата"; DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.20);
                DGV.Columns[3].HeaderText = "Действие"; DGV.Columns[3].FillWeight = (int)(DGV.Width * 0.65);
                DGV.Columns[4].Visible = false;//place
                DGV.Columns[5].Visible = false;//action_type
                DGV.Columns[6].Visible = false;//is_deleted
                DGV.Columns[7].Visible = false;//navigation
                DGV.Columns[8].Visible = false;//navigation
                DGV.Columns[9].Visible = false;//locations
                DGV.Columns[9].Visible = false;//posessions
                DGV.Columns[10].Visible = false;
                DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список действий";
            }
            if (type == typeof(Author))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id"; DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].HeaderText = "Автор"; DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[2].Visible = false;//is_deleted
                DGV.Columns[3].Visible = false;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список авторов";
            }
            else if (type == typeof(Language))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Язык";
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[4].Visible = false;
                DGV.Columns[5].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список языков";
            }
            else if (type == typeof(ViewBook))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id"; DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.1);
                DGV.Columns[1].HeaderText = "Название"; DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.25);
                DGV.Columns[2].HeaderText = "Автор(ы)"; DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.25);
                DGV.Columns[3].HeaderText = "Год издания"; DGV.Columns[3].FillWeight = (int)(DGV.Width * 0.1);
                DGV.Columns[4].HeaderText = "Жанр"; DGV.Columns[4].FillWeight = (int)(DGV.Width * 0.1);
                DGV.Columns[5].HeaderText = "Издательство"; DGV.Columns[5].FillWeight = (int)(DGV.Width * 0.1);
                DGV.Columns[6].HeaderText = "Шифр"; DGV.Columns[6].FillWeight = (int)(DGV.Width * 0.1);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null)
                {
                    StatusProperty.Message = "Список книг";
                    StatusProperty.ToolStripMenuItem__Book_Edit = true;
                }
            }
            else if (type == typeof(Art))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Произведение";
                DGV.Columns[2].HeaderText = "Автор(ы)";
                DGV.Columns[3].HeaderText = "Жанр";
                DGV.Columns[5].HeaderText = "Год написания";
                DGV.Columns[4].HeaderText = "Язык ориг.";
                DGV.Columns[5].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.35);
                DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.20);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список произведений";
            }
            else if (type == typeof(City))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Город";
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список городов";
            }
            else if (type == typeof(Series))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Серия";
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список серий книг";
            }
            else if (type == typeof(PublishingHouse))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Издательство";
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список издательств";
            }
            else if (type == typeof(Genre))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Жанр";
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список жанров";

            }
        }
    }
}