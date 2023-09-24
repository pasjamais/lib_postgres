using lib_postgres.CODE;
using lib_postgres.CODE.CRUD;
using lib_postgres.CODE.DEPLOY;
using lib_postgres.CODE.VIEW.DELITEMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lib_postgres.FORMS
{
    public partial class Form_Settings : Form
    {
        private Deleted_Entities_Visuaisator deleted_Entities_Visuaisator;
        public Form_Settings()
        {
            InitializeComponent();
            ChB_Backup_on_Start.Checked = Backup.is_Backup_on_Start();
            deleted_Entities_Visuaisator = new Deleted_Entities_Visuaisator();
            ChB_Show_Deleted_Entities.Checked = deleted_Entities_Visuaisator.Is_Colorize_deleted_items;
            ChB_Delete_Forever.Checked = CRUD_Item_Determinator.is_Elements_Erasable();
        }

    }
}
