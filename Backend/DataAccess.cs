using System;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace Backend
{
    public class DataAccess
    {
        SqlConnection SqlConnection;
        SqlCommand SqlCommand;
        SqlDataReader sqlReader;

        private string getConnection()
        {
            try
            {                
                return "workstation id=examen;packet size=4096;user id=examen;pwd=examen;data source=129.159.108.167;persist security info=False;initial catalog=examen";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable executeTable(string sqlQuery)
        {
            DataTable dataTable = new DataTable();
            DataColumn dataColumn = new DataColumn();
            try
            {
                SqlConnection = new SqlConnection(getConnection());
                SqlCommand = new SqlCommand();
                SqlConnection.Open();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandTimeout = 0;
                SqlCommand.CommandType = CommandType.Text;
                SqlCommand.CommandText = sqlQuery;
                sqlReader = SqlCommand.ExecuteReader();
                dataTable.Load(sqlReader);
                SqlConnection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                if (SqlConnection != null)
                {
                    if (SqlConnection.State == ConnectionState.Open)
                    {
                        SqlConnection.Close();
                    }
                    SqlConnection.Dispose();
                }
                throw new Exception(ex.Message);
            }
            finally
            {
                SqlConnection.Close();
            }
        }

        public int executeCommand(string sqlQuery)
        {
            try
            {
                SqlConnection = new SqlConnection(getConnection());
                SqlCommand = new SqlCommand();
                SqlConnection.Open();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandTimeout = 0;
                SqlCommand.CommandType = CommandType.Text;
                SqlCommand.CommandText = sqlQuery;
                return SqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (SqlConnection != null)
                {
                    if (SqlConnection.State == ConnectionState.Open)
                    {
                        SqlConnection.Close();
                    }
                    SqlConnection.Dispose();
                }
                throw new Exception(ex.Message);
            }
            finally
            {
                SqlConnection.Close();
            }
        }

    }

}
