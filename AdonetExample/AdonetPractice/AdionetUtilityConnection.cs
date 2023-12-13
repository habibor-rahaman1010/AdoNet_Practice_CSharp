using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdonetPractice
{
    public class AdionetUtilityConnection
    {
        private string _connectionString;

        public AdionetUtilityConnection(string connection)
        {
            _connectionString = connection;
        }

        public SqlConnection DataBaseConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
                Console.WriteLine("database connection stublished...");
            }
            else
            {
                Console.WriteLine("database connection not stublished...");
            }
            return connection;
        }

        private SqlCommand CreateCommand(string query)
        {
            SqlConnection connection = DataBaseConnection();
            SqlCommand command = new SqlCommand(query, connection);
            return command;
        }

        public void InsertData(string query)
        {
            using SqlCommand command = CreateCommand(query);
            int effection = command.ExecuteNonQuery();
            Console.WriteLine($"Effection: {effection}");
        }

        public IList<Dictionary<string, object>> GetData(string query)
        {
            using SqlCommand command = CreateCommand(query);
            using SqlDataReader reader = command.ExecuteReader();
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                foreach (string keys in Enumerable.Range(0, reader.FieldCount).Select(reader.GetName))
                {
                    data.Add(keys, reader[keys]);
                }
                items.Add(data);
            }
            return items;
        }
    }
}
