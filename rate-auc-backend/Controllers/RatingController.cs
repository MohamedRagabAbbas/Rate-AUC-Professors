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
    public class RatingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public RatingController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public async Task<IActionResult> Add(RatingInfo ratingInfo, string userId)
        {
            Rating rating = _mapper.MapToRating(ratingInfo, userId);
            var result = await _unitOfWork.Rating.Add(rating);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(RatingInfo ratingInfo, string userId)
        {
            Rating rating = _mapper.MapToRating(ratingInfo, userId);
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
