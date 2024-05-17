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
    public class ProfessorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public ProfessorController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var professors = await _unitOfWork.Professor.GetAllAsync();
            return Ok(professors);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var professor = await _unitOfWork.Professor.GetByIdAsync(id);
            return Ok(professor);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(ProfessorInfo professorInfo)
        {
            Professor professor = _mapper.MapToProfessor(professorInfo);
            var result = await _unitOfWork.Professor.Add(professor);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPost]
        [Route("add-multiple-with-departmentName")]
        public async Task<IActionResult> AddMultipleWithdepartmentName(List<ProfessorSeeding> professorSeedings)
        {
            List<Professor> professors = new List<Professor>();
            foreach (var professorSeeding in professorSeedings)
            {
                var department = await _unitOfWork.Department.GetFirstAsync(d => d.Name == professorSeeding.departmentName);
                if(department is not null && department.Data is not null)
                {
                    Professor professor = _mapper.MapToProfessorDataSeeding(professorSeeding, department.Data.Id);
                    professors.Add(professor);
                }
            }
            await _unitOfWork.Professor.AddRange(professors);
            var result = await _unitOfWork.SaveAsync();
            return Ok(result != 0 ? "Professors are added successfuly.." : "Error while adding professors...");
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(ProfessorInfo professorInfo)
        {
            Professor professor = _mapper.MapToProfessor(professorInfo);
            var result = _unitOfWork.Professor.Update(professor);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Professor.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete-all")]
        public async Task<IActionResult> DeleteAll()
        {
            var result = await _unitOfWork.Professor.DeleteAllAsync();
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
