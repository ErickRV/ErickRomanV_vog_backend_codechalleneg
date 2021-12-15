using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.Domain.Entities;

namespace VogCodeChallenge.Tests.Domain
{
    [TestClass]
    public class DepartmentTests
    {
        [TestMethod]
        public void Create_Department_OK() {
            //Arrnage
            string Name = "TestDepartment";
            string Address = "Test Unique address";
            //Act
            Department department = new Department(Name, Address);
            //Assert
            Assert.AreEqual(Name, department.Name);
            Assert.AreEqual(Address, department.Address);
        }
    }
}
