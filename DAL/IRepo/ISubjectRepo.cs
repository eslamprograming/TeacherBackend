using DAL.Entities;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface ISubjectRepo
    {
        Task<Response<Subject>> CreateSubject(Subject subject);
        Task<Response<Subject>> UpdateSubject(Subject subject,int Id);
        Task<Response<Subject>> DeleteSubject(int Id);
        Task<Response<Subject>> GetSubject(int Id);
        Task<Response<Subject>> GetAllSubject();
    }
}
