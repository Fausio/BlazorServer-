using EmployeeBlazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeBlazor.API.Interface
{
 public  interface IDepartmentRepository
    {
      Task<IEnumerable<Department>>   GetAllModels();
        Task<Department>  GetModelById(int ModelId);
    }
}
