using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lib_postgres.CODE.VIEW.DELITEMS
{
    public class DeletedEntities
    {
        private Dictionary<bool, IShowDeletedEntities> _commands;
        public DeletedEntities()
        {
            _commands = new Dictionary<bool, IShowDeletedEntities>();
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

     

        public static void Set_Value_Show_Deleted(bool new_value)
        {
            IniFileInteraction.Set_Value_into_Settings_File("Show_Deleted_Items", new_value.ToString());
        }
        public static bool is_Show_Deleted_Items()
        {
            string value = IniFileInteraction.Get_Value_from_Settings_File("Show_Deleted_Items", "GENERAL");
            bool result = Convert.ToBoolean(value);
            if (result) return true;
            else return false;
        }
    }
}
