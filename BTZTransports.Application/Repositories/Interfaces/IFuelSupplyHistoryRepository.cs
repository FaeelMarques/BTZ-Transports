using BTZTransports.Application.Models;

namespace BTZTransports.Application.Repositories.Interfaces
{
    public interface IFuelSupplyHistoryRepository
    {
        List<FuelSupplyHistory> GetAll();
        void Insert(FuelSupplyHistory repository);
    }
}
