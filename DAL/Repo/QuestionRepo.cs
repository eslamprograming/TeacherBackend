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
    public class QuestionRepo:IQuchtionRepo
    {
        private readonly ApplicationDbContext db;

        public QuestionRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Response<Question>> CreateQuestion(Question Question1)
        {
            try
            {
                await db.Question.AddAsync(Question1);
                await db.SaveChangesAsync();
                return new Response<Question>
                {
                    success = true,
                    statuscode = "201",
                    Value = Question1
                };
            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Question>> DeleteQuestion(int Id)
        {
            try
            {
                var choice = await db.QuestionChoices.Where(n => n.QuestionId == Id).ToListAsync();
                var Question = await db.Question.Where(n => n.Id == Id).SingleOrDefaultAsync();
                db.QuestionChoices.RemoveRange(choice);
                db.Question.Remove(Question);
                await db.SaveChangesAsync();
                return new Response<Question>
                {
                    statuscode = "200",
                    success = true,
                    Value = Question
                };
            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Question>> GetAllQuestion(int CheapterId)
        {
            try
            {
                var Questions = await db.Question.Where(n=>n.CheapterId==CheapterId).Include(c=>c.Choices).ToListAsync();

                return new Response<Question>
                {
                    statuscode = "200",
                    success = true,
                    values = Questions
                };
            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Question>> GetQuestion(int Id)
        {
            try
            {
                var Question = await db.Question.Where(n=>n.Id==Id).Include(c=>c.Choices).SingleOrDefaultAsync();
                return new Response<Question>
                {
                    statuscode = "200",
                    success = true,
                    Value = Question
                };
            }
            catch (Exception e)
            {

                return new Response<Question>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Question>> UpdateQuestion(Question Question, int Id)
        {
            try
            {
                var Question1 = await db.Question.FindAsync(Id);
                Question1.Quction = Question.Quction;
                Question1.Ansure=Question.Ansure;
                Question1.CheapterId = Question.CheapterId;
                var choice = await db.QuestionChoices.Where(n => n.QuestionId == Id).ToListAsync();
                db.QuestionChoices.RemoveRange(choice);
                Question1.Choices = Question.Choices;
                
                await db.SaveChangesAsync();
                return new Response<Question>
                {
                    statuscode = "200",
                    success = true,
                    Value = Question1
                };
            }
            catch (Exception e)
            {

                return new Response<Question>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }
    }
}
