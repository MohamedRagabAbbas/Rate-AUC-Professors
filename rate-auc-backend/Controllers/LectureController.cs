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
    public class LectureController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public LectureController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //[HttpGet]
        //[Route("get-all")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var lectures = await _unitOfWork.Lecture.GetAllAsync();
        //    return Ok(lectures);
        //}
        //[HttpGet]
        //[Route("get-by-id/{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var lecture = await _unitOfWork.Lecture.GetByIdAsync(id);
        //    return Ok(lecture);
        //}
        //[HttpPost]
        //[Route("add")]
        //public async Task<IActionResult> Add(LectureInfo lectureInfo,string userId)
        //{
        //    Lecture lecture = _mapper.MapToLecture(lectureInfo, userId);
        //    var result = await _unitOfWork.Lecture.Add(lecture);
        //    await _unitOfWork.SaveAsync();
        //    return Ok(result);
        //}
        //[HttpPut]
        //[Route("update")]
        //public IActionResult Update(LectureInfo lectureInfo, string userId)
        //{
        //    Lecture lecture = _mapper.MapToLecture(lectureInfo, userId);
        //    var result = _unitOfWork.Lecture.Update(lecture);
        //    _unitOfWork.SaveAsync();
        //    return Ok(result);
        //}
        //[HttpDelete]
        //[Route("delete/{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _unitOfWork.Lecture.Delete(id);
        //    await _unitOfWork.SaveAsync();
        //    return Ok(result);
        //}
    }
}
