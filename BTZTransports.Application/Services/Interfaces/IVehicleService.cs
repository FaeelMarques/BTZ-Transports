using BTZTransports.Application.Models;

namespace BTZTransports.Application.Services.Interfaces
{
    public interface IVehicleService
    {
        List<Vehicle> GetAll();
        Vehicle GetById(int id);
        void Insert(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Remove(int id);
    }
}
