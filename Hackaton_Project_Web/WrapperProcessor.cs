using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackaton_Project;
using System.IO;

namespace Hackaton_Project_Web
{
    public class WrapperProcessor
    {
        public string Id { get; set; }
        public bool processCompilite { get; private set; } = false;
        public Task Task { get; set; }
        public void startProcess()
        {
            string path = "clientapp/FileIN/"  + Id;
            AddressProcessor ap = new AddressProcessor();
            FileCSV fileCSV = new FileCSV();
            fileCSV.loadFile(path);
            fileCSV.outAddress = ap.processor(fileCSV.listAddres).ToList();
            fileCSV.saveFile("clientapp/FileOUT/" + Id);
            processCompilite = true;
            File.Delete(path);
        }
    }
}
