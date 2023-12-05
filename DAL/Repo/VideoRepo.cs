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
    public class VideoRepo:IVideoRepo
    {
        private readonly ApplicationDbContext db;

        public VideoRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Response<Video>> CreateVideo(Video Video1)
        {
            try
            {
                await db.Videos.AddAsync(Video1);
                await db.SaveChangesAsync();
                return new Response<Video>
                {
                    success = true,
                    statuscode = "201",
                    Value = Video1
                };
            }
            catch (Exception e)
            {
                return new Response<Video>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Video>> DeleteVideo(int Id)
        {
            try
            {
                var Video = await db.Videos.Where(n => n.Id == Id).SingleOrDefaultAsync();
                db.Videos.Remove(Video);
                await db.SaveChangesAsync();
                return new Response<Video>
                {
                    statuscode = "200",
                    success = true,
                    Value = Video
                };
            }
            catch (Exception e)
            {
                return new Response<Video>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Video>> GetAllVideo(int CheapterId)
        {
            try
            {
                var Videos = await db.Videos.Where(n=>n.CheapterId==CheapterId).ToListAsync();

                return new Response<Video>
                {
                    statuscode = "200",
                    success = true,
                    values = Videos
                };
            }
            catch (Exception e)
            {
                return new Response<Video>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Video>> GetVideo(int Id)
        {
            try
            {
                var Video = await db.Videos.FindAsync(Id);
                return new Response<Video>
                {
                    statuscode = "200",
                    success = true,
                    Value = Video
                };
            }
            catch (Exception e)
            {

                return new Response<Video>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

       
    }
}
