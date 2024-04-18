using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var students = await _unitOfWork.Student.GetAllAsync();
            return Ok(students);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _unitOfWork.Student.GetByIdAsync(id);
            return Ok(student);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Student student)
        {
            var result = await _unitOfWork.Student.Add(student);
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Student student)
        {
            var result = _unitOfWork.Student.Update(student);
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Student.Delete(id);
            return Ok(result);
        }
    }
}
