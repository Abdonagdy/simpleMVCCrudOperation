using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCore.Models;

namespace MvcCore.Controllers
{
    public class CategoryTaskController : Controller
    {
		private readonly Context _context;

		public CategoryTaskController(Context contex)
		{
			_context = contex;
		}

		public IActionResult Index()
		{
			return View(_context.CategoryTask.ToList());
		}
		public IActionResult Details(int id)
		{
			try
			{
				return View(_context.CategoryTask.FirstOrDefault(c => c.Id == id));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(id);
			}

		}
		public IActionResult New()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult New(CategoryTask cat)
		{
			try
			{
				_context.CategoryTask.Add(cat);
				_context.SaveChanges();
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(cat);
			}

		}
		public IActionResult Edite(int id)
		{
			try
			{
				return View(_context.CategoryTask.FirstOrDefault(c => c.Id == id));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(id);
			}
		}
		[HttpPost]
		public IActionResult Edite(CategoryTask cat)
		{

			try
			{
				_context.CategoryTask.Update(cat);
				_context.SaveChanges();
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(cat);
			}
		}
		public IActionResult Delete(int id)
		{
			try
			{
				var cat = _context.CategoryTask.FirstOrDefault(a=>a.Id == id);
				_context.CategoryTask.Remove(cat);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(id);
			}

		}
	}
}
