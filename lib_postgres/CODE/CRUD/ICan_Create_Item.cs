using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace lib_postgres.CODE.CRUD
{
    public  interface ICan_Create_Item
    {   
        //throw an exception to avoid method default body  throw an exception
        static long  Create_Item() => throw new NotImplementedException();
    }
}
