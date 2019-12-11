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
            Console.WriteLine(config.getConfig("Storage"));            
        }
    }
}
