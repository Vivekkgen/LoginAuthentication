using AutoMapper;
using ChatBotBackend.Data;
using Microsoft.AspNetCore.Identity;

namespace ChatBotBackend.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountRepository(UserManager<User> userManager,
           SignInManager<User> signInManager,
           IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<IdentityResult> SignUpAsync(UserDto employee)
        {
            var user = new User()
            {
                Name = employee.Name,
                UserName = employee.UserName,
                PasswordHash = employee.Password,
                Email = employee.UserName
                
            };
           
            return await _userManager.CreateAsync(user, employee.Password);
        }
        public async Task<RespnseDto> LoginAsync(LoginDto loginDto)
        {
            // var user = await _userManager.FindByEmailAsync(loginDto.EmployeeEmail);
            // Console.WriteLine(user.EmployeeName);
            // Console.WriteLine(user.UserName);

            // bool isvalidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            var result = await _signInManager.PasswordSignInAsync(loginDto.EmployeeEmail, loginDto.Password, false, false);
            var _user = await _userManager.FindByEmailAsync(loginDto.EmployeeEmail);
            Console.WriteLine(_user.ToString());
            Console.WriteLine("In Login Async Method");
           
            /*if (_user == null || result == null)
            {
                return null;
            }*/
            Console.WriteLine("In Login Async Method");
            /* var authClaims = new List<Claim>
             {
                 new Claim(ClaimTypes.Name, loginDto.EmployeeEmail),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };
             var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]));
             Console.WriteLine($"{authSigninKey}");
             var token = new JwtSecurityToken(
                 issuer: _configuration["JwtSettings:ValidIssuer"],
                 audience: _configuration["JwtSettings:ValidAudience"],
                 expires: DateTime.Now.AddDays(1),
                 claims: authClaims,
                 signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                 );
 */

            var m = _mapper.Map<RespnseDto>(_user);
           
            //   m.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return m;
        }
    }
}
