using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MusicStore2.Models;

namespace MusicStore2.DataBaseManager
{
    public class Initializer : DropCreateDatabaseAlways<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            base.Seed(context);
            context.Roles.Add(new Role { Id = 1, Name = "Admin"});
            context.Roles.Add(new Role { Id = 2, Name = "Purchase" });
            context.Purchases.Add(new Purchase { Id = Guid.NewGuid(), Email = "verenick@mail.ru", Name = "Admin", SurName = "Admin",
                Password = "Admin123456789", Phone = "+79788998955", Address = "Simferopol, Gorkogo 11", IndexPost = "290000", RoleId = 1});
            context.Instruments.Add(new Instrument { Id = Guid.NewGuid(), Name = "Фортепиано Yamaha P-45", Description = "Хорошее", Category = "Клавишные", SubCategory = "Фортепиано", Price = 75000, ImgUrl = "http://svmusic.ru/images/0851965a12294d60957bd9659e7f8ca3.900x.jpg" });
            context.Instruments.Add(new Instrument { Id = Guid.NewGuid(), Name = "Барабаны Yamaha ", Description = "Хорошее", Category = "Ударные", SubCategory = "Ударные с неопределенным звуком звучания", Price = 200000, ImgUrl = "https://ru.yamaha.com/ru/files/Tour_Custom_540x540_735x735_edfdd941e293336c1a106628dfe272c9.jpg" });
            context.Instruments.Add(new Instrument { Id = Guid.NewGuid(), Name = "Гитара Parkwood", Description = "Хорошее", Category = "Гитары", SubCategory = "Классические гитары", Price = 10000, ImgUrl = "https://lutner.ru/upload/medialibrary/a49/parkwood_1.jpg" });
            context.Instruments.Add(new Instrument { Id = Guid.NewGuid(), Name = "Саксофон Yamaha Альт YAS-875EX", Description = "Саксофон альт серии EX, покрытие: золотой лак", Category = "Духовые", SubCategory = "Деревянные", Price = 50000, ImgUrl = "https://ru.yamaha.com/ru/files/yas-875ex_02_540x540_735x735_3eb2d6a78238357cfd27aacf034c0475.jpg" });

            base.Seed(context);
        }
    }
}