using DAL.Entities;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface ITestRepo
    {
        Task<Response<Test>> CreateTest(Test Test);
        Task<Response<Test>> UpdateTest(Test Test, int Id);
        Task<Response<Test>> DeleteTest(int Id);
        Task<Response<Test>> GetTest(int Id);
        Task<Response<Test>> GetAllTest(int SubjectId);
    }
}
