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



        static void Main(string[] args)
        {
            string path = "Resource\\bad.csv";
            AddressProcessor ap = new AddressProcessor();
            FileCSV fileCSV = new FileCSV();
            fileCSV.loadFile(path);
            fileCSV.outAddress = ap.processor(fileCSV.listAddres).ToList();
            fileCSV.saveFile("out.csv");
        }
    }
}