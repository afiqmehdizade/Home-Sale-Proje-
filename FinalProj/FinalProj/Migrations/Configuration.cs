namespace FinalProj.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProj.Data.FinalProjContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FinalProj.Data.FinalProjContext context)
        {
            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data.
            //context.Cities.AddOrUpdate(m => m.CityName, new City[] {
            //    new City { CityName = "Baki"},
            //    new City { CityName = "Bilesuvar" },
            //    new City { CityName = "Masalli" },
            //    new City { CityName = "Sumqayit" },
            //    new City { CityName = "Shamaxi" },
            //    new City { CityName = "Shemkir" },
            //    new City { CityName = "Astara" },
            //    new City { CityName = "Lenkeran" },
            //    new City { CityName = "Gence" },
            //    new City { CityName = "Goychay" },
            //    new City { CityName = "Salyan" },
            //    new City { CityName = "Yardımlı" },
            //    new City { CityName = "Ucar" },
            //    new City { CityName = "Ağdam" },
            //    new City{CityName = "Zerdab"},
            //    new City { CityName = "Yevlax" }

            //});
            //context.SaveChanges();

            //context.AdminSettings.AddOrUpdate(m => m.Email, new adminSetting[] {
            //new adminSetting{Email = "admin@code.az", Firstname="Afiq" , Lastname = "Mehdizade", Password = "AAq2pQz50fN+/oak9cfQMV9YQuF/DdB98eOZ0SeIxdOHhvVHawH6ceaN71vznAdNJg=="}
            //});
            //context.SaveChanges();


            //context.RentTypes.AddOrUpdate(m => m.SaleType, new RentType[] {
            //    new RentType{ SaleType = "Satiliq"},
            //    new RentType{ SaleType = "Kiraye"}
            //});
            //context.SaveChanges();

            //context.Users.AddOrUpdate(m => m.Email, new User[] {

            //    new User{ Firstname="Afiq", Lastname="Mehdizade", Phone="+994515090515",
            //        Status = false, Email="afig@code.az", Password="AM9tA2YPeRdjIdl8pgtitvGygRiNrqVPqVgvy6KECljM7nouytxExrhlWf/EwFlhcA==",
            //        ConfirmPassword ="AM9tA2YPeRdjIdl8pgtitvGygRiNrqVPqVgvy6KECljM7nouytxExrhlWf/EwFlhcA=="}

            //});

            //context.SaveChanges();

            //context.Adverts.AddOrUpdate(m => m.Address, new Advert[] {

            //    new Advert{ Address = "Naximov.11A", BathRoom=2, BedRoom=3, CityId=1, CreatedAt=DateTime.Now, Description="Ev TEcili satilir.Qaz Su Herseyi Var", Image="homes/home1.jpg", IsNew=false, IsVip=false, Price=350000,RentTypeId=1, RoomArea=168, RoomCount=5, UserId=1,  },
            //    new Advert{ Address = "Naximov.12A", BathRoom=3, BedRoom=4, CityId=2, CreatedAt=DateTime.Now.AddMinutes(39), Description="Bineqedi Qesebesinde Tam Temirli. 3 otaqlı həyət evi satılır. Evin yaxinliqinda Məktəb, bağça, marketlər, poliklinika, masrut dayanacagi, yerləşirlər. Qaz, su, işiq daimidir saygaclar qurasdirilib. Eve Şəkildən baxa bilərsiniz ve ya Gelib Baxada Bilersiniz.", Image="homes/58aaf932-6f71-456b-91e2-63cc10b6d05eridgrecrest-6011-exterior-800x500-880x600.jpg", IsNew=false, IsVip=false, Price=350000,RentTypeId=1, RoomArea=168, RoomCount=5, UserId=1,  },
            //    new Advert{ Address = "Naximov.13A", BathRoom=1, BedRoom=2, CityId=3, CreatedAt=DateTime.Now.AddMinutes(33), Description="Ev TEcili satilir.Qaz Su Herseyi Var", Image="homes/96244208-0cc3-446e-a75f-694e522dc6532801-3-880x600.jpg", IsNew=true, IsVip=false, Price=2000,RentTypeId=2, RoomArea=132, RoomCount=3, UserId=1,  },
            //    new Advert{ Address = "Naximov.14A", BathRoom=3, BedRoom=1, CityId=4, CreatedAt=DateTime.Now.AddMinutes(25), Description="Bineqedi Qesebesinde Tam Temirli. 3 otaqlı həyət evi satılır. Evin yaxinliqinda Məktəb, bağça, marketlər, poliklinika, masrut dayanacagi, yerləşirlər. Qaz, su, işiq daimidir saygaclar qurasdirilib. Eve Şəkildən baxa bilərsiniz ve ya Gelib Baxada Bilersiniz.", Image="homes/c064a671-849b-47c4-ba15-e94106ca66ef7.jpg", IsNew=false, IsVip=true, Price=3000,RentTypeId=2, RoomArea=123, RoomCount=6, UserId=1,  },
            //    new Advert{ Address = "Naximov.15A", BathRoom=2, BedRoom=3, CityId=5, CreatedAt=DateTime.Now.AddMinutes(18), Description="Ev TEcili satilir.Qaz Su Herseyi Var", Image="homes/22cd34b5-fc7f-46d7-abb2-eb28afb047d76.jpg", IsNew=true, IsVip=false, Price=190000,RentTypeId=1, RoomArea=152, RoomCount=4, UserId=1,  },
            //    new Advert{ Address = "Naximov.16A", BathRoom=2, BedRoom=3, CityId=5, CreatedAt=DateTime.Now.AddMinutes(18), Description="Bineqedi Qesebesinde Tam Temirli. 3 otaqlı həyət evi satılır. Evin yaxinliqinda Məktəb, bağça, marketlər, poliklinika, masrut dayanacagi, yerləşirlər. Qaz, su, işiq daimidir saygaclar qurasdirilib. Eve Şəkildən baxa bilərsiniz ve ya Gelib Baxada Bilersiniz.", Image="homes/327dc01d-d729-4730-8043-c4f4a798014f5.jpg", IsNew=false, IsVip=true, Price=90000,RentTypeId=1, RoomArea=152, RoomCount=2, UserId=1,  },
            //    new Advert{ Address = "Naximov.17A", BathRoom=2, BedRoom=3, CityId=5, CreatedAt=DateTime.Now.AddMinutes(18), Description="Ev TEcili satilir.Qaz Su Herseyi Var", Image="homes/83f9a651-9be1-47fe-bb4e-a58d43d397dd4.jpg", IsNew=true, IsVip=false, Price=290000,RentTypeId=1, RoomArea=152, RoomCount=4, UserId=1,  },
            //    new Advert{ Address = "Naximov.18A", BathRoom=2, BedRoom=3, CityId=5, CreatedAt=DateTime.Now.AddMinutes(18), Description="Bineqedi Qesebesinde Tam Temirli. 3 otaqlı həyət evi satılır. Evin yaxinliqinda Məktəb, bağça, marketlər, poliklinika, masrut dayanacagi, yerləşirlər. Qaz, su, işiq daimidir saygaclar qurasdirilib. Eve Şəkildən baxa bilərsiniz ve ya Gelib Baxada Bilersiniz.", Image="homes/79f783ba-c7cf-43f1-8b6f-757f10643f633.jpg", IsNew=true, IsVip=true, Price=70000,RentTypeId=1, RoomArea=152, RoomCount=3, UserId=1,  },
            //    new Advert{ Address = "Naximov.19A", BathRoom=2, BedRoom=3, CityId=5, CreatedAt=DateTime.Now.AddMinutes(18), Description="Ev TEcili satilir.Qaz Su Herseyi Var", Image="homes/a851e521-382c-4029-8e3b-42eca724c3653.jpg", IsNew=false, IsVip=true, Price=800,RentTypeId=2, RoomArea=152, RoomCount=6, UserId=1,  },
            //    new Advert{ Address = "Naximov.10A", BathRoom=2, BedRoom=3, CityId=5, CreatedAt=DateTime.Now.AddMinutes(18), Description="Ev TEcili satilir.Qaz Su Herseyi Var", Image="homes/15999a9e-4900-4e5b-ac14-3c3ca95f50feridgrecrest-6011-exterior-800x500-880x600.jpg", IsNew=true, IsVip=false, Price=1500,RentTypeId=2, RoomArea=152, RoomCount=5, UserId=1,  },
            //    new Advert{ Address = "Naximov.20A", BathRoom=3, BedRoom=4, CityId=1002, CreatedAt=DateTime.Now.AddMinutes(15), Description="Xarici təsirlərə məruz qalıb satıram", Image="homes/27370f39-2a64-4e92-8ee4-f83e8bbedd2c2801-3-880x600.jpg", IsNew=true, IsVip=true, Price=155500,RentTypeId=1, RoomArea=300, RoomCount=6, UserId=1,  }
            //});
        }
    }
}
