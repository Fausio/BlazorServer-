using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBlazor.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required( ErrorMessage ="O nome do funcionario é obrigatório")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBrith { get; set; }

        public Gender Gender { get; set; }

        public int DepartmentId { get; set; }

        public String PhotoPath { get; set; }
    }
}
