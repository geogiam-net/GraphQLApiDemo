using Demo.Api.Dtos;
using Demo.Business.Interfaces;

namespace Demo.Api.Exceptions.Endpoints;

public class Mutation
{
    public async Task<EmployeeDto> CreateEmployee(NewEmployeeDto employee, IEmployeeService employeeService, CancellationToken cancellationToken)
    {
        var newEmployee = await employeeService.CreateEmployeeAsync(employee.Name, employee.Lastname, cancellationToken);
        return new EmployeeDto(newEmployee);
    }
}
