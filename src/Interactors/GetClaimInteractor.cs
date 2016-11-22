using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Core;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;
using EDeviceClaims.Repositories.Migrations;

namespace EDeviceClaims.Interactors
{
    public interface IGetClaimInteractor
    {
        ClaimEntity CreateClaim(Guid policyId, string userId);
        ClaimEntity GetByClaimId(Guid claimId);
        ClaimEntity GetByPolicyId(Guid policyId);
        ICollection<ClaimEntity> GetAllActive();
    }
    public class GetClaimInteractor : IGetClaimInteractor
    {
        private IClaimRepository ClaimRepo
        {
            get { return _claimRepo ?? (_claimRepo = new ClaimRepository()); }
            set { _claimRepo = value; }
        }
        private IClaimRepository _claimRepo;

        public GetClaimInteractor() { }

        public GetClaimInteractor(IClaimRepository claimRepo)
        {
            _claimRepo = claimRepo;
        }

        public ClaimEntity CreateClaim(Guid policyId, string userId)
        {
            var claimEntity = new ClaimEntity();
            claimEntity.Id = Guid.NewGuid();
            claimEntity.Status = ClaimStatus.Active;
            claimEntity.PolicyId = policyId;
            claimEntity.UserId = userId;
            claimEntity.WhenLastModified = DateTime.Now;

            return ClaimRepo.Create(claimEntity);
        }

        public ClaimEntity GetByClaimId(Guid claimId)
        {
            var claimEntity = ClaimRepo.GetById(claimId);
            if (claimEntity == null) return null;
            return claimEntity;
        }

        public ClaimEntity GetByPolicyId(Guid policyId)
        {
            var claimEntity = ClaimRepo.GetByPolicyId(policyId);
            if (claimEntity == null) return null;
            return claimEntity;
        }

        public ICollection<ClaimEntity> GetAllActive()
        {
            return ClaimRepo.GetAllActive();
        }
    }
}
