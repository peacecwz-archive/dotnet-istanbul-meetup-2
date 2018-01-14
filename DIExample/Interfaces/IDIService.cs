using System;

namespace DIExample.Interfaces
{
    public interface IDIService
    {
        Guid Id{get;set;}

        void Create();
    }
}