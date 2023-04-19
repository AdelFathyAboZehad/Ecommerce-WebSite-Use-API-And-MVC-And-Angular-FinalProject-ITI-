using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("Brand")]
    public class Brand
    {

        public int Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }
        //private readonly IList<Product> _products;
        public string? ImageURL { get; set; }

        public IEnumerable<Product> Products { get; set; }
        public Brand(string nameEN,string nameAR)
        {
            NameEN = nameEN;
            NameAR = nameAR;
            Products = new List<Product>(); ;
        }
        public Brand() : this(null!,null!) { }
        //public bool AddProduct(Product product)
        //{

        //    var checkProductName = Products.FirstOrDefault(a => a.Name == product.Name);
        //    if (checkProductName != null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        _products.Add(product);
        //        return true;
        //    }
        //}
    }
}
