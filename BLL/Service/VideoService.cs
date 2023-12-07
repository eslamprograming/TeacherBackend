using DAL.Entities;
using DAL.IRepo;
using DAL.Models.Video;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.IService;
using BLL.Helper;

namespace BLL.Service
{
    public class VideoService:IVideoService
    {
        private readonly IVideoRepo _videoRepo;

        public VideoService(IVideoRepo videoRepo)
        {
            _videoRepo = videoRepo;
        }
        public async Task<Response<Video>> CreateVideoAsync(CreateVideo Video)
        {
            try
            {
                Video Video1 = new Video();
                Video1.Name = Video.Name;
                Video1.video = Files.Save(Video.video);
                Video1.CheapterId = Video.CheapterId;
                var result = await _videoRepo.CreateVideo(Video1);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Video>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Video>> DeleteVideoAsync(int VideoId)
        {
            try
            {
                var result = await _videoRepo.DeleteVideo(VideoId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Video>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Video>> GetAllVideosInCheapter(int CheapterId)
        {
            try
            {
                var result = await _videoRepo.GetAllVideo(CheapterId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Video>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Video>> GetVideo(int VideoId)
        {
            try
            {
                var result = await _videoRepo.GetVideo(VideoId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Video>
                {
                    message = e.Message
                };
            }
        }
    }
}
