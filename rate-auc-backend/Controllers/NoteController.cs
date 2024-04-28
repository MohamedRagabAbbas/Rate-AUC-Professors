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
    public class NoteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public NoteController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public async Task<IActionResult> Add(NoteInfo noteInfo, string userId)
        {
            Note note = _mapper.MapToNote(noteInfo, userId);
            var result = await _unitOfWork.Note.Add(note);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(NoteInfo noteInfo, string userId)
        {
            Note note = _mapper.MapToNote(noteInfo, userId);
            var result = _unitOfWork.Note.Update(note);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Note.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
