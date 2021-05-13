using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleDb db;
        public PeopleController(PeopleDb db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var people = db.People.ToList();
            return Ok(people);
        }
        [HttpPost]
        public async Task<ActionResult<PeopleDb>> Post(Person people)
        {
            await db.People.AddAsync(people);
            await db.SaveChangesAsync();

            return Ok(people);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Person people)
        {
            if (id != people.Id)
            {
                return BadRequest();
            }

            db.Entry(people).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool TodoItemExists(long id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PeopleDb>> Get(int id)
        {
            var people = await db.People.FindAsync(id);

            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var people = await db.People.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            db.People.Remove(people);
            await db.SaveChangesAsync();

            return NoContent();
        }

    }
}
