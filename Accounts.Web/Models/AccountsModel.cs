using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounts.Web.Models
{
    public class AccountsModel
    {
        [Required(ErrorMessage ="Account Number is required")]
        public int AccountNumber { get;set;}


        [Required(ErrorMessage ="Account Holder is required")]
        public string AccountHolder { get; set; }




        [Required(ErrorMessage = "Current Balance  is required")]
        public decimal CurrentBalance { get; set; }

        [Required(ErrorMessage = "Bank Name  is required")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Opening Date  is required")]
        public string OpeningDate { get; set; }
        public bool IsActive { get; set; }
    }
}