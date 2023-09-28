using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_postgres.CRUD;

namespace lib_postgres.QUERIES
{
    public static class Queries_from_Views
    {
        public static List<ViewAllRealBook> Get_Books_in_their_Places()
        {
            return DB_Agent.Get_ViewAllRealBook();
        }
        public static List<ViewBook> Get_Books()
        {
            return DB_Agent.Get_ViewBooks();
        }
        public static List<ViewMyBooksInOtherHand> Get_My_Books_in_Other_Hands()
        {
            return DB_Agent.Get_ViewMyBooksInOtherHands();
        }



    }
}
