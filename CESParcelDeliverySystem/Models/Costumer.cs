using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Costumer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }

        public Costumer(string name, string phoneNumber, string email, string companyName, string companyNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.CompanyName = companyName;
            this.CompanyNumber = companyNumber;
        }
    }
}