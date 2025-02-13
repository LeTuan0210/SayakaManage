using DataModels.Entities;
using DataModels.Filter;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class MemberDataServices(ApplicationDbContext _context) : IMemberDataServices
    {
        public Task<List<MemberInfo>> CreateListMemberAsync(List<MemberInfo> member)
        {
            throw new NotImplementedException();
        }

        public async Task<MemberInfo> CreateNewMemberAsync(MemberInfo member)
        {
            _context.MemberInfos.Add(member);

            await _context.SaveChangesAsync();

            return member;
        }

        public Task<bool> DeleteMemberAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MemberInfo>> GetAllMenuAsync(MenuFilter filter)
        {
            return await _context.MemberInfos.ToListAsync();
        }

        public async Task<MemberInfo> GetMemberAsync(string user_id_by_app)
        {
            var member = await _context.MemberInfos.FirstOrDefaultAsync(x => x.user_Id_By_App == user_id_by_app);

            return member;
        }

        public async Task<MemberInfo> UpdateMemberAsync(MemberInfo menu)
        {
            _context.MemberInfos.Update(menu);
            await _context.SaveChangesAsync();
            return menu;
        }
    }
}
