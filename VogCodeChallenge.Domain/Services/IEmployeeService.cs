using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.Domain.DTOs.Employee;
using VogCodeChallenge.Domain.Entities;

namespace VogCodeChallenge.Domain.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        IList<Employee> ListAll();
        IList<OutputEmployeeDto> ListAllByDepartment(int DepartmentId);
    }
}
