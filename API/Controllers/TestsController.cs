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
    public class TestsController : ApiController
    {
        private IBLLUnitOfWork _db = new BLLUnitOfWork(ConfigurationManager.ConnectionStrings["EduDb"].ToString());
        Mapper map = new Mapper(MapperProfile.Configured());

        // GET: api/Tests
        public IEnumerable<TestModel> Get()
        {
            IEnumerable<TestModel> result = map.Map<IEnumerable<TestModel>>(_db.TestService.GetAll());
            return result;
        }

        // GET: api/Tests/5
        public TestModel Get(int id)
        {
            TestModel result = map.Map<TestModel>(_db.TestService.GetByID(id));
            return result;
        }

        // POST: api/Tests
        [ResponseType(typeof(TestModel))]
        public IHttpActionResult Post(TestModel value)
        {
            _db.TestService.CreateTest(map.Map<TestDTO>(value));
            return CreatedAtRoute("DefaultApi", new { }, value);
        }

        // PUT: api/Tests/5
        public IHttpActionResult Put(int id, TestModel value)
        {
            if (id != value.TestID)
            {
                return BadRequest();
            }
            try
            {
                TestDTO edited = map.Map<TestDTO>(value);
                _db.TestService.EditTest(edited);
            }
            catch
            {
                if (!TestExists(id))
                    return NotFound();
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool TestExists(int id)
        {
            return _db.TestService.GetAll().Count(x => x.TestID == id) > 0;
        }

        // DELETE: api/Tests/5
        [ResponseType(typeof(TestModel))]
        public IHttpActionResult Delete(int id)
        {
            TestDTO toDelete = _db.TestService.GetByID(id);
            if (toDelete == null)
            {
                return NotFound();
            }

            _db.TestService.DeleteTest(toDelete);
            return Ok(toDelete);
        }
    }
}
