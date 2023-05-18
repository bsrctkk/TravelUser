using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelUser.Models.ORM
{
    public class Contact
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        [MaxLength(250)]
        public string Message { get; set; }
        
        public int WebUserId { get; set; }

        public virtual WebUser WebUser { get; set; }
    }
}
