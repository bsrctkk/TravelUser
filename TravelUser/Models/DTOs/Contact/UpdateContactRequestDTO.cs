namespace TravelUser.Models.DTOs.Contact
{
    public class UpdateContactRequestDTO
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public int WebUserId { get; set; }
    }
}
