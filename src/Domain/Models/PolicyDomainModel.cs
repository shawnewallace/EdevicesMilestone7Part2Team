using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
    public class PolicyDomainModel
    {
        public PolicyDomainModel(PolicyEntity policyEntity)
        {
            Id = policyEntity.Id;
            WhenCreated = policyEntity.WhenCreated;
            WhenLastModified = policyEntity.WhenLastModified;
            Number = policyEntity.Number;
            SerialNumber = policyEntity.SerialNumber;
            DeviceName = policyEntity.DeviceName;
            CustomerEmail = policyEntity.CustomerEmail;
            UserId = policyEntity.UserId;
            Claims = new List<ClaimDomainModel>();
            foreach (var claimEntity in policyEntity.Claims)
            {
                Claims.Add(new ClaimDomainModel(claimEntity));
            }
        }
        public Guid Id { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime? WhenLastModified { get; set; }
        public string Number { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceName { get; set; }
        public string CustomerEmail { get; set; }
        public string UserId { get; set; }
        public List<ClaimDomainModel> Claims { get; set; }
    }
}
