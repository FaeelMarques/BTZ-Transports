using BTZTransports.Application.Models;

namespace BTZTransports.Application.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll();
        Vehicle GetById(int id);
        void Insert(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Remove(int id);
    }
}
