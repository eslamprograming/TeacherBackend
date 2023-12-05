using DAL.Entities;
using DAL.Models.Sheard;
using DAL.Models.SubjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface ISubjectServiec
    {
        Task<Response<Subject>> CreateSubjectAsync(CreateSubject subject);
        Task<Response<Subject>> UpdateSubjectAsync(UpdateSubject subject, int Id);
        Task<Response<Subject>> DeleteSubjectAaync(int Id);
        Task<Response<Subject>> GetSubjectAsync(int Id);
        Task<Response<Subject>> GetAllSubjectAsync();
    }
}
