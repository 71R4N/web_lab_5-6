using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DilersController : ControllerBase
    {
        DilerContext db;
        public DilersController(DilerContext context)
        {
            db = context;
            if (!db.Diler.Any())
            {
                db.Diler.Add(new Models.Diler { Name = "Name1", City = "City1", Address = "Address1", Area = "Area1", Rating = 111.1f });
                db.Diler.Add(new Models.Diler { Name = "Name2", City = "City2", Address = "Address2", Area = "Area2", Rating = 222.2f });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Diler>>> Get()
        {
            return await db.Diler.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Diler>> Get(int id)
        {
            Models.Diler user = await db.Diler.FirstOrDefaultAsync(x => x.diler_id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Models.Diler>> Post(Models.Diler diler)
        {
            if (diler == null)
            {
                return BadRequest();
            }

            db.Diler.Add(diler);
            await db.SaveChangesAsync();
            return Ok(diler);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Models.Diler>> Put(Models.Diler diler)
        {
            if (diler == null)
            {
                return BadRequest();
            }
            if (!db.Diler.Any(x => x.diler_id == diler.diler_id))
            {
                return NotFound();
            }

            db.Update(diler);
            await db.SaveChangesAsync();
            return Ok(diler);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Diler>> Delete(int id)
        {
            Models.Diler diler = db.Diler.FirstOrDefault(x => x.diler_id == id);
            if (diler == null)
            {
                return NotFound();
            }
            db.Diler.Remove(diler);
            await db.SaveChangesAsync();
            return Ok(diler);
        }
    }
}
