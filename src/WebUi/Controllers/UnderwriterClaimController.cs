using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;
using EDeviceClaims.Core;

namespace EDeviceClaims.WebUi.Controllers
{
    [Authorize(Roles = ApplicationRoles.Underwriter)]
    public class UnderwriterClaimController : AppController
    {
        private IClaimService _claimService = new ClaimService();

        public ActionResult ClaimDetails(Guid claimId)
        {
            return null;
        }
        public ActionResult ClaimList()
        {
            var claimListDomainModel = _claimService.GetAllActive();
            var claimListViewModel = new ClaimListViewModel(claimListDomainModel);

            return View(claimListViewModel);
        }
    }
}