using lib_postgres.CODE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class SourceToreadAnother
    {
        public static long Add_Another_Source()
        {
            var new_name = General_Manipulations.simple_element_add("Добавить другой источник рекомендации", "Наименование:");
            if (new_name != "")
            {
                if (DB_Agent.Is_Exists_Another_Source(new_name))
                {
                    General_Manipulations.simple_message("Источник уже существует");
                    return 0;
                }
                else
                {
                    lib_postgres.SourceToreadAnother element = new lib_postgres.SourceToreadAnother();
                    element.Name = new_name;
                    DB_Agent.db.SourceToreadAnothers.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return 0;
        }
    }
}
