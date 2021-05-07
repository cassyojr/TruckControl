using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TruckControl.Models;

namespace TruckControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITruckService _truckService;

        public HomeController(
            IMapper mapper,
            ITruckService truckService)
        {
            _mapper = mapper;
            _truckService = truckService;
        }

        public async Task<IActionResult> Index()
        {
            var trucks = await _truckService.GetTrucksAsync();
            var trucksViewModel = _mapper.Map<IList<TruckViewModel>>(trucks);

            return View(trucksViewModel);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateTruckModelsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterTruckViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateTruckModelsDropDownList(model.TruckModelId);
                return View(model);
            }

            try
            {
                var truck = _mapper.Map<Truck>(model);
                await _truckService.AddTruckAsync(truck);
            }
            catch (Exception) { }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0) return NotFound();

            var truck = await _truckService.GetTruckByIdAsync(id);

            if (truck == null) return NotFound();

            await PopulateTruckModelsDropDownList(truck.TruckModelId);
            
            var trucksViewModel = _mapper.Map<RegisterTruckViewModel>(truck);

            return View(trucksViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegisterTruckViewModel model)
        {
            if (id == 0) return NotFound();

            if (!ModelState.IsValid)
            {
                await PopulateTruckModelsDropDownList(model.TruckModelId);
                return View(model);
            }

            var truck = await _truckService.GetTruckByIdAsync(id);

            if (truck == null) return NotFound();

            try
            {
                var truckToUpdate = _mapper.Map<Truck>(model);
                await _truckService.UpdateTruckAsync(id, truckToUpdate);
            }
            catch (Exception) { }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return NotFound();

            var truck = await _truckService.GetTruckByIdAsync(id);

            if (truck == null) return NotFound();

            var truckViewModel = _mapper.Map<TruckViewModel>(truck);
            return View(truckViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == 0) return NotFound();

            var truck = await _truckService.GetTruckByIdAsync(id);

            if (truck == null) return RedirectToAction(nameof(Index));

            try
            {
                await _truckService.DeleteTruckAsync(id);
            }
            catch (Exception) { }

            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task PopulateTruckModelsDropDownList(object selectedDepartment = null)
        {
            var truckModels = await _truckService.GetTruckModelsAsync();
            ViewBag.TruckModels = new SelectList(truckModels, "TruckModelId", "Name", selectedDepartment);
        }
    }
}
