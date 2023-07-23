using lib_postgres.CODE;
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
        public Form_Settings()
        {
            InitializeComponent();
            ChB_Backup_on_Start.Checked = Backup.is_Backup_on_Start();
            ChB_Show_Deleted_Entities.Checked = DeletedEntities.is_Show_Deleted_Items();
        }

    }
}
