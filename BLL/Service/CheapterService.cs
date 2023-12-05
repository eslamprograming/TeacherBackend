using BLL.Helper;
using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.Cheapter;
using DAL.Models.Sheard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class CheapterService:ICheapterService
    {
        private readonly ICheapterRepo _cheapterRepo;

        public CheapterService(ICheapterRepo cheapterRepo)
        {
            _cheapterRepo = cheapterRepo;
        }

        public async Task<Response<Cheapter>> CreateCheapterAsync(CreateCheapter cheapter)
        {
            try
            {
                Cheapter cheapter1 = new Cheapter();
                cheapter1.Name = cheapter.Name;
                cheapter1.Poster = Files.Save(cheapter.Poster);
                cheapter1.Note = Files.Save(cheapter.Note);
                cheapter1.SubjectId = cheapter.SubjectId;

                var result = await _cheapterRepo.CreateCheapter(cheapter1);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Cheapter>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Cheapter>> DeleteCheapterAsync(int CheapterId)
        {
            try
            {
                var result = await _cheapterRepo.DeleteCheapter(CheapterId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Cheapter>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Cheapter>> GetAllCheaptersInSubject(int SubjectId)
        {
            try
            {
                var result = await _cheapterRepo.GetAllCheapter(SubjectId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Cheapter>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Cheapter>> GetCheapter(int CheapterId)
        {
            try
            {
                var result = await _cheapterRepo.GetCheapter(CheapterId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Cheapter>
                {
                    message = e.Message
                };
            }
        }

        public async Task<Response<Cheapter>> UpdateCheapter(CreateCheapter cheapter, int CheapterId)
        {
            try
            {
                Cheapter cheapter1 = new Cheapter();
                cheapter1.Name = cheapter.Name;
                cheapter1.Poster = Files.Save(cheapter.Poster);
                cheapter1.Note = Files.Save(cheapter.Note);
                cheapter1.SubjectId = cheapter.SubjectId;

                var result = await _cheapterRepo.UpdateCheapter(cheapter1,CheapterId);
                return result;

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
