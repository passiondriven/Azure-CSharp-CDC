using System;
using System.Data.SqlClient;
using System.Text;

namespace Azure_CSharp_CDC
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source= mysqlserver1101.database.windows.net;Initial Catalog=mySampleDatabase;User ID=azureuser;Password=qwe123QWE!@#;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //Show database connection string
            string query = "";
            // SQL query to select changes from CDC table
            //string query = "SELECT * FROM cdc.YourCDCSchema_YourTrackedTable_CT";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("=========================Category_Table=================================");
            query = "SELECT category_name FROM dbo.Categories";
            ShowCategory(query, connection);
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Are you update database? y/n");
            string updateOk = Console.ReadLine();
            if (updateOk == "y")
            {
                Console.WriteLine("Input the category_name to update!");
                string value1 = Console.ReadLine();
                Console.WriteLine("Input the new category_name !");
                string value2 = Console.ReadLine();
                query = "UPDATE dbo.Categories SET category_name = '" + value2.ToString() + "' WHERE category_name = '" + value1.ToString() + "'";
                Console.WriteLine(query);
                ShowCategory(query, connection);
                query = "SELECT category_name FROM dbo.Categories";
                ShowCategory(query, connection);
            }
            else if (updateOk == "n")
            {
                 query = "SELECT category_name FROM dbo.Categories";
                ShowCategory(query, connection);
            }
            else
            {
                query = "SELECT category_name FROM dbo.Categories";
                ShowCategory(query, connection);
            }

           // SqlCommand command1 = new SqlCommand(query1, connection);

            Console.ReadLine();
        }

        public static void  ShowCategory(string query ,SqlConnection connection) 
        {
            StringBuilder errorMessages = new StringBuilder();
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                int rowsAffected = 0;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rowsAffected++;
                    string column = reader["category_name"].ToString();
                    Console.WriteLine(column);
                }
                reader.Close();
                Console.WriteLine("Rows affected: " + rowsAffected);

            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
            }
        }
    }
}
