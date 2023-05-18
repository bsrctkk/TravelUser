using Microsoft.AspNetCore.Mvc;
using System;
using TravelUser.Context;
using TravelUser.Models.DTOs.WebUser;
using TravelUser.Models.ORM;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebUserController : ControllerBase
    {
        MyContext context;
        public WebUserController()
        {
            context = new MyContext();
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
           List<GetAllWebUserResponseDTO> response=context.WebUsers.Select(x => new GetAllWebUserResponseDTO 
           {
               Id= x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Adress = x.Adress
           }).ToList();
            if (response.Count != 0)
            {
                return Ok(response);
            }
            else { return NotFound("Data not found"); }
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            WebUser webUser = context.WebUsers.FirstOrDefault(x => x.Id == id);
           if (webUser == null) 
            {
                return NotFound(id + " User with id not found");
            }
           else
            {
                GetWebUserByIdResponseDTO response=new GetWebUserByIdResponseDTO();
                response.Name = webUser.Name;
                response.Surname= webUser.Surname;
                response.Email= webUser.Email;
                response.Adress= webUser.Adress;
                return Ok(response);
            }
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] CreateWebUserRequestDTO request)
        {
            WebUser webUser=new WebUser();
            webUser.Name= request.Name.ToLower().Trim();
            webUser.Surname = request.Surname.ToLower().Trim();
            webUser.Email= request.Email.ToLower().Trim();
            webUser.Adress= request.Adress.ToLower();
            context.WebUsers.Add(webUser);
            context.SaveChanges();
            List<GetAllWebUserResponseDTO> response = context.WebUsers.Select(x => new GetAllWebUserResponseDTO
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Adress = x.Adress
            }).ToList();
            return Ok(response);
        }

      
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            WebUser webUser=context.WebUsers.FirstOrDefault(x => x.Id == id);
            if (webUser != null) 
            {
                context.WebUsers.Remove(webUser);
                context.SaveChanges();
                return Ok("Deleted");
            }
            else
            { 
                return NotFound("User with id not found"); 
            }
        }
    }
}
