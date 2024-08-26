using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace admin.matteria.Controllers
{
    public class TranslationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
