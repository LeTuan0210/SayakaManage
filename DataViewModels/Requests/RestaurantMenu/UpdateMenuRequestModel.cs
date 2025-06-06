﻿namespace DataViewModels.Requests
{
    public class UpdateMenuRequestModel
    {
        public Guid Id { get; set; }
        public string menuName { get; set; }
        public string menuDescription { get; set; }
        public int menuPrice { get; set; }
        public List<string> menuImages { get; set; }
        public string menuType { get; set; }
    }
}
