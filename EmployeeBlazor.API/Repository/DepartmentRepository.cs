using EmployeeBlazor.API.Interface;
using EmployeeBlazor.API.Model;
using EmployeeBlazor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeBlazor.API.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext db;

        public DepartmentRepository(ApplicationDbContext applicationDbContext)
        {
            this.db = applicationDbContext;
        }
        public async Task<IEnumerable<Department>> GetAllModels()
        {
            return await db.Department.ToListAsync();
        }

        public async Task<Department> GetModelById(int ModelId)
        {
            Task<Department> result = db.Department.FirstOrDefaultAsync(x => x.DepartmentId == ModelId);
            if (result != null)
            {
                return await result;
            }
            else
            {
                return  null;
            }
        }
    }
}
