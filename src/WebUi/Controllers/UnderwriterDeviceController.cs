using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;
using EDeviceClaims.Core;

namespace EDeviceClaims.WebUi.Controllers
{
    [Authorize(Roles = ApplicationRoles.Underwriter)]
    public class UnderwriterDeviceController : AppController
    {
        private IPolicyService _policyService = new PolicyService();

        public ActionResult DeviceDetails(Guid policyId)
        {
            var deviceDomainModel = _policyService.GetByPolicyId(policyId);
            var deviceViewModel = new DeviceViewModel(deviceDomainModel);

            return View(deviceViewModel);
        }
        public ActionResult DeviceList()
        {
            var deviceListDomainModel = _policyService.GetAll();
            var deviceListViewModel = new DeviceListViewModel(deviceListDomainModel);

            return View(deviceListViewModel);
        }
    }
}