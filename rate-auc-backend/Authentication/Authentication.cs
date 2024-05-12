using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ResponseMessage<Student>> Update(StudentInfo model, string userId)
        {
            // get the student by userId
            var student = await _userManager.FindByIdAsync(userId);
            if (student == null)
            {
                return new ResponseMessage<Student>()
                {
                    Message = "The user is not found"
                };
            }
            // udpate the student
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.PhoneNumber = model.PhoneNumber;
            student.Standing = model.Standing;
            student.GraduationYear = model.GraduationYear;
            student.Student_Id = model.Student_Id;
            student.Color = model.Color;
            student.Gender = model.Gender;

            var result = await _userManager.UpdateAsync(student);
            if (result.Succeeded)
            {
                return new ResponseMessage<Student>()
                {
                    Status = true,
                    Message = "The user is updated successfully",
                    Data = student
                };
            }
            var errors = result.Errors.ToList();
            string Error = "";
            foreach (var item in errors)
            {
                Error += item.Description + " ";
            }
            return new ResponseMessage<Student>()
            {
                Message = $"The user is not updated due to the following {Error}"
            };
        }

        public async Task<ResponseMessage<string>> AssignMajorToStudent(string studentId, Major major)
        {
            var student = await _unitOfWork.Student.GetByIdAsync(studentId);
            if (student.Data is null)
                return new ResponseMessage<string>() { Message = "The student is not found..." };
            Student student1 = student.Data;
           // student1.Majors?.Add(major);
            await _userManager.UpdateAsync(student1);
            var result = await _userManager.UpdateAsync(student1);
            if (result.Succeeded)
            {
                return new ResponseMessage<string>()
                {
                    Message = "The student is successfully assigned to the major...",
                    Status = true,
                    Data = "The student is successfully assigned to the major..."
                };
            }
            var errors = result.Errors.ToList();
            string Error = "";
            foreach (var item in errors)
            {
                Error += item.Description + " ";
            }
            return new ResponseMessage<string>()
            {
                Message = $"The student is not assigned to the major due to the following {Error}"
            };
        }

        // return student's majors by _userManager
        public async Task<ResponseMessage<List<Major>>> GetMajorsByStudentId(string studentId)
        {
            var student = await _userManager.FindByIdAsync(studentId);
            if (student is null)
                return new ResponseMessage<List<Major>>() { Message = "The student is not found..." };
           
            return new ResponseMessage<List<Major>>() {};
        }



    }
}