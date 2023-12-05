using DAL.Entities;
using DAL.IRepo;
using DAL.Models.Cheapter;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface ICheapterService
    {
        Task<Response<Cheapter>> CreateCheapterAsync(CreateCheapter cheapter);
        Task<Response<Cheapter>> DeleteCheapterAsync(int CheapterId);
        Task<Response<Cheapter>> GetAllCheaptersInSubject(int SubjectId);
        Task<Response<Cheapter>> GetCheapter(int CheapterId);
        Task<Response<Cheapter>> UpdateCheapter(CreateCheapter cheapter,int  CheapterId);
    }
}
