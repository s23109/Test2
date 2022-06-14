using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Controllers
{
    public class MusicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
