using DAL.Entities;
using DAL.Models.Question;
using DAL.Models.Sheard;
using DAL.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IQuctionTestService
    {
        Task<Response<QuctionTest>> CreateQuctionTestAsync(CreateQuestionTest QuctionTest);
        Task<Response<QuctionTest>> DeleteQuctionTestAsync(int QuctionTestId);
        Task<Response<QuctionTest>> GetAllQuctionTestsInCheapter(int CheapterId);
        Task<Response<QuctionTest>> GetQuctionTest(int QuctionTestId);
        Task<Response<QuctionTest>> UpdateQuctionTest(CreateQuestionTest QuctionTest, int QuctionTestId);
        Task<Response<string>> CorrectTest(List<CorrectQuectionTest> QuestionsTest, int TestId, int StudentId, int SubjectId);
    }
}
