using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace Hackaton_Project_Web.Controllers
{
    [Route("AddresProcessor")]
    [ApiController]
    public class HakatonController : ControllerBase
    {
        static List<WrapperProcessor> processList = new List<WrapperProcessor>();
        public HakatonController()
        {
          
            
        }
       // [Route("FileLoad")]
        [HttpPost]
        public bool AddFile()
        {
            if (HttpContext.Request.Form.Files.Count == 0)
            {
                return false;
            }
            var s = HttpContext.Request.Form.Files[0];
            if (s != null)
            {
            string  id = Guid.NewGuid().ToString();

            string path = "clientapp/FileIN/" + id;
            
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                    s.CopyTo(fileStream);
            }
                WrapperProcessor wrapperProcessor = new WrapperProcessor() { Id = id };
                wrapperProcessor.Task = new Task(wrapperProcessor.startProcess);
                wrapperProcessor.Task.Start();
                processList.Add(wrapperProcessor);
                HttpContext.Response.Cookies.Append("id", id, new CookieOptions() {  });
                return true;
            }

            return false;
        }
        [HttpGet]
        public string GetUrl()
        {
            var id = HttpContext.Request.Cookies["id"];
            foreach (var item in processList)
            {
                if (item.processCompilite)
                {
                    if (item.Id == id)
                    {
                    
                        string url = "/AddresProcessor/GetFile";
                        
                        return url;
                    }
                }

            } 
            return "12";
        }
        [Route("GetFile")]
        [HttpGet]
        public FileResult GetFile()
        {
            var id = HttpContext.Request.Cookies["id"];
            if (id != null)
            {
                FileStream fs = new FileStream("clientapp/FileOut/" + id, FileMode.Open);
                string file_type = "application/csv";
                string file_name = "out.csv";
                return File(fs, file_type, file_name);
            }
            return null;
        }
    }
}
