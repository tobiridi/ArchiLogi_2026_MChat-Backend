using MChat.Application.Features.Authentication.Commands.Register;
using MChat.Application.Features.Authentication.Queries.Login;
using MChat.Application.Interfaces;
using MChat.Domain.Entities;
using MChat.WebAPI.DTOs.Requests.Authentication;
using MChat.WebAPI.DTOs.Responses.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace MChat.WebAPI.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // POST: api/v1/Authentication/register
        [HttpPost("register", Name = "register")]
        [EnableRateLimiting("Authentication")]
        public async Task<IActionResult> Register(AuthenticateRequest request)
        {
            RegisterCommand command = new RegisterCommand(request.Email, request.Password, request.Username);
            try
            {
                bool isRegister = await _authenticationService.RegisterUser(command);
                if (isRegister)
                    return Created();
                else
                    return Problem(detail: "Can not register the user.", statusCode: StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return Problem(detail: "An error occurred when register the user", statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // POST: api/Authentication/login
        [HttpPost("login", Name = "login")]
        [EnableRateLimiting("Authentication")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginQuery query = new LoginQuery(request.Email, request.Password);
            User? user = await _authenticationService.LoginUser(query);

            if(user is null)
            {
                return BadRequest("Credentials are invalid.");
            }

            LoginResponse response = new LoginResponse(user);
            return Ok(response);
        }

        //// GET: api/Authentication/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(Guid id)
        //{
        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}

        //// PUT: api/Authentication/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(Guid id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Authentication
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //}

        //// DELETE: api/Authentication/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(Guid id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

    }
}
