using System;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace sqlbro
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper db = new DatabaseHelper();
            List<String> myData = db.getData("firstName = 'Ian'");
            foreach(string name in myData)
            {
                Console.WriteLine(name);
            }
        }
    }
}
