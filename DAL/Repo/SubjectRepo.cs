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
    public class SubjectRepo : ISubjectRepo
    {
        private readonly ApplicationDbContext db;

        public SubjectRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Subject>> CreateSubject(Subject subject1)
        {
            try
            {
                await db.Subjects.AddAsync(subject1);
                await db.SaveChangesAsync();
                return new Response<Subject>
                {
                    success = true,
                    statuscode = "201",
                    Value = subject1
                };
            }
            catch (Exception e)
            {
                return new Response<Subject>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Subject>> DeleteSubject(int Id)
        {
            try
            {
                var subject = await db.Subjects.Where(n => n.Id == Id).SingleOrDefaultAsync();
                db.Subjects.Remove(subject);
                await db.SaveChangesAsync();
                return new Response<Subject>
                {
                    statuscode = "200",
                    success = true,
                    Value = subject
                };
            }
            catch (Exception e)
            {
                return new Response<Subject>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Subject>> GetAllSubject()
        {
            try
            {
                var subjects = await db.Subjects.ToListAsync();

                return new Response<Subject>
                {
                    statuscode = "200",
                    success = true,
                    values=subjects
                };
            }
            catch (Exception e)
            {
                return new Response<Subject>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Subject>> GetSubject(int Id)
        {
            try
            {
                var Subject = await db.Subjects.FindAsync(Id);
                return new Response<Subject>
                {
                    statuscode = "200",
                    success = true,
                    Value=Subject
                };
            }
            catch (Exception e)
            {

                return new Response<Subject>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }

        public async Task<Response<Subject>> UpdateSubject(Subject subject, int Id)
        {
            try
            {
                var Subject = await db.Subjects.FindAsync(Id);
                Subject.Poster = subject.Poster;
                Subject.Book = subject.Book;
                Subject.Name = subject.Name;
                await db.SaveChangesAsync();
                return new Response<Subject>
                {
                    statuscode = "200",
                    success = true,
                    Value = Subject
                };
            }
            catch (Exception e)
            {

                return new Response<Subject>
                {
                    message = e.Message,
                    statuscode = "500",
                    success = false
                };
            }
        }
    }
}
