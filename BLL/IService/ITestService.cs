using DAL.Entities;
using DAL.Models.Test;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface ITestService
    {
        Task<Response<Test>> CreateTestAsync(CreateTest Test);
        Task<Response<Test>> DeleteTestAsync(int TestId);
        Task<Response<Test>> GetAllTestsInSubject(int SubjectId);
        Task<Response<Test>> GetTest(int TestId);
        Task<Response<Test>> UpdateTest(CreateTest Test, int TestId);
    }
}
