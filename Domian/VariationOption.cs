using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("VariationOption")]
    public class VariationOption
    {

        public int Id { get; set; }
        [MinLength(2), MaxLength(200)]
        public string Value { get; set; }

        public Variation Variation { get; set; }

        public VariationOption(string value, Variation variation)
        {

            Value = value;
            Variation = variation;
        }

        public VariationOption() : this(null!, null!) { }
    }
}
