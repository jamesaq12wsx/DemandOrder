using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandOrder.Models
{
    public class Index2ViewModel
    {
        public IEnumerable<IGrouping<string, SimpleOrderViewModel>> OrderGroups { get; set; }

        public DateTime Searchdate { get; set; }
    }
}