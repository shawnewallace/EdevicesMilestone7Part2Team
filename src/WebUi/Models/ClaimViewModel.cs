using EDeviceClaims.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDeviceClaims.WebUi.Models
{
    public class ClaimViewModel
    {
        public ClaimViewModel()
        {
        }

        public ClaimViewModel(ClaimDomainModel claimDomainModel)
        {
            //fields from the ClaimDomainModel
            Id = claimDomainModel.Id;
            Status = claimDomainModel.Status;
            Notes = claimDomainModel.Notes;
            PolicyId = claimDomainModel.PolicyId;
            UserId = claimDomainModel.UserId;
            WhenCreated = claimDomainModel.WhenCreated;
            WhenLastModified = claimDomainModel.WhenLastModified;

            //fields from the Policy attribute in the ClaimDomainModel
            Number = claimDomainModel.Policy.Number;
            SerialNumber = claimDomainModel.Policy.SerialNumber;
            DeviceName = claimDomainModel.Policy.DeviceName;
        }

        public ClaimViewModel(ClaimDomainModel claimDomainModel, PolicyDomainModel policyDomainModel)
        {
            //fields from the ClaimDomainModel
            Id = claimDomainModel.Id;
            Status = claimDomainModel.Status;
            Notes = claimDomainModel.Notes;
            PolicyId = claimDomainModel.PolicyId;
            UserId = claimDomainModel.UserId;
            WhenCreated = claimDomainModel.WhenCreated;
            WhenLastModified = claimDomainModel.WhenLastModified;

            //fields from the PolicyDomainModel
            Number = policyDomainModel.Number;
            SerialNumber = policyDomainModel.SerialNumber;
            DeviceName = policyDomainModel.DeviceName;   
        }

        //fields from the ClaimDomainModel
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public Guid PolicyId { get; set; }
        public string UserId { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime? WhenLastModified { get; set; }

        //fields from the PolicyDomainModel
        public string Number { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceName { get; set; }
    }
}