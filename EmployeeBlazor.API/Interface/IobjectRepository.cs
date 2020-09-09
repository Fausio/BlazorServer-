using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBlazor.Model;

namespace EmployeeBlazor.API.Interface
{
    interface IobjectRepository
    {
        Task<IEnumerator<object>> GetAllModel();
        Task<object> AddModel(object obj);
        Task<object> UpdateModel(object obj);
        void DeleteModel(int objID);
    }
}
