using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public FeedController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var feeds = await _unitOfWork.Feed.GetAllAsync();
            return Ok(feeds);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feed = await _unitOfWork.Feed.GetByIdAsync(id);
            return Ok(feed);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Feed feed)
        {
            var result = await _unitOfWork.Feed.Add(feed);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Feed feed)
        {
            var result = _unitOfWork.Feed.Update(feed);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Feed.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

    }
}
