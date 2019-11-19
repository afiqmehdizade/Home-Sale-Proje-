using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProj.Models
{
    public class Advert
    {
     
        public int Id { get; set; }
        [Display(Name ="Qiymət")]
        [Range(50, 1500000, ErrorMessage = "Duzgun qiymet daxil edin")]
        [Required(ErrorMessage = "Qiymeti daxil edin")]
        public int Price { get; set; }

        [Display(Name ="Otaq Sayı")]
        [Range(1,10,ErrorMessage ="Maksimum  10 otaq !")]
        [Required(ErrorMessage ="Otaq Sayını Daxil Edin")]
        public int RoomCount { get; set; }

        [Display(Name ="Yataq Otaqı Sayı")]
        [Required(ErrorMessage = "Yataq Otaqı Sayını Daxil Edin")]
        [Range(1,5, ErrorMessage = "Maksimum 5 Otaq")]
        public int BedRoom { get; set; }

        [Display(Name ="Hamam Otaqı Sayı")]
        [Required(ErrorMessage = "Hamam Otaqı Sayını Daxil Edin")]
        [Range(1, 5, ErrorMessage = "Maksimum 5 Otaq")]
        public int BathRoom { get; set; }

        [Display(Name ="Evin Ümumi Sahəsi")]
        [Range(50,5000,ErrorMessage ="Maksimum sahə 5000m2 olaraq nəzərdə tutulub")]
        [Required(ErrorMessage = "Evin Sahəsini Daxil Edin")]
        public int RoomArea { get; set; }

        [StringLength(100, ErrorMessage = "Maksimum simbol sayini kecdiniz")]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Adresi daxil edin")]
        public string Address { get; set; }
        [Display(Name ="Tarix")]
        public DateTime CreatedAt { get; set; }

        [StringLength(500, ErrorMessage = "Maksimum simbol sayini kecdiniz")]
        [Display(Name = "Melumat")]
        [Required(ErrorMessage = "Melumati daxil edin")]
        public string Description { get; set; }
        [Display(Name ="Vip Elan")]
        public bool IsVip { get; set; }
        [Display(Name ="Ev yenidir")]
        public bool IsNew { get; set; }
        [StringLength(200)]
        public string Image { get; set; }

        [NotMapped]
        [Display(Name ="Şəkil")]
        public HttpPostedFileBase Photo{ get; set; }

        [Display(Name ="Satış Növü")]
        [Required(ErrorMessage ="Elan tipini seçin")]
        public int RentTypeId { get; set; }
        [Display(Name ="Istifadəçi")]
        public int UserId { get; set; }
        [Display(Name ="Şəhər")]
        [Required(ErrorMessage ="Şəhəri daxil edin")]
        public int CityId { get; set; }

        public virtual RentType RentType { get; set; }
        public virtual User User { get; set; }
        public virtual City City { get; set; }
    }
}