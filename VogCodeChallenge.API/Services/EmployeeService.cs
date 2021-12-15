using System;
using System.Collections.Generic;
using System.Linq;
using VogCodeChallenge.API.Data;
using VogCodeChallenge.Domain.DTOs.Employee;
using VogCodeChallenge.Domain.Entities;
using VogCodeChallenge.Domain.Services;

namespace VogCodeChallenge.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApiDbContext context;

        public EmployeeService(ApiDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                return context.Employees;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Employee> ListAll()
        {
            try
            {
                return context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<OutputEmployeeDto> ListAllByDepartment(int DepartmentId)
        {
            try
            {
                Department department = context.Departments.FirstOrDefault(d => d.DepartmentId == DepartmentId);
                if (department == default)
                    throw new Exception("Department not found!");

                return context.Employees.Where(e => e.DepartmentId == department.DepartmentId).Select(e => e.toOutput()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
