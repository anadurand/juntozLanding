using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Chile.Models;

namespace Web.Chile.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _env;

        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("subscribe")]
        [HttpPost]
        public IActionResult Subscribe (subscribeModel model)
        {
            if (ModelState.IsValid)
            {
                StreamReader st = null;
                StreamWriter sw = null;

                List<subscribeModel> users = null;
                try
                {
                    var f = $"{_env.ContentRootPath}\\storage\\users.json";
                    st = new StreamReader(f);
                    users = JsonConvert.DeserializeObject<List<subscribeModel>>(st.ReadToEnd());
                    st.Close();
                    if (users.Where(u => u.email == model.email).FirstOrDefault() == null)
                    {
                        sw = new StreamWriter(f);
                        users.Add(model);
                        var s = new JsonSerializer();
                        s.Serialize(sw, users);
                            sw.Close();
                        
                    }
                    
                }
                catch 
                {

                    try
                    {
                        st.Close();
                        sw.Close();
                    }
                    catch 
                    {

                        
                    }
                }
                return Ok(users);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
