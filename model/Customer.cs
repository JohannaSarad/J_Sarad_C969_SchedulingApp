using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_Sarad_C969_SchedulingApp.model
{
    class Customer
    {
        //public int CurrentCustomerIndex = -1;
        public int ID { get; set; }
        public string Name { get; set; } 
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Customer(int id, string name, string phone, string address, string city, string country)
        {
            ID = id;
            Name = name;
            Phone = phone;
            Address = address;
            City = city;
            Country = country;
        }
    }
}
