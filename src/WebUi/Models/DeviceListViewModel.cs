using System.Collections.Generic;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
  public class DeviceListViewModel : List<DeviceViewModel>
  {
    public DeviceListViewModel(IEnumerable<PolicyDomainModel> policyListDomainModel)
    {
      foreach (var policyDomainModel in policyListDomainModel)
      {
        Add(new DeviceViewModel(policyDomainModel));
      }
    }
  }
}