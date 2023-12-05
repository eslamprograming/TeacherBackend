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
    public class DegreeRepo:IDegreeRepo
    {
        private readonly ApplicationDbContext db;

        public DegreeRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Response<Degree>> CreateDegree(Degree Degree1)
        {
            try
            {
                await db.Degrees.AddAsync(Degree1);
                await db.SaveChangesAsync();
                return new Response<Degree>
                {
                    success = true,
                    statuscode = "201",
                    Value = Degree1
                };
            }
            catch (Exception e)
            {
                return new Response<Degree>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Degree>> DeleteDegree(int Id)
        {
            try
            {
                var Degree = await db.Degrees.Where(n => n.Id == Id).SingleOrDefaultAsync();
                db.Degrees.Remove(Degree);
                await db.SaveChangesAsync();
                return new Response<Degree>
                {
                    statuscode = "200",
                    success = true,
                    Value = Degree
                };
            }
            catch (Exception e)
            {
                return new Response<Degree>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Degree>> GetAllDegree(int TestId)
        {
            try
            {
                var Degrees = await db.Degrees.Where(n=>n.TestId==TestId).ToListAsync();

                return new Response<Degree>
                {
                    statuscode = "200",
                    success = true,
                    values = Degrees
                };
            }
            catch (Exception e)
            {
                return new Response<Degree>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Degree>> GetDegree(int StudentId, int TestId)
        {
            try
            {
                var Degree = await db.Degrees.Where(n=>n.TestId==TestId && n.StudentId==StudentId)
                    .SingleOrDefaultAsync();
                return new Response<Degree>
                {
                    statuscode = "200",
                    success = true,
                    Value = Degree
                };
            }
            catch (Exception e)
            {

                return new Response<Degree>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Degree>> GetStudentDegrees(int SAtudentId)
        {
            try
            {
                var Degree = await db.Degrees.Where(n=>n.StudentId==SAtudentId).ToListAsync();
                return new Response<Degree>
                {
                    statuscode = "200",
                    success = true,
                    values = Degree
                };
            }
            catch (Exception e)
            {

                return new Response<Degree>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }
    }
}
