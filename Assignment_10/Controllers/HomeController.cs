using Assignment_10.Models;
using Assignment_10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }


        public IActionResult Index(long? teamnameid, string teamname, int pageNum = 0)
        {
            int pageSize = 5;

            ViewBag.TeamName = teamname;

            return View(new IndexViewModel
            {
                Bowlers = context.Bowlers
                    .Where(b => b.TeamId == teamnameid || teamnameid == null)
                    .OrderBy(b => b.BowlerFirstName)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    //if no bowling team has been selected, then get the full count. otherwise, only count
                    //the number from the teamnane that has been selected
                    TotalNumItems = (teamnameid == null ? context.Bowlers.Count() : context.Bowlers.Where(x => x.TeamId == teamnameid).Count())
                },

                Type = teamname
            });
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