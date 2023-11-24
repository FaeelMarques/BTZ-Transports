using BTZTransports.Application.Data;
using BTZTransports.Application.Models;
using BTZTransports.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTZTransports.Application.Controllers
{
    [Authorize]
    public class DriversController : Controller
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverSerice)
        {
            _driverService = driverSerice;
        }

        public IActionResult Index()
        {
            List<Driver> drivers = _driverService.GetAll();

            return View(drivers);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver driver = _driverService.GetById(id.Value);

            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _driverService.Insert(driver);
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver driver = _driverService.GetById(id.Value);

            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Driver driver)
        {
            if (id != driver.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _driverService.Update(driver);

                }
                catch (DbUpdateConcurrencyException)
                {
                    Driver selectedDriver = _driverService.GetById(driver.Id);

                    if (selectedDriver == null)
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
            return View(driver);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver driver = _driverService.GetById(id.Value);

            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _driverService.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
