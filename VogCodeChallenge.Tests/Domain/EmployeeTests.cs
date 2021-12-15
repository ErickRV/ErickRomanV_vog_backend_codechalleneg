using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.Domain.DTOs.Employee;
using VogCodeChallenge.Domain.Entities;

namespace VogCodeChallenge.Tests.Domain
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void Create_Employee_Ok() {
            //Arrange 
            CreateEmployeeDto input = new CreateEmployeeDto
            {
                DepartmentId = 1,
                FirstName = "Test_Name",
                LastName = "Test_LastName",
                JobTitle = "Software Developer",
                MailingAddress = "Some mailing adress..."
            };

            //Act
            Employee employee = new Employee(input);

            //Assert
            Assert.AreEqual(input.DepartmentId, employee.DepartmentId);
            Assert.AreEqual(input.FirstName, employee.FirstName);
            Assert.AreEqual(input.LastName, employee.LastName);
            Assert.AreEqual(input.JobTitle, employee.JobTitle);
            Assert.AreEqual(input.MailingAddress, employee.MailingAddress);
        }
    }
}
