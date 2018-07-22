using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace RentingVehicles.Models
{
    public class mydbcontext:DbContext
    {
        public mydbcontext():base("constr")
        {
            Database.SetInitializer<mydbcontext>(new CreateDatabaseIfNotExists<mydbcontext>());
        }
      
        public DbSet<NewUserModel> NewUsers { get; set; }
        public DbSet<AddVehicleModel> Vehicles { get; set; }
        public DbSet<MessagesModel> messages { get; set; }
        public DbSet<wishlistmodel> wishlist { get; set; }

    }
}