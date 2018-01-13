using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIExample.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DIExample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IDIService service;
        public ValuesController(IDIService service)
        {
            this.service = service;
        }

        // GET api/values
        [HttpGet]
        public Guid Get()
        {
            return service.Id;
        }

        [HttpGet("create")]
        public void Create()
        {
            service.Create();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
