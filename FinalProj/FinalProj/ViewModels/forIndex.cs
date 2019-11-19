using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProj.Models;

namespace FinalProj.ViewModels
{
    public class forIndex
    {
        public List<Advert> forRent { get; set; }
        public List<Advert> forSale { get; set; }
        public List<Advert> forPrice { get; set; }
        public List<Advert> newHomes { get; set; }
        public List<Advert> forVip { get; set; }
    }
}