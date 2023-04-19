
using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name(English)")]

        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }

        [Display(Name = "Name(Arabic)")]
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }
        [Display(Name = "Image")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "Parent Category")]

        public int? ParentCategoryId { get; set; }

        public string? ImageURL { get; set; }

        public CategoryViewModel()
        {

        }

        public CategoryViewModel(int id, string nameEN, string nameAR, IFormFile? imageFile)
        {
            Id = id;
            NameEN = nameEN;
            NameAR = nameAR;
            ImageFile = imageFile;
        }

        public CategoryViewModel(int id, string nameEN, string nameAR)
        {
            Id = id;
            NameEN = nameEN;
            NameAR = nameAR;
        }
       
    }
}
