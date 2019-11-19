using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProj.Models
{
    public class City
    {
        public City()
        {
            Adverts = new HashSet<Advert>();
        }

        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Duzgun seher adi daxil edin")]
        [MinLength(3, ErrorMessage = "Minimum 3 simbol olmalidir!")]
        public string CityName { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}