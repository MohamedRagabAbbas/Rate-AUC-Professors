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
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public DepartmentController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public async Task<IActionResult> Add(DepartmentInfo departmentInfo)
        {
            Department department = _mapper.MapToDepartment(departmentInfo);
            var result = await _unitOfWork.Department.Add(department);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPost]
        [Route("add-multiple")]
        public async Task<IActionResult> AddMultiple(List<DepartmentInfo> departmentInfos)
        {
            List<Department> departments = new List<Department>();
            departments = _mapper.MapToDepartment(departmentInfos);
            await _unitOfWork.Department.AddRange(departments);
            var result = await _unitOfWork.SaveAsync();
            return Ok(result !=0 ? "Departments are added successfuly.." : "Error while adding departments...");
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(DepartmentInfo departmentInfo)
        {
            Department department = _mapper.MapToDepartment(departmentInfo);
            var result = _unitOfWork.Department.Update(department);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Department.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
