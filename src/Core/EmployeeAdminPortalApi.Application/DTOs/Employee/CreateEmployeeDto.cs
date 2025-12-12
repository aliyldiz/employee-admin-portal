namespace EmployeeAdminPortalApi.Application.DTOs.Employee;

public class CreateEmployeeDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public decimal Salary { get; set; }
}