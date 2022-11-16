using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mssql_connection_crud_operations.Connect
{
    public class CRUD
    {
        string sql=String.Empty;
        SqlConnection conn = new SqlConnection(Dalc.GetConnect);
        SqlCommand command;
        int result;
        bool output;
    public int Insert(string Name, string Surname, string Father_Name, string Birth_date, string Address, 
                string Email, string Gender, string Status)
        {
            sql = "insert into Students values('" + Name + "','" + Surname + "','"+Father_Name+"','"+Birth_date+"','"+Address+"','"+Email+"','"+Gender+"','"+Status+"')";
            command = new SqlCommand(sql, conn);
            try
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }
                int rslt=command.ExecuteNonQuery();
                if(rslt>0)
                {
                    result=1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(conn.State!=ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return 1;
        }
        public int Update(int id, string Name, string Surname, string Father_Name, string Birth_date, string Address,
                string Email, string Gender, string Status)
        {
            if(id<=0)
            {
                return 0;
            }
            SqlCommand cmd=new SqlCommand("select * from Students", conn);
            SqlDataReader ds = cmd.ExecuteReader();
            if (Name == "")
            {
                if (ds.Read())
                {
                    Name = ds[1].ToString();
                }
            }

            if (Surname=="")
            {
                if(ds.Read())
                {
                    Surname = ds[2].ToString();
                }
            }
            if (Father_Name == "")
            {
                if (ds.Read())
                {
                    Father_Name = ds[3].ToString();
                }
            }
            if (Birth_date == "")
            {
                if (ds.Read())
                {
                    Birth_date = ds[4].ToString();
                }
            }
            if (Address == "")
            {
                if (ds.Read())
                {
                    Address = ds[5].ToString();
                }
            }
            if (Email == "")
            {
                if (ds.Read())
                {
                    Email = ds[6].ToString();
                }
            }
            if (Gender == "")
            {
                if (ds.Read())
                {
                    Gender = ds[7].ToString();
                }
            }
            if (Status == "")
            {
                if (ds.Read())
                {
                    Status = ds[8].ToString();
                }
            }
            ds.Close();
            sql = "update Students set Name = '" + Name + "',Surname='" + Surname + "', Father_Name='" + Father_Name + "',Birth_date='" + Birth_date + "',Adress='"+ Address + "',Email='" + Email + "',Gender='" + Gender + "',Status='" + Status + "' where ID="+id;
            command = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                int res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    result = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return 1;
        }
        public int Delete(int id)
        {
            sql = "Delete from Students where ID=" + id;
            command = new SqlCommand(sql, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                int res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    result = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return 1;
        }

        public List<Data> Select()
        {
            sql = "select * from Students";
            command = new SqlCommand(sql, conn);
            List<Data> lst = new List<Data>();
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add(new Data((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return lst;
        }

        public bool selectId(int ID)
        {

            string query = "select ID from Students where ID=" + ID;
            command= new SqlCommand(query, conn);
            try
            {
                string checkid = "";
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                IDataReader dr=command.ExecuteReader();
                if(dr.Read())
                {
                    checkid=dr[0].ToString();
                }
                if (checkid==ID.ToString())
                {
                    output = true;
                }
                else
                {
                     output = false;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return output;
        }



    }



 }

