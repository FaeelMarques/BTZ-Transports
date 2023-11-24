using BTZTransports.Application.Models;
using BTZTransports.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTZTransports.Application.Controllers
{
    [Authorize]
    public class FuelSupplyHistoryController : Controller
    {
        private readonly IFuelSupplyHistoryService _supplyService;

        public FuelSupplyHistoryController(IFuelSupplyHistoryService supplyService)
        {
            _supplyService = supplyService;
        }

        public IActionResult Index()
        {
            List<FuelSupplyHistory> supplies = _supplyService.GetAll();

            return View(supplies);
        }

        public IActionResult Create()
        {
            List<SelectListItem> driversSelectList = _supplyService.GenerateDriversSelectList();
            List<SelectListItem> vehiclesSelectList = _supplyService.GenerateVehicleSelectList();
            List<SelectListItem> fuelTypeSelectList = _supplyService.GenerateFuelTypeSelectList();

            ViewBag.fuelTypeSelectList = fuelTypeSelectList;
            ViewBag.driversSelectList = driversSelectList;
            ViewBag.vehiclesSelectList = vehiclesSelectList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FuelSupplyHistory fuelSupplyHistory)
        {
            try
            {
                _supplyService.Insert(fuelSupplyHistory);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                List<SelectListItem> driversSelectList = _supplyService.GenerateDriversSelectList();
                List<SelectListItem> vehiclesSelectList = _supplyService.GenerateVehicleSelectList();
                List<SelectListItem> fuelTypeSelectList = _supplyService.GenerateFuelTypeSelectList();

                ViewBag.ErrorMessage = ex.Message;
                ViewBag.fuelTypeSelectList = fuelTypeSelectList;
                ViewBag.driversSelectList = driversSelectList;
                ViewBag.vehiclesSelectList = vehiclesSelectList;

                return View(fuelSupplyHistory);
            }
        }
    }
}
