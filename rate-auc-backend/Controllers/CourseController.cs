using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
                public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _unitOfWork.Course.GetAllAsync();
            return Ok(courses);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _unitOfWork.Course.GetByIdAsync(id);
            return Ok(course);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Course course)
        {
            var result = await _unitOfWork.Course.Add(course);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Course course)
        {
            var result = _unitOfWork.Course.Update(course);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Course.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
