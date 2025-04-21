using DataModels.Entities;
using DataModels.Filter;
using DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Repository
{
    public class MemberDataServices(ApplicationDbContext _context) : IMemberDataServices
    {
        public int CountUnsendMember()
        {
            throw new NotImplementedException();
        }

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

            return await query.ToListAsync();
        }

        public async Task<MemberInfo> GetMemberAsync(string user_id_by_app)
        {
            var member = await _context.MemberInfos.FirstOrDefaultAsync(x => x.user_Id_By_App == user_id_by_app);

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
            menu.hasModify = true;
            _context.MemberInfos.Update(menu);
            await _context.SaveChangesAsync();
            return menu;
        }
    }
}
