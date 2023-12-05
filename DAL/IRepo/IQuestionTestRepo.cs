using DAL.Entities;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IQuestionTestRepo
    {
        Task<Response<QuctionTest>> CreateQuctionTest(QuctionTest QuctionTest);
        Task<Response<QuctionTest>> UpdateQuctionTest(QuctionTest QuctionTest, int Id);
        Task<Response<QuctionTest>> DeleteQuctionTest(int Id);
        Task<Response<QuctionTest>> GetQuctionTest(int Id);
        Task<Response<QuctionTest>> GetAllQuctionTest(int TestId);
    }
}
