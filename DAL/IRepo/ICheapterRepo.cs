using DAL.Entities;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface ICheapterRepo
    {
        Task<Response<Cheapter>> CreateCheapter(Cheapter Cheapter);
        Task<Response<Cheapter>> UpdateCheapter(Cheapter Cheapter, int Id);
        Task<Response<Cheapter>> DeleteCheapter(int Id);
        Task<Response<Cheapter>> GetCheapter(int Id);
        Task<Response<Cheapter>> GetAllCheapter(int SubjectId);
    }
}
