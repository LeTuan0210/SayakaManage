using System.ComponentModel.DataAnnotations;

namespace DataViewModels.Requests
{
    public class CreateAreaRequestModel
    {
        [Required]
        public string areaName {  get; set; }
    }
}
