using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{
    public interface IPolicyRepository : IEfRepository<PolicyEntity, Guid>
    {
        PolicyEntity GetByPolicyNumber(string number);
        ICollection<PolicyEntity> GetByUserId(string userId);
    }

    public class PolicyRepository : EfRepository<PolicyEntity, Guid>, IPolicyRepository
    {
        public PolicyRepository() : base(new EDeviceClaimsUnitOfWork())
        {
        }

        public PolicyRepository(IEfUnitOfWork unitOfWork) : base(unitOfWork) { }

        public PolicyEntity GetByPolicyNumber(string number)
        {
            return ObjectSet
              .FirstOrDefault(p => p.Number.ToLower() == number.ToLower());
        }

        public ICollection<PolicyEntity> GetByUserId(string userId)
        {
            return ObjectSet.Where(p => p.UserId == userId).Include(c => c.Claims).ToList();
        }
    }
}