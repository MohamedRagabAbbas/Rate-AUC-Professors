using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var reactions = await _unitOfWork.Reaction.GetAllAsync();
            return Ok(reactions);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reaction = await _unitOfWork.Reaction.GetByIdAsync(id);
            return Ok(reaction);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Reaction reaction)
        {
            var result = await _unitOfWork.Reaction.Add(reaction);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Reaction reaction)
        {
            var result = _unitOfWork.Reaction.Update(reaction);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Reaction.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
