using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyllabusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SyllabusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var syllabuses = await _unitOfWork.Syllabus.GetAllAsync();
            return Ok(syllabuses);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var syllabus = await _unitOfWork.Syllabus.GetByIdAsync(id);
            return Ok(syllabus);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Syllabus syllabus)
        {
            var result = await _unitOfWork.Syllabus.Add(syllabus);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Syllabus syllabus)
        {
            var result = _unitOfWork.Syllabus.Update(syllabus);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Syllabus.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
