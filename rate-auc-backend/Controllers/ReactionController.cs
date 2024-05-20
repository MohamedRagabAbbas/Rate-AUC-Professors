using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.DTO.Requests;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;
using RateAucProfessors.ObjectsMapping;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public ReactionController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var reactions = await _unitOfWork.Reaction.GetAllAsync();
            return Ok(reactions);
        }
        [HttpGet]
        [Route("get-all-reactions-by-feedId/{feedId}")]
        public async Task<IActionResult> GetAllReactions(int feedId)
        {
            var reactions = await _unitOfWork.Reaction.GetWhereAsync(x => x.FeedId == feedId);
            return Ok(reactions);
        }
        [HttpGet]
        [Route("get-all-reactions-by-replyId/{replyId}")]
        public async Task<IActionResult> GetAllReactionsByReplyId(int replyId)
        {
            var reactions = await _unitOfWork.Reaction.GetWhereAsync(x => x.ReplyId == replyId);
            return Ok(reactions);
        }
        [HttpGet]
        [Route("get-all-reactions-by-commentId/{commentId}")]
        public async Task<IActionResult> GetAllReactionsByCommentId(int commentId)
        {
            var reactions = await _unitOfWork.Reaction.GetWhereAsync(x => x.CommentId == commentId);
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
        public async Task<IActionResult> Add(ReactionInfo reactionInfo)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId is not null)
            {
                Reaction reaction = _mapper.MapToReaction(reactionInfo, userId);
                var result = await _unitOfWork.Reaction.Add(reaction);
                await _unitOfWork.SaveAsync();
                return Ok(result);
            }
            return BadRequest("User not found");
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(ReactionInfo reactionInfo)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId is not null)
            {
                Reaction reaction = _mapper.MapToReaction(reactionInfo, userId);
                var result = _unitOfWork.Reaction.Update(reaction);
                _unitOfWork.SaveAsync();
                return Ok(result);
            }
            return BadRequest("User not found");
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
