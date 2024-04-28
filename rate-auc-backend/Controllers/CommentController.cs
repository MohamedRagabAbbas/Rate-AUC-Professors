using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _unitOfWork.Comment.GetAllAsync();
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
        public async Task<IActionResult> Add(Comment comment)
        {
            var result = await _unitOfWork.Comment.Add(comment);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Comment comment)
        {
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
