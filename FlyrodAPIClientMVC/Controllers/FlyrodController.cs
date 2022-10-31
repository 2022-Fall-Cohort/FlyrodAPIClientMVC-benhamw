using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using FlyrodAPIClientMVC.Models;
using FlyrodAPIClientMVC.Services.Interfaces;

namespace FlyrodAPIClientMVC.Controllers
{
    public class FlyrodController : Controller
    {
        private IFlyrodService? _service;

        private static readonly HttpClient client = new HttpClient();

        private string requestUri = "https://localhost:7078/api/Flyrod/";

        public FlyrodController(IFlyrodService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Bill's API");
        }

        // Example: https://localhost:7256/api/Flyrod
        public async Task<IActionResult> Index()
        {
            var response = await _service.FindAll();

            return View(response);
        }

        // GET: Flyrod/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var flyrod = await _service.FindOne(id);
            if (flyrod == null)
            {
                return NotFound();
            }

            return View(flyrod);
        }

        // GET: Flyrod/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flyrod/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,LengthFeet,Sections,LineWeight,YearMade,Type,Construction,RodImage,MakerId")] Flyrod flyrod)
        {
            flyrod.Id = null;
            var resultPost = await client.PostAsync<Flyrod>(requestUri, flyrod, new JsonMediaTypeFormatter());

            return RedirectToAction(nameof(Index));
        }

        // GET: Flyrod/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var flyrod = await _service.FindOne(id);
            if (flyrod == null)
            {
                return NotFound();
            }

            return View(flyrod);
        }

        // POST: Flyrod/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,LengthFeet,Sections,LineWeight,YearMade,Type,Construction,RodImage,MakerId,Maker)")] Flyrod flyrod)
        {
            if (id != flyrod.Id)
            {
                return NotFound();
            }

            var resultPut = await client.PutAsync<Flyrod>(requestUri + flyrod.Id.ToString(), flyrod, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }

        // GET: Flyrod/Delete/5
        public async Task<IActionResult> Delete(int id)

        {
            var flyrod = await _service.FindOne(id);
            if (flyrod == null)
            {
                return NotFound();
            }

            return View(flyrod);
        }

        // POST: Flyrod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDelete = await client.DeleteAsync(requestUri + id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}
