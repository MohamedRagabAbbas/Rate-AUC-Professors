using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.DTO.Requests;
using RateAucProfessors.DTO.Response;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;
using RateAucProfessors.ObjectsMapping;
using RateAucProfessors.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        [Authorize]
        [Route("get-by-id/{id}")]  
        public async Task<IActionResult> GetById(string id)
        {
            var student = await _unitOfWork.Student.GetByIdAsync(id);
            return Ok(student);
        }
        [HttpGet]
        [Authorize]
        [Route("get-majors-name-by-studentId")]
        public async Task<IActionResult> GetMajorsIdByStudentId()
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId is not null)
            {
                var response = await _authentication.GetMajorsByStudentId(userId);
                if (response.Data is null)
                {
                    return BadRequest(response);
                }
                List<int> Ids = response.Data;
                List<string> Names = new List<string>();
                foreach (var id in Ids)
                {
                    var major = await _unitOfWork.Major.GetByIdAsync(id);
                    if (major.Data is null)
                    {
                        return BadRequest(response);
                    }
                    Names.Add(major.Data.Name);
                }
                ResponseMessage<List<string>> response1 = new ResponseMessage<List<string>>()
                {
                    Data = Names
                };
                return Ok(response1);
            }
            return BadRequest("User not found");
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
        [Authorize]
        [HttpPost]
        [Route("assign-major-to-student/{majorId}")]
        public async Task<IActionResult> AssignMajorToStudent(int majorId)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId is not null)
            {
                var response = await _authentication.AssignMajorToStudent(userId, majorId);
                return Ok(response);
            }
            return BadRequest("User not found");
        }
        [HttpPut]
        [Authorize]
        [Route("update")]
        public async Task<IActionResult> Update(StudentInfo studentInfo)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId is not null)
            {
                var result = await _authentication.Update(studentInfo, userId);
                return Ok(result);
            }
            return BadRequest("User not found");

        }
    }
}
