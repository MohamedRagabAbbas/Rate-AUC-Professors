using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public NoteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _unitOfWork.Note.GetAllAsync();
            return Ok(notes);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _unitOfWork.Note.GetByIdAsync(id);
            return Ok(note);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Note note)
        {
            var result = await _unitOfWork.Note.Add(note);
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Note note)
        {
            var result = _unitOfWork.Note.Update(note);
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Note.Delete(id);
            return Ok(result);
        }
    }
}
