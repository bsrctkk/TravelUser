namespace TravelUser.Models.DTOs.Contact
{
    public class GetContactByIdResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public string Email { get; set; }
    }
}
