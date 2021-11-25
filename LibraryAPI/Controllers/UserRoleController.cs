
using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    public class UserRoleController : ControllerBaseCustom
    {
        readonly IGenericRepository<UserRole> repository;
        public UserRoleController(IGenericRepository<UserRole> _repository)
        {
            repository = _repository;
        }
        /// <summary>
        /// Yetkili kişi ve yetkisini Id ye göre getiren method
        /// </summary>
        [Route("~/api/UserRole/{Id}")]
        [HttpGet]
        public IActionResult GetUserRoleById(int Id)
        {
            return Ok(repository.GetByIdAsync(new UserRoleWithFiltersForCountSpecification(Id)).Result);
        }
        /// <summary>
        /// Yetkili kişi ve yetkisilerini sınırlı sayıda getiren method
        /// </summary>
        [HttpGet]
        public IActionResult GetUserRolePagination([FromQuery] UserRoleSearchPaginationParams model)
        {
            return Ok(repository.ListBySpecAsync(new UserRoleSpecification(model)).Result);
        }
        /// <summary>
        /// Yetkili kişiye yetkisinin eklendiği method
        /// </summary>
        [HttpPost]
        public IActionResult Post(UserRoleAddDto model)
        {
            return Ok(repository.Add(model).Result);
        }
        /// <summary>
        /// Yetkili kişinin yetkisinin silindiği method
        /// </summary>
        [HttpDelete]
        public IActionResult Delete(UserRoleDeleteDto model)
        {
            return Ok(repository.Delete(model.Id.Value).Result);
        }
        /// <summary>
        /// Yetkili kişinin yetkisiyle güncellendiği method
        /// </summary>
        [HttpPut]
        public IActionResult Put(UserRoleUpdateDto model)
        {
            return Ok(repository.Update(model).Result);
        }
    }
}
