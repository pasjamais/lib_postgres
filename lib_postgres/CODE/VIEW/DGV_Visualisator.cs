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
            Form_Main form = Form_Main.GetInstance();
            if (StatusProperty is not null) form.Current_Working_Type = type;
            if (type == typeof(Action))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id"; DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].Visible = false;//name
                DGV.Columns[2].HeaderText = _s("Date"); DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.20);
                DGV.Columns[3].HeaderText = _s("Action"); DGV.Columns[3].FillWeight = (int)(DGV.Width * 0.65);
                DGV.Columns[4].Visible = false;//place
                DGV.Columns[5].Visible = false;//action_type
                DGV.Columns[6].Visible = false;//is_deleted
                DGV.Columns[7].Visible = false;//navigation
                DGV.Columns[8].Visible = false;//navigation
                DGV.Columns[9].Visible = false;//locations
                DGV.Columns[9].Visible = false;//posessions
                DGV.Columns[10].Visible = false;
                DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("Action_list");
            }
            if (type == typeof(Author))
            {
                Author.Prepare_DGV(DGV);
                if (StatusProperty is not null) StatusProperty.Message = _s("Authors_list");
            }
            
            else if (type == typeof(Language))
            {
                
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Language");
                for (int i = 2; i < DGV.ColumnCount; i++)
                    DGV.Columns[i].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("Languages_list");
            }
            else if (type == typeof(ViewBook))
            {
                DGV.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                DGV.Columns[0].HeaderText = "Id"; DGV.Columns[0].FillWeight = 10;
                DGV.Columns[1].HeaderText = _s("Appellation"); 
                DGV.Columns[2].HeaderText = _s("Author_s"); 
                DGV.Columns[3].HeaderText = _s("Publication_year"); DGV.Columns[3].FillWeight = 20;
                DGV.Columns[4].HeaderText = _s("Genre"); DGV.Columns[4].FillWeight = 40;
                DGV.Columns[5].HeaderText = _s("Pubhouse"); DGV.Columns[5].FillWeight = 25;
                DGV.Columns[6].HeaderText = _s("Code"); DGV.Columns[6].FillWeight = 10;
                if (StatusProperty is not null)
                {
                    StatusProperty.Message = _s("Books_list");
                    StatusProperty.ToolStripMenuItem__Book_Edit = true;
                }
            }
            else if (type == typeof(Art))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Art");
                DGV.Columns[2].HeaderText = _s("Author_s");
                DGV.Columns[3].HeaderText = _s("Genre");
                DGV.Columns[5].HeaderText = _s("Writing_year");
                DGV.Columns[4].HeaderText = _s("Langue_original");
                DGV.Columns[5].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.35);
                DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.20);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("Art_list");
            }
            else if (type == typeof(City))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("City");
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("Cities_list");
            }
            else if (type == typeof(Series))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Series");
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("Series_list");
            }
            else if (type == typeof(PublishingHouse))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Pubhouse");
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("Pubhouses_list");
            }
            else if (type == typeof(Genre))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Genre");
                for (int i = 2; i < DGV.ColumnCount; i++)
                    DGV.Columns[i].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("Genres_list");
            }
            else if (type == typeof(ViewHasRead) || type == typeof(ArtRead))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Date");
                DGV.Columns[2].HeaderText = _s("Author_s");
                DGV.Columns[3].HeaderText = _s("Appellation");
                DGV.Columns[4].HeaderText = _s("Genre");
                DGV.Columns[5].HeaderText = _s("Langue_original");
                DGV.Columns[6].HeaderText = _s("Notice");
                DGV.Columns[7].HeaderText = _s("Mark");
                DGV.Columns[8].HeaderText = _s("Format");
                if (StatusProperty is not null) StatusProperty.Message = _s("Read_list");
            }
            else if (type == typeof(ViewMyBooksInOtherHand))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].Visible = false;//Place
                DGV.Columns[2].HeaderText = _s("Notice");
                DGV.Columns[3].HeaderText = _s("Action");
                DGV.Columns[4].HeaderText = _s("Date");
                DGV.Columns[5].HeaderText = _s("Appellation");
                DGV.Columns[6].HeaderText = _s("Author_s");
                for (int i = 7; i <= 13; i++) { DGV.Columns[i].Visible = false; }
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.05);
                DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.25);
                DGV.Columns[3].FillWeight = (int)(DGV.Width * 0.05);
                DGV.Columns[4].FillWeight = (int)(DGV.Width * 0.05);
                DGV.Columns[5].FillWeight = (int)(DGV.Width * 0.25);
                DGV.Columns[6].FillWeight = (int)(DGV.Width * 0.3);
                if (StatusProperty is not null) StatusProperty.Message = _s("Books_list_taken_by_others");
            }
            else if (type == typeof(Mark))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Mark");
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("Marks_list");
            }
            else if (type == typeof(BookFormat))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Format");
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("Formats_list");
            }
            else if (type == typeof(Place))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[3].Visible = false;
                DGV.Columns[4].Visible = false;
                DGV.Columns[5].Visible = false;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].HeaderText = _s("Storage");
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.45);
                DGV.Columns[2].HeaderText = _s("Comment");
                DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.45);

                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("Storages_list");
            }
            else if (type == typeof(Person))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Simple_proper_name");
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[4].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("Persons_list");
            }
            else if (type == typeof(ArtToRead))
            {
                DGV.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Date");
                DGV.Columns[2].HeaderText = _s("Source_type");
                DGV.Columns[3].HeaderText = _s("Source");
                DGV.Columns[4].HeaderText = _s("Recommendation_type");
                DGV.Columns[5].HeaderText = _s("Recommendation");
                DGV.Columns[6].HeaderText = _s("Comment");
                DGV.Columns[0].FillWeight = 20;
                DGV.Columns[1].FillWeight = 20;
                DGV.Columns[2].FillWeight = 20;
                DGV.Columns[4].FillWeight = 20; 
                if (StatusProperty is not null) StatusProperty.Message = _s("Recommendations_list");
            }
            else if (type == typeof(SourceToreadAnother))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Appellation");
                for (int i = 2; i < DGV.ColumnCount; i++)
                    DGV.Columns[i].Visible = false;
                DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
                DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (StatusProperty is not null) StatusProperty.Message = _s("another_source_list");
             }
            else if (type == typeof(Location))
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGV.Columns[0].HeaderText = "Id";
                DGV.Columns[1].HeaderText = _s("Date");
                DGV.Columns[2].HeaderText = _s("Action");
                DGV.Columns[3].HeaderText = _s("Notice");
                DGV.Columns[4].HeaderText = _s("Appellation");
                DGV.Columns[5].HeaderText = _s("Author_s");
                DGV.Columns[6].HeaderText = _s("Genre");
                DGV.Columns[7].HeaderText = _s("Publication_year");
                DGV.Columns[8].HeaderText = _s("Code");
                DGV.Columns[9].HeaderText = _s("ID_book_short_text");
                DGV.Columns[10].HeaderText = _s("Placement");
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
                if (StatusProperty is not null) StatusProperty.Message = _s("Placements_list");
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
                                       where row.Cells["Формат"].Value is not null
                                       where f.Name == row.Cells["Формат"].Value.ToString()
                                       select f.Id).FirstOrDefault();
                if (lib_postgres.CODE.Data.format_colors.ContainsKey(format_color_id))
                    row.DefaultCellStyle.BackColor = lib_postgres.CODE.Data.format_colors[format_color_id];
                var mark_color_id = (from m in marks
                                     where row.Cells["Оценка"].Value is not null
                                     where m.Name == row.Cells["Оценка"].Value.ToString()
                                     select m.Id).FirstOrDefault();
                if(lib_postgres.CODE.Data.marks_colors.ContainsKey(mark_color_id))
                    if (mark_color_id < 4 || mark_color_id > 6)
                        row.Cells["Оценка"].Style.BackColor = lib_postgres.CODE.Data.marks_colors[mark_color_id];
            }

        }
        /// <summary>
        /// just for substitute string with local version more simble in code
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string _s(string key)
        {
            return lib_postgres.Localization.Substitute(key);
        }
        public void Refresh_DGV_for_Get_Books_by_Place_Name(DataGridView DGV)
        {
          
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.Columns[0].HeaderText = "Id";
            DGV.Columns[1].Visible = false;
            DGV.Columns[2].HeaderText = _s("Notice");
            DGV.Columns[3].HeaderText = _s("Action");
            DGV.Columns[4].HeaderText = _s("Date");
            DGV.Columns[5].HeaderText = _s("Appellation");
            DGV.Columns[6].HeaderText = _s("Author_s");
            DGV.Columns[7].HeaderText = _s("Genre");
            DGV.Columns[8].HeaderText = _s("Langue_original");
            DGV.Columns[9].HeaderText = _s("Language_pub");
            DGV.Columns[10].HeaderText = _s("Publication_year");
            DGV.Columns[11].HeaderText = _s("Pubhouse");
            DGV.Columns[12].HeaderText = _s("Code");
            DGV.Columns[13].HeaderText = _s("Pages");
        }
    }
}