using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    public class CategoryController : ControllerBaseCustom
    {
        readonly IGenericRepository<Category> repository;
        public CategoryController(IGenericRepository<Category> _repository)
        {
            repository = _repository;
        }
        /// <summary>
        /// Kategori ve kitapları kategori Id ye göre getiren method
        /// </summary>
        /// <param name="Id"></param>
        [HttpDelete]
        [Route("~/api/Category/{Id}")]
        [HttpGet]
        public IActionResult GetCategoryById(int Id)
        {
            var t = repository.GetByIdAsync(new CategoriesWithBooksSpecification(Id)).Result;
            return Ok(t);
        }
        /// <summary>
        /// Kategorileri ve altındaki kitapları sınırlı sayıda listeleyen method
        /// </summary>
        [HttpGet]
        public IActionResult GetCategoryPagination([FromQuery] CategorySearchParams model)
        {
            return Ok(repository.ListBySpecAsync(new CategoriesWithBooksSpecification(model)).Result);
        }
        /// <summary>
        /// Kategori Ekleme Methodu
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryAddDto model)
        {
            return Ok(repository.Add(model).Result);
        }
        /// <summary>
        /// Kategori Silme Methodu
        /// </summary>
        [HttpDelete]
        public IActionResult Delete([FromBody] CategoryDeleteDto model)
        {
            return Ok(repository.Delete(model.Id.Value).Result);
        }
        /// <summary>
        /// Kategori Güncelleme Methodu
        /// </summary>
        [HttpPut]
        public IActionResult Put([FromBody] CategoryUpdateDto model)
        {
            return Ok(repository.Update(model).Result);
        }
    }
}
