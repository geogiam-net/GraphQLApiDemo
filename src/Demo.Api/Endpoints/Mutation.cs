using Demo.Api.Dtos;
using Demo.Business.Interfaces;
using Demo.Business.Models;

namespace Demo.Api.Exceptions.Endpoints;

public class Mutation
{
    public async Task<EmployeeDto> CreateEmployee(NewEmployeeDto employee, IEmployeeService employeeService, CancellationToken cancellationToken)
    {
        var newEmployee = await employeeService.CreateEmployeeAsync(employee.Name, employee.Lastname, cancellationToken);
        return new EmployeeDto(newEmployee);
    }

    public async Task<CompanyDto?> UpdateCompanyFinancials(string legalName, decimal newEarnings, decimal newRevenue, 
        ICompanyService companyService, CancellationToken cancellationToken)
    {
        var company = await companyService.UpdateCompanyFinancialsAsync(legalName, newEarnings, newRevenue, cancellationToken);
        if (company is null) {
            return null;
        }
        return new CompanyDto(company);
    }
}
