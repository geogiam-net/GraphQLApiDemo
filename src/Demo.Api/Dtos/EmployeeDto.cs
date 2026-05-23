using Demo.Business.Models;

namespace Demo.Api.Dtos;

public class EmployeeDto
{
    public Guid Id { get; set; } = default;

    public string Name { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; } = default;

    public Role Role { get; set; } = Role.None;

    public Company? Company { get; set; }

    public EmployeeDto()
    {
    }

    public EmployeeDto(Employee employee)
    {
        Id = employee.Id;
        Name = employee.Name;
        Lastname = employee.Lastname;
    }
}
