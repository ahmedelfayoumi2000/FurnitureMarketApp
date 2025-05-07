using FurnitureMarketApp.Application.DTOs;
using FurnitureMarketApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureMarketApp.Presentation.Controllers
{
    public class OffersController : Controller
    {
        private readonly IOfferService _offerService;

        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<IActionResult> Index()
        {
            var offers = await _offerService.GetAllAsync();
            return View(offers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var offer = await _offerService.GetByIdAsync(id);
            if (offer == null) return NotFound();
            return View(offer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OfferDto dto)
        {
            if (ModelState.IsValid)
            {
                await _offerService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var offer = await _offerService.GetByIdAsync(id);
            if (offer == null) return NotFound();
            return View(offer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OfferDto dto)
        {
            if (ModelState.IsValid)
            {
                await _offerService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var offer = await _offerService.GetByIdAsync(id);
            if (offer == null) return NotFound();
            return View(offer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _offerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
