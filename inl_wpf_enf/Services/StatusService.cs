using inl_wpf_enf.Data;
using inl_wpf_enf.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inl_wpf_enf.Services
{
    internal interface IStatusService
    {
        void CreateStatus( string stustype);
        IEnumerable<Status> GetAll();
    }
    internal class StatusService : IStatusService
    {
        private readonly SqlContext _context = new SqlContext();

        public void CreateStatus(string stustype)
        {
            var name = _context.Statuses.Where(x => x.StatusType == stustype).FirstOrDefault();
            if (name == null)
            {
                _context.Statuses.Add(new Status { StatusType = stustype });
                _context.SaveChanges();
            }
            
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.Statuses;
        }

    }
}
