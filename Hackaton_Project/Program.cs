using System;
using System.Text;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{

    class Program
    {
        static void Main(string[] args)
        {
            string path = "Resource\\bad.csv";
            List<string> listAddres = new List<string>();
            using (var reader = new StreamReader(path))
            {
                reader.ReadLine(); //костыль
                while (!reader.EndOfStream)
                {
                    string str = reader.ReadLine();
                    string[] strArr = str.Split(';');
                    str = str.Remove(0, strArr[0].Count() + 1);
                    listAddres.Add(str);
                }

            }

        }
    }
}