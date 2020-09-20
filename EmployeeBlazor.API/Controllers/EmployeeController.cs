using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBlazor.API.Interface;
using EmployeeBlazor.API.Repository;
using EmployeeBlazor.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBlazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employee)
        {
            this.employeeRepository = employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                return Ok(await employeeRepository.AddModel(employee));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar o modelo na dados da base ");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployee()
        {
            try
            {
                return Ok(await employeeRepository.GetAllModel());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao ler os dados da base ");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            try
            {
                var result = Ok(await employeeRepository.GetAllModelById(id));
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao ler os dados da base ");
            }
        }
    }
}
