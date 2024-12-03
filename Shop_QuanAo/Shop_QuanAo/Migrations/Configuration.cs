namespace Shop_QuanAo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop_QuanAo.Models.ShopQuanAoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shop_QuanAo.Models.ShopQuanAoContext context)
        {
            
        }
    }
}
