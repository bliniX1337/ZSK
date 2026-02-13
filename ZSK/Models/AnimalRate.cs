using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZSK.Models
{
    public class AnimalRate
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal EuroValue { get; set; }   
        public List<Conversion> Conversions { get; set; } = new();
    }
}
