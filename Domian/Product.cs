using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("Product")]
    public class Product
    {
        public long Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }
        //Globalization
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }
        [MinLength(5), MaxLength(500)]
        public string? DescriptionEN { get; set; }
        //Globalization
        [MinLength(5), MaxLength(500)]
        public string? DescriptionAR { get; set; }
        [Range(0, 100)]
        public int? DiscountPercentage { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Brand Brand { get; set; }
        public Stock Stock { get; set; }
        //private IList<Category> categories;
        public ICollection<Category> Categories { get; set; }

        //private readonly IList<Image> images;
        public IEnumerable<Image> Images { get; set; }

        //private readonly IList<VariationOption> variationOptions;
        public IEnumerable<VariationOption> VariationOption { get; set; }



        public Product(string nameEN,string nameAR, decimal price, Category category, Brand brand, Stock stock, string? descriptionEN = null, string? descriptionAR = null, int? discountPercentage = null)
        {
            NameEN = nameEN;
            NameAR = nameAR;
            DescriptionEN = descriptionEN;
            DescriptionAR = descriptionAR;
            DiscountPercentage = discountPercentage;
            Price = price;
            Brand = brand;
            Stock = stock;
            Categories = new List<Category>();
            Images = new List<Image>();
            VariationOption = new List<VariationOption>();



        }

        public Product() : this(null!,null!, 0, null!, null!, null!) { }

        //public Product(Guid id, string name, string? description, int? discountPercentage, double price, int quantity, Brand brand, Stock stock)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    DiscountPercentage = discountPercentage;
        //    Price = price;
        //    Quantity = quantity;
        //    Brand = brand;
        //    Stock = stock;
        //    Categories = categories;
        //    Images = images;
        //}



        //public Product(string name, double price, Category category, string? description = null, int? discountPercentage = null)
        //{
        //    Name = name;
        //    Description = description;
        //    DiscountPercentage = discountPercentage;
        //    Price = price;


        //    categories = new List<Category>();
        //    categories.Add(category);

        //    categories = new List<Category>
        //    {
        //        category
        //    };
        //    images = new List<Image>();

        //}
        //private Product() : this(null!, 0, null!) { }

        //    public bool AddImage(Image image)
        //    {
        //        var ISImageNull = images.FirstOrDefault(x => x.Name == image.Name);
        //        if (ISImageNull == null)
        //        {
        //            images.Add(image);
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    public bool AddCategory(Category category)
        //    {
        //        var ISCategoryNull = categories.FirstOrDefault(x => x.Name == category.Name);
        //        if (ISCategoryNull == null)
        //        {
        //            categories.Add(category);
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    public bool AddvariationOption(VariationOption variationOption)
        //    {
        //        var ISVariationOptionNull = variationOptions.FirstOrDefault(x => x.Value == variationOption.Value);
        //        if (ISVariationOptionNull == null)
        //        {
        //            variationOptions.Add(variationOption);
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
    }
}