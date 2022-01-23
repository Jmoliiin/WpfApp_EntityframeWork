using inl_wpf_enf.Data;
using inl_wpf_enf.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inl_wpf_enf.Services
{
    internal interface IAdminsService
    {
        bool Create(string firstName, string lastName);
        IEnumerable<Admin> GetAll();
    }
    internal class AdminsService : IAdminsService
    {
        private readonly SqlContext _context = new SqlContext();
        public bool Create(string firstName, string lastName)
        {
            var name = _context.Admins.Where(x => x.FirstName == firstName && x.LastName==lastName).FirstOrDefault();
            if (name == null)
            {
                _context.Admins.Add(new Admin { FirstName = firstName,LastName=lastName });
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Admin> GetAll()
        {
            return _context.Admins;
        }
    }
}
