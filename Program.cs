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
            string firstName;
            string lastName;

            //connect to databse
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConnection))
                {
                    string query = @"SELECT m.firstname, m.lastName from managers m";                
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
                            firstName = dataReader.GetString(0);
                            lastName = dataReader.GetString(1);

                            //display retrieved record
                            Console.WriteLine("{0},{1}", firstName, lastName);
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
