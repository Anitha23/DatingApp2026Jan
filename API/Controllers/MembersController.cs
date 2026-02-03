using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    
    public class MembersController(IMemberRepository memberRepository) : BaseApiController
    {
        

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Member>>> GetMembers() 
        {
           return Ok( await memberRepository.GetAllMemebersAsync());            
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(string id)
        {
            var memeber = await memberRepository.GetMemberByIdAsync(id);

            if (memeber == null) { return NotFound(); }
            return  memeber;
        }

        [HttpGet("{id}/photos")]
       public async Task<ActionResult<IReadOnlyList<Photo>>> GetMemberPhotos(string id)
        {
            return Ok(await memberRepository.GetPhotosForMemebersAsync(id));
        }


    }
}
