using DAL.Data;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.Sheard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class QuestionTestRepo:IQuestionTestRepo
    {
        private readonly ApplicationDbContext db;

        public QuestionTestRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Response<QuctionTest>> CreateQuctionTest(QuctionTest QuctionTest1)
        {
            try
            {
                await db.QuaternionTest.AddAsync(QuctionTest1);
                await db.SaveChangesAsync();
                return new Response<QuctionTest>
                {
                    success = true,
                    statuscode = "201",
                    Value = QuctionTest1
                };
            }
            catch (Exception e)
            {
                return new Response<QuctionTest>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<QuctionTest>> DeleteQuctionTest(int Id)
        {
            try
            {
                var Choice = await db.TestQuestionsChoice.Where(n => n.QuestionTestId == Id).ToListAsync();
                db.TestQuestionsChoice.RemoveRange(Choice);
                var QuctionTest = await db.QuaternionTest.Where(n => n.Id == Id).SingleOrDefaultAsync();
                db.QuaternionTest.Remove(QuctionTest);
                await db.SaveChangesAsync();
                return new Response<QuctionTest>
                {
                    statuscode = "200",
                    success = true,
                    Value = QuctionTest
                };
            }
            catch (Exception e)
            {
                return new Response<QuctionTest>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<QuctionTest>> GetAllQuctionTest(int TestId)
        {
            try
            {
                var QuctionTests = await db.QuaternionTest.Where(n => n.TestId == TestId).Include(n=>n.Choices).ToListAsync();

                return new Response<QuctionTest>
                {
                    statuscode = "200",
                    success = true,
                    values = QuctionTests
                };
            }
            catch (Exception e)
            {
                return new Response<QuctionTest>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<QuctionTest>> GetQuctionTest(int Id)
        {
            try
            {
                var QuctionTest = await db.QuaternionTest.Where(n=>n.Id==Id)
                    .Include(m=>m.Choices).SingleOrDefaultAsync();
                return new Response<QuctionTest>
                {
                    statuscode = "200",
                    success = true,
                    Value = QuctionTest
                };
            }
            catch (Exception e)
            {

                return new Response<QuctionTest>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<QuctionTest>> UpdateQuctionTest(QuctionTest QuctionTest, int Id)
        {
            try
            {
                var Choice = await db.TestQuestionsChoice.Where(n => n.QuestionTestId == Id).ToListAsync();
                db.TestQuestionsChoice.RemoveRange(Choice);
                await db.SaveChangesAsync();
                var QuctionTest1 = await db.QuaternionTest.Where(n => n.Id == Id)
                    .Include(m => m.Choices).SingleOrDefaultAsync();
                QuctionTest1.Quction = QuctionTest.Quction;
                QuctionTest1.Ansure = QuctionTest.Ansure;
                QuctionTest1.TestId = QuctionTest.TestId;
                QuctionTest1.Choices = QuctionTest.Choices;

                await db.SaveChangesAsync();
                return new Response<QuctionTest>
                {
                    statuscode = "200",
                    success = true,
                    Value = QuctionTest1
                };
            }
            catch (Exception e)
            {

                return new Response<QuctionTest>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }
    }
}
