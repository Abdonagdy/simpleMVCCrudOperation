using MvcCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MvcCore.Controllers
{
	public class UsersController : Controller
	{
		private readonly Context _context;

		public UsersController(Context context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View(_context.Users.ToList());
		}
		public IActionResult Details(int id)
		{
			try
			{
				return View(_context.Users.FirstOrDefault(c=>c.Id==id));
			}catch (Exception ex)
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
		public IActionResult New(Users user )
		{
			try
			{
				_context.Users.Add(user);
				_context.SaveChanges();
				return RedirectToAction("Index");

			}catch(Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(user);
			}
			
		}
		public IActionResult Edite(int id) 
		{
			try
			{
				return View(_context.Users.FirstOrDefault(c => c.Id == id));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(id);
			}
		}
		[HttpPost]
		public IActionResult Edite(Users user)
		{
		
			try
			{
				_context.Users.Update(user);	
				_context.SaveChanges();
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(user);
			}
		}
		public IActionResult Delete(int id)
		{
			try
			{
				var pro= _context.Users.FirstOrDefault(c => c.Id == id);
				_context.Users.Remove(pro);
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
