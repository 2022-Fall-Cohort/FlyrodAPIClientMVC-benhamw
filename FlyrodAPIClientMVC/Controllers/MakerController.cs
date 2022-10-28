using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using FlyrodAPIClientMVC.Models;
using FlyrodAPIClientMVC.Services.Interfaces;

namespace FlyrodAPIClientMVC.Controllers
{
    public class MakerController : Controller
    {
        private IMakerService? _service;

        private static readonly HttpClient client = new HttpClient();

        private string requestUri = "https://localhost:7078/api/Maker/";

        public MakerController(IMakerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Bill's API");
        }

        // Example: https://localhost:7256/api/Maker
        public async Task<IActionResult> Index()
        {
            var response = await _service.FindAll();

            return View(response);
        }

        // GET: Maker/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var maker = await _service.FindOne(id);
            if (maker == null)
            {
                return NotFound();
            }

            return View(maker);
        }

        // GET: Maker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maker/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,YearFounded,Type")] Maker maker)
        {
            maker.Id = null;
            var resultPost = await client.PostAsync<Maker>(requestUri, maker, new JsonMediaTypeFormatter());

            return RedirectToAction(nameof(Index));
        }

        // GET: Maker/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var videoGame = await _service.FindOne(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // POST: Maker/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,StudioId, MainCharacterId")] Maker maker)
        {
            if (id != maker.Id)
            {
                return NotFound();
            }

            var resultPut = await client.PutAsync<Maker>(requestUri + maker.Id.ToString(), maker, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }

        // GET: Maker/Delete/5
        public async Task<IActionResult> Delete(int id)

        {
            var maker = await _service.FindOne(id);
            if (maker == null)
            {
                return NotFound();
            }

            return View(maker);
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
