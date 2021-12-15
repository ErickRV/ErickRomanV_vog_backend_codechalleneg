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
        Employee CreateTestEmployee() {
            CreateEmployeeDto input = new CreateEmployeeDto
            {
                DepartmentId = 1,
                FirstName = "Test_Name",
                LastName = "Test_LastName",
                JobTitle = "Software Developer",
                MailingAddress = "Some mailing adress..."
            };

            return new Employee(input);
        }



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

        [TestMethod]
        public void toOutput_Ok() {
            //Arrange
            Employee employee = CreateTestEmployee();
            //Act
            OutputEmployeeDto output = employee.toOutput();
            //Assert
            Assert.AreEqual(employee.EmployeeId, output.EmployeeId);
            Assert.AreEqual(employee.DepartmentId, output.DepartmentId);
            Assert.AreEqual(employee.FirstName, output.FirstName);
            Assert.AreEqual(employee.LastName, output.LastName);
            Assert.AreEqual(employee.JobTitle, output.JobTitle);
            Assert.AreEqual(employee.MailingAddress, output.MailingAddress);

        }
    }
}
