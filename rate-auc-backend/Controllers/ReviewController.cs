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
    public class ReviewController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public ReviewController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _unitOfWork.Review.GetAllAsync();
            return Ok(reviews);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _unitOfWork.Review.GetByIdAsync(id);
            return Ok(review);
        }
        [HttpGet]
        [Route("get-all-reviews-by-professorId/{professorId}")]
        public async Task<IActionResult> GetAllReviewsByprofessorId(int professorId)
        {
            var reviews = await _unitOfWork.Review.GetWhereAsync(x=>x.ProfessorId == professorId);
            return Ok(reviews);
        }
        [HttpGet]
        [Route("get-all-reviews-by-courseId/{courseId}")]
        public async Task<IActionResult> GetAllReviewsBycourseId(int courseId)
        {
            var reviews = await _unitOfWork.Review.GetWhereAsync(x => x.CourseId== courseId);
            return Ok(reviews);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(ReviewInfo reviewInfo, string userId)
        {
            Review review = _mapper.MapToReview(reviewInfo, userId);
            var result = await _unitOfWork.Review.Add(review);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(ReviewInfo reviewInfo, string userId)
        {
            Review review = _mapper.MapToReview(reviewInfo, userId);
            var result = _unitOfWork.Review.Update(review);
            _unitOfWork.SaveAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Review.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }

}
