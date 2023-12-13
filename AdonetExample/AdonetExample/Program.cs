using AdonetExample;
using System;
using System.Threading.Channels;
namespace AdoDotNetExample
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("Enter you insert a Student: ");
            string[] parts = Console.ReadLine().Split(" ");

            Console.WriteLine();

            string connectionString = "Server=HABIBOR-RAHAMAN\\SQLEXPRESS;Database=CSharp_Batch_15;User Id=habibor144369;Password=c++c++c#; Trust Server Certificate=True;";
            AdionetUtility adionetUtility = new AdionetUtility(connectionString);

            string insertQuery = "Insert Into Students(Name, Address, CGPA) Values(@Name, @Address, @CGPA);";
            string updateQuery = "Update Students Set Name = 'Allen Walker Mark' Where Id = 16";
            string deleteQuery = "Delete From Students Where Id = @Id";
            string getDataQuery = "Select * From Students Where Id = @Id";

            //inser data in database
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Name", parts[0]);
            parameters.Add("Address", parts[1]);
            parameters.Add("CGPA", parts[2]);

            // delete student by id
            Dictionary<string, object> parameters2 = new Dictionary<string, object>();
            Console.WriteLine("Enter student id which will delete: ");
            int Id = int.Parse(Console.ReadLine());
            parameters2.Add("Id", Id);

            //get data by id
            Dictionary<string, object> parameters3 = new Dictionary<string, object>();
            Console.WriteLine("Enter student id which will provide info to you: ");
            int pk = int.Parse(Console.ReadLine());
            parameters3.Add("Id", pk);

            adionetUtility.ExecuteSql(insertQuery, parameters);
            adionetUtility.ExecuteSql(deleteQuery, parameters2);


            IList<Dictionary<string, object>> results = adionetUtility.GetData(getDataQuery, parameters3);
            foreach(Dictionary<string, object> item in results)
            {
                foreach(KeyValuePair<string, object> kvp in item)
                {
                    Console.Write($"{kvp.Value} ");
                }
                Console.WriteLine();
            }
        }
    }
}
