using System;

namespace AdonetPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello programmer");

            string connectionString = "Server=HABIBOR-RAHAMAN\\SQLEXPRESS;Database=School;User Id=habibor144369;Password=c++c++c#;Trust Server Certificate=True;";

            AdionetUtilityConnection adionetUtilityConnection = new AdionetUtilityConnection(connectionString);

            string insertQuery = """
                Insert Into Students (Name, Department, Session, Email, CGPA, Enrollment)
                Values('Md Abdullah Seikh', 'CSE', 2023, 'abdullahseikh12@gmail.com', 3.22, '2023-06-12');
                """;

            string deleteQuery = """
                Delete Students Where id = 5;
                """;

            string updateQuery = """
                Update Students Set Email  = 'mahmusullah32@gmail.com' Where id  = 6;
                """;

            string getQuery = "Select *From Students";

            adionetUtilityConnection.InsertData(updateQuery);

            IList<Dictionary<string, object>> data = adionetUtilityConnection.GetData(getQuery);
            foreach (Dictionary<string, object> item in data)
            {
                foreach (var key in item)
                {
                    Console.Write($"{key.Value} ");
                }
                Console.WriteLine();
            }
        }
    }
}
