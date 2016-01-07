using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace LeagueStore.Models
{
    public class MyContextInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            base.Seed(context);

            context.Employees.Add(new Employee() { Name = "Ger Saris", Role = "Sales man", ImageUrl = "Content/img/ger.jpg" });
            context.Employees.Add(new Employee() { Name = "Bart Mutsaers", Role = "Manager", ImageUrl = "Content/img/bart.jpg" });
            context.Employees.Add(new Employee() { Name = "Stijn Smulders", Role = "Service desk", ImageUrl = "Content/img/stijn.jpg" });

            context.Products.Add(new Product() {Id = 1, Name = "Boots of Speed",    ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1001.png", Description = "Slightly increases Movement Speed"                              , Gold = 300 }); 
            context.Products.Add(new Product() {Id = 2, Name = "Faerie Charm",      ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1004.png", Description = "Slightly increases Mana Regen"                                  , Gold = 125 });
            context.Products.Add(new Product() {Id = 3, Name = "Rejuvenation Bead", ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1006.png", Description = "Slightly increases Health Regen"                                , Gold = 150 });
            context.Products.Add(new Product() {Id = 4, Name = "Giant's Belt",      ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1011.png", Description = "Greatly increases Health"                                       , Gold = 600 });
            context.Products.Add(new Product() {Id = 5, Name = "Cloak of Agility",  ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1018.png", Description = "Increases critical strike chance"                               , Gold = 800 });
            context.Products.Add(new Product() {Id = 6, Name = "Blasting Wand",     ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1026.png", Description = "Moderately increases Ability Power"                             , Gold = 850  });
            context.Products.Add(new Product() {Id = 7, Name = "Sapphire Crystal",  ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1027.png", Description = "Increases Mana"                                                 , Gold = 350 });
            context.Products.Add(new Product() {Id = 8, Name = "Ruby Crystal",      ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1028.png", Description = "Increases Health"                                               , Gold = 400 });
            context.Products.Add(new Product() {Id = 9, Name = "Cloth Armor",       ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1029.png", Description = "Slightly increases Armor"                                       , Gold = 300  });
            context.Products.Add(new Product() {Id = 10, Name = "Chain Vest",        ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1031.png", Description = "Greatly increases Armor"                                        , Gold = 500 });
            context.Products.Add(new Product() {Id = 11, Name = "Null-Magic Mantle", ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1033.png", Description = "Slightly increases Magic Resist"                                , Gold = 450 });
            context.Products.Add(new Product() {Id = 12, Name = "Long Sword",        ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1036.png", Description = "Slightly increases Attack Damage"                               , Gold = 350  });
            context.Products.Add(new Product() {Id = 13, Name = "Pickaxe",           ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1037.png", Description = "Moderately increases Attack Damage"                             , Gold = 875 });
            context.Products.Add(new Product() {Id = 14, Name = "B. F. Sword",       ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1038.png", Description = "Greatly increases Attack Damage"                                , Gold = 1300 });
            context.Products.Add(new Product() {Id = 15, Name = "Hunter's Talisman", ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1039.png", Description = "Provides damage against Monsters and Mana Regen in the Jungle"  , Gold = 350 });
            context.Products.Add(new Product() {Id = 16, Name = "Hunter's Machete",  ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1041.png", Description = "Provides damage and life steal versus Monsters"                 , Gold = 350 });
            context.Products.Add(new Product() {Id = 17, Name = "Dagger",            ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1042.png", Description = "Slightly increases Attack Speed"                                , Gold = 300 });
            context.Products.Add(new Product() {Id = 18, Name = "Recurve Bow",       ItemUrl = "http://ddragon.leagueoflegends.com/cdn/5.23.1/img/item/1043.png", Description = "Greatly increases Attack Speed"                                 , Gold = 400 });
            
            var bundle1 = new Bundle() {  Name = "Frozen", Description = "Frozen pool party", BannerUrl = "Content/img/slide-1.jpg", RiotPoints = 500 };
            bundle1.Products.Add(context.Products.Find(1));
            bundle1.Products.Add(context.Products.Find(2));
            bundle1.Products.Add(context.Products.Find(3));
            context.Bundles.Add(bundle1);

            var bundle2 = new Bundle() { Name = "Invetational", Description = "Mid Season championship items", BannerUrl = "Content/img/slide-2.jpg", RiotPoints = 500 };
            bundle2.Products.Add(context.Products.Find(4));
            bundle2.Products.Add(context.Products.Find(5));
            bundle2.Products.Add(context.Products.Find(6));
            context.Bundles.Add(bundle2);

            var bundle3 = new Bundle() { Name = "Origin", Description = "Starter pack bundle", BannerUrl = "Content/img/slide-3.jpg", RiotPoints = 500 };
            bundle3.Products.Add(context.Products.Find(7));
            bundle3.Products.Add(context.Products.Find(8));
            bundle3.Products.Add(context.Products.Find(9));
            context.Bundles.Add(bundle3);

            context.SaveChanges();
        }
    }
}
