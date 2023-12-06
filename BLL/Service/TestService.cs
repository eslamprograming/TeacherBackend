using DAL.Entities;
using DAL.IRepo;
using DAL.Models.Test;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Helper;
using BLL.IService;

namespace BLL.Service
{
    public class TestService:ITestService
    {
        private readonly ITestRepo _testRepo;

        public TestService(ITestRepo testRepo)
        {
            _testRepo = testRepo;
        }

        public async Task<Response<Test>> CreateTestAsync(CreateTest Test)
        {
            try
            {
                Test Test1 = new Test();
                Test1.Name = Test.Name;
                Test1.FullMark = Test.FullMark;
                Test1.Count = Test.Count;
                Test1.Poster = Files.Save(Test.Poster);
                Test1.SubjectId = Test.SubjectId;

                var result = await _testRepo.CreateTest(Test1);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Test>> DeleteTestAsync(int TestId)
        {
            try
            {
                var result = await _testRepo.DeleteTest(TestId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Test>> GetAllTestsInSubject(int SubjectId)
        {
            try
            {
                var result = await _testRepo.GetAllTest(SubjectId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Test>> GetTest(int TestId)
        {
            try
            {
                var result = await _testRepo.GetTest(TestId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Test>> UpdateTest(CreateTest Test, int TestId)
        {
            try
            {
                Test Test1 = new Test();
                Test1.Name = Test.Name;
                Test1.FullMark = Test.FullMark;
                Test1.Count = Test.Count;
                Test1.Poster = Files.Save(Test.Poster);
                Test1.SubjectId = Test.SubjectId;

                var result = await _testRepo.UpdateTest(Test1, TestId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    message = e.Message
                };
            }
        }
    }
}
