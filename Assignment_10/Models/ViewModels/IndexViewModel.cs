using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_10.Models.ViewModels
{
    public class IndexViewModel
    {
        
        public List<Bowlers> Bowlers { get; set; }

  
        public PagingInfo PagingInfo { get; set; }
        public string Type { get; set; }
    }
}