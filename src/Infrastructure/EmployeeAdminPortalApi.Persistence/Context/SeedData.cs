using Bogus;
using EmployeeAdminPortalApi.Domain.Entities;

namespace EmployeeAdminPortalApi.Persistence.Context;

public class SeedData
{
    private static List<Employee> GetUsers()
    {
        var result = new Faker<Employee>("tr")
            .RuleFor(u => u.Id, u => Guid.NewGuid())
            .RuleFor(u => u.Name, u => u.Name.FullName())
            .RuleFor(u => u.Email, u => u.Internet.Email())
            .RuleFor(u => u.Phone, u => u.Phone.PhoneNumber())
            .RuleFor(u => u.Salary, u => u.Finance.Amount(30000, 150000))
            .Generate(500);
        return result;
    }

    public async Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Employees.Any())
        {
            await Task.CompletedTask;
            return;
        }

        var users = GetUsers();

        await context.Employees.AddRangeAsync(users);
        await context.SaveChangesAsync();
    }
}
