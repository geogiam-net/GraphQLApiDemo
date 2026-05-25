using Demo.Api.Dtos;

namespace Demo.Business.Models;

public class CompanyDto
{
    public Guid Id { get; set; } = default;

    public CorporationDto? Corporation { get; set; }

    public string LegalName { get; set; } = string.Empty;

    public decimal EarningsLastYear { get; set; } = default;

    public decimal RevenueLastYear { get; set; } = default;

    public DateTime CreationDate { get; set; } = default;

    public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();

    public List<LocationDto> Locations { get; set; } = new List<LocationDto>();

    public CompanyDto() { }

    public CompanyDto(Company company)
    {
        Id = company.Id;
        Corporation = company.Corporation is not null ? new CorporationDto(company.Corporation) : null;
        LegalName = company.LegalName;
        EarningsLastYear = company.EarningsLastYear;
        RevenueLastYear = company.RevenueLastYear;
        CreationDate = company.CreationDate;
        Employees = company.Employees.Select(e => new EmployeeDto(e)).ToList();
        Locations = company.Locations.Select(l => new LocationDto(l)).ToList();
    }
}
