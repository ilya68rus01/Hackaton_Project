using System;
using System.Text;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static Hackaton_Project.RomanConverter;

namespace Hackaton_Project
{
    
    class Program
    {
        static char[] removeChar = { '\"' } ;
        static void Main(string[] args)
        {
            string path = "Resource\\bad.csv";
            List<string> listAddres = new List<string>();
            
            AddressProcessor ap = new AddressProcessor();
            ap.RemoveChars = removeChar;
            
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
            List<string> outAddress = ap.processor(listAddres).ToList();

        }
    }
}