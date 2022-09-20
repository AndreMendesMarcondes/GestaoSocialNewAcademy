using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GSNA.View.Models;
using GSNA.Domain.Interfaces.Services;
using GSNA.Domain.DTO;

namespace GSNA.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _log;
        private readonly IInstagramDetailsService _service;

        public HomeController(ILogger<HomeController> log,
                             IInstagramDetailsService service)
        {
            _log = log;
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAll();
            return View(list);
        }

        public async Task<IActionResult> Details(string id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InstagramDetailsDTO instagramDetailsDTO)
        {
            await _service.Insert(instagramDetailsDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var instagramDetails = await _service.GetById(id);
            if (instagramDetails == null)
            {
                return NotFound();
            }
            return View(instagramDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, InstagramDetailsDTO instagramDetailsDTO)
        {
            if (ModelState.IsValid)
            {

                await _service.Update(id, instagramDetailsDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(instagramDetailsDTO);
        }

        public async Task<IActionResult> Delete(string? id)
        {
            var instagramDetailsDTO = await _service.GetById(id);
            if (instagramDetailsDTO == null)
            {
                return NotFound();
            }

            return View(instagramDetailsDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var instagramDetailsDTO = await _service.GetById(id);
            if (instagramDetailsDTO != null)
            {
                await _service.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
