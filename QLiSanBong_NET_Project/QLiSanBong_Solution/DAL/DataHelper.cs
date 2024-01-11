using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLiSanBong_Solution.DAL
{
    public class DataHelper
    {
        private static SqlConnection sqlcon = null;

        [Obsolete]
        public DataHelper()
        {
            string MyCS = ConfigurationSettings.AppSettings["ConnectionString"];
            sqlcon = new SqlConnection(MyCS);

        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();

            try
            {
                if(sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter(query, sqlcon);
                da.Fill(table);
            }
            catch(Exception ex)
            {
                throw new Exception("Error Query : " + ex.Message);
            }
            finally
            {
                sqlcon.Close(); 
            }
            return table;
        }
        public void ExecuteNonQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, sqlcon);

            try
            {
                if(sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Execute non query error: " + ex.Message);
            }
            finally
            {
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }

                if (cmd != null)
                {
                    cmd.Dispose(); // Xoa tai da cap cho cmd ra khoi bo nho
                }
            }
        }
        public int ExcuteScalar(string query)
        {
            SqlCommand cmd = new SqlCommand(query, sqlcon);

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Execute non query error: " + ex.Message);
            }
            finally
            {
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }

                if (cmd != null)
                {
                    cmd.Dispose(); // Xoa tai da cap cho cmd ra khoi bo nho
                }
            }
        }
        public long ExcuteScalar2(string query)
        {
            SqlCommand cmd = new SqlCommand(query, sqlcon);

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                long result = (long)cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Execute non query error: " + ex.Message);
            }
            finally
            {
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }

                if (cmd != null)
                {
                    cmd.Dispose(); // Xoa tai da cap cho cmd ra khoi bo nho
                }
            }
        }
    }
}
