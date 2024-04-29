using Microsoft.AspNetCore.Identity;
using RateAucProfessors.DTO.Requests;
using RateAucProfessors.DTO.Response;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;
using RateAucProfessors.ObjectsMapping;

namespace RateAucProfessors.Authentication
{
    public class Authentication
    {
        private readonly UserManager<Student> _userManager;
        private readonly Token _token;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public Authentication(UserManager<Student> userManager, Token token, IUnitOfWork unitOfWork, Mapper mapper)
        {
            _userManager = userManager;
            _token = token;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<AuthenticationResponse> SignUP(StudentInfo model)
        {
            Student student = _mapper.MapToStudent(model);
            var result = await _userManager.CreateAsync(student, model.Password);
            if (result.Succeeded)
            {
                //add Role
                await _userManager.AddToRoleAsync(student, "Student");
                if (student.Email is not null)
                {
                    var user = await _userManager.FindByEmailAsync(student.Email);
                    return new AuthenticationResponse()
                    {
                        Id = user.Id,
                        Role = "Student",
                        IsAuthenticated = true,
                        Token = _token.GenerateToken(user.Id)
                    };
                }
                
            }
            var errors = result.Errors.ToList();
            string Error = "";
            foreach (var item in errors)
            {
                Error += item.Description + " ";
            }
            return new AuthenticationResponse() { Message = Error };
        }
        
    }
}