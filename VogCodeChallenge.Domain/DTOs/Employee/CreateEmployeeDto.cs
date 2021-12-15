using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.Domain.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string MailingAddress { get; set; }
    }
}
