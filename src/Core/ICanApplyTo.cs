namespace EDeviceClaims.Core
{
  public interface ICanApplyTo<T> where T : class
  {
    T ApplyTo(T x);
  }
}