using System.Collections.Generic;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
    public class ClaimListViewModel : List<ClaimViewModel>
    {
        public ClaimListViewModel(IEnumerable<ClaimDomainModel> claimListDomainModel)
        {
            foreach (var claimDomainModel in claimListDomainModel)
            {
                Add(new ClaimViewModel(claimDomainModel));
            }
        }
    }
}