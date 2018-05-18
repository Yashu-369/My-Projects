using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int PrivilegeId { get; set; }
        internal void UpdateValues(Customer customer)
        {
            this.Email = customer.Email;
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.PasswordHash = customer.PasswordHash;
            this.Salt = customer.Salt;
            this.PrivilegeId = customer.PrivilegeId;
        }
    }
}
