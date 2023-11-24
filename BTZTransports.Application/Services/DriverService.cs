using BTZTransports.Application.Models;
using BTZTransports.Application.Repositories.Interfaces;
using BTZTransports.Application.Services.Interfaces;

namespace BTZTransports.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public List<Driver> GetAll()
        {
           return _driverRepository.GetAll();
        }

        public Driver GetById(int id)
        {
            return _driverRepository.GetById(id);
        }

        public void Insert(Driver driver)
        {
            _driverRepository.Insert(driver);
        }

        public void Remove(int id)
        {
            _driverRepository.Remove(id);
        }

        public void Update(Driver driver)
        {
           _driverRepository.Update(driver);
        }
    }
}
