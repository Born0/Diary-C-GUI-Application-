using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_36449_1.cs.Repository
{
    class DataAccess
    {
        static SqlConnection connection;
        static SqlCommand command;

        public DataAccess()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Diary"].ConnectionString);
            connection.Open();
        }

        public SqlDataReader GetData(string sql)
        {
            connection.Close();
            connection.Open();
            command = new SqlCommand(sql, connection);
            return command.ExecuteReader();
        }

        public int ExecuteQuery(string sql)
        {
            connection.Close();
            connection.Open();
            command = new SqlCommand(sql, connection);
            
            return command.ExecuteNonQuery();
            
        }

        public void Dispose()
        {
            connection.Close();
        }
       
    }
}
