using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AssignmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var assignments = await _unitOfWork.Assignment.GetAllAsync();
            return Ok(assignments);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var assignment = await _unitOfWork.Assignment.GetByIdAsync(id);
            return Ok(assignment);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Assignment assignment)
        {
            var result = await _unitOfWork.Assignment.Add(assignment);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Assignment assignment)
        {
            var result = _unitOfWork.Assignment.Update(assignment);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Assignment.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
