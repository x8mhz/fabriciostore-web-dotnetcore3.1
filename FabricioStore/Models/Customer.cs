using System;

namespace FabricioStore.Models
{
    public class Customer
    {
        protected Customer() { }

        public Customer(string firstName, string lastName, string document, string email, string password)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Password = password;
        }


        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; } 
        public string Password { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} + {LastName}";
        }
    }
}