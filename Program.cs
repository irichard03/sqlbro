using System;
using System.IO;
using System.Data.SqlClient;

namespace sqlbro
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHelper config = new ConfigurationHelper();
            string DatabaseConnection = config.getConfig("Database");

            //connect to databse
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConnection))
                {
                    string query = @"SELECT @@VERSION";                
                    SqlCommand command = new SqlCommand(query, connection);
                    //open connection
                    connection.Open();

                    //execute the SQLCommand
                    SqlDataReader dataReader = command.ExecuteReader();

                    //check if there are records
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            //display retrieved record (first column only/string value)
                            Console.WriteLine(dataReader.GetString(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dataReader.Close();
                }
            }
            
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }


        }
    }
}
