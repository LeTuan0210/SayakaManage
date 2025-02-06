namespace DataViewModels.Requests
{
    public class UpdateMemberModel
    {
        public string memberName { get; set; } = string.Empty;
        public DateTime memberBirthday { get; set; } = DateTime.Today;
        public string memberGender { get; set; } = string.Empty;
    }
}
