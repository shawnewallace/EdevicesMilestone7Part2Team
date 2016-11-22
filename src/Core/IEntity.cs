namespace EDeviceClaims.Core
{
  public interface IEntity<TKey>
  {
    TKey Id { get; set; }
  }
}