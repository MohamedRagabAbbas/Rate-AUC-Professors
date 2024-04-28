using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RatingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var ratings = await _unitOfWork.Rating.GetAllAsync();
            return Ok(ratings);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rating = await _unitOfWork.Rating.GetByIdAsync(id);
            return Ok(rating);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Rating rating)
        {
            var result = await _unitOfWork.Rating.Add(rating);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(Rating rating)
        {
            var result = _unitOfWork.Rating.Update(rating);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Rating.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }

}
