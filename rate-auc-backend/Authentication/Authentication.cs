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
        public async Task<AuthenticationResponse> Authenticate(string email, string password)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                if (role != null)
                {
                    return new AuthenticationResponse()
                    {
                        Id = user.Id,
                        Role = role,
                        IsAuthenticated = true,
                        Token = _token.GenerateToken(user.Id)
                    };
                }
                return new AuthenticationResponse() { Message = "Error..."};
            }
            return new AuthenticationResponse()
            {
                Message = "The user is not found or the password is incorrect"
            };
        }

        public async Task<AuthenticationResponse> SignUP(StudentInfo model)
        {
            Student student = _mapper.MapToStudent(model);
            var result = await _userManager.CreateAsync(student, model.Password);
            if (result.Succeeded)
            {
                //add Role
                await _userManager.AddToRoleAsync(student, "Student");
                if (student.UserName is not null)
                {
                    var user = await _userManager.FindByNameAsync(student.UserName);
                    if (user is not null)
                    {
                        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                        if (role != null)
                        {
                            return new AuthenticationResponse()
                            {
                                Id = user.Id,
                                Role = role,
                                IsAuthenticated = true,
                                Token = _token.GenerateToken(user.Id)
                            };
                        }
                        return new AuthenticationResponse()
                        {
                            Message = "The user is found but his/her role is not found"
                        };
                    }
                    return new AuthenticationResponse()
                    {
                        Message = "User not found"
                    };
                }
                var errors = result.Errors.ToList();
                string Error = "";
                foreach (var item in errors)
                {
                    Error += item.Description + " ";
                }
                return new AuthenticationResponse() { Message = Error };
            }
            var errors2 = result.Errors.ToList();
            string Error2 = "";
            foreach (var item in errors2)
            {
                Error2 += item.Description + " ";
            }
            return new AuthenticationResponse()
            {
                Message = $"The user is not created due to the following {Error2}"
            };

        }

    }
}