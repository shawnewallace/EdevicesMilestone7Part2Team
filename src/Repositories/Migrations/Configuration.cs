using EDeviceClaims.Entities;
using EDeviceClaims.Repositories.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EDeviceClaims.Repositories.Migrations
{
    using Core;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EDeviceClaims.Repositories.Contexts.EDeviceClaimsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EDeviceClaims.Repositories.Contexts.EDeviceClaimsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var policyHolder = CreateUser("user@personal.com", "user@personal.com", context, ApplicationRoles.PolicyHolder);
            CreateUser("admin@company.com", "admin@company.com", context, ApplicationRoles.Admin);
            CreateUser("underwriter@company.com", "underwriter@company.com", context, ApplicationRoles.Underwriter);

            var p1 = new PolicyEntity
            {
                Id = Guid.NewGuid(),
                Number = "12345",
                SerialNumber = "ABCDEF",
                DeviceName = "iPhone 6+",
                CustomerEmail = "user@personal.com",
                UserId = policyHolder.Id
            };
            var p2 = new PolicyEntity
            {
                Id = Guid.NewGuid(),
                Number = "67890",
                SerialNumber = "GHIJKL",
                DeviceName = "Android",
                CustomerEmail = "user@personal.com",
                UserId = policyHolder.Id
            };
            var p3 = new PolicyEntity
            {
                Id = Guid.NewGuid(),
                Number = "99999",
                SerialNumber = "RF3C6000MNA",
                DeviceName = "iPad Pro",
                CustomerEmail = "user@personal.com",
                UserId = policyHolder.Id
            };
            var p4 = new PolicyEntity
            {
                Id = Guid.NewGuid(),
                Number = "88888",
                SerialNumber = "SN483-AB-448N7",
                DeviceName = "Samsung Galaxy Note7",
                CustomerEmail = "user@personal.com",
                UserId = policyHolder.Id
            };

            context.Policies.AddOrUpdate(
              p => p.Number,
              p1,
              p2,
              new PolicyEntity { Id = Guid.NewGuid(), Number = "11121", SerialNumber = "MNOPQ", DeviceName = "iPhone 6+", CustomerEmail = "d@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "31415", SerialNumber = "RSTUV", DeviceName = "iPhone 6+", CustomerEmail = "e@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "16171", SerialNumber = "WXYZA", DeviceName = "iPhone 6+", CustomerEmail = "f@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "81920", SerialNumber = "BCDEF", DeviceName = "iPhone 6+", CustomerEmail = "g@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "21222", SerialNumber = "GHIJK", DeviceName = "iPhone 6+", CustomerEmail = "h@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "32425", SerialNumber = "LMNOP", DeviceName = "iPhone 6+", CustomerEmail = "i@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "26272", SerialNumber = "QRSTU", DeviceName = "iPhone 6+", CustomerEmail = "j@b.com" }
            );

            //policyHolder.UserPolicies.Add(p1);
            //policyHolder.UserPolicies.Add(p2);
            //policyHolder.UserPolicies.Add(p3);
            //policyHolder.UserPolicies.Add(p4);
            //context.SaveChanges();
        }

        public AuthorizedUser CreateUser(string userName, string email, EDeviceClaimsContext context, string role)
        {
            var userStore = new UserStore<AuthorizedUser>(context);
            var userManager = new UserManager<AuthorizedUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var user = userManager.FindByEmail(email);

            if (user != null) return user;

            user = new AuthorizedUser { UserName = userName, Email = email };
            userManager.Create(user, "password");
            roleManager.Create(new IdentityRole { Name = role });
            userManager.AddToRole(user.Id, role);
            return user;
        }
    }
}
