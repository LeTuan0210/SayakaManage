﻿using AutoMapper;
using DataModels.Filter;
using DataServices.Interfaces;
using DataViewModels.Responses;

namespace BusinessServices.Repositories.MemberServices
{
    public class MemberBaseServices(IMemberDataServices _memberServices, IMapper _mapper) : IMemberBaseServices
    {
        public Task<MemberResponseModel> GetAllMemberAsync(MemberFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MemberResponseModel>> GetMemberByBirthdayMonthAsync(int month)
        {
            try
            {
                if (month < 0 || month > 12)
                    return null;
                var result = await _memberServices.GetAllMemberAsync(new MemberFilter { birthdayMonth = month });

                return _mapper.Map<List<MemberResponseModel>>(result);
            }
            catch 
            {
                return null;
            }
        }

        public async Task<MemberResponseModel> GetMemberById(string id)
        {
            try
            {
                var result = await _memberServices.GetMemberByUserIdAsync(id);

                if(result == null)
                {
                    return null;
                }

                return _mapper.Map<MemberResponseModel>(result);
            }
            catch
            {
                return null;
            }
        }
    }
}
