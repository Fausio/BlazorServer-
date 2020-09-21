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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                Employee employeeToDatele = await employeeRepository.GetAllModelById(id);
                if (employeeToDatele == null)
                {
                    return BadRequest("Funcionário não encontrado");
                }

                return await employeeRepository.DeleteModel(id);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao apagar o modelo na dados da base ");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateModel(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest("ID de funcionário incompatível");
                }

                Employee employeeToUpdate = await employeeRepository.GetAllModelById(id);
                if (employeeToUpdate == null)
                {
                    return NotFound("Funcionário não encontrado");
                }

                return await employeeRepository.UpdateModel(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                Employee EmailOfEmployee = await employeeRepository.GetAllModelByEmail(employee.Email);

                if (EmailOfEmployee != null)
                {
                    ModelState.AddModelError("Email", "Já existe um funcionario com email: " + employee.Email);
                    return BadRequest(ModelState);
                }

                Employee CreateEmployee = await employeeRepository.AddModel(employee);

                return CreatedAtAction(nameof(GetEmployeeById), new { id = CreateEmployee.EmployeeId }, CreateEmployee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar o modelo na dados da base ");
            }
        }

        [HttpGet("{SearchEmployee}")]
        public async Task<ActionResult<Employee>> SearchEmployee(string Name, Gender? Gender)
        {
            try
            {
                List<Employee> employees = await employeeRepository.Search(Name, Gender);

                if (employees.Any())
                {
                    return Ok(employees);
                }

                return NotFound();
            }
            catch (Exception)
            {

                throw;
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
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
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
