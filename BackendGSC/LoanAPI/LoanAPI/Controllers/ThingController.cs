using LoadApi.Entities;
using LoanAPI.DataAccess;
using LoanAPI.Extensions;
using LoanAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
//TO VIEW MODEL Y OTRAS FUNCIONES DE MAPPEADO REACER CON AUTOMAPPER
namespace LoanAPI.Controllers
{
    public class ThingController : Controller
    {
        private readonly IUnityOfWork uow;
        private readonly ILogger<ThingController> logger;

        public ThingController(ILogger<ThingController> logger, IUnityOfWork uow)
        {
            this.logger = logger;
            this.uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            var dbThings = await uow.ThingRepository.GetAllAsync();
            var viewModel = dbThings.ToViewModels();
            return View(viewModel);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var thing = await uow.ThingRepository.GetByIdAsync(id.Value);
            if(thing == null)
                return NotFound(thing);

            return View(thing.ToViewModel());
        }
        public async Task<IActionResult> Create()
        {
            var lista = await uow.CategoryRepository.GetAllAsync();
            ViewData["Categorias"] = new SelectList(lista, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ThingViewModel thingViewModel)
        {
            var lista = await uow.CategoryRepository.GetAllAsync();
            ViewData["Categorias"] = new SelectList(lista, "Id", "Description");

            if (!ModelState.IsValid)
                return View("Create", thingViewModel);

            var list = await uow.ThingRepository.GetAllAsync();
            if (list.Any(t => t.Description == thingViewModel.Description))
            {
                ModelState.AddModelError(String.Empty, "Ya existe una cosa con esta descripcion.");
                return View(thingViewModel);
            }

            var entity = thingViewModel.ToEntity();
            entity.CategoryId = 1;
            uow.ThingRepository.Add(entity);
            await uow.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id) //La accion se llama Edit, pero es un GET? Como es eso?
        {
            var lista = await uow.CategoryRepository.GetAllAsync();
            ViewData["Categorias"] = new SelectList(lista, "Id", "Description");
            if (id == null)
            {
                return NotFound();
            }

            var thing = await uow.ThingRepository.GetByIdAsync(id.Value);
            if (thing == null)
            {
                return NotFound();
            }
            return View(thing.ToViewModel());
        }

        [HttpPost] 
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit(int id, ThingViewModel thingViewModel)
        {
            var lista = await uow.CategoryRepository.GetAllAsync();
            ViewData["Categorias"] = new SelectList(lista, "Id", "Description");
            if (id != thingViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                uow.ThingRepository.Update(thingViewModel.ToEntity());
                await uow.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thingViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var thing = await uow.ThingRepository.GetByIdAsync(id.Value);
            if (thing == null)
            {
                return NotFound();
            }

            return View(thing.ToViewModel());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thing = await uow.ThingRepository.GetByIdAsync(id);
            if (thing is null)
            {
                return NotFound();
            }

            await uow.ThingRepository.DeleteAsync(thing.Id);
            await uow.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
