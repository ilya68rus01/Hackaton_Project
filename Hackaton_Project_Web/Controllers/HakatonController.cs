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
       static class List<>
        public HakatonController()
        {
          
            
        }
       // [Route("FileLoad")]
        [HttpPost]
        public bool AddFile()
        {
            var s = HttpContext.Request.Form.Files[0];
            if (s != null)
            {
            string  g = Guid.NewGuid().ToString();
            // путь к папке Files
            string path = "clientapp/FileIN/" + g;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                    s.CopyTo(fileStream);
            }
                return true;
            }

            return false;
        }
    }
}
