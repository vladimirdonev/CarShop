using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class Issue
    {
        public Issue()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public bool IsFixed { get; set; }

        public string CarId { get; set; }

        public virtual Car Car { get; }
    }
}
