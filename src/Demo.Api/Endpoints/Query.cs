using Demo.Api.Dtos;
using Demo.Business.Interfaces;

namespace Demo.Api.Exceptions.Endpoints;

public class Query
{
    public string GetGreeting() => "Hello, World!";
    
    public async Task<IEnumerable<EmployeeDto>> GetEmployees(int? pageSize, int? pageNum, IEmployeeService employeeService, CancellationToken cancellationToken) 
    {
        var employees = await employeeService.GetEmployeesAsync(pageSize ?? 0, pageNum ?? 0, cancellationToken);
        var employeeDtos = employees.Select(e => new EmployeeDto(e));
        return employeeDtos;
    }

}
