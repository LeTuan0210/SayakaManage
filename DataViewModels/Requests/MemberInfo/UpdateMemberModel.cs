using System.ComponentModel.DataAnnotations;

namespace DataViewModels.Requests
{
    public class UpdateMemberModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MinLength(2)]
        public string memberName { get; set; } = string.Empty;
        [Required]
        [MinLength(10)]
        public string memberPhone { get; set; } = string.Empty;
        public string memberAvatar { get; set; } = string.Empty;
        public bool canEditPhone { get; set; } = true;
        public DateTime memberBirthday { get; set; }
        public string memberGender { get; set; } = string.Empty;
        public string memberEmail {  get; set; } = string.Empty;
    }
}
