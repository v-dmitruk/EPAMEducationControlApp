using API.Infrastructure;
using API.Models;
using AutoMapper;
using BLL.DTOModels;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers
{
    public class LectionResultsController : ApiController
    {
        private IBLLUnitOfWork _db = new BLLUnitOfWork(ConfigurationManager.ConnectionStrings["EduDb"].ToString());
        Mapper map = new Mapper(MapperProfile.Configured());

        // GET: api/LectionResults
        public IEnumerable<LectionResultModel> Get(int courseId, int studentId)
        {
            IEnumerable<LectionResultModel> result = map.Map<IEnumerable<LectionResultModel>>(_db.PerformanceService.GetLectionResultsForCourse(courseId, studentId));
            return result;
        }

        // GET: api/LectionResults/5
        public LectionResultModel Get(int id)
        {
            LectionResultModel result = map.Map<LectionResultModel>(_db.PerformanceService.GetLectionResult(id));
            return result;
        }

        // POST: api/LectionResults
        [ResponseType(typeof(LectionResultModel))]
        public IHttpActionResult Post(LectionResultModel value)
        {
            _db.PerformanceService.AddLectionResult(map.Map<LectionResultDTO>(value));
            return CreatedAtRoute("DefaultApi", new { }, value);
        }

        // PUT: api/LectionResults/5
        public IHttpActionResult Put(int id, LectionResultModel value)
        {
            if (id != value.LectionResultID)
            {
                return BadRequest();
            }
            try
            {
                LectionResultDTO edited = map.Map<LectionResultDTO>(value);
                _db.LectionService.EditArchievedLection(edited);
            }
            catch
            {
                if (!LectionResultExists(id))
                    return NotFound();
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool LectionResultExists(int id)
        {
            return _db.LectionService.GetAllArchieved().Count(x => x.LectionResultID == id) > 0;
        }

        // DELETE: api/LectionResults/5
        [ResponseType(typeof(LectionResultModel))]
        public IHttpActionResult Delete(int id)
        {
            LectionResultDTO toDelete = _db.PerformanceService.GetLectionResult(id);
            if (toDelete == null)
            {
                return NotFound();
            }

            _db.PerformanceService.DeleteLectionResult(id);
            return Ok(toDelete);
        }
    }
}
