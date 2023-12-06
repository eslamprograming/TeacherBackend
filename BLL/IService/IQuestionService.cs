using DAL.Entities;
using DAL.Models.Question;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IQuestionService
    {
        Task<Response<Question>> CreateQuestionAsync(CreateQuestion Question);
        Task<Response<Question>> DeleteQuestionAsync(int QuestionId);
        Task<Response<Question>> GetAllQuestionsInCheapter(int CheapterId);
        Task<Response<Question>> GetQuestion(int QuestionId);
        Task<Response<Question>> UpdateQuestion(CreateQuestion Question, int QuestionId);
    }
}
