using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_10.Models.ViewModels
{
    public class IndexViewComponentModel
    {
      
        public IEnumerable<Teams> Teams { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}