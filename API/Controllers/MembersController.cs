using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers() 
        {
           var memebers= await context.Users.ToListAsync();
            return memebers;
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetMember(string id)
        {
            var memeber = context.Users.Find(id);

            if (memeber == null) { return NotFound(); }
            return memeber;
        }
    }
}
