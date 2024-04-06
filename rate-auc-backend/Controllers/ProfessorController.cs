using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProfessorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
        public async Task<IActionResult> Add(Professor professor)
        {
            var result = await _unitOfWork.Professor.Add(professor);
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Professor professor)
        {
            var result = _unitOfWork.Professor.Update(professor);
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Professor.Delete(id);
            return Ok(result);
        }
    }
}
