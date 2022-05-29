using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyPortal.Data
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        [Display(Name = "Property")]


        public int PropertyId
        {
            get;set;
        }
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }


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

        [Display(Name = "Transaction Date")]

        public DateTime TransactionDate { get; set; }

    }
}
