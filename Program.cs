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
            if (args.Length > 0)
            {
                List<String> myData = db.getData("ianrichard03@gmail.com");

                foreach (string name in myData)
                {
                    Console.WriteLine(name);
                }
            }

        }
    }
}
