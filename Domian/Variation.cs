using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("Variation")]
    public class Variation
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }

        public IEnumerable<VariationOption> VariationOptions { get; set; }

        public Variation(string name)
        {

            Name = name;
            VariationOptions = new List<VariationOption>();
        }

        public Variation() : this(null!) { }
    }
}
