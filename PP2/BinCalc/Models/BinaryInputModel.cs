using System.ComponentModel.DataAnnotations;

namespace BinCalc.Models
{
    public class BinaryInputModel
    {
        [Display(Name = "a")]
        [BinaryStringStrict]
        public string A { get; set; } = string.Empty;

        [Display(Name = "b")]
        [BinaryStringStrict]
        public string B { get; set; } = string.Empty;
    }
}
