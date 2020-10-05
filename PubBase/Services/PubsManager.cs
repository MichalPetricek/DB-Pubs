using PubBase.Models;
using PubBase.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubBase.Services
{
    public class PubsManager
    {
        private AppDbContext _db;

        public PubsManager(AppDbContext db)
        {
            _db = db;
        }
        public List<Pub> List(string name)
        {
            IQueryable<Pub> pubs = _db.Pubs;
            if (!String.IsNullOrEmpty(name)) pubs.Where(p => p.Name.Contains(name));
            return pubs.ToList();
        }
        public bool Create(Pub item)
        {
            try
            {
                _db.Pubs.Add(item);//1
                _db.Pubs.Add(new Pub { Name = item.Name, Address = item.Address });//2
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            } 
        }
        public Pub Read(int id)
        {
            return _db.Pubs.SingleOrDefault(p => p.Id == id);
        }
        public bool Delete(int id)
        {
            try
            {
                var pub = _db.Pubs.SingleOrDefault(p => p.Id == id);
                _db.Pubs.Remove(pub);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(int id, Pub item)
        {
            try
            {
                var pub = _db.Pubs.SingleOrDefault(p => p.Id == id);
                pub.Name = item.Name;
                pub.Address = item.Address;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
