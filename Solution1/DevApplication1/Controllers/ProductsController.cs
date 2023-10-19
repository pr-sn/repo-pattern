using DevApplication1.Models;
using DevApplication1.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace DevApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo repo;
        public ProductController(IProductRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await repo.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Product Product)
        {
            await repo.InsertAsync(Product);
            await repo.CompleteAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await repo.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product Product)
        {
            await repo.UpdateAsync(Product);
            await repo.CompleteAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {

            return View(await repo.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product Product)
        {

            await repo.DeleteAsync(Product);
            await repo.CompleteAsync();
            return RedirectToAction("Index");
        }

    }
}
