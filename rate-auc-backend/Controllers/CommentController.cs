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
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public CommentController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _unitOfWork.Comment.GetAllAsync();
            return Ok(comments);
        }
        [HttpGet]
        [Route("get-all-comments-by-feedId/{feedId}")]
        public async Task<IActionResult> GetAllComments(int feedId)
        {
            var comments = await _unitOfWork.Comment.GetWhereAsync(x =>x.FeedId == feedId);
            return Ok(comments);
        }


        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _unitOfWork.Comment.GetByIdAsync(id);
            return Ok(comment);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(CommentInfo commentInfo, string userName)
        {
            Comment comment = _mapper.MapToComment(commentInfo, userName);
            var result = await _unitOfWork.Comment.Add(comment);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(CommentInfo commentInfo, string userName)
        {
            Comment comment = _mapper.MapToComment(commentInfo, userName);
            var result = _unitOfWork.Comment.Update(comment);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Comment.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
