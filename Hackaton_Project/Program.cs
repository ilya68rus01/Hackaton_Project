using System;
using System.Text;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;

using CsvHelper.Configuration;

namespace Hackaton_Project
{
    
    class Program
    {
        public class Foo
        {
            public int Id { get; set; }
            public string badAddres { get; set; }
            public string goodAddres { get; set; }
        }

        public class FooMap : ClassMap<Foo>
        {
            public FooMap()
            {
                Map(m => m.Id).Index(0).Name("id");
                Map(m => m.badAddres).Index(1).Name("badAddress");
                Map(m => m.goodAddres).Index(1).Name("goodAddress");
            }
        }

        static char[] removeChar = { '\"' } ;
        static void Main(string[] args)
        {
            string path = "Resource\\bad.csv";
            List<string> listAddres = new List<string>();
            List<int> id = new List<int>();
            AddressProcessor ap = new AddressProcessor();
            ap.RemoveChars = removeChar;
            
            using (var reader = new StreamReader(path))
            {
                reader.ReadLine(); //костыль
                while (!reader.EndOfStream)
                {
                    string str = reader.ReadLine();
                    string[] strArr = str.Split(';');
                    id.Add(Convert.ToInt32(strArr[0]));
                    str = str.Remove(0, strArr[0].Count() + 1);
                    listAddres.Add(str);
                }
            }
            
            List<string> outAddress = ap.processor(listAddres).ToList();
            List<Foo> foos = new List<Foo>();
            for (int i = 0; i < listAddres.Count; i++)
            {
                foos.Add(new Foo() { Id = id[i], badAddres = listAddres[i], goodAddres = outAddress[i] });
            }
            using (var writer = new StreamWriter("out.csv"))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";
                    csv.WriteRecords(foos);
                }
            }
        }
    }
}