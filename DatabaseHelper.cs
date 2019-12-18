using System;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

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
            string email;
            string firstName;
            string lastName;
            int managerId;

            
            List<string> data = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.DatabaseConnection))
                {
                    string spName = @"dbo.[uspGetManager]";
                    SqlCommand command = new SqlCommand(spName, connection);
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@email";
                    param1.SqlDbType = SqlDbType.VarChar;
                    param1.Value = criteria;
                    command.Parameters.Add(param1);
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {

                        while (dataReader.Read())
                        {
                            //display retrieved record (first column only/string value)
                            managerId = dataReader.GetInt32(0);
                            firstName = dataReader.GetString(1);
                            lastName = dataReader.GetString(2);
                            email = dataReader.GetString(3);

                            //display retrieved record
                    
                            data.Add(
                                $"ID\tFirst\tLast\temail\n{managerId}\t{firstName}\t{lastName}\t{email}");
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