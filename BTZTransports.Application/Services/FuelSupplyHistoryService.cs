using BTZTransports.Application.Models;
using BTZTransports.Application.Repositories.Interfaces;
using BTZTransports.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTZTransports.Application.Services
{
    public class FuelSupplyHistoryService : IFuelSupplyHistoryService
    {
        private readonly IFuelSupplyHistoryRepository _supplyRepository;
        private readonly IDriverService _driverService;
        private readonly IVehicleService _vehicleService;

        public FuelSupplyHistoryService(IFuelSupplyHistoryRepository supplyRepository,
            IDriverService driverService,
            IVehicleService vehicleService)
        {
            _supplyRepository = supplyRepository;
            _driverService = driverService;
            _vehicleService = vehicleService;
        }

        public List<SelectListItem> GenerateDriversSelectList()
        {
            List<Driver> drivers = _driverService.GetAll().Where(d => d.Active).ToList();

            List<SelectListItem> listSelectItems = new List<SelectListItem>();

            listSelectItems.Add(new SelectListItem
            {
                Text = "Selecione...",
                Value = "",
                Selected = true
            });

            foreach (var driver in drivers)
            {
                listSelectItems.Add(new SelectListItem
                {
                    Text = driver.Name,
                    Value = driver.Id.ToString(),
                    Selected = false
                });
            }
            return listSelectItems;
        }

        public List<SelectListItem> GenerateVehicleSelectList()
        {
            List<Vehicle> vehicles = _vehicleService.GetAll();

            List<SelectListItem> listSelectItems = new List<SelectListItem>();

            listSelectItems.Add(new SelectListItem
            {
                Text = "Selecione...",
                Value = "",
                Selected = true
            });

            foreach (var vehicle in vehicles)
            {
                listSelectItems.Add(new SelectListItem
                {
                    Text = vehicle.Name,
                    Value = vehicle.Id.ToString(),
                    Selected = false
                });
            }
            return listSelectItems;
        }

        public List<SelectListItem> GenerateFuelTypeSelectList()
        {
            List<SelectListItem> listSelectItems = new List<SelectListItem>();

            listSelectItems.Add(new SelectListItem
            {
                Text = "Selecione...",
                Value = "",
                Selected = true
            });

            listSelectItems.Add(new SelectListItem
            {
                Text = "Gasolina",
                Value = "0",
                Selected = true
            });

            listSelectItems.Add(new SelectListItem
            {
                Text = "Etanol",
                Value = "1",
                Selected = true
            });

            listSelectItems.Add(new SelectListItem
            {
                Text = "Díesel",
                Value = "2",
                Selected = true
            });

            return listSelectItems;
        }

        public List<FuelSupplyHistory> GetAll()
        {
            return _supplyRepository.GetAll();
        }

        public void Insert(FuelSupplyHistory fuelSupplyHistory)
        {
            if (fuelSupplyHistory.DriverId == 0 || fuelSupplyHistory.VehicleId == 0)
            {
                throw new Exception("Associate a valid driver/vehicle");
            }

            Vehicle vehicle = _vehicleService.GetById(fuelSupplyHistory.VehicleId);

            if (fuelSupplyHistory.FuelType != vehicle.FuelType)
            {
                throw new Exception("The vehicle don't accept this type of fuel");
            }

            if (fuelSupplyHistory.QuantitySupplied > vehicle.FuelCapacity)
            {
                throw new Exception("It's not possible to supply over vehicle fuel capacity!");
            }

            fuelSupplyHistory.TotalValueSupplied = CalculateTotalValueSuplied(vehicle.FuelType, fuelSupplyHistory.QuantitySupplied);

            _supplyRepository.Insert(fuelSupplyHistory);

        }

        private static double CalculateTotalValueSuplied(FuelType fuelType, double totalValueSupplied)
        {
            double fuelBaseValue = 0.0;

            switch (fuelType)
            {
                case FuelType.Gasolina:
                    fuelBaseValue = 4.29;
                    break;
                case FuelType.Etanol:
                    fuelBaseValue = 2.99;
                    break;

                case FuelType.Diesel:
                    fuelBaseValue = 2.09;
                    break;
            }
            double totalValue = totalValueSupplied * fuelBaseValue;

            return Math.Round(totalValue, 2);
        }
    }
}