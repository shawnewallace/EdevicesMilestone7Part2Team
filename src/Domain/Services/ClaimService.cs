using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;


namespace EDeviceClaims.Domain.Services
{
    public interface IClaimService
    {
        ClaimDomainModel StartClaim(Guid policyId);
        ClaimDomainModel GetByClaimId(Guid claimId);
        ClaimDomainModel GetByPolicyId(Guid policyId);
        IEnumerable<ClaimDomainModel> GetAllActive();
    }

    public class ClaimService : IClaimService
    {
        private IGetPolicyInteractor GetPolicyInteractor
        {
            get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
            set { _getPolicyInteractor = value; }
        }
        private IGetPolicyInteractor _getPolicyInteractor;

        private IGetClaimInteractor GetClaimInteractor
        {
            get { return _getClaimInteractor ?? (_getClaimInteractor = new GetClaimInteractor()); }
            set { _getClaimInteractor = value; }
        }
        private IGetClaimInteractor _getClaimInteractor;


        public ClaimDomainModel StartClaim(Guid policyId)
        {
            //Get the policy
            var policyEntity = GetPolicyInteractor.GetByPolicyId(policyId);
            if (policyEntity == null) return null;  //alternate code for this line below
            //if (policy == null) throw new ArgumentException("Policy does not exist");

            //Exercise business rules that apply to the policy
            //For example,
            //check whether the policy belongs to the user,
            //check whether the policy is active,
            //check whether the policy already has an active claim

            //Create new claim
            var claimEntity = GetClaimInteractor.CreateClaim(policyEntity.Id, policyEntity.UserId);

            //Exercise business rules that apply to the claim
            //none yet

            return new ClaimDomainModel(claimEntity);
        }

        public ClaimDomainModel GetByClaimId(Guid claimId)
        {
            //get existing claim.
            var claimEntity = GetClaimInteractor.GetByClaimId(claimId);
            if (claimEntity == null) return null;  //alternate code for this line below
            //if (claimEntity == null) throw new ArgumentException("Claim does not exist");

            //Exercise business rules that apply to the claim
            //none yet

            return new ClaimDomainModel(claimEntity);
        }

        public ClaimDomainModel GetByPolicyId(Guid policyId)
        {
            //get existing claim.
            var claimEntity = GetClaimInteractor.GetByPolicyId(policyId);
            if (claimEntity == null) return null;  //alternate code for this line below
            //if (claimEntity == null) throw new ArgumentException("Claim does not exist");

            return new ClaimDomainModel(claimEntity);
        }

        public IEnumerable<ClaimDomainModel> GetAllActive()
        {
            var claimEntities = GetClaimInteractor.GetAllActive();

            return claimEntities
                .Select(claimEntity => new ClaimDomainModel(claimEntity))
                .ToList();
        }
    }
}