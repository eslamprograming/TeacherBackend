using DAL.Entities;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IQuchtionRepo
    {
        Task<Response<Question>> CreateQuestion(Question Question);
        Task<Response<Question>> UpdateQuestion(Question Question, int Id);
        Task<Response<Question>> DeleteQuestion(int Id);
        Task<Response<Question>> GetQuestion(int Id);
        Task<Response<Question>> GetAllQuestion(int CheapterId);
    }
}
