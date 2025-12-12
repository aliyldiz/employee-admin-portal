using EmployeeAdminPortalApi.Application.DTOs.Employee;
using EmployeeAdminPortalApi.Domain.Entities;
using EmployeeAdminPortalApi.Persistence.Context;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortalApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly ApplicationDbContext dbContext;

    public EmployeesController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var allEmployees = dbContext.Employees.ToList();
        return Ok(allEmployees);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetEmployeeById(Guid id)
    {
        var employee = dbContext.Employees.Find(id);
        
        if (employee is null)
        {
            return NotFound();
        }
        
        return Ok(employee);
    }
    
    [HttpPost]
    public IActionResult CreateEmployee(CreateEmployeeDto dto)
    {
        var newEmployee = new Employee
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            Salary = dto.Salary
        };

        dbContext.Employees.Add(newEmployee);
        dbContext.SaveChanges();

        return Ok(newEmployee);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto dto)
    {
        var employee = dbContext.Employees.Find(id);
        
        if (employee is null)
        {
            return NotFound();
        }
        
        employee.Name = dto.Name;
        employee.Email = dto.Email;
        employee.Phone = dto.Phone;
        employee.Salary = dto.Salary;

        dbContext.SaveChanges();
        
        return Ok(employee);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult DeleteEmployee(Guid id)
    {
        var employee = dbContext.Employees.Find(id);
        
        if (employee is null)
        {
            return NotFound();
        }

        dbContext.Employees.Remove(employee);
     
        dbContext.SaveChanges();
        
        return Ok();
    }
}