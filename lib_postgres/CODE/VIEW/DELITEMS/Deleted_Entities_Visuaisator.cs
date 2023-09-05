using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace lib_postgres.CODE.VIEW.DELITEMS
{
    public class Deleted_Entities_Visuaisator
    {
        private bool is_Colorize_del_items;
        public bool Is_Colorize_deleted_items
        {
            get
            {
                return is_Colorize_del_items;
            }
            set
            {
                is_Colorize_del_items = value;
            }
        }

        private Dictionary<bool, IShowDeletedEntities> _commands;
        public Deleted_Entities_Visuaisator()
        {
            this.is_Colorize_del_items = Get_Value_isShow_Deleted_from_INI_File();
            _commands = new Dictionary<bool, IShowDeletedEntities>();
            SetCommand(true, new DeletedItemsColorizator());
            SetCommand(false, new NothingDo());
        }
        public void SetCommand(bool commandId, IShowDeletedEntities cmd)
        {
            _commands[commandId] = cmd;
        }
        public void RunCommand(bool commandId, List<long> deleted_IDs, DataGridView DGV)
        {
            if (_commands.ContainsKey(commandId))
                _commands[commandId].Execute(deleted_IDs, DGV);
        }
        
        public void Write_Value_isShow_Deleted_to_INI_File(bool new_value)
        {
            IniFileInteraction.Set_Value_into_Settings_File("Show_Deleted_Items", new_value.ToString());
        }
        public void Write_Value_isShow_Deleted_to_INI_File()
        {
            IniFileInteraction.Set_Value_into_Settings_File("Show_Deleted_Items", is_Colorize_del_items.ToString());
        }
        public bool Get_Value_isShow_Deleted_from_INI_File()
        {
            string value = IniFileInteraction.Get_Value_from_Settings_File("Show_Deleted_Items", "GENERAL");
            bool result = Convert.ToBoolean(value);
            if (result) return true;
            else return false;
        }

        public void RunCommand(List<long> deleted_IDs, DataGridView DGV)
        {
            if (_commands.ContainsKey(is_Colorize_del_items))
                _commands[is_Colorize_del_items].Execute(deleted_IDs, DGV);
        }
    }
}
