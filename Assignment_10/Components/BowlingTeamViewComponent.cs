using Assignment_10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_10.Components
{
    //calling ViewComponent class to inherit things from
    public class BowlingTeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        //call this constructor when someone calls BowlingTeamViewCoomponent
        public BowlingTeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }

        //this is how we'll get a list of teams
        public IViewComponentResult Invoke()
        {
            return View(context.Teams
                //so we don't get duplicates
                .Distinct()
                .OrderBy(b => b));
        }
    }
}