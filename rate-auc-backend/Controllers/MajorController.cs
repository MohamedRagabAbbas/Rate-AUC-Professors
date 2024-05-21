using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.DTO.Requests;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;
using RateAucProfessors.ObjectsMapping;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public MajorController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var majors = await _unitOfWork.Major.GetAllAsync();
            return Ok(majors);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var major = await _unitOfWork.Major.GetByIdAsync(id);
            return Ok(major);
        }


        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(MajorInfo majorinfo)
        {
            Major major = _mapper.MapToMajor(majorinfo);
            var result = await _unitOfWork.Major.Add(major);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(MajorInfo majorinfo)
        {
            Major major = _mapper.MapToMajor(majorinfo);
            var result =  _unitOfWork.Major.Update(major);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Major.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
