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
    public class LectionsController : ApiController
    {
        private IBLLUnitOfWork _db = new BLLUnitOfWork(ConfigurationManager.ConnectionStrings["EduDb"].ToString());
        Mapper map = new Mapper(MapperProfile.Configured());

        // GET: api/Lections
        public IEnumerable<LectionModel> Get()
        {
            IEnumerable<LectionModel> result = map.Map<IEnumerable<LectionModel>>(_db.LectionService.GetAll());
            return result;
        }

        // GET: api/Lections/5
        public LectionModel Get(int id)
        {
            LectionModel result = map.Map<LectionModel>(_db.LectionService.GetByID(id));
            return result;
        }

        // POST: api/Lections
        [ResponseType(typeof(LectionModel))]
        public IHttpActionResult Post(LectionModel value)
        {
            _db.LectionService.CreateLection(map.Map<LectionDTO>(value));
            return CreatedAtRoute("DefaultApi", new { }, value);
        }

        // PUT: api/Lections/5
        public IHttpActionResult Put(int id, LectionModel value)
        {
            if (id != value.LectionID)
            {
                return BadRequest();
            }
            try
            {
                LectionDTO edited = map.Map<LectionDTO>(value);
                _db.LectionService.EditLection(edited);
            }
            catch
            {
                if (!LectionExists(id))
                    return NotFound();
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool LectionExists(int id)
        {
            return _db.LectionService.GetAll().Count(x => x.LectionID == id) > 0;
        }

        // DELETE: api/Lections/5
        [ResponseType(typeof(LectionModel))]
        public IHttpActionResult Delete(int id)
        {
            LectionDTO toDelete = _db.LectionService.GetByID(id);
            if (toDelete == null)
            {
                return NotFound();
            }

            _db.LectionService.DeleteLection(toDelete);
            return Ok(toDelete);
        }
    }
}
