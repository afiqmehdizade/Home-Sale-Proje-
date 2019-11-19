using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProj.Models
{
    public class RentType
    {
        public RentType()
        {
            Adverts = new HashSet<Advert>();
        }

        public int Id { get; set; }
        [StringLength(20, ErrorMessage = "Duzgun Tip daxil edin")]
        [MinLength(6, ErrorMessage = "Minimum 3 simbol olmalidir!")]
        public string SaleType { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}