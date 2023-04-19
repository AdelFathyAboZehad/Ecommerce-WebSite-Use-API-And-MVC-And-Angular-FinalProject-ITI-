

using Dtos.Product;
using System.ComponentModel.DataAnnotations;

namespace Dtos.Category
{
    public class CategoryDetailsDto
    {


        public int Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }
        //Globalization
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }
        public IEnumerable<ProductMinimalDTO> productMinimalDtos { get; set; } = new List<ProductMinimalDTO>();



    }
}
