using FurnitureMarketApp.Application.DTOs;
using FurnitureMarketApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureMarketApp.Presentation.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        public async Task<IActionResult> Index()
        {
            var favorites = await _favoriteService.GetAllAsync();
            return View(favorites);
        }

        public async Task<IActionResult> Details(int id)
        {
            var favorite = await _favoriteService.GetByIdAsync(id);
            if (favorite == null) return NotFound();
            return View(favorite);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FavoriteDto dto)
        {
            if (ModelState.IsValid)
            {
                await _favoriteService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var favorite = await _favoriteService.GetByIdAsync(id);
            if (favorite == null) return NotFound();
            return View(favorite);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FavoriteDto dto)
        {
            if (ModelState.IsValid)
            {
                await _favoriteService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var favorite = await _favoriteService.GetByIdAsync(id);
            if (favorite == null) return NotFound();
            return View(favorite);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _favoriteService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
