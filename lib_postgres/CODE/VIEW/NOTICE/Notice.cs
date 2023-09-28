using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public class Notice
    {
        public async void Notice_by_Color<T>(T control)   where T : IHase_Field_BackColor
        {

            Color _color = control.BackColor;
            control.BackColor = Color.Red;
            await Task.Delay(500);
            control.BackColor = _color;
        }

    }
}
