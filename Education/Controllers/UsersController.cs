using Education.Data;
using Education.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UsersController(AppDbContext _context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }
}
