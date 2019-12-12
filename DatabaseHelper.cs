using System;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace sqlbro
{
    class DatabaseHelper
    {
        //constructor
        private string DatabaseConnection;
        public DatabaseHelper()
        {
            ConfigurationHelper config = new ConfigurationHelper();
            this.DatabaseConnection = config.getConfig("Database");
        }

        public List<string> getData(string criteria)
        {
            List<string> data = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.DatabaseConnection))
                {
                    string query = @"Select m.firstName, m.lastName from managers m where " + criteria;
                    string firstName;
                    string lastName;
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {

                        while (dataReader.Read())
                        {
                            //display retrieved record (first column only/string value)
                            firstName = dataReader.GetString(0);
                            lastName = dataReader.GetString(1);

                            //display retrieved record
                            data.Add(firstName + " " + lastName);
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
                Console.WriteLine("Exception: " + ex.Message);
            }
            return data;
        }
    }
}