using DataModels.Entities;
using DataModels.Filter;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class MemberDataServices(ApplicationDbContext _context) : IMemberDataServices
    {
        public int CountUnsendMember() => _context.MemberInfos.Count(x => !x.isSendedPromotion);

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

        public async Task<List<MemberInfo>> GetAllMemberAsync(MemberFilter filter)
        {
            var query = _context.MemberInfos.AsQueryable();

            if (filter.birthdayMonth != 0)
                query = query.Where(x => x.memberBirthday.Month == filter.birthdayMonth);

            switch(filter.isSentPromotion)
            {
                case 1:
                    query = query.Where(x => !x.isSendedPromotion);
                    break;
                case 2:
                    query = query.Where(x => x.isSendedPromotion);
                    break;
            }    

            query = query.Skip(filter.skipItem).Take(filter.PageSize);

            return await query.ToListAsync();
        }

        public async Task<MemberInfo> GetMemberAsync(string user_id_by_app)
        {
            var member = await _context.MemberInfos.FirstOrDefaultAsync(x => x.user_Id_By_App == user_id_by_app);

            return member;
        }

        public async Task<MemberInfo> GetMemberByUserIdAsync(string userId)
        {
            var member = await _context.MemberInfos.FirstOrDefaultAsync(x => x.user_Id == userId);

            return member;
        }

        public void ResetMemberSend()
        {
            try
            {
                _context.Database.ExecuteSqlRaw("Update MemberInfos set ");
            }
            catch
            {

            }
        }

        public async Task<MemberInfo> UpdateMemberAsync(MemberInfo menu)
        {
            _context.MemberInfos.Update(menu);
            await _context.SaveChangesAsync();
            return menu;
        }
    }
}
