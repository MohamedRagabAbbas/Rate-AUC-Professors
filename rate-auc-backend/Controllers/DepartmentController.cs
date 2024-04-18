using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _unitOfWork.Department.GetAllAsync();
            return Ok(departments);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _unitOfWork.Department.GetByIdAsync(id);
            return Ok(department);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Department department)
        {
            var result = await _unitOfWork.Department.Add(department);
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Department department)
        {
            var result = _unitOfWork.Department.Update(department);
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Department.Delete(id);
            return Ok(result);
        }
    }
}
