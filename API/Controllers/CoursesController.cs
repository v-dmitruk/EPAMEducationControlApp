using API.Infrastructure;
using API.Models;
using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CoursesController : ApiController
    {
        private IBLLUnitOfWork _db = new BLLUnitOfWork(ConfigurationManager.ConnectionStrings["EduDb"].ToString());
        Mapper map = new Mapper(MapperProfile.Configured());

        // GET: api/Courses
        public IEnumerable<CourseModel> Get()
        {
            IEnumerable<CourseModel> result = map.Map<IEnumerable<CourseModel>>(_db.CourseService.GetAll());
            return result;
        }

        // GET: api/Courses/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Courses
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Courses/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Courses/5
        public void Delete(int id)
        {
        }
    }
}
