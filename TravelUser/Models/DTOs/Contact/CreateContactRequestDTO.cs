namespace TravelUser.Models.DTOs.Contact
{
    public class CreateContactRequestDTO
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public int WebUserId { get; set; }
    }
}
