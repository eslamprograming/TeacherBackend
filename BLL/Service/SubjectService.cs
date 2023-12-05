using BLL.Helper;
using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.Sheard;
using DAL.Models.SubjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class SubjectService : ISubjectServiec
    {
        private readonly ISubjectRepo _subjectRepo;

        public SubjectService(ISubjectRepo subjectRepo)
        {
            _subjectRepo = subjectRepo;
        }

        public async Task<Response<Subject>> CreateSubjectAsync(CreateSubject subject)
        {
            try
            {
                Subject subject1 = new Subject();
                subject1.Name=subject.Name;
                subject1.Book= BLL.Helper.Files.Save(subject.Book);
                subject1.Poster = BLL.Helper.Files.Save(subject.Poster);
                subject1.TeacherID=1;

                var result = await _subjectRepo.CreateSubject(subject1);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Subject>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Subject>> DeleteSubjectAaync(int Id)
        {
            try
            {
                var result = await _subjectRepo.DeleteSubject(Id);
                Files.DeleteFileByLink(result.Value.Book);
                Files.DeleteFileByLink(result.Value.Poster);
                result.Value = null;
                return result;
            }
            catch (Exception e)
            {
                return new Response<Subject>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Subject>> GetAllSubjectAsync()
        {
            try
            {
                var result= await _subjectRepo.GetAllSubject();
                return result;
            }
            catch (Exception e)
            {
                return new Response<Subject>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Subject>> GetSubjectAsync(int Id)
        {
            try
            {
                var result=await _subjectRepo.GetSubject(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Subject>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Subject>> UpdateSubjectAsync(UpdateSubject subject, int Id)
        {
            try
            {
                Subject subject1 = new Subject();
                subject1.Name = subject.Name;
                subject1.Book = BLL.Helper.Files.Save(subject.Book);
                subject1.Poster = BLL.Helper.Files.Save(subject.Poster);

                var result = await _subjectRepo.UpdateSubject(subject1,Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Subject>
                {
                    message = e.Message
                };
            }
        }
    }
}
