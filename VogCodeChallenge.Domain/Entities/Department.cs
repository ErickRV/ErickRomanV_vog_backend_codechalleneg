using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.Domain.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
