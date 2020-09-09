using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBlazor.API.Interface;
using EmployeeBlazor.API.Repository;
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
    }
}
