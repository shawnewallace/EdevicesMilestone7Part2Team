using System;
using System.Data.Entity;
using System.Linq;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories.Contexts;
using NUnit.Framework;

namespace EDeviceClaims.Domain.Integration.Tests.ServicesTests.PolicyServiceTests
{
  [TestFixture]
  public class GetByUserIdTests : RepositoryTestBase<EDeviceClaimsContext>
  {
    private AuthorizedUser _user;
    private PolicyService _service;

    [SetUp]
    public void SetUpFixture()
    {
      using (var db = new EDeviceClaimsContext())
      {
        _user = CreateUser("policyholder@company.com", "policyholder@company.com", db);
        db.SaveChanges();

        db.Policies.Add(new PolicyEntity { Id = Guid.NewGuid(), Number = "11121", SerialNumber = "MNOPQ", DeviceName = "iPhone 6+", CustomerEmail = "d@b.com", UserId = _user.Id});
        db.Policies.Add(new PolicyEntity { Id = Guid.NewGuid(), Number = "11122", SerialNumber = "ABCDE", DeviceName = "iPhone 6+", CustomerEmail = "d@b.com", UserId = _user.Id });
        db.Policies.Add(new PolicyEntity { Id = Guid.NewGuid(), Number = "11123", SerialNumber = "EDCBA", DeviceName = "iPhone 6+", CustomerEmail = "d@b.com" });

        db.SaveChanges();
      }

      _service = new PolicyService();
    }

    [Test]
    public void it_returns_the_policies_for_the_user()
    {
      var result = _service.GetByUserId(_user.Id);
      Assert.GreaterOrEqual(result.Count(), 2);
    }

    [Test]
    public void it_returnes_zerp_policies_when_the_user_id_does_not_exist()
    {
      var result = _service.GetByUserId("NOT FOUND");
      Assert.IsEmpty(result);
    }
  }
}
