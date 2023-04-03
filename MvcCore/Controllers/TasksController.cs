using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCore.Models;
using TaskStatus = MvcCore.Models.TaskStatus;

namespace MvcCore.Controllers
{
	public class TasksController : Controller
	{
		private readonly Context _context;

		public TasksController(Context context)
		{
			_context = context;
		}

		public IActionResult Index(string? searchString,TaskStatus? statusFilter)
		{
			var tasks = _context.Tasks;

        if(!String.IsNullOrEmpty(searchString) && statusFilter.HasValue)
			{
				return View(tasks.Where(t => t.Name==searchString && t.Status==statusFilter.Value).ToList());
			}
		else if (!String.IsNullOrEmpty(searchString))
			{
				
				return View(tasks.Where(t => t.Name==searchString).ToList());
			}

		else if (statusFilter.HasValue)
			{
				 
				return View(tasks.Where(t => t.Status == statusFilter.Value).ToList());
			}
			else
			{ 
					return View(tasks.ToList());
			}
		}

		public IActionResult Details(int id)
		{
			try
			{
				return View(_context.Tasks.FirstOrDefault(c => c.Id == id));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(id);
			}

		}
		public IActionResult New()
		{
			ViewBag.Categories = _context.CategoryTask.ToList();
			ViewBag.Users = _context.Users.ToList();

			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult New(Tasks task)
		{
			try
			{
				_context.Tasks.Add(task);
				_context.SaveChanges();
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(task);
			}
		}
		public IActionResult Edite(int id)
		{
			ViewBag.Categories = _context.CategoryTask.ToList();
			ViewBag.Users = _context.Users.ToList();

			try
			{
				return View(_context.Tasks.FirstOrDefault(c => c.Id == id));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(id);
			}
		}
		[HttpPost]
		public IActionResult Edite(Tasks task)
		{
			try
			{
				_context.Tasks.Update(task);
				_context.SaveChanges();
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(task);
			}
		}
		public IActionResult Delete(int id)
		{
			try
			{
				var task = _context.Tasks.FirstOrDefault(c => c.Id == id);
				_context.Tasks.Remove(task);
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
