using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDeviceClaims.WebUi.Controllers
{
    public class ClaimController : AppController
    {
        private IClaimService _claimService = new ClaimService();
        private IPolicyService _policyService = new PolicyService();

        public ActionResult ClaimDetails(Guid claimId)
        {
            var claimDomainModel = _claimService.GetByClaimId(claimId);
            var claimViewModel = new ClaimViewModel(claimDomainModel);
            return View(claimViewModel);
        }
        public ActionResult Start(Guid policyId)
        {
            var claimDomainModel = _claimService.StartClaim(policyId);
            var policyDomainModel = _policyService.GetByPolicyId(policyId);
            var claimViewModel = new ClaimViewModel(claimDomainModel, policyDomainModel);
            return View(claimViewModel);
        } 
    }
}