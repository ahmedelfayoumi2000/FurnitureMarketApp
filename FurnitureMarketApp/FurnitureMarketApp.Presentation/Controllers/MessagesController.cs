using FurnitureMarketApp.Application.DTOs;
using FurnitureMarketApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureMarketApp.Presentation.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _messageService.GetAllAsync();
            return View(messages);
        }

        public async Task<IActionResult> Details(int id)
        {
            var message = await _messageService.GetByIdAsync(id);
            if (message == null) return NotFound();
            return View(message);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MessageDto dto)
        {
            if (ModelState.IsValid)
            {
                await _messageService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var message = await _messageService.GetByIdAsync(id);
            if (message == null) return NotFound();
            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MessageDto dto)
        {
            if (ModelState.IsValid)
            {
                await _messageService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var message = await _messageService.GetByIdAsync(id);
            if (message == null) return NotFound();
            return View(message);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _messageService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
