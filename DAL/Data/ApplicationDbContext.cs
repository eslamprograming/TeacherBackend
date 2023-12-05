using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cheapter> Cheapters { get; set; }
        public DbSet<Degree> Degrees { get; set; }  
        public DbSet<QuctionTest> QuaternionTest { get; set; }
        public DbSet<Question> Question { get; set; }   
        public DbSet<QuestionChoice> QuestionChoices { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestionChoice> TestQuestionsChoice { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}
