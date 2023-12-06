using BLL.Helper;
using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.Question;
using DAL.Models.Sheard;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuchtionRepo _quchtionRepo;

        public QuestionService(IQuchtionRepo quchtionRepo)
        {
            _quchtionRepo = quchtionRepo;
        }
        public async Task<Response<Question>> CreateQuestionAsync(CreateQuestion Question)
        {
            try
            {
                List<QuestionChoice> questionChoices = new List<QuestionChoice>();
                Question Question1 = new Question();
                Question1.Quction = Question.Quction;
                Question1.Ansure = Question.Ansure;
                foreach (var item in Question.Choices)
                {
                    QuestionChoice qchoice = new QuestionChoice();
                    qchoice.choice = item;
                    qchoice.QuestionId = Question1.Id;
                    questionChoices.Add(qchoice);
                }
                Question1.Choices = questionChoices;
                Question1.CheapterId = Question.CheapterId;

                var result = await _quchtionRepo.CreateQuestion(Question1);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Question>> DeleteQuestionAsync(int QuestionId)
        {
            try
            {
                var result = await _quchtionRepo.DeleteQuestion(QuestionId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Question>> GetAllQuestionsInCheapter(int CheapterId)
        {
            try
            {
                var result = await _quchtionRepo.GetAllQuestion(CheapterId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Question>> GetQuestion(int QuestionId)
        {
            try
            {
                var result = await _quchtionRepo.GetQuestion(QuestionId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Question>> UpdateQuestion(CreateQuestion Question, int QuestionId)
        {
            try
            {
                List<QuestionChoice> questionChoices = new List<QuestionChoice>();
                Question Question1 = new Question();
                Question1.Quction = Question.Quction;
                Question1.Ansure = Question.Ansure;
                foreach (var item in Question.Choices)
                {
                    QuestionChoice qchoice = new QuestionChoice();
                    qchoice.choice = item;
                    qchoice.QuestionId = Question1.Id;
                    questionChoices.Add(qchoice);
                }
                Question1.Choices = questionChoices;
                Question1.CheapterId = Question.CheapterId;

                var result = await _quchtionRepo.UpdateQuestion(Question1, QuestionId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    message = e.Message
                };
            }
        }
    }
}
