using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBlazor.API.Interface;
using EmployeeBlazor.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBlazor.API.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetAllEmployee()
        {
            try
            {
                return Ok(await departmentRepository.GetAllModels());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao ler os dados da base ");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            try
            {
                var result = Ok(await departmentRepository.GetModelById(id));
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
