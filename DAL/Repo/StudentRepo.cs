using DAL.Data;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDbContext db;

        public StudentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Student>> CreateStudent(string ApplicationId, int subjectId)
        {
			try
			{
                Student student = new Student();
                student.SubjectID = subjectId;
                student.ApplicationUserId=ApplicationId;
                await db.Students.AddAsync(student);
                await db.SaveChangesAsync();
                return new Response<Student>
                {
                    success = true,
                    statuscode = "200",
                    Value = student
                };
			}
			catch (Exception e)
			{
                return new Response<Student>
                {
                    message = e.Message
                };
			}
        }
    }
}
