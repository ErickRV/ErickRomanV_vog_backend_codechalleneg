using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VogCodeChallenge.API.Data;
using VogCodeChallenge.API.Services;
using VogCodeChallenge.Domain.DTOs.Employee;
using VogCodeChallenge.Domain.Entities;
using VogCodeChallenge.Domain.Services;

namespace VogCodeChallenge.Tests.API.Services
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private ApiDbContext context;
        private IEmployeeService employeeService;

        private void SeedTestingContext()
        {
            var dbOptions = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new ApiDbContext(dbOptions);
            employeeService = new EmployeeService(context);

            SeedTestData(context);
        }
        private void SeedTestData(ApiDbContext context)
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

        [TestMethod]
        public void GetAll_Ok() {
            //Arrange 
            SeedTestingContext();
            IEnumerable<Employee> control = context.Employees;
            //Act
            IEnumerable<Employee> employees = employeeService.GetAll();
            //Assert
            Assert.AreEqual(control, employees);
        }

        [TestMethod]
        public void ListAll_Ok()
        {
            //Arrange 
            SeedTestingContext();
            IList<Employee> control = context.Employees.ToList();
            //Act
            IList<Employee> employees = employeeService.ListAll();
            //Assert
            Assert.AreEqual(control.Count, employees.Count);
            for (int i = 0; i< employees.Count; i++)
                Assert.AreEqual(control[i], employees.First(e => e.EmployeeId == control[i].EmployeeId));
        }

        [TestMethod]
        public void ListAllByDepartment_Ok() {
            //Arrange
            SeedTestingContext();
            Department department = context.Departments.First();
            IList<OutputEmployeeDto> control = context.Employees.Where(e => e.DepartmentId == department.DepartmentId).Select(e => e.toOutput()).ToList();
            //Act
            IList<OutputEmployeeDto> employees = employeeService.ListAllByDepartment(department.DepartmentId);
            //Assert
            Assert.AreEqual(control.Count, employees.Count);
            foreach (OutputEmployeeDto employee in control) {
                OutputEmployeeDto result = employees.First(e => e.EmployeeId == employee.EmployeeId);
                Assert.AreEqual(employee.DepartmentId, result.DepartmentId);
                Assert.AreEqual(employee.FirstName, result.FirstName);
                Assert.AreEqual(employee.LastName, result.LastName);
                Assert.AreEqual(employee.JobTitle, result.JobTitle);
                Assert.AreEqual(employee.MailingAddress, result.MailingAddress);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Department not found!")]
        public void ListAllByDepartment_Fails_DepartmentNotFound()
        {
            //Arrange
            SeedTestingContext();
            //Act & Assert
            employeeService.ListAllByDepartment(0);
        }
    }
}
