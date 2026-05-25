namespace Demo.Business.Models;

public class CorporationDto
{
    public Guid Id { get; set; } = default;

    public string LegalName { get; set; } = string.Empty;

    public CorporationDto() { }

    public CorporationDto(Corporation cop)
    {
        Id = cop.Id;
        LegalName = cop.LegalName;

    }
}
