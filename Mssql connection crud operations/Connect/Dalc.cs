using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mssql_connection_crud_operations.Connect
{
    public class Dalc
    {
        public static string GetConnect
        {
            get { return "Data Source =HOME-PC\\SQLEXPRESS; Initial Catalog = Northwind; Integrated Security = True"; }
        }
    }
}
