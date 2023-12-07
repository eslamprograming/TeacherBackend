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
        private readonly IDegreeService _degreeService;


        public QuctionTestService(IQuestionTestRepo QuctionTestTest, IDegreeService degreeService)
        {
            _QuctionTestTest = QuctionTestTest;
            _degreeService = degreeService;
        }


        private async Task<object> AddDegree(CreateDegree Degree)
        {
            var result = await _degreeService.CreateDegreeAsync(Degree);
            return result;
        }

        public async Task<Response<string>> CorrectTest(List<CorrectQuectionTest> QuestionsTest,int TestId,int StudentId,int SubjectId)
        {
            try
            {
                int x = 0;
                int degree = 0;
                var result = await GetAllQuctionTestsInCheapter(TestId);
                
                foreach (var item in QuestionsTest)
                {
                    if (item.Quction == result.values[x].Quction)
                    {
                        if(item.Ansure == result.values[x].Ansure)
                        {
                            degree++;
                        }
                    }
                    x++;
                }
                CreateDegree degree1 = new CreateDegree();
                degree1.degree=degree;
                degree1.TestId = TestId;
                degree1.StudentId = StudentId;
                degree1.SubjectId = SubjectId;
                await AddDegree(degree1);
                return new Response<string>
                {
                    success = true,
                    statuscode="200",
                    Value ="Degree = "+ degree.ToString()
                };
            }
            catch (Exception e)
            {
                return new Response<string>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<QuctionTest>> CreateQuctionTestAsync(CreateQuestionTest QuctionTest)
        {
            try
            {
                List<TestQuestionChoice> testQuestionChoices = new List<TestQuestionChoice>();
                QuctionTest QuctionTest1 = new QuctionTest();
                QuctionTest1.Quction = QuctionTest.Quction;
                QuctionTest1.Ansure = QuctionTest.Ansure;
                foreach (var item in QuctionTest.Choices)
                {
                    TestQuestionChoice testQuestionChoice = new TestQuestionChoice();
                    testQuestionChoice.choice = item;
                    testQuestionChoice.QuestionTestId = QuctionTest1.Id;
                    testQuestionChoices.Add(testQuestionChoice);
                }
                TestQuestionChoice testQuestionChoice2 = new TestQuestionChoice();
                testQuestionChoice2.choice = QuctionTest.Ansure;
                testQuestionChoice2.QuestionTestId = QuctionTest1.Id;
                testQuestionChoices.Add(testQuestionChoice2);
                QuctionTest1.Choices = testQuestionChoices;
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
                List<TestQuestionChoice> testQuestionChoices = new List<TestQuestionChoice>();
                QuctionTest QuctionTest1 = new QuctionTest();
                QuctionTest1.Quction = QuctionTest.Quction;
                QuctionTest1.Ansure = QuctionTest.Ansure;
                foreach (var item in QuctionTest.Choices)
                {
                    TestQuestionChoice testQuestionChoice = new TestQuestionChoice();
                    testQuestionChoice.choice = item;
                    testQuestionChoice.QuestionTestId = QuctionTest1.Id;
                    testQuestionChoices.Add(testQuestionChoice);
                }
                TestQuestionChoice testQuestionChoice2 = new TestQuestionChoice();
                testQuestionChoice2.choice = QuctionTest.Ansure;
                testQuestionChoice2.QuestionTestId = QuctionTest1.Id;
                testQuestionChoices.Add(testQuestionChoice2);
                QuctionTest1.Choices = testQuestionChoices;
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
