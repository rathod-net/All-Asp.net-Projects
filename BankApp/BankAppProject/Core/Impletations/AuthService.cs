using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace Core.Impletations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtTokenService _jwtTokenService;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> RegisterUserAsync(string email, string password)
        {
            var user = new ApplicationUser { Email = email, UserName = email };
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                throw new Exception("User registration failed");

            return _jwtTokenService.GenerateToken(user.Id,"User");
        }

        public async Task<string> LoginUserAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new Exception("Invalid credentials");

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (!result.Succeeded)
                throw new Exception("Invalid credentials");

            return _jwtTokenService.GenerateToken(user.Id, "User");
        }
    }
}
