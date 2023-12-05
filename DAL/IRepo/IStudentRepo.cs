using DAL.Entities;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IStudentRepo
    {
        Task<Response<Student>> CreateStudent(string ApplicationId, int subjectId); 
    }
}
