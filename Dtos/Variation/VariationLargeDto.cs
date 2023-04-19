using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Variation
{
    public class VariationLargeDto
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }

        public List<string> VariationOptions { get; set; } = new List<string>();
    }
}
