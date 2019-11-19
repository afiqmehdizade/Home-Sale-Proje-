using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProj.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Display(Name ="Istifadəçi")]
        [Required(ErrorMessage = "Adı  daxil edin")]
        [StringLength(50, ErrorMessage = "Duzgun Ad daxil edin!")]
        [MinLength(3, ErrorMessage = "Adi daxil edin!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email daxil edin")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Duzgun Email Daxil Edin!")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Duzgun Email daxil edin")]
        [MinLength(5, ErrorMessage = "Duzgun Email daxil edin")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Maksimum simbol sayini kecdiniz")]
        [Display(Name = "Başlıq")]
        [Required(ErrorMessage = "Başlıqı daxil edin")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Maksimum simbol sayini kecdiniz")]
        [Display(Name = "Mesaj")]
        [Required(ErrorMessage = "Mesaji daxil edin")]
        public string Content { get; set; }
        [Display(Name = "Vaxt")]

        public DateTime CreatedAt { get; set; }

        public bool isRead { get; set; }
    }
}