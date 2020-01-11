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
    public class TestResultsController : ApiController
    {
        private IBLLUnitOfWork _db = new BLLUnitOfWork(ConfigurationManager.ConnectionStrings["EduDb"].ToString());
        Mapper map = new Mapper(MapperProfile.Configured());

        // GET: api/TestResults
        public IEnumerable<TestResultModel> Get(int courseId, int studentId)
        {
            IEnumerable<TestResultModel> result = map.Map<IEnumerable<TestResultModel>>(_db.PerformanceService.GetTestResultsForCourse(courseId, studentId));
            return result;
        }

        // GET: api/TestResults/5
        public TestResultModel Get(int id)
        {
            TestResultModel result = map.Map<TestResultModel>(_db.PerformanceService.GetTestResult(id));
            return result;
        }

        // POST: api/TestResults
        [ResponseType(typeof(TestResultModel))]
        public IHttpActionResult Post(TestResultModel value)
        {
            _db.PerformanceService.AddTestResult(map.Map<TestResultDTO>(value));
            return CreatedAtRoute("DefaultApi", new { }, value);
        }

        // PUT: api/TestResults/5
        public IHttpActionResult Put(int id, TestResultModel value)
        {
            if (id != value.TestResultID)
            {
                return BadRequest();
            }
            try
            {
                TestResultDTO edited = map.Map<TestResultDTO>(value);
                _db.TestService.ChangeArchievedTest(edited);
            }
            catch
            {
                if (!TestResultExists(id))
                    return NotFound();
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool TestResultExists(int id)
        {
            return _db.TestService.GetAllArchieved().Count(x => x.TestResultID == id) > 0;
        }

        // DELETE: api/TestResults/5
        [ResponseType(typeof(TestResultModel))]
        public IHttpActionResult Delete(int id)
        {
            TestResultDTO toDelete = _db.PerformanceService.GetTestResult(id);
            if (toDelete == null)
            {
                return NotFound();
            }

            _db.PerformanceService.DeleteTestResult(id);
            return Ok(toDelete);
        }
    }
}
