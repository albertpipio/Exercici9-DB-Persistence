using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleatsSQLVSCode.Models
{
    public class Empleat
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Position")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Position { get; set; }

        [Display(Name = "Salary")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal Salary { get; set; }
    }
}