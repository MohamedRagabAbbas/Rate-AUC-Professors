using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.DTO.Requests;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;
using RateAucProfessors.ObjectsMapping;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly Mapper _mapper;
        public StudentController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public async Task<IActionResult> Add(StudentInfo studentinfo)
        {
            Student student = _mapper.MapToStudent(studentinfo);
            var result = await _unitOfWork.Student.Add(student);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(StudentInfo studentinfo)
        {
            Student student = _mapper.MapToStudent(studentinfo);
            var result = _unitOfWork.Student.Update(student);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Student.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
