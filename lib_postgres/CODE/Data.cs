using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.CODE
{
    public class Data
    {
        public static Dictionary<long, Color> format_colors = new Dictionary<long, Color>
        {
            {1, Color.LightYellow   },
            {2, Color.LightGray     },
            {3, Color.LightGreen     }
        };
        
        public static Dictionary<long, Color> marks_colors = new Dictionary<long, Color>
        {
            {1, Color.Black         },
            {2, Color.Brown         },
            {3, Color.Gray          },
            {4, Color.Gray          },
            {5, Color.Gray          },
            {6, Color.Gray          },
            {7, Color.MistyRose     },
            {8, Color.PaleVioletRed },
            {9, Color.MediumVioletRed },
            {10, Color.DarkRed      }
        };

        public static string ini_file_name = "settings.ini";
    }
}
