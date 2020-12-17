using WebApplication11.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication11.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : Controller
    {
        ApplicationContext db;
        public RoleController(ApplicationContext context)
        {
            db = context;
            if (!db.Roles.Any())
            {
                db.Roles.Add(new Role { Name = "Manager" });
            }
        }

        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return db.Roles.ToList();
        }

        [HttpGet("{id}")]
        public Role Get(int id)
        {
            Role role = db.Roles.FirstOrDefault(x => x.Id == id);
            return role;
        }

        [HttpPost]
        public IActionResult Post(Role role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return Ok(role);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Role role)
        {
            if (ModelState.IsValid)
            {
                db.Update(role);
                db.SaveChanges();
                return Ok(role);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            Role role = db.Roles.FirstOrDefault(x => x.Id == id);
            if( role != null)
            {
                db.Remove(role);
                db.SaveChanges();
              
            }
            return Ok(role);
        }
    }
}
