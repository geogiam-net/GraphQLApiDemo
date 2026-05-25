namespace Demo.Business.Models;

public class LocationDto
{
    public Guid Id { get; set; } = default;

    public string Number { get; set; } = string.Empty;

    public string Street { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    public bool IsHeadquarters { get; set; } = default;

    public bool IsLeased { get; set; } = default;

    public LocationDto() { }

    public LocationDto(Location location)
    {
        Id = location.Id;
        Number = location.Number;
        Street = location.Street;
        City = location.City;
        ZipCode = location.ZipCode;
        IsHeadquarters = location.IsHeadquarters;
        IsLeased = location.IsLeased;
    }
}
