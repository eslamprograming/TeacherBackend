using DAL.Entities;
using DAL.Models.Video;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IVideoService
    {
        Task<Response<Video>> CreateVideoAsync(CreateVideo Video);
        Task<Response<Video>> DeleteVideoAsync(int VideoId);
        Task<Response<Video>> GetAllVideosInCheapter(int CheapterId);
        Task<Response<Video>> GetVideo(int VideoId);
    }
}
