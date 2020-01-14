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
    public class TeachersController : ApiController
    {
        private IBLLUnitOfWork _db = new BLLUnitOfWork(ConfigurationManager.ConnectionStrings["EduDb"].ToString());
        Mapper map = new Mapper(MapperProfile.Configured());

        // GET: api/Teachers
        [HttpGet]
        [Route("api/Teachers")]
        public IEnumerable<TeacherModel> Get()
        {
            IEnumerable<TeacherModel> result = map.Map<IEnumerable<TeacherModel>>(_db.TeacherService.GetAll());
            return result;
        }

        // GET: api/Teachers/5
        public TeacherModel Get(int id)
        {
            TeacherModel result = map.Map<TeacherModel>(_db.TeacherService.GetByID(id));
            return result;
        }

        // POST: api/Teachers
        [ResponseType(typeof(TeacherModel))]
        public IHttpActionResult Post(TeacherModel value)
        {
            _db.TeacherService.AddTeacher(map.Map<TeacherDTO>(value));
            return CreatedAtRoute("DefaultApi", new { }, value);
        }

        // PUT: api/Teachers/5
        public IHttpActionResult Put(int id, TeacherModel value)
        {
            if (id != value.TeacherID)
            {
                return BadRequest();
            }
            try
            {
                TeacherDTO edited = map.Map<TeacherDTO>(value);
                _db.TeacherService.EditTeacher(edited);
            }
            catch
            {
                if (!TeacherExists(id))
                    return NotFound();
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool TeacherExists(int id)
        {
            return _db.TeacherService.GetAll().Count(x => x.TeacherID == id) > 0;
        }

        // DELETE: api/Teachers/5
        [ResponseType(typeof(TeacherModel))]
        public IHttpActionResult Delete(int id)
        {
            TeacherDTO toDelete = _db.TeacherService.GetByID(id);
            if (toDelete == null)
            {
                return NotFound();
            }

            _db.TeacherService.DeleteTeacher(toDelete.TeacherID);
            return Ok(toDelete);
        }
    }
}
