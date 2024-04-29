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
    [Authorize(Roles = "Student,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public AssignmentController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //[HttpGet]
        //[Route("get-all")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var assignments = await _unitOfWork.Assignment.GetAllAsync();
        //    return Ok(assignments);
        //}
        //[HttpGet]
        //[Route("get-by-id/{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var assignment = await _unitOfWork.Assignment.GetByIdAsync(id);
        //    return Ok(assignment);
        //}
        //[HttpPost]
        //[Route("add")]
        //public async Task<IActionResult> Add(AssignmentInfo assignmentInfo)
        //{
        //    var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        //    if(userId is not null)
        //    {
        //        Assignment assignment = _mapper.MapToAssignment(assignmentInfo, userId); ;
        //        var result = await _unitOfWork.Assignment.Add(assignment);
        //        await _unitOfWork.SaveAsync();
        //        return Ok(result);
        //    }
        //    return BadRequest("User not found");
        //}
        //[HttpPut]
        //[Route("update")]
        //public IActionResult Update(AssignmentInfo assignmentInfo)
        //{
        //    var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        //    if (userId is not null) 
        //    {
        //        Assignment assignment = _mapper.MapToAssignment(assignmentInfo, userId);
        //        var result = _unitOfWork.Assignment.Update(assignment);
        //        _unitOfWork.SaveAsync();
        //        return Ok(result);
        //    }
        //    return BadRequest("User not found");
        //}
        //[HttpDelete]
        //[Route("delete/{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _unitOfWork.Assignment.Delete(id);
        //    await _unitOfWork.SaveAsync();
        //    return Ok(result);
        //}
    }
}
