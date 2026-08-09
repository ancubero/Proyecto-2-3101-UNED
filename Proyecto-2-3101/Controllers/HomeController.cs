using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto_2_3101.Extensions;
using Proyecto_2_3101.Filters;
using Proyecto_2_3101.Models;
using Proyecto_2_3101.Services;

namespace Proyecto_2_3101.Controllers;

public class HomeController(ILoginService loginService) : Controller
{
    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(LoginModel loginModel)
    {
        if (!ModelState.IsValid)
        {
            return View(loginModel);
        }

        try
        {
            var user = await loginService.LoginAsync(loginModel);
            HttpContext.Session.SetUser(user);
            return RedirectToAction("Dashboard", "Home");
        } catch (Exception e)
        {
            ViewBag.ErrorMessage = e.Message;
        }
        
        return View();
    }


    [ValidateSession]
    public IActionResult Dashboard()
    {
        ViewData["Title"] = "Dashboard";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}