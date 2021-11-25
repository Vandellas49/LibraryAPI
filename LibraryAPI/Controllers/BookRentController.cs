using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    public class BookRentController : ControllerBaseCustom
    {
        readonly IGenericRepository<BookRent> repository;
        public BookRentController(IGenericRepository<BookRent> _repository)
        {
            repository = _repository;
        }
        /// <summary>
        /// Kitab ve Alan kişinin Id ye göre dönmesini sağlıyor
        /// </summary>
        [Route("~/api/BookRent/{Id}")]
        [HttpGet]
        public IActionResult GetBookRentById(int Id)
        {
            var t = repository.GetByIdAsync(new BookRentAnySpecification(Id)).Result;
            return Ok(t);
        }
        /// <summary>
        /// Kitap ve alan kişilerin listesini sınırlı olarak veriyor
        /// </summary>
        [HttpGet]
        public IActionResult GetBookRentPagination([FromQuery] BookRentPaginationSearchParams model)
        {
            return Ok(repository.ListBySpecAsync(new BookRentWithPersonandBookSpecification(model)).Result);
        }
        /// <summary>
        /// Kitap ve alan kişiyi kaydediyor
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] BookRentAddDto model)
        {
            return Ok(repository.Add(model).Result);
        }
        /// <summary>
        /// Kitap ve alan kişiyi siliyor
        /// </summary>
        [HttpDelete]
        public IActionResult Delete([FromBody] BookRentDeleteDto model)
        {
            return Ok(repository.Delete(model.Id.Value).Result);
        }
        /// <summary>
        /// Kitap ve alan kişiyi güncelliyor
        /// </summary>
        [HttpPut]
        public IActionResult Put([FromBody] BookRentUpdateDto model)
        {
            return Ok(repository.Update(model).Result);
        }
    }
}
