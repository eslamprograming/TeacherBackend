using DAL.Data;
using DAL.Entities;
using DAL.IRepo;
using DAL.Migrations;
using DAL.Models.Sheard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class TestRepo:ITestRepo
    {
        private readonly ApplicationDbContext db;

        public TestRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Test>> CreateTest(Test Test1)
        {
            try
            {
                await db.Tests.AddAsync(Test1);
                await db.SaveChangesAsync();
                return new Response<Test>
                {
                    success = true,
                    statuscode = "201",
                    Value = Test1
                };
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Test>> DeleteTest(int Id)
        {
            try
            {
                var AllQuestionTest = await db.QuaternionTest.Where(n => n.TestId == Id).ToListAsync();
                foreach (var item in AllQuestionTest)
                {
                    var QuestionTestChoice = await db.TestQuestionsChoice.Where(n => n.QuestionTestId == item.Id).ToListAsync();
                    db.TestQuestionsChoice.RemoveRange(QuestionTestChoice);
                    db.QuaternionTest.Remove(item);
                    await db.SaveChangesAsync();
                }
                var TestDegree = await db.Degrees.Where(n => n.TestId == Id).ToListAsync();
                db.Degrees.RemoveRange(TestDegree);
                var Test = await db.Tests.Where(n => n.Id == Id).SingleOrDefaultAsync();
                db.Tests.Remove(Test);
                await db.SaveChangesAsync();
                return new Response<Test>
                {
                    statuscode = "200",
                    success = true,
                    Value = Test
                };
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Test>> GetAllTest(int SubjectId)
        {
            try
            {
                var Tests = await db.Tests.Where(n=>n.SubjectId==SubjectId).ToListAsync();

                return new Response<Test>
                {
                    statuscode = "200",
                    success = true,
                    values = Tests
                };
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Test>> GetTest(int Id)
        {
            try
            {
                var Test = await db.Tests.FindAsync(Id);
                return new Response<Test>
                {
                    statuscode = "200",
                    success = true,
                    Value = Test
                };
            }
            catch (Exception e)
            {

                return new Response<Test>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Test>> UpdateTest(Test Test, int Id)
        {
            try
            {
                var Test1 = await db.Tests.FindAsync(Id);
                Test1.Poster = Test.Poster;
                Test1.Name = Test.Name;
                Test1.Count = Test.Count;
                Test1.FullMark = Test.FullMark;
                await db.SaveChangesAsync();
                return new Response<Test>
                {
                    statuscode = "200",
                    success = true,
                    Value = Test
                };
            }
            catch (Exception e)
            {

                return new Response<Test>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }
    }
}
