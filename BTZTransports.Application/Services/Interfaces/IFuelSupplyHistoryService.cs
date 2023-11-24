using BTZTransports.Application.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTZTransports.Application.Services.Interfaces
{
    public interface IFuelSupplyHistoryService
    {
        List<FuelSupplyHistory> GetAll();
        void Insert(FuelSupplyHistory fuelSupplyHistory);

        List<SelectListItem> GenerateDriversSelectList();
        List<SelectListItem> GenerateVehicleSelectList();
        List<SelectListItem> GenerateFuelTypeSelectList();
    }
}
