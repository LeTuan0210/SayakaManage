﻿using System.ComponentModel.DataAnnotations;

namespace DataViewModels.Responses
{
    public class MemberResponseModel
    {
        public string user_Id { get; set; }
        public string user_Id_By_App { get; set; }
        public string memberName { get; set; }
        public string memberPhone { get; set; }
        public string memberAvatar { get; set; }
        public string memberEmail { get; set; }
        public bool canEditPhone { get; set; }
        public DateTime memberBirthday { get; set; }
        public List<RestaurantResponseModel> favouriteRestaurant { get; set; } = new List<RestaurantResponseModel>();
        public string memberGender { get; set; }
        public bool isActive { get; set; }
        public bool isSendedPromotion { get; set; } = false;
        public bool hasModify { get; set; } = false;
    }
}
