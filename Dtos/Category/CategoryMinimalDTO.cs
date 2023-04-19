using System.ComponentModel.DataAnnotations;

namespace Dtos.Category
{
    public class CategoryMinimalDTO
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }
        //Globalization
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }
        public string  ImageUrl { get; set; }
    }
}
