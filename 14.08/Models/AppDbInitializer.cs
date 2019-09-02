using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace _14._08.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };

            // добавляем роли в бд
            roleManager.Create(role1);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "nagula.anton@mail.ru", UserName = "nagula.anton@mail.ru" };
            string password = "1234_abCD";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
            }

            var role2 = new IdentityRole { Name = "user" };
            roleManager.Create(role2);


            var admin2 = new ApplicationUser { Email = "somemail@mail.ru", UserName = "somemail@mail.ru" };
            string password2= "1234_ABcd";
            var result2 = userManager.Create(admin2, password2);

            // если создание пользователя прошло успешно
            if (result2.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin2.Id, role2.Name);
            }

            var role3 = new IdentityRole { Name = "moderator" };
            roleManager.Create(role3);


            var admin3 = new ApplicationUser { Email = "any@mail.ru", UserName = "any@mail.ru" };
            string password3 = "3333_ABcd";
            var result3 = userManager.Create(admin3, password3);

            // если создание пользователя прошло успешно
            if (result3.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin3.Id, role3.Name);
            }
            base.Seed(context);
        }
    }
}