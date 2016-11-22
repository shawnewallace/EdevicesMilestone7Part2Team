using EDeviceClaims.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDeviceClaims.Domain.Models
{
    public class ClaimDomainModel
    {
        public ClaimDomainModel(ClaimEntity claimEntity)
        {
            Id = claimEntity.Id;
            Status = claimEntity.Status;
            Notes = claimEntity.Notes;
            PolicyId = claimEntity.PolicyId;
            UserId = claimEntity.UserId;
            Policy = claimEntity.Policy;
            WhenCreated = claimEntity.WhenCreated;
            WhenLastModified = claimEntity.WhenLastModified;
        }

        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public Guid PolicyId { get; set; }
        public string UserId { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime? WhenLastModified { get; set; }
        public virtual PolicyEntity Policy { get; set; }
    }
}
