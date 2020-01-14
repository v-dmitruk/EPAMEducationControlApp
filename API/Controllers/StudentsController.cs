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
    public class StudentsController : ApiController
    {
        private IBLLUnitOfWork _db = new BLLUnitOfWork(ConfigurationManager.ConnectionStrings["EduDb"].ToString());
        Mapper map = new Mapper(MapperProfile.Configured());

        // GET: api/Students
        [HttpGet]
        [Route("api/Students")]
        public IEnumerable<StudentModel> Get()
        {
            IEnumerable<StudentModel> result = map.Map<IEnumerable<StudentModel>>(_db.StudentService.GetAll());
            return result;
        }

        // GET: api/Students/5
        public StudentModel Get(int id)
        {
            StudentModel result = map.Map<StudentModel>(_db.StudentService.GetByID(id));
            return result;
        }

        // POST: api/Students
        [ResponseType(typeof(StudentModel))]
        public IHttpActionResult Post(StudentModel value)
        {
            _db.StudentService.AddStudent(map.Map<StudentDTO>(value));
            return CreatedAtRoute("DefaultApi", new { }, value);
        }

        // PUT: api/Students/5
        public IHttpActionResult Put(int id, StudentModel value)
        {
            if (id != value.StudentID)
            {
                return BadRequest();
            }
            try
            {
                StudentDTO edited = map.Map<StudentDTO>(value);
                _db.StudentService.EditStudent(edited);
            }
            catch
            {
                if (!StudentExists(id))
                    return NotFound();
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool StudentExists(int id)
        {
            return _db.StudentService.GetAll().Count(x => x.StudentID == id) > 0;
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(StudentModel))]
        public IHttpActionResult Delete(int id)
        {
            StudentDTO toDelete = _db.StudentService.GetByID(id);
            if (toDelete == null)
            {
                return NotFound();
            }

            _db.StudentService.DeleteStudent(toDelete.StudentID);
            return Ok(toDelete);
        }
    }
}
