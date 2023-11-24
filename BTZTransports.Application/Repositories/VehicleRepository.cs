using BTZTransports.Application.Data;
using BTZTransports.Application.Models;
using BTZTransports.Application.Repositories.Interfaces;

namespace BTZTransports.Application.Repositories
{
    public class VehicleRepository : IVehicleRepository, IDisposable
    {
        protected readonly IdentityApplicationContext _context;

        public VehicleRepository(IdentityApplicationContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Vehicle> GetAll()
        {
            return _context.Vehicles.ToList();
        }

        public Vehicle GetById(int id)
        {
            return _context.Vehicles.First(v => v.Id == id);
        }

        public void Insert(Vehicle vehicle)
        {
            _context.Add(vehicle);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            Vehicle vehicle = _context.Vehicles.First(v => v.Id == id);

            _context.Remove(vehicle);
            _context.SaveChanges();
        }

        public void Update(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }
    }
}
