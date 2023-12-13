using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdonetExample
{
    public class AdionetUtility
    {
        private readonly string _connectionString;
        public AdionetUtility(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ExecuteSql(string sqlQuery, Dictionary<string, object> parameters)
        {
            using SqlCommand command = CreateCommand(sqlQuery, parameters);
            

            int effection = command.ExecuteNonQuery();
            Console.WriteLine($"Effection: {effection}");
        }

        public IList<Dictionary<string, object>> GetData(string sqlQuery, Dictionary<string, object> parameters)
        {
            using SqlCommand command = CreateCommand(sqlQuery, parameters);
            using SqlDataReader reader =  command.ExecuteReader();
            List<Dictionary<string, object>> Items = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                foreach(string keys in Enumerable.Range(0, reader.FieldCount).Select(reader.GetName))
                {
                    data.Add(keys, reader[keys]);
                }

                /*for (int i = 0; i < reader.FieldCount; i++)
                {
                    data.Add(reader.GetName(i), reader.GetValue(i));
                }*/
                Items.Add(data);
            }
            return Items;
        }

        private SqlCommand CreateCommand(string sqlQuery, Dictionary<string, object> parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
            }

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            return command;
        }
    }
}
