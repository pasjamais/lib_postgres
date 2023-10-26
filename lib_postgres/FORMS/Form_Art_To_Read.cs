using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;
using lib_postgres.VIEW.COMBOBOX;
using lib_postgres.VIEW.NOTICE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static lib_postgres.VIEW.SPEC_ENTITIES_VIEWS.Structures;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using RadioButton = System.Windows.Forms.RadioButton;

namespace lib_postgres.FORMS
{
    public partial class Form_Art_To_Read : Form
    {
        private ArtToRead item = new();

        public RadioButton_Colorized    selectedrb_toread, // selectedrb_toread.Tag = true : art; = false : author
                                        selectedrb_source; // selectedrb_source.Tag can be "Art", "Author" or "SourceToreadAnother"  
        private Dictionary<string, long> Sources_saved_positions;
        public Form_Art_To_Read(Dictionary<string, long> sources_saved_positions) : this()
        {
            Sources_saved_positions = sources_saved_positions;
            ComboBox_Helper.CB_reload_for_Special_Types<Short_Art>(CB_Toread_Art, sources_saved_positions["art_to_read"]);
            ComboBox_Helper.CB_reload<Author>(CB_Toread_Author, sources_saved_positions["author_to_read"]);
            ComboBox_Helper.CB_reload_for_Special_Types<Short_Art>(CB_Source_Art, sources_saved_positions["art"]);
            ComboBox_Helper.CB_reload<Author>(CB_Source_Author, sources_saved_positions["author"]);
            ComboBox_Helper.CB_reload<SourceToreadAnother>(CB_Source_Another, sources_saved_positions["another"]);
        
        }
        public Form_Art_To_Read()
        {
            InitializeComponent();
            ComboBox_Helper.CB_reload_for_Special_Types<Short_Art>(CB_Toread_Art);
            ComboBox_Helper.CB_reload<Author>(CB_Toread_Author);
            ComboBox_Helper.CB_reload_for_Special_Types<Short_Art>(CB_Source_Art);
            ComboBox_Helper.CB_reload<Author>(CB_Source_Author);
            ComboBox_Helper.CB_reload<SourceToreadAnother>(CB_Source_Another);
            RB_Toread_Art.Tag = true;
            RB_Toread_Author.Tag = false;
        }
        public Form_Art_To_Read(ArtToRead item) : this()
        {
            this.item = item;
            Load_Item_in_Form(item);
        }
        private void BT_Add_Art_Click(object sender, EventArgs e)
        {
            var id = Art.Create_Item();
            if (id > 0)
            {   if(CB_Source_Art.SelectedValue != null)
                    CB_Source_Art.Tag = CB_Source_Art.SelectedValue;
                ComboBox_Helper.CB_reload<Art>(CB_Toread_Art, id);
                ComboBox_Helper.CB_reload<Art>(CB_Source_Art, (long)CB_Source_Art.Tag);
                RB_Toread_Art.Checked = true;
            }
            DialogResult = DialogResult.None;
           
        }

        private void BT__Toread_Author_Click(object sender, EventArgs e)
        {
            var id = Author.Create_Item();
            if (id > 0)
            {
                if (CB_Source_Author.SelectedValue != null)
                    CB_Source_Author.Tag = CB_Source_Author.SelectedValue;
                ComboBox_Helper.CB_reload<Author>(CB_Toread_Author, id);
                ComboBox_Helper.CB_reload<Author>(CB_Source_Author, (long)CB_Source_Author.Tag);
                RB_Toread_Author.Checked = true;
            }
            DialogResult = DialogResult.None;
            
        }

        private void BT__Another_Source_Add_Click(object sender, EventArgs e)
        {
            var id = SourceToreadAnother.Create_Item();
            if (id > 0)
            {
                ComboBox_Helper.CB_reload<SourceToreadAnother>(CB_Source_Another, id);
                RB_Source_Another.Checked = true;
            }
            DialogResult = DialogResult.None;
            
        }

        private void radioButton_ToRead_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_Colorized rb = sender as RadioButton_Colorized;
            if (rb == null)
            {
                return;
            }
            if (rb.Checked)
            {
                selectedrb_toread = rb;
            }
        }

        private void radioButton_Source_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_Colorized rb = sender as RadioButton_Colorized;
            if (rb == null)
            {
                return;
            }
            if (rb.Checked)
            {
                selectedrb_source = rb;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Notice notice = new Notice();

            if (selectedrb_toread == null || !selectedrb_toread.Checked)
            {
                this.DialogResult = DialogResult.TryAgain;
                notice.Notice_by_Color<RadioButton_Colorized>(RB_Toread_Art);
                notice.Notice_by_Color<RadioButton_Colorized>(RB_Toread_Author);
            }
            else if (selectedrb_source == null || !selectedrb_source.Checked)
            {
                this.DialogResult = DialogResult.TryAgain;
                notice.Notice_by_Color<RadioButton_Colorized>(RB_Source_Another);
                notice.Notice_by_Color<RadioButton_Colorized>(RB_Source_Art);
                notice.Notice_by_Color<RadioButton_Colorized>(RB_Source_Author);
            }
            else if ((bool)selectedrb_toread.Tag && CB_Toread_Art.SelectedValue == null) //art
            {
                this.DialogResult = DialogResult.TryAgain;
                notice.Notice_by_Color<RadioButton_Colorized>(RB_Toread_Art);
            }
            else if (!(bool)selectedrb_toread.Tag && CB_Toread_Author.SelectedValue == null) //author
            {
                this.DialogResult = DialogResult.TryAgain;
                notice.Notice_by_Color<RadioButton_Colorized>(RB_Toread_Author);
            }
            else if ((string)selectedrb_source.Tag == "Art" && CB_Source_Art.SelectedValue == null)
            {
                this.DialogResult = DialogResult.TryAgain;
                notice.Notice_by_Color<RadioButton_Colorized>(RB_Source_Art);
            }
            else if ((string)selectedrb_source.Tag == "Author" && CB_Source_Author.SelectedValue == null)
            {
                this.DialogResult = DialogResult.TryAgain;
                notice.Notice_by_Color<RadioButton_Colorized>(RB_Source_Author);
            }
            else if ((string)selectedrb_source.Tag == "SourceToreadAnother" && CB_Source_Another.SelectedValue == null)
            {
                this.DialogResult = DialogResult.TryAgain;
                notice.Notice_by_Color<RadioButton_Colorized>(RB_Source_Another);
            }
            else
            {
                Check_if_Recommendation_Already_Exists();
                //this.DialogResult = DialogResult.OK;
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void Form_Art_To_Read_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.TryAgain)
                e.Cancel = true;
        }
        private  void Notice_to_Fill_RBs()
        {
            Notice notice = new Notice();
            notice.Notice_by_Color<RadioButton_Colorized>(RB_Source_Another);
            notice.Notice_by_Color<RadioButton_Colorized>(RB_Source_Art);
            notice.Notice_by_Color<RadioButton_Colorized>(RB_Source_Author);
            notice.Notice_by_Color<RadioButton_Colorized>(RB_Toread_Art);
            notice.Notice_by_Color<RadioButton_Colorized>(RB_Toread_Author);
        }

