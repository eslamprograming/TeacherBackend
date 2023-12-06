using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Migrations;
using DAL.Models.Sheard;
using DAL.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class DegreeService:IDegreeService
    {
        private readonly IDegreeRepo _degreeRepo;

        public DegreeService(IDegreeRepo degreeRepo)
        {
            _degreeRepo = degreeRepo;
        }
        public async Task<Response<Degree>> CreateDegreeAsync(CreateDegree Degree1)
        {
            try
            {
                Degree degree = new Degree();
                degree.degree = Degree1.degree;
                degree.SubjectId=Degree1.SubjectId;
                degree.StudentId=Degree1.StudentId;
                degree.TestId=Degree1.TestId;
                var result = await _degreeRepo.CreateDegree(degree);
                return result;
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

        public async Task<Response<Degree>> DeleteDegreeAsync(int Id)
        {
            try
            {
                var result = await _degreeRepo.DeleteDegree(Id);
                return result;
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

        public async Task<Response<Degree>> GetAllDegreeAsync(int TestId)
        {
            try
            {
                var result =await _degreeRepo.GetAllDegree(TestId);
                return result;
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

        public async Task<Response<Degree>> GetDegreeAsync(int StudentId, int TestId)
        {
            try
            {
                var result = await _degreeRepo.GetDegree(StudentId, TestId);
                return result;
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

        public async Task<Response<Degree>> GetStudentDegreesAsync(int SAtudentId)
        {
            try
            {
                var result = await _degreeRepo.GetStudentDegrees(SAtudentId);
                return result;
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
