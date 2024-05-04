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
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public CourseController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public async Task<IActionResult> Add(CourseInfo courseInfo)
        {
            Course course = _mapper.MapToCourse(courseInfo);
            var result = await _unitOfWork.Course.Add(course);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPost]
        [Route("add-multiple-with-departmentName")]
        public async Task<IActionResult> AddMultipleWithdepartmentName(List<CourseSeeding> courseSeedings)
        {
            List<Course> courses = new List<Course>();
            foreach (var courseSeeding in courseSeedings)
            {
                var department = await _unitOfWork.Department.GetFirstAsync(d => d.Name == courseSeeding.departmentName);
                if(department is not null && department.Data is not null)
                {
                    Course course = _mapper.MapToCourseDataSeeding(courseSeeding, department.Data.Id);
                    courses.Add(course);
                }
            }
            await _unitOfWork.Course.AddRange(courses);
            var result = await _unitOfWork.SaveAsync();
            return Ok(result != 0 ? "Courses are added successfuly.." : "Error while adding courses...");
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(CourseInfo courseInfo)
        {
            Course course = _mapper.MapToCourse(courseInfo);
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
