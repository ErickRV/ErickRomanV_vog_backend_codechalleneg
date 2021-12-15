using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VogCodeChallenge.API.Data;
using VogCodeChallenge.Domain.DTOs.Employee;
using VogCodeChallenge.Domain.Entities;

namespace VogCodeChallenge.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()) 
            {
                // Seed Testing Data
                ApiDbContext context = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
                if (context.Database.IsInMemory())
                    SeedTestData(context);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        private static void SeedTestData(ApiDbContext context)
        {
            Department department1 = new Department("Department1", "UniqueAddress1");
            context.Departments.Add(department1);
            Department department2 = new Department("Department2", "UniqueAddress2");
            context.Departments.Add(department2);
            context.SaveChanges();

            CreateEmployeeDto createEmployee1 = new CreateEmployeeDto
            {
                DepartmentId = department1.DepartmentId,
                FirstName = "Test_Name1",
                LastName = "Test_LastName1",
                JobTitle = "Software Developer one",
                MailingAddress = "Some mailing adress..."
            };
            Employee employee1 = new Employee(createEmployee1);

            CreateEmployeeDto createEmployee2 = new CreateEmployeeDto
            {
                DepartmentId = department1.DepartmentId,
                FirstName = "Test_Name2",
                LastName = "Test_LastName2",
                JobTitle = "Software Developer two",
                MailingAddress = "Some other mailing adress"
            };
            Employee employee2 = new Employee(createEmployee2);

            CreateEmployeeDto createEmployee3 = new CreateEmployeeDto
            {
                DepartmentId = department2.DepartmentId,
                FirstName = "Test_Name3",
                LastName = "Test_LastName3",
                JobTitle = "Software Developer three",
                MailingAddress = "Constanza Norte 10"
            };
            Employee employee3 = new Employee(createEmployee3);

            context.Employees.Add(employee1);
            context.Employees.Add(employee2);
            context.Employees.Add(employee3);
            context.SaveChanges();
        }
    }
}
