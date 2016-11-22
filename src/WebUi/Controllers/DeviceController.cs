using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;
using EDeviceClaims.Core;

namespace EDeviceClaims.WebUi.Controllers
{
    [Authorize(Roles = ApplicationRoles.PolicyHolder)]
    public class DeviceController : AppController
    {
        private IPolicyService _policyService = new PolicyService();

        public ActionResult DeviceDetails(Guid id)
        {
            var domainModel = _policyService.GetByPolicyId(id);
            var model = new DeviceViewModel(domainModel);

            return View(model);
        }
        public ActionResult DeviceList()
        {
            var domainModel = _policyService.GetByUserId(CurrentUserId);
            var model = new DeviceListViewModel(domainModel);

            return View(model);
        }
    }
}