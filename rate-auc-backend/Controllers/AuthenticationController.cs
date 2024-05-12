using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.DTO.Requests;
using RateAucProfessors.DTO.Response;
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
        [HttpGet]
        [Route("get-majors-name-by-studentId/{studentId}")]
        public async Task<IActionResult> GetMajorsIdByStudentId(string studentId)
        {
            var response = await _authentication.GetMajorsByStudentId(studentId);
            if(response.Data is null)
            {
                return BadRequest(response);
            }
            List<int> Ids = response.Data;
            List<string> Names = new List<string>();
            foreach (var id in Ids)
            {
                var major = await _unitOfWork.Major.GetByIdAsync(id);
                if(major.Data is null)
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
        [HttpPost]
        [Route("assign-major-to-student/{studentId}/{majorId}")]
        public async Task<IActionResult> AssignMajorToStudent(string studentId, int majorId)
        {
            var response = await _authentication.AssignMajorToStudent(studentId,majorId);
            return Ok(response);
        }
        [HttpPut]
        [Route("update/{userId}")]
        public async Task<IActionResult> Update(StudentInfo studentInfo,string userId)
        {
            var result = await _authentication.Update(studentInfo, userId);
            return Ok(result);
        }
    }
}
