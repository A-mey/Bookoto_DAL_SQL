using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.Text;
using DataAccess.Models;

namespace DataAccess.DBAccess
{
    public class DBA
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        DataSet ds;
        SqlDataReader reader;
        String SqlConnectionString;


        public SqlConnection getConnection()
        {
            //String SqlConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnectionString = "Server =DESKTOP-5JAU2HK\\SQLEXPRESS; Database = SIP; User Id = sa; Password = root;";

            if (con == null || con.State == ConnectionState.Closed)
                con = new SqlConnection(SqlConnectionString);


            return con;
        }

        public DataSet DBExec(String StoredProcedure, Test Test)
        {
            try
            {
                //string Query = GetQuery(StoredProcedure, ObjectClass);
                //SqlConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlConnectionString = "Server =DESKTOP-5JAU2HK\\SQLEXPRESS; Database = SIP; User Id = sa; Password = root;";
                getConnection();
                SqlCommand cmd = GetCmd(StoredProcedure, Test);
                //SqlCommand cmd = new SqlCommand(StoredProcedure);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CategoryID", Test.CategoryID);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.Connection = con;
                adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                adapter.Dispose();
                DisposeAll();
                return ds;
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return null;
            }


        }

        public SqlCommand GetCmd(String StoredProcedure, object ObjectClass = null)
        {
            SqlCommand cmd = new SqlCommand(StoredProcedure);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (ObjectClass != null)
                {
                    Type type = ObjectClass.GetType();
                    PropertyInfo[] properties = type.GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        cmd.Parameters.AddWithValue("@"+ property.Name, property.GetValue(ObjectClass, null));                      
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return cmd;
        }

        public void DisposeAll()
        {
            try
            {
                if (cmd != null)
                    cmd.Dispose();

                if (con != null)
                    con.Dispose();

                if (reader != null)
                    reader.Close();

                if (adapter != null)
                    adapter.Dispose();



            }
            catch (Exception ex)
            {

            }
        }
    }
}
