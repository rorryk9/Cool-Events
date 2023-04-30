using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolEvents.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string CreatedBy { get; set; }
        public string UserName { get; set; }
    }
}
