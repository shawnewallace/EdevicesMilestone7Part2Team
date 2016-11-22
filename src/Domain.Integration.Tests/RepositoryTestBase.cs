using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;
using EDeviceClaims.Repositories.Contexts;
using NUnit.Framework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EDeviceClaims.Domain.Integration.Tests
{
  public class RepositoryTestBase<TContext> where TContext : DbContext, new()
  {
    [TestFixtureSetUp]
    public void SetUp()
    { 
      Database.SetInitializer(new DropCreateDatabaseAlways<TContext>());
    }

    protected AuthorizedUser CreateUser(string userName, string email, TContext context)
    {
      var userStore = new UserStore<AuthorizedUser>(context);
      var userManager = new UserManager<AuthorizedUser>(userStore);

      var user = userManager.FindByEmail(email);

      if (user != null) return user;

      user = new AuthorizedUser { UserName = userName, Email = email };
      userManager.Create(user, "password");
      return user;
    }
  }
}
