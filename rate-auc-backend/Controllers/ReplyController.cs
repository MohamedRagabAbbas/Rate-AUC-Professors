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
    public class ReplyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public ReplyController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public async Task<IActionResult> Add(ReplyInfo replyInfo, string userId)
        {
            Reply reply = _mapper.MapToReply(replyInfo, userId);
            var result = await _unitOfWork.Reply.Add(reply);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(ReplyInfo replyInfo, string userId)
        {
            Reply reply = _mapper.MapToReply(replyInfo, userId);
            var result = _unitOfWork.Reply.Update(reply);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Reply.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
