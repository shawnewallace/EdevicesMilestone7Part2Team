using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{
    public interface IPolicyService
    {
        IEnumerable<PolicyDomainModel> GetByUserId(string userId);
        PolicyDomainModel GetByPolicyId(Guid policyId);
        IEnumerable<PolicyDomainModel> GetAll();
    }

    public class PolicyService : IPolicyService
    {
        private IGetPolicyInteractor _getPolicyInteractor;

        private IGetPolicyInteractor GetPolicyInteractor
        {
            get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
            set { _getPolicyInteractor = value; }
        }

        public IEnumerable<PolicyDomainModel> GetByUserId(string userId)
        {
            var policyEntities = GetPolicyInteractor.GetByUserId(userId);

            return policyEntities.Select(policyEntity => new PolicyDomainModel(policyEntity)).ToList();
        }

        public PolicyDomainModel GetByPolicyId(Guid policyId)
        {
            var policyEntity = GetPolicyInteractor.GetByPolicyId(policyId);

            if (policyEntity == null) return null;

            return new PolicyDomainModel(policyEntity);
        }

        public IEnumerable<PolicyDomainModel> GetAll()
        {
            var policyEntities = GetPolicyInteractor.GetAll();

            return policyEntities.Select(policyEntity => new PolicyDomainModel(policyEntity)).ToList();
        }
    }
}
