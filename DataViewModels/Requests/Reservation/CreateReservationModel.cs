using System.ComponentModel.DataAnnotations;

namespace DataViewModels.Requests
{
    public class CreateReservationModel
    {
        public Guid id { get; set; }
        public DateTime orderDate { get; set; } = DateTime.Now.AddHours(1);
        public Guid restaurantId { get; set; }
        public string? memberId { get; set; }
        public int countCustomer { get; set; } = 2;
        [Required]
        public string customerName { get; set; } = string.Empty;
        [Required]
        public string customerPhone { get; set; } = string.Empty;
        public string customerEmail { get; set; } = string.Empty;
        public string orderNote { get; set; } = "Không có";

    }
}
