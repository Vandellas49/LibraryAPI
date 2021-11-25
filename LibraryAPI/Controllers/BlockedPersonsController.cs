using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    public class BlockedPersonsController : ControllerBaseCustom
    {
        readonly IGenericRepository<BlockedPersons> repository;
        public BlockedPersonsController(IGenericRepository<BlockedPersons> _repository)
        {
            repository = _repository;
        }
        /// <summary>
        /// Kitap almaya engellenen kişiyi Id ye göre gönderiyor
        /// </summary>
        /// <param name="Id"></param>
        [Route("~/api/BlockedPersons/{Id}")]
        [HttpGet]
        public IActionResult BlockedPersonById(int Id)
        {
            return Ok(repository.GetByIdAsync(new BlockedPersonWithPersonSpecification(Id)).Result);
        }
        /// <summary>
        /// Kitap almaya engellenen kişileri sınırlı şekilde listeliyor
        /// </summary>
        [HttpGet]
        public IActionResult GetPersonPagination([FromQuery] BlockedPersonsSearchPaginationParams model)
        {
            return Ok(repository.ListBySpecAsync(new BlockedPersonWithPersonSpecification(model)).Result);
        }
        /// <summary>
        /// Kitap almaya engellenen kişiyi ekliyor
        /// </summary>
        [HttpPost]
        public IActionResult Post(BlockedPersonAddDto model)
        {
            return Ok(repository.Add(model).Result);
        }
        /// <summary>
        /// Kitap almaya engellenen kişiyi siliyor
        /// </summary>
        [HttpDelete]
        public IActionResult Delete(BlockedPersonDeleteDto model)
        {
            return Ok(repository.Delete(model.Id.Value).Result);
        }
        /// <summary>
        /// Kitap almaya engellenen kişiyi güncelliyor
        /// </summary>
        [HttpPut]
        public IActionResult Put(BlockedPersonUpdateDto model)
        {
           return Ok(repository.Update(model).Result);
        }
    }
}
