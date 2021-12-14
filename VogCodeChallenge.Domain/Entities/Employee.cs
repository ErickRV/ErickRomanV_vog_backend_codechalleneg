using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string MailingAddress { get; set; }
    }
}
