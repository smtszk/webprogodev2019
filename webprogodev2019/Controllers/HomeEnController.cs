using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using webprogodev2019.Models;

namespace webprogodev2019.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration configuration;

        public HomeController(IConfiguration config)
        {
            configuration = config;
        }

        public IActionResult Index(ViewModel viewModel)
        {
            string connectionString = configuration.GetConnectionString("WebProgOdev2019Connection");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select * from Haberler.dbo.HaberTable", connection);
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    viewModel.haberList.Add(new Haber{
                        haber_baslik=reader.GetString(1),
                        haber_icerik=reader.GetString(2),
                        haber_resim=reader.GetString(3)
                    });
                }
            }
            connection.Close();

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult HaberSayfa(string id)
        {
            string connectionString = configuration.GetConnectionString("WebProgOdev2019Connection");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            ViewModel viewModel = new ViewModel();
            SqlCommand command = new SqlCommand("select * from Haberler.dbo.HaberTable where id="+id+"", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    viewModel.haberList.Add(new Haber
                    {
                        haber_baslik = reader.GetString(1),
                        haber_icerik = reader.GetString(2),
                        haber_resim = reader.GetString(3)
                    });
                }
            }
            connection.Close();
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }    
}