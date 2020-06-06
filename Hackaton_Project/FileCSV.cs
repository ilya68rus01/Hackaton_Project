using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Globalization;

namespace Hackaton_Project
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
    public class FileCSV
    {
        public List<string> listAddres = new List<string>();
        public List<int> id = new List<int>();
        public List<string> outAddress;
        public void loadFile(string path)
        {
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
        }
        public void saveFile(string path)
        {
            List<Foo> foos = new List<Foo>();
            for (int i = 0; i < listAddres.Count; i++)
            {
                foos.Add(new Foo() { Id = id[i], badAddres = listAddres[i], goodAddres = outAddress[i] });
            }
            using (var writer = new StreamWriter(path))
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
