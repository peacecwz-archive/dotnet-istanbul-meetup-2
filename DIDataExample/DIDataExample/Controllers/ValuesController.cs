using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIDataExample.Entities;
using DIDataExample.Entities.Tables;
using DIDataExample.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DIDataExample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IPersonRepository personRepository;
        public ValuesController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return personRepository.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return personRepository.GetById<int>(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Person value)
        {
            if (personRepository.Add(value))
                return Ok();

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person value)
        {
            if (personRepository.Update(value))
                return Ok();

            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = personRepository.GetById<int>(id);
            if (person == null) return NotFound();
            if (personRepository.Add(person))
                return Ok();

            return BadRequest();
        }
    }
}
