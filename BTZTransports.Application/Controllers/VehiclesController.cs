using BTZTransports.Application.Models;
using BTZTransports.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BTZTransports.Application.Controllers
{
    [Authorize]
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            List<Vehicle> vehicles = _vehicleService.GetAll();
            return View(vehicles);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehicle vehicle = _vehicleService.GetById(id.Value);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        public IActionResult Create()
        {
            ViewBag.fuelTypeList = GenerateFuelTypeList();

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.Insert(vehicle);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            
            var vehicle = _vehicleService.GetById(id.Value);
            if (vehicle == null)
            {
                return NotFound();
            }

            ViewBag.fuelTypeList = GenerateFuelTypeList();

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _vehicleService.Update(vehicle);
                }
                catch (DbUpdateConcurrencyException)
                {
                    Vehicle selectedVehicle = _vehicleService.GetById(id);

                    if (selectedVehicle == null)
                    {
                        return NotFound();
                    }
                  
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehicle vehicle = _vehicleService.GetById(id.Value);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _vehicleService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private static List<SelectListItem> GenerateFuelTypeList()
        {

            List<SelectListItem> fuelTypeList = new List<SelectListItem>();

            fuelTypeList.Add(new SelectListItem
            {
                Text = "Selecione...",
                Value = "",
                Selected = true
            });

            fuelTypeList.Add(new SelectListItem
            {
                Text = "Gasolina",
                Value = "0",
                Selected = false
            });

            fuelTypeList.Add(new SelectListItem
            {
                Text = "Etanol",
                Value = "1",
                Selected = false
            });

            fuelTypeList.Add(new SelectListItem
            {
                Text = "Díesel",
                Value = "2",
                Selected = false
            });

            return fuelTypeList;
        }

    }
}
