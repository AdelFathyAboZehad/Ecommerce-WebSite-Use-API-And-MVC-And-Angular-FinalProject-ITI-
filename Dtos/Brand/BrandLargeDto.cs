using Dtos.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Brand
{
    public class BrandLargeDto
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }
        //Globalization
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }

        //public List<string> Products { get; set; } = new List<string>();
        //public string Images { get; set; } 
        public List<ProductMinimalDTO> productMinimalDTOs { get; set; } = new List<ProductMinimalDTO>();

    }
}
