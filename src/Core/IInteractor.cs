using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDeviceClaims.Core
{
  public interface IInteractor
  {
    ICollection<ValidationResult> ErrorMessages { get; set; }
  }
}