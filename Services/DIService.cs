using System;
using DIExample.Interfaces;

namespace DIExample.Services
{
    public class DIService : IDIService
    {

        public Guid Id { get; set; }
        public void Create()
        {
            this.Id = Guid.NewGuid();
        }
    }
}