﻿using DataModels.Entities;
using DataModels.Filter;
using DataViewModels.Responses;

namespace BusinessServices.Repositories
{
    public interface IMemberBaseServices
    {
        Task<MemberResponseModel> GetMemberById(string id);
        Task<MemberResponseModel> GetAllMemberAsync(MemberFilter filter);
        Task<List<MemberResponseModel>> GetMemberByBirthdayMonthAsync(int month);
    }
}
