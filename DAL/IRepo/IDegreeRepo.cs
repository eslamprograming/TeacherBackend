using DAL.Entities;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IDegreeRepo
    {
        Task<Response<Degree>> CreateDegree(Degree Degree);
        Task<Response<Degree>> DeleteDegree(int Id);
        Task<Response<Degree>> GetDegree(int StudentId,int TestId);
        Task<Response<Degree>> GetStudentDegrees(int SAtudentId);
        Task<Response<Degree>> GetAllDegree(int TestId);
    }
}
