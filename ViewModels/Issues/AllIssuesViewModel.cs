using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Issues
{
    public class AllIssuesViewModel
    {
        public string Id { get; set; }

        public string CarId { get; set; }

        public string CarModelName { get; set; }

        public string Description { get; set; }

        public bool IsFixed { get; set; }

    }
}