        private void BT_Add_Art_Source_Click(object sender, EventArgs e)
        {
            var id = Art.Create_Item();
            if (id > 0)
            {
                if (CB_Toread_Art.SelectedValue != null)
                    CB_Toread_Art.Tag = CB_Toread_Art.SelectedValue;

                ComboBox_Helper.CB_reload<Art>(CB_Toread_Art, (long) CB_Toread_Art.Tag);
                ComboBox_Helper.CB_reload<Art>(CB_Source_Art, id);
                RB_Source_Art.Checked = true;
            }
            DialogResult = DialogResult.None;
        }

        private void BT__Toread_Author_Source_Click(object sender, EventArgs e)
        {
            var id = Author.Create_Item();
            if (id > 0)
            {
                if (CB_Toread_Author.SelectedValue != null)
                    CB_Toread_Author.Tag = CB_Toread_Author.SelectedValue;
                ComboBox_Helper.CB_reload<Author>(CB_Toread_Author, (long)CB_Toread_Author.Tag);
                ComboBox_Helper.CB_reload<Author>(CB_Source_Author, id);
                RB_Source_Author.Checked = true;
            }
            DialogResult = DialogResult.None;
        }

        private void CB_Toread_Art_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RB_Toread_Art.Checked = true;
        }

        private void CB_Toread_Author_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RB_Toread_Author.Checked = true;
        }

        private void CB_Source_Art_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RB_Source_Art.Checked = true;
        }

        private void CB_Source_Author_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RB_Source_Author.Checked = true;
        }

        private void CB_Source_Another_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RB_Source_Another.Checked = true;
        }

        private void Load_Item_in_Form(ArtToRead item)
        {
            if (item.Date is not null)
            {
                DateTime d = new DateTime(item.Date.Value.Year, item.Date.Value.Month, item.Date.Value.Day);
                dateTimePicker.Value = d;
            }
            if (item.Comment != null) TB_Comment.Text = item.Comment;
            if (item.ToreadArtId != null)
            {
                CB_Toread_Art.SelectedValue = item.ToreadArtId;
                RB_Toread_Art.Checked = true;
                selectedrb_toread = RB_Toread_Art;
            }
            if (item.ToreadAuthorId != null)
            {
                CB_Toread_Author.SelectedValue = item.ToreadAuthorId;
                RB_Toread_Author.Checked = true;
                selectedrb_toread = RB_Toread_Author;
            }
            if (item.SourceAnotherId != null)
            {
                CB_Source_Another.SelectedValue = item.SourceAnotherId;
                RB_Source_Another.Checked = true;
                selectedrb_source = RB_Source_Another;
            }
            if (item.SourceAuthorId != null)
            {
                CB_Source_Author.SelectedValue = item.SourceAuthorId;
                RB_Source_Author.Checked = true;
                selectedrb_source = RB_Source_Author;
            }
            if (item.SourceArtId != null)
            {
                CB_Source_Art.SelectedValue = item.SourceArtId;
                RB_Source_Art.Checked = true;
                selectedrb_source = RB_Source_Art;
            }
        }
        public void Check_if_Recommendation_Already_Exists()
        {
            ArtToRead item_in_DB = new();
            ArtToRead.Get_Sources_and_Recommendations_from_Form(item_in_DB, this);
            long item_in_DB_ID = ArtToRead.Get_Already_Existing_Recommendation_ID(item_in_DB);
            if (item_in_DB_ID > 0) // exists in BD
            {
                if (item.Id == 0) // trying to add existing record
                {
                    this.DialogResult = DialogResult.TryAgain;
                    General_Manipulations.Simple_Message(Localization.Substitute("Recommendation_already_exists_and_has_ID") + item_in_DB_ID.ToString());
                }
                else if (item.Id == item_in_DB_ID) //existing record edition
                {
                    this.DialogResult = DialogResult.OK;
                }
                else //trying to edit existing record, but result record already exists
                {
                    this.DialogResult = DialogResult.TryAgain;
                    General_Manipulations.Simple_Message(Localization.Substitute("Recommendation_already_exists_and_has_ID") + item_in_DB_ID.ToString());
                }
            }
            else // does not exist in BD
            {
                if (item.Id == 0) // new element adding
                {
                    this.DialogResult = DialogResult.OK;
                }
                else // impossible case
                { 
                
                }
            }
        }
    }
}