using BTZTransports.Application.Data;
using BTZTransports.Application.Models;
using BTZTransports.Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BTZTransports.Application.Repositories
{
    public class FuelSupplyHistoryRepository : IFuelSupplyHistoryRepository, IDisposable
    {
        protected readonly IdentityApplicationContext _context;

        public FuelSupplyHistoryRepository(IdentityApplicationContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
           _context.Dispose();
        }

        public List<FuelSupplyHistory> GetAll()
        {
            return _context.FuelSupplyHistory.Include("Driver").Include("Vehicle").ToList();
        }

        public void Insert(FuelSupplyHistory fuelSupplyHistory)
        {
            _context.FuelSupplyHistory.Add(fuelSupplyHistory);
            _context.SaveChanges();
        }
    }
}
