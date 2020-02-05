using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
