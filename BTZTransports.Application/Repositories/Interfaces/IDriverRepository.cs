using BTZTransports.Application.Models;

namespace BTZTransports.Application.Repositories.Interfaces
{
    public interface IDriverRepository
    {
        List<Driver> GetAll();
        Driver GetById(int id);
        void Insert(Driver driver);
        void Update(Driver driver);
        void Remove(int id);
    }
}
