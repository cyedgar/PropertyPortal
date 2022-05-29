using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyPortal.Data
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyId { get; set; }

        [Display(Name = "Property Name")]
        [StringLength(256)]
        public string PropertyName { get; set; }
        [Display(Name = "Bedroom")]

        public int Bedroom { get; set; }
        [Display(Name = "Is Available?")]

        public bool IsAvailable { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Sale Price")]

        public decimal? SalePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Lease Price")]

        public decimal? LeasePrice { get; set; }

        public string UserId
        {
            get;
            set;
        }
        [ForeignKey("UserId")]

        public virtual ApplicationUser User
        {
            get;
            set;
        }
    }
}
