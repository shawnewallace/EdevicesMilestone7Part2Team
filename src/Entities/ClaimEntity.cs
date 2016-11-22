using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace EDeviceClaims.Entities
{
    [Table("claims", Schema = "app")]
    public class ClaimEntity : EntityBase<Guid>
    {
        public string Status { get; set; }
        public string Notes { get; set; }
        public Guid PolicyId { get; set; }
        public string UserId { get; set; }
        public virtual AuthorizedUser User { get; set; }
        public virtual PolicyEntity Policy { get; set; }
    }
}