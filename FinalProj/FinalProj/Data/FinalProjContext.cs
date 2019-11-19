using FinalProj.Models;
using System.Data.Entity;

namespace FinalProj.Data
{
    public class FinalProjContext:DbContext
    {
        public FinalProjContext() : base("FinalProjContext") { }

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RentType> RentTypes { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<adminSetting> AdminSettings { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}