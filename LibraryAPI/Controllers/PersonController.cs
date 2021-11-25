using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{

    public class PersonController : ControllerBaseCustom
    {
        readonly IGenericRepository<Persons> repository;
        public PersonController(IGenericRepository<Persons> _repository)
        {
            repository = _repository;
        }
        /// <summary>
        /// Kişiyi Id ye göre getiren method
        /// </summary>
        [Route("~/api/Person/{Id}")]
        [HttpGet]
        public IActionResult GetPersonById(int Id)
        {
            return Ok(repository.GetByIdAsync(new PersonSpecification(Id)).Result);
        }
        /// <summary>
        /// Kişileri sınırlı sayıda getiren method
        /// </summary>
        [HttpGet]
        public IActionResult GetPersonPagination([FromQuery] PersonsSearchPaginationParams model)
        {
            return Ok(repository.ListBySpecAsync(new PersonSpecification(model)).Result);
        }
        /// <summary>
        /// Kişi ekleme methodu
        /// </summary>
        [HttpPost]
        public IActionResult Post(PersonAddDto model)
        {
            return Ok(repository.Add(model).Result);
        }
        /// <summary>
        /// Kişi silme methodu
        /// </summary>
        [HttpDelete]
        public IActionResult Delete(PersonDeleteDto model)
        {
            return Ok(repository.Delete(model.Id.Value).Result);
        }
        /// <summary>
        /// Kişi güncellem methodu
        /// </summary>
        [HttpPut]
        public IActionResult Put(PersonUpdateDto model)
        {
            return Ok(repository.Update(model).Result);
        }
    }
}
