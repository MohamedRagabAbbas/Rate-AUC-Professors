using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.DTO.Requests;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;
using RateAucProfessors.ObjectsMapping;
using RateAucProfessors.Repository;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly Authentication.Authentication _authentication;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;


        public AuthenticationController(Authentication.Authentication authentication, IUnitOfWork unitOfWork, Mapper mapper)
        {
            _authentication = authentication;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // get user(stduent) by userId
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var student = await _unitOfWork.Student.GetByIdAsync(id);
            return Ok(student);
        }
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(LoginRequest request)
        {
            var result = await _authentication.Authenticate(request.Email, request.Password);
            return Ok(result);
        }
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(StudentInfo studentInfo)
        {
            var result = await _authentication.SignUP(studentInfo);
            return Ok(result);
        }
        [HttpPut]
        [Route("update/{userId}")]
        public async Task<IActionResult> Update(StudentInfo studentInfo,string userId)
        {
            Student stduent = _mapper.MapToStudent(studentInfo, userId);
            var result = _unitOfWork.Student.Update(stduent);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
