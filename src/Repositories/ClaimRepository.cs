using EDeviceClaims.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EDeviceClaims.Entities;
using EDeviceClaims.Core;

namespace EDeviceClaims.Repositories
{
    public interface IClaimRepository : IEfRepository<ClaimEntity, Guid>
    {
        //ClaimEntity GetByClaimNumber(string claimNumber);

        //ICollection<ClaimEntity> GetByUserId(string userId);
        ClaimEntity GetByPolicyId(Guid policyId);
        ICollection<ClaimEntity> GetAllActive();
    }

    public class ClaimRepository : EfRepository<ClaimEntity, Guid>, IClaimRepository
    {
        public ClaimRepository() : base(new EDeviceClaimsUnitOfWork())
        {
        }

        public ClaimRepository(IEfUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ClaimEntity GetByPolicyId(Guid policyId)
        {
            return null;
        }

        public ICollection<ClaimEntity> GetAllActive()
        {
            return ObjectSet
                    .Where(c => c.Status == ClaimStatus.Active)
                    .Include(c => c.Policy)
                    //.Include(c => c.Policy.User)  Is this line really necessary ??
                    .ToList();
        }
    }
}
