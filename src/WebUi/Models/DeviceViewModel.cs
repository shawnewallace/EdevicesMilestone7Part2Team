using System;
using System.Security.Policy;
using EDeviceClaims.Domain.Models;
using System.Linq;
using System.Security.Claims;

namespace EDeviceClaims.WebUi.Models
{
    public class DeviceViewModel
    {
        public DeviceViewModel(PolicyDomainModel policyDomainModel)
        {
            PolicyId = policyDomainModel.Id;
            PolicyNumber = policyDomainModel.Number;
            SerialNumber = policyDomainModel.SerialNumber;
            Name = policyDomainModel.DeviceName;
            HasClaim = policyDomainModel.Claims.Any();
            if (HasClaim) ClaimId = policyDomainModel.Claims.First().Id;
        }

        public Guid PolicyId { get; set; }
        public string PolicyNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public bool HasClaim { get; set; }
        public Guid ClaimId { get; set; }   
    }
}