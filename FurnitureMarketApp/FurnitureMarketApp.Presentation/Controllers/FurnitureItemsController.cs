using FurnitureMarketApp.Application.DTOs;
using FurnitureMarketApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureMarketApp.Presentation.Controllers
{
    public class FurnitureItemsController : Controller
    {
        private readonly IFurnitureItemService _furnitureItemService;

        public FurnitureItemsController(IFurnitureItemService furnitureItemService)
        {
            _furnitureItemService = furnitureItemService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _furnitureItemService.GetAllAsync();
            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _furnitureItemService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FurnitureItemDto dto)
        {
            if (ModelState.IsValid)
            {
                await _furnitureItemService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _furnitureItemService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FurnitureItemDto dto)
        {
            if (ModelState.IsValid)
            {
                await _furnitureItemService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _furnitureItemService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _furnitureItemService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
