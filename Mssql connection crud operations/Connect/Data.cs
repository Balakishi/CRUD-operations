using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mssql_connection_crud_operations.Connect
{
    public class Data
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Father_Name { get; set; }
        public string Birth_date { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public Data()
        {

        }

        public Data(int id, string Name, string Surname, string Father_Name, string Birth_date, string Address,
                string Email, string Gender, string Status)
        {
            this.ID= id;
            this.Name =Name;
            this.Surname = Surname;
            this.Father_Name = Father_Name;
            this.Birth_date = Birth_date;
            this.Adress = Address;
            this.Email = Email;
            this.Gender = Gender;
            this.Status = Status;
        }

    }
}
