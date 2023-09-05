using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_postgres.FORMS;
using System.Windows.Forms;
using lib_postgres.CODE.VIEW.DELITEMS;
using static lib_postgres.DB_Agent;
using Microsoft.VisualBasic.Logging;

namespace lib_postgres.CODE
{
    public class DGV_Visualisator
    {
        public Deleted_Entities_Visuaisator deleted_Entities_Visuaisator;
        public delegate void Turn_Off_or_ON_Current_Menu_Item();
        public DGV_Visualisator()
        {
            deleted_Entities_Visuaisator = new Deleted_Entities_Visuaisator();
        }

        public void Prepare_DGV_For_Type<T>(DataGridView DGV, Main_Form_Status_Update? StatusProperty = null)
        {
            // return;
            Type type = typeof(T);
            if (StatusProperty is not null) Form_Main.GridViewItemType = type;
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
                Author.Prepare_DGV(DGV);
                if (StatusProperty is not null) StatusProperty.Message = "Список авторов";
            }
            else if (type == typeof(Language))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Язык";
                for (int i = 2; i < DGV.ColumnCount; i++)
                    DGV.Columns[i].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список языков";
            }
            else if (type == typeof(ViewBook))
            {
                DGV.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                DGV.Columns[0].HeaderText = "Id"; DGV.Columns[0].FillWeight = 10;
                DGV.Columns[1].HeaderText = "Название"; 
                DGV.Columns[2].HeaderText = "Автор(ы)"; 
                DGV.Columns[3].HeaderText = "Год издания"; DGV.Columns[3].FillWeight = 20;
                DGV.Columns[4].HeaderText = "Жанр"; DGV.Columns[4].FillWeight = 40;
                DGV.Columns[5].HeaderText = "Издательство"; DGV.Columns[5].FillWeight = 25;
                DGV.Columns[6].HeaderText = "Шифр"; DGV.Columns[6].FillWeight = 10;
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
                for (int i = 2; i < DGV.ColumnCount; i++)
                    DGV.Columns[i].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список жанров";
            }
            else if (type == typeof(ViewHasRead) || type == typeof(ArtRead))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список прочтённого";
            }
            else if (type == typeof(ViewMyBooksInOtherHand))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].Visible = false;//Место
                for (int i = 7; i <= 13; i++) { DGV.Columns[i].Visible = false; }
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.1);
                DGV.Columns[5].FillWeight = (int)(DGV.Width * 0.3);
                if (StatusProperty is not null) StatusProperty.Message = "Список книг, которые у меня взяли";
            }
            else if (type == typeof(Mark))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Оценка";
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список оценок";
            }
            else if (type == typeof(BookFormat))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Формат";
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список форматов прочтения";
            }
            else if (type == typeof(Place))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[3].Visible = false;
                DGV.Columns[4].Visible = false;
                DGV.Columns[5].Visible = false;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].HeaderText = "Место хранения";
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.45);
                DGV.Columns[2].HeaderText = "Комментарий";
                DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.45);

                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список мест хранения";
            }
            else if (type == typeof(Person))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Имя";
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[4].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список лиц";
            }
            else if (type == typeof(ArtToRead))
            {
                DGV.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Дата";
                DGV.Columns[2].HeaderText = "Тип ист.";
                DGV.Columns[3].HeaderText = "Источник";
                DGV.Columns[4].HeaderText = "Тип рек.";
                DGV.Columns[5].HeaderText = "Рекомендация";
                DGV.Columns[6].HeaderText = "Комментарий";
                DGV.Columns[0].FillWeight = 20;
                DGV.Columns[1].FillWeight = 20;
                DGV.Columns[2].FillWeight = 20;
                DGV.Columns[4].FillWeight = 20;
                if (StatusProperty is not null) StatusProperty.Message = "Список рекомендаций";
            }
            else if (type == typeof(SourceToreadAnother))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Наименование";
                for (int i = 2; i < DGV.ColumnCount; i++)
                    DGV.Columns[i].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = "Список иных источников рекомендаций";
             }
            else if (type == typeof(Location))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = "Дата";
                DGV.Columns[2].HeaderText = "Действие";
                DGV.Columns[3].HeaderText = "Примечание";
                DGV.Columns[4].HeaderText = "Название";
                DGV.Columns[5].HeaderText = "Автор_ы";
                DGV.Columns[6].HeaderText = "Жанр";
                DGV.Columns[7].HeaderText = " Год изд.";
                DGV.Columns[8].HeaderText = " Шифр";
                DGV.Columns[9].HeaderText = "Id кн.";
                DGV.Columns[10].HeaderText = "Размещение";
                DGV.Columns[0].FillWeight = 10;
                DGV.Columns[1].FillWeight = 20;
                DGV.Columns[2].FillWeight = 27;
                DGV.Columns[3].FillWeight = 30;
                //   DGV.Columns[4].FillWeight = 20;
                //   DGV.Columns[5].FillWeight = 20;
                DGV.Columns[6].FillWeight = 10;
                DGV.Columns[7].FillWeight = 8;
                DGV.Columns[8].FillWeight = 10;
                DGV.Columns[9].FillWeight = 10;
                DGV.Columns[10].FillWeight = 25;
                if (StatusProperty is not null) StatusProperty.Message = "Записи размещения";
            }
        }   
      
        public void Refresh_DGV_for_Item_Type<T>(DataGridView DGV,
                                                 Turn_Off_or_ON_Current_Menu_Item Turn_Off_Current_Menu_Item,
                                                 Turn_Off_or_ON_Current_Menu_Item Turn_On_Current_Menu_Item,
                                                 Main_Form_Status_Update? StatusProperty = null)
        {
            DGV.Columns.Clear();
            DGV.DataSource = CODE.CRUD.CRUD_Item_Determinator.Get_All_Items_List_by_Type<T>();
            Turn_Off_Current_Menu_Item();
            Prepare_DGV_For_Type<T>(DGV, StatusProperty);
            //++ colorization of deleted elements 
            List<long> deleted_IDs = CODE.CRUD.CRUD_Item_Determinator.Get_Deleted_Items_IDs<T>();
            deleted_Entities_Visuaisator.RunCommand(deleted_IDs, DGV);
            //-- colorization of deleted elements
            Turn_On_Current_Menu_Item();
        }

        public long Get_Selected_Entity_ID(DataGridView DGV)
        {
            int index = DGV.SelectedRows[0].Index;
            long id = (long)DGV.Rows[index].Cells["Id"].Value;
            return id;
        }

        /// <summary>
        /// for art have read only
        /// </summary>
        /// <param name="DGV"></param>
        public void Colorise_DGV(DataGridView DGV)
        {
            var formats = DB_Agent.Get_BookFormats();
            var marks = DB_Agent.Get_Marks();
            foreach (DataGridViewRow row in DGV.Rows)
            {
                var format_color_id = (from f in formats
                                       where f.Name == row.Cells["Формат"].Value.ToString()
                                       select f.Id).First();
                row.DefaultCellStyle.BackColor = lib_postgres.CODE.Data.format_colors[format_color_id];
                var mark_color_id = (from m in marks
                                     where m.Name == row.Cells["Оценка"].Value.ToString()
                                     select m.Id).First();
                if (mark_color_id < 4 || mark_color_id > 6)
                    row.Cells["Оценка"].Style.BackColor = lib_postgres.CODE.Data.marks_colors[mark_color_id];
            }

        }

    }
}