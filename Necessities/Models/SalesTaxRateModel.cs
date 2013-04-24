using System;
using System.ComponentModel.DataAnnotations;

namespace Necessities.Models
{
    public class SalesTaxRateModel
    {
        [Required]
        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Tax rate")]
        public Percentage TaxRate { get; set; }
    }
}