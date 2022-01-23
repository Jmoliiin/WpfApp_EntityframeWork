using inl_wpf_enf.Data;
using inl_wpf_enf.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inl_wpf_enf.Services
{
    internal interface ICostumerService
    {
        bool Create(string firstname, string lastname, string email,string mobilenumber, string streetName, string postalCode, string city, string country);
        IEnumerable<Costumer> GetAll();
    }
    internal class CostumerServices : ICostumerService
    {
        private readonly SqlContext _context = new SqlContext();
        public bool Create(string firstname, string lastname, string email, string mobilenumber, string streetName, string postalCode,string city,string country)
        {

            //ko9lla om användaren finns
            var _user = _context.Costumers.Where(x => x.Email == email).FirstOrDefault();
            //om den är null och inte finns
            if (_user == null)
            {
                //kontrollera om adressen finns
                var address = _context.Addresses
                    .Where(x => x.StreetName == streetName && x.PostalCode == postalCode && x.Country==country)
                    .FirstOrDefault();
                if (address == null) //om adressen inte finns lägg till en ny
                {
                    address = new Address() { StreetName = streetName, PostalCode = postalCode, City = city, Country=country };
                    _context.Addresses.Add(address);
                    _context.SaveChanges();
                }
                //Lägg in costumer med adressId
                _context.Costumers.Add(new Costumer { FirstName = firstname, LastName = lastname,MobileNumber=mobilenumber, Email = email, AddressId = address.Id });
                _context.SaveChanges();
                return true;
            }
            return false;

        }
        public IEnumerable<Costumer> GetAll()
        {
            //returnera lista på alla user och adress??????
            return _context.Costumers.Include(x => x.Address).ToList(); 
        }
    }
}
