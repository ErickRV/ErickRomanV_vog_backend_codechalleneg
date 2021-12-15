using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VogCodeChallenge.Domain.DTOs.Employee;
using VogCodeChallenge.Domain.Entities;
using VogCodeChallenge.Domain.Services;

namespace VogCodeChallenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees() {
            try{
                return Ok(employeeService.GetAll());
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("department/{departmentId}")]
        public IActionResult GetByDepartment(int departmentId)
        
        {
            try
            {
                List<OutputEmployeeDto> employees = employeeService.ListAllByDepartment(departmentId).ToList();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
