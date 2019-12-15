using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webprogodev2019.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webprogodev2019.Controllers
{
    public class HaberSayfaController : Controller
    {
        ViewModel viewModel = new ViewModel();
        // GET: /<controller>/
        public IActionResult Index(string id)
        {
            viewModel.index = id;
            return View(viewModel);
        }
    }
}
