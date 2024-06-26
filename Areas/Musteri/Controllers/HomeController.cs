﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restorant.Data;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Restorant.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;   
        }

        public IActionResult Index()
        {
            var Menu = _db.Menuler.Where(i => i.Aktif).ToList();
            var Tatlı = _db.Menuler.Where(i =>i.Aktif).ToList();
            return View(Menu);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
