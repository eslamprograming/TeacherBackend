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
    public class CheapterRepo : ICheapterRepo
    {
        private readonly ApplicationDbContext db;

        public CheapterRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Cheapter>> CreateCheapter(Cheapter Cheapter)
        {
            try
            {
                await db.Cheapters.AddAsync(Cheapter);
                await db.SaveChangesAsync();    
                return new Response<Cheapter>
                {
                    success = true,
                    statuscode = "200",
                    Value=Cheapter
                };
            }
            catch (Exception e)
            {
                return new Response<Cheapter>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Cheapter>> DeleteCheapter(int Id)
        {
            try
            {
                var Cheapter=await db.Cheapters.FindAsync(Id);
                db.Cheapters.Remove(Cheapter);
                await db.SaveChangesAsync();
                return new Response<Cheapter>
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception e)
            {
                return new Response<Cheapter>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Cheapter>> GetAllCheapter(int SubjectId)
        {
            try
            {
                var Cheapters = await db.Cheapters.Where(n=>n.SubjectId==SubjectId).ToListAsync();
                return new Response<Cheapter>
                {
                    success = true,
                    statuscode = "200",
                    values=Cheapters
                };
            }
            catch (Exception e)
            {
                return new Response<Cheapter>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Cheapter>> GetCheapter(int Id)
        {
            try
            {
                var Cheapter = await db.Cheapters.FindAsync(Id);
                return new Response<Cheapter>
                {
                    success = true,
                    statuscode = "200",
                    Value=Cheapter
                };
            }
            catch (Exception e)
            {
                return new Response<Cheapter>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Cheapter>> UpdateCheapter(Cheapter Cheapter, int Id)
        {
            try
            {
                var Cheapter1 = await db.Cheapters.FindAsync(Id);
                Cheapter1.Name = Cheapter.Name;
                Cheapter1.Note= Cheapter.Note;
                Cheapter1.SubjectId = Cheapter.SubjectId;
                await db.SaveChangesAsync();
                return new Response<Cheapter>
                {
                    success = true,
                    statuscode = "200",
                    Value = Cheapter
                };
            }
            catch (Exception e)
            {
                return new Response<Cheapter>
                {
                    message = e.Message
                };
            }
        }
    }
}
