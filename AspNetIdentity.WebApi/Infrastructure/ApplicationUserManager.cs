using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace AspNetIdentity.WebApi.Infrastructure
{
    using AspNetIdentity.WebApi.Validators;

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<ApplicationDbContext>();
            var appUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(appDbContext));

            appUserManager.EmailService = new AspNetIdentity.WebApi.Services.EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                appUserManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    //Code for email confirmation and reset password life time
                    TokenLifespan = TimeSpan.FromHours(6)
                };
            }

            //Configure validation logic for usernames
            //appUserManager.UserValidator = new UserValidator<ApplicationUser>(appUserManager)
            //{
            //    AllowOnlyAlphanumericUserNames = true,
            //    RequireUniqueEmail = true
            //};

            //Configure validation logic for usernames  || custom validator
            //only support these domain "outlook.com", "hotmail.com", "gmail.com", "yahoo.com" , "yopmail.com"
            //if you do not want to restrict domain then use the above comented code.
            appUserManager.UserValidator = new MyCustomUserValidator(appUserManager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            //Configure validation logic for passwords
            //appUserManager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 6, //length atleast 6 char
            //    RequireNonLetterOrDigit = true, //special charecter
            //    RequireDigit = false,
            //    RequireLowercase = true,
            //    RequireUppercase = true
            //};

            // Configure validation logic for passwords || custom validator for password 
            //(this is vary basic test to check the custom validation)
            //If you do not want to restrict domain then use the above comented code.
            appUserManager.PasswordValidator = new MyCustomPasswordValidator
            {
                RequiredLength = 6, //length atleast 6 char
                RequireNonLetterOrDigit = true, //special charecter
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            return appUserManager;
        }

    }
}
