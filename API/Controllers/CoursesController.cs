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
    public class CoursesController : ApiController
    {
        private IBLLUnitOfWork _db = new BLLUnitOfWork(ConfigurationManager.ConnectionStrings["EduDb"].ToString());
        Mapper map = new Mapper(MapperProfile.Configured());

        // GET: api/Courses
        [HttpGet]
        [Route("api/Courses")]
        public IEnumerable<CourseModel> Get()
        {
            IEnumerable<CourseModel> result = map.Map<IEnumerable<CourseModel>>(_db.CourseService.GetAll());
            return result;
        }

        [Route("api/GetActiveCourses")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<CourseModel> GetActiveCourses()
        {
            IEnumerable<CourseModel> result = map.Map<IEnumerable<CourseModel>>(_db.CourseService.GetAllActive());
            return result;
        }

        // GET: api/Courses/5
        public CourseModel Get(int id)
        {
            CourseModel result = map.Map<CourseModel>(_db.CourseService.GetByID(id));
            return result;
        }

        // POST: api/Courses
        [ResponseType(typeof(CourseModel))]
        public IHttpActionResult Post(CourseModel value)
        {
            _db.CourseService.CreateCourse(map.Map<CourseDTO>(value));
            return CreatedAtRoute("DefaultApi", new {  }, value);
        }
        
        // PUT: api/Courses/5
        public IHttpActionResult Put(int id, CourseModel value)
        {
            if (id != value.CourseID)
            {
                return BadRequest();
            }
            try
            {
                CourseDTO edited = map.Map<CourseDTO>(value);
                _db.CourseService.EditCourse(edited);
            }
            catch 
            {
                if (!CourseExists(id))
                    return NotFound();
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool CourseExists(int id)
        {
            return _db.CourseService.GetAll().Count(x => x.CourseID == id) > 0;
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(CourseModel))]
        public IHttpActionResult Delete(int id)
        {
            CourseDTO course = _db.CourseService.GetByID(id);
            if (course == null)
            {
                return NotFound();
            }

            _db.CourseService.DeleteCourse(course);
            return Ok(course);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        CourseService.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
