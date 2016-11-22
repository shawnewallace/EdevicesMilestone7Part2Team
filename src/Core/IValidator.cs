using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDeviceClaims.Core
{
  public interface IValidator
  {
    ICollection<ValidationResult> ErrorCollection { get; }
    bool TryValidate(object @object);
  }
}
