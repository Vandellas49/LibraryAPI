using BL.InterFaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    /// <summary>
    /// Yapılacak
    /// </summary>
    public class VisitorsController : ControllerBaseCustom
    {
        readonly IGenericRepository<Visitors> repository;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public VisitorsController(IGenericRepository<Visitors> _repository)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            repository = _repository;
        }
        /// <summary>
        ///  Yapılacak.
        /// </summary>
        [Route("~/api/Visitors/{Id}")]
        [HttpGet]
        public IActionResult GetVisitorsById(int Id)
        {
            return Ok();
        }
        /// <summary>
        ///  Yapılacak.
        /// </summary>
        [HttpGet]
        public IActionResult GetVisitorsPagination()
        {
            return Ok();
        }
        /// <summary>
        ///  Yapılacak.
        /// </summary>
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        /// <summary>
        ///  Yapılacak.
        /// </summary>
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
        /// <summary>
        ///  Yapılacak.
        /// </summary>
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
    }
}
