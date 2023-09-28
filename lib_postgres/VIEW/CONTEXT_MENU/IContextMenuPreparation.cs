using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.VIEW.CONTEXT_MENU
{
    public interface IContextMenuPreparation
    {
        ToolStripItemCollection ContexctMenu_Prepare() => throw new NotImplementedException();
    }
}
