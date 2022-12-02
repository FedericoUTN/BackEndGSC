using AutoMapper;
using LoadApi.Entities;
using LoanAPI.DataAccess;
using LoanAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace LoanAPI.Controllers
{
    public class ThingController : Controller
    {
        private readonly IUnityOfWork uow;
        private readonly ILogger<ThingController> logger;
        private readonly IMapper mapper;
        

        public ThingController(
            ILogger<ThingController> logger,
            IUnityOfWork uow,
            IMapper mapper
            )
        {
            this.logger = logger;
            this.uow = uow;
            this.mapper = mapper;
            
        }

        public async Task<IActionResult> Index()
        {
            var thingDtoList = new List<ThingDTOViewModel>();
            var dbThings = await uow.ThingRepository.GetAllAsync();
            foreach (var thing in dbThings)
            {
                var temp = mapper.Map<ThingDTOViewModel>(thing);
                thingDtoList.Add(temp);
            }
            return View(thingDtoList);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var thing = await uow.ThingRepository.GetByIdAsync(id.Value);
            if(thing == null)
                return NotFound(thing);

            return View(mapper.Map<ThingDTOViewModel>(thing));
        }
        public async Task<IActionResult> Create()
        {
            var lista = await uow.CategoryRepository.GetAllAsync();
            ViewData["Categorias"] = new SelectList(lista, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ThingDTOViewModel thingViewModel)
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

            var entity = mapper.Map<Thing>(thingViewModel);
            entity.CategoryId = 1;
            uow.ThingRepository.Add(entity);
            await uow.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id) 
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
            return View(mapper.Map<ThingDTOViewModel>(thing));
        }

        [HttpPost] 
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit(int id, ThingDTOViewModel thingViewModel)
        {
            var lista = await uow.CategoryRepository.GetAllAsync();
            ViewData["Categorias"] = new SelectList(lista, "Id", "Description");
            if (id != thingViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                uow.ThingRepository.Update(mapper.Map<Thing>(thingViewModel));
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

            return View(mapper.Map<ThingDTOViewModel>(thing));
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
