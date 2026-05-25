using Demo.Api.Dtos;
using Demo.Business.Interfaces;
using Demo.Business.Models;

namespace Demo.Api.Exceptions.Endpoints;

public class Query
{
    public async Task<EmployeeDto?> GetEmployeeById(Guid id, IEmployeeService employeeService, CancellationToken cancellationToken)
    {
        var employee = await employeeService.GetEmployeeAsync(id, cancellationToken);
        if (employee is null)
        {
            return null;
        }
        return new EmployeeDto(employee);
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployees(int? pageSize, int? pageNum, IEmployeeService employeeService, CancellationToken cancellationToken) 
    {
        var employees = await employeeService.GetEmployeesAsync(pageSize ?? 0, pageNum ?? 0, cancellationToken);
        var employeeDtos = employees.Select(e => new EmployeeDto(e));
        return employeeDtos;
    }

    public async Task<CompanyDto?> GetCompanyData(string legalName, ICompanyService companyService, CancellationToken cancellationToken)
    {
        var company = await companyService.GetCompanyDataAsync(legalName, cancellationToken);
        if (company is null)
        {
            return null;
        }
        return new CompanyDto(company);
    }

}
