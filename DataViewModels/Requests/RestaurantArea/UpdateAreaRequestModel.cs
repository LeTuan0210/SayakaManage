using System.ComponentModel.DataAnnotations;

namespace DataViewModels.Requests
{
    public class UpdateAreaRequestModel
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(1)]
        public string areaName { get; set; }
    }
}
