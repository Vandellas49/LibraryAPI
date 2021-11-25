using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBaseCustom
    {
        readonly IGenericRepository<User> repository;
        public UserController(IGenericRepository<User> _repository)
        {
            repository = _repository;
        }
        /// <summary>
        /// Yetkili kişi Id ye göre getiren method
        /// </summary>
        [Route("~/api/User/{Id}")]
        [HttpGet]
        public IActionResult GetUserById(int Id)
        {
            var r = repository.GetByIdAsync(new UsersWithFiltersForCountSpecification(Id)).Result;
            if (r == null)
                return NotFound();
            r.Password = null;
            return Ok(r);
        }
        /// <summary>
        /// Yetkili kişileri sınırlayarak getiren method
        /// </summary>
        [HttpGet]
        public IActionResult GetUserPagination([FromQuery] UsersSearchPaginationParams model)
        {
            var r = repository.ListBySpecAsync(new UserSpecification(model)).Result;
            if (r == null || r.Count == 0)
                return NotFound();
            return Ok(r.Select(c => { c.Password = null; return c; }).ToList());
        }
        /// <summary>
        /// Yetkili kişiyi ekleyen method
        /// </summary>
        [HttpPost]
        public IActionResult Post(UserAddDto model)
        {
            return Ok(repository.Add(model).Result);
        }
        /// <summary>
        /// Yetkili kişiyi silen method
        /// </summary>
        [HttpDelete]
        public IActionResult Delete(UserDeleteDto model)
        {
            return Ok(repository.Delete(model.Id.Value).Result);
        }
        /// <summary>
        /// Yetkili kişiyi güncelleyen method
        /// </summary>
        [HttpPut]
        public IActionResult Put(UserUpdateDto model)
        {
            return Ok(repository.Update(model).Result);
        }
    }
}
