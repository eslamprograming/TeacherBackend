using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.Question;
using DAL.Models.Sheard;
using DAL.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class QuctionTestService: IQuctionTestService
    {
        private readonly IQuestionTestRepo _QuctionTestTest;

        public QuctionTestService(IQuestionTestRepo QuctionTestTest)
        {
            _QuctionTestTest = QuctionTestTest;
        }
        public async Task<Response<QuctionTest>> CreateQuctionTestAsync(CreateQuestionTest QuctionTest)
        {
            try
            {
                QuctionTest QuctionTest1 = new QuctionTest();
                QuctionTest1.Quction = QuctionTest.Quction;
                QuctionTest1.Ansure = QuctionTest.Ansure;
                QuctionTest1.Choices = QuctionTest.Choices;
                QuctionTest1.TestId = QuctionTest.TestId;

                var result = await _QuctionTestTest.CreateQuctionTest(QuctionTest1);
                return result;

            }
            catch (Exception e)
            {
                return new Response<QuctionTest>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<QuctionTest>> DeleteQuctionTestAsync(int QuctionTestId)
        {
            try
            {
                var result = await _QuctionTestTest.DeleteQuctionTest(QuctionTestId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<QuctionTest>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<QuctionTest>> GetAllQuctionTestsInCheapter(int CheapterId)
        {
            try
            {
                var result = await _QuctionTestTest.GetAllQuctionTest(CheapterId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<QuctionTest>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<QuctionTest>> GetQuctionTest(int QuctionTestId)
        {
            try
            {
                var result = await _QuctionTestTest.GetQuctionTest(QuctionTestId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<QuctionTest>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<QuctionTest>> UpdateQuctionTest(CreateQuestionTest QuctionTest, int QuctionTestId)
        {
            try
            {
                QuctionTest QuctionTest1 = new QuctionTest();
                QuctionTest1.Quction = QuctionTest.Quction;
                QuctionTest1.Ansure = QuctionTest.Ansure;
                QuctionTest1.Choices = QuctionTest.Choices;
                QuctionTest1.TestId = QuctionTest.TestId;

                var result = await _QuctionTestTest.UpdateQuctionTest(QuctionTest1, QuctionTestId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<QuctionTest>
                {
                    message = e.Message
                };
            }
        }
    }
}
