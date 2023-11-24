using BTZTransports.Application.Models;

namespace BTZTransports.Application.Services.Interfaces
{
    public interface IDriverService
    {
        List<Driver> GetAll();
        Driver GetById(int id);
        void Insert(Driver driver);
        void Update(Driver driver);
        void Remove(int id);

    }
}
