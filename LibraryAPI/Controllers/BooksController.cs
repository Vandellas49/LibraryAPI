using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{

    public class BooksController : ControllerBaseCustom
    {
        readonly IGenericRepository<Books> repository;
        public BooksController(IGenericRepository<Books> _repository)
        {
            repository = _repository;
        }

        [Route("~/api/Books/{Id}")]
        [HttpGet]
        public IActionResult GetBookById(int Id)
        {
            return Ok(repository.GetByIdAsync(new BooksWithCategorySpecification(Id)).Result);
        }
        /// <summary>
        /// Kitaplar sınırlı şekilde listeliyen method
        /// </summary>
        [HttpGet]
        public IActionResult GetBookPagination([FromQuery] BookSearchParams model)
        {
            return Ok(repository.ListBySpecAsync(new BooksWithCategorySpecification(model)).Result);
        }
        /// <summary>
        /// Kitap ekleme methodu
        /// </summary>
        [HttpPost]
        public IActionResult Post(BookAddDto model)
        {
            return Ok(repository.Add(model).Result);
        }
        /// <summary>
        /// Kitap silme methodu
        /// </summary>
        [HttpDelete]
        public IActionResult Delete(BookDeleteDto model)
        {
            return Ok(repository.Delete(model.Id.Value).Result);
        }
        /// <summary>
        /// Kitap güncelleme methodu
        /// </summary>
        [HttpPut]
        public IActionResult Put(BookUpdateDto model)
        {
            return Ok(repository.Update(model).Result);
        }
    }
}
