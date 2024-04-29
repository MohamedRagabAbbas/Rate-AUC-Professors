using Microsoft.AspNetCore.Identity;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;

namespace RateAucProfessors.Authentication
{
    public class Authentication
    {
        private readonly UserManager<Student> _userManager;
        private readonly Token _token;
        private readonly IUnitOfWork _unitOfWork;
        public Authentication(UserManager<Student> userManager, Token token, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _token = token;
            _unitOfWork = unitOfWork;
        }
        

    }
}
