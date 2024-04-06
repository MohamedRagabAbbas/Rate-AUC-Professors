using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReplyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var replies = await _unitOfWork.Reply.GetAllAsync();
            return Ok(replies);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reply = await _unitOfWork.Reply.GetByIdAsync(id);
            return Ok(reply);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Reply reply)
        {
            var result = await _unitOfWork.Reply.Add(reply);
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Reply reply)
        {
            var result = _unitOfWork.Reply.Update(reply);
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Reply.Delete(id);
            return Ok(result);
        }
    }
}
