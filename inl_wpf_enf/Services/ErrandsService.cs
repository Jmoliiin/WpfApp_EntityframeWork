using inl_wpf_enf.Data;
using inl_wpf_enf.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inl_wpf_enf.Services
{
    internal interface IErrandsService
    {
        bool Create( string heading,string description, int statusId, int adminId,int CostumerId);
        void Save();
        IEnumerable<Errand> GetAll();
    }
    internal class ErrandsService : IErrandsService
    {
        private readonly SqlContext _context = new SqlContext();

    public bool Create(string heading, string description, int statusId, int adminId, int costumerId)
        {
            //kontrollera vilken kund som ärrendet ska läggas på
            var _costumer = _context.Costumers.Where(x=>x.Id==costumerId).FirstOrDefault();
            if(_costumer != null)
            {
                _context.Errands.Add(new Errand { Heading = heading, Descriptions = description, DateCreated = DateTime.Now, CostumerId=_costumer.Id, AdminsId=adminId,SatusId=statusId});
                _context.SaveChanges();
                return true;
            }
                return false;
        }

        public IEnumerable<Errand> GetAll()
        {

            return _context.Errands.Include(x=>x.Satus).Include(x=>x.Costumer).ToList(); 
        }
        public void Save()
        {            
            _context.SaveChanges();            
        }
    }
}
