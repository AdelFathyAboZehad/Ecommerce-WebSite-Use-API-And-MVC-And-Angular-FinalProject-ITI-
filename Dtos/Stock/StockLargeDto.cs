using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Stock
{
    public class StockLargeDto
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }
        [MinLength(3), MaxLength(200)]
        public string Address { get; set; }
        public List<string> Products { get; set; } = new List<string>();
    }
}
