using DAL.Entities;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IVideoRepo
    {
        Task<Response<Video>> CreateVideo(Video Video);
        Task<Response<Video>> DeleteVideo(int Id);
        Task<Response<Video>> GetVideo(int Id);
        Task<Response<Video>> GetAllVideo(int CheapterId);
    }
}
