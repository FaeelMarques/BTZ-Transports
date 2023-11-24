using BTZTransports.Application.Data;
using BTZTransports.Application.Models;
using BTZTransports.Application.Repositories.Interfaces;

namespace BTZTransports.Application.Repositories
{
    public class DriverRepository : IDriverRepository, IDisposable
    {
        protected readonly IdentityApplicationContext _context;

        public DriverRepository(IdentityApplicationContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Driver> GetAll()
        {
            return _context.Drivers.ToList();
        }

        public Driver GetById(int id)
        {
            return _context.Drivers.First(d => d.Id == id);
        }

        public void Insert(Driver driver)
        {
            _context.Add(driver);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            Driver driver = _context.Drivers.First(d => d.Id == id);

            _context.Remove(driver);
            _context.SaveChanges();
        }

        public void Update(Driver driver)
        {
            _context.Update(driver);
            _context.SaveChanges();
        }
    }
}
