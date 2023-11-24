using BTZTransports.Application.Models;
using BTZTransports.Application.Repositories.Interfaces;
using BTZTransports.Application.Services.Interfaces;

namespace BTZTransports.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
                _vehicleRepository = vehicleRepository;
        }

        public List<Vehicle> GetAll()
        {
            return _vehicleRepository.GetAll();
        }

        public Vehicle GetById(int id)
        {
            return _vehicleRepository.GetById(id);
        }

        public void Insert(Vehicle vehicle)
        {
            _vehicleRepository.Insert(vehicle);
        }

        public void Remove(int id)
        {
            _vehicleRepository.Remove(id);
        }

        public void Update(Vehicle vehicle)
        {
            _vehicleRepository.Update(vehicle);
        }
    }
}
