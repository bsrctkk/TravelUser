using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelUser.Context;
using TravelUser.Models.DTOs.Contact;
using TravelUser.Models.ORM;



namespace TravelUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        MyContext context;
        public ContactController()
        {
            context = new MyContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllContactResponseDTO> response = context.Contacts.Include("WebUser").Select(c => new GetAllContactResponseDTO
            {
                Id = c.Id,
                Title = c.Title,
                Message = c.Message,
                Email = c.WebUser.Email
            }).ToList();
            if (response.Count != 0)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("Data not found");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Contact contact = context.Contacts.Include("WebUser").FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound(id + " User with id not found");
            }
            else
            {
                GetContactByIdResponseDTO response = new GetContactByIdResponseDTO();
                response.Id = contact.Id;
                response.Title = contact.Title;
                response.Message = contact.Message;
                response.Email = contact.WebUser.Email;
                return Ok(response);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateContactRequestDTO request)
        {
            Contact contact = new Contact();
            contact.Title = request.Title.ToLower();
            contact.Message = request.Message.ToLower();
            contact.WebUserId = request.WebUserId;
            context.Contacts.Add(contact);
            context.SaveChanges();
            return Ok(request);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateContactRequestDTO Contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not A valid data");
            }
            var existingContact = context.Contacts.Where(p => p.Id == id).FirstOrDefault<Contact>();
            if (existingContact != null)
            {
                existingContact.Title = Contact.Title;
                existingContact.Message = Contact.Message;
                existingContact.WebUserId = Contact.WebUserId;
                context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            List<GetAllContactResponseDTO> response = context.Contacts.Include("WebUser").Select(c => new GetAllContactResponseDTO
            {
                Id = c.Id,
                Title = c.Title,
                Message = c.Message,
                Email = c.WebUser.Email
            }).ToList();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Contact contact = context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
                return Ok("Deleted");
            }
            else
                return NotFound("User with id not found");
        }
    }
}
