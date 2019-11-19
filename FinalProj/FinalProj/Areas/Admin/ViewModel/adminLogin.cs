using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace FinalProj.Areas.Admin.ViewModel
{
    public class adminLogin
    {
        [Required(ErrorMessage = "Email daxil edin")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Duzgun Email Daxil Edin!")]
        [Index("UN_Email", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Duzgun Email daxil edin")]
        [MinLength(5, ErrorMessage = "Duzgun Email daxil edin")]
        public string Email { get; set; }

        [Display(Name = "Parol")]
        [MinLength(8, ErrorMessage = "Parol qisadir!")]
        [StringLength(300)]
        [Required(ErrorMessage = "Parolu Daxil Edin")]
        public string Password { get; set; }
    }
}