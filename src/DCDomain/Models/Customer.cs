using System;

namespace DCDomain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        protected Customer() { }

        public string Name { get; private set; }

        public string Email { get; private set; }
    }
}