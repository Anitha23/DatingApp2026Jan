using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class MemberRepository(AppDbContext dbContext) : IMemberRepository
    {
        public async Task<IReadOnlyList<Member>> GetAllMemebersAsync()
        {
            return await dbContext.Members
                .Include(x =>x.Photos)
                .ToListAsync();
        }

        public async Task<Member?> GetMemberByIdAsync(string id)
        {
          return await dbContext.Members.FindAsync(id);
        }

        public async Task<IReadOnlyList<Photo>> GetPhotosForMemebersAsync(string memberId)
        {
            return await dbContext.Members
                .Where(photo => photo.Id == memberId)
                .SelectMany(x=>x.Photos)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public void Update(Member member)
        {
            dbContext.Entry(member).State = EntityState.Modified;
        }
    }
}











