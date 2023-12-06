using DAL.Entities;
using DAL.Models.Sheard;
using DAL.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IDegreeService
    {
        Task<Response<Degree>> CreateDegreeAsync(CreateDegree Degree);
        Task<Response<Degree>> DeleteDegreeAsync(int Id);
        Task<Response<Degree>> GetDegreeAsync(int StudentId, int TestId);
        Task<Response<Degree>> GetStudentDegreesAsync(int SAtudentId);
        Task<Response<Degree>> GetAllDegreeAsync(int TestId);
    }
}
