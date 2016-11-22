using System;
using System.Data.Entity;
using EDeviceClaims.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EDeviceClaims.Repositories.Contexts
{
  public class EDeviceClaimsContext : IdentityDbContext<AuthorizedUser>
  {
    public DbSet<PolicyEntity> Policies { get; set; }
    public DbSet<ClaimEntity> Claims { get; set; }

    public EDeviceClaimsContext(string cn) : base(cn)
    {
    }

    public EDeviceClaimsContext() : base("EDeviceClaimsContext", throwIfV1Schema: false)
    {
    }

    public static EDeviceClaimsContext Create()
    {
      return new EDeviceClaimsContext();
    }
  }
}