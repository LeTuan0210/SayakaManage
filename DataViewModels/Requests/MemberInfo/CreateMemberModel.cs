﻿namespace DataViewModels.Requests.MemberInfo
{
    public class CreateMemberModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string user_Id { get; set; } = string.Empty;
        public string user_Id_By_App { get; set; } = string.Empty;
        public string memberName { get; set; } = string.Empty;
        public string memberPhone { get; set; } = string.Empty;
        public string memberAvatar { get; set; } = string.Empty;
        public string memberEmail { get; set; } = string.Empty;
        public bool canEditPhone { get; set; } = true;
        public DateTime memberBirthday { get; set; } = DateTime.Today;
        public string memberGender { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
    }
}
