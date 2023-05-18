namespace TravelUser.Models.DTOs.WebUser
{
    public class GetAllWebUserResponseDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }
    }
}
