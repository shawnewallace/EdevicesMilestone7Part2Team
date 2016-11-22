namespace EDeviceClaims.Core
{
  public interface IAddress
  {
    string Street { get; set; }
    string City { get; set; }
    string State { get; set; }
    string ZipCode { get; set; }
    string AddressName { get; set; }
  }
}