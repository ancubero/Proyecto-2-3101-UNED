using Microsoft.AspNetCore.Mvc;
using Proyecto_2_3101.Extensions;
using Proyecto_2_3101.Models;
using Proyecto_2_3101.Services;

namespace Proyecto_2_3101.Controllers;

public class JobTypeController(IJobTypeService jobTypeService) : SecureController
{
    
    public async Task<IActionResult> Index()
    {
        
        var jobTypes = await jobTypeService.GetAllAsync();
        
        return View(jobTypes);
    }
    
    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(JobTypeModel jobTypeModel)
    {

        try
        {

            var user = HttpContext.Session.GetUser();
            await jobTypeService.AddAsync(jobTypeModel, user!.UserId);
            TempData["message"] = "El servicio fue creado con exito";
            return RedirectToAction("Index");

        }
        catch (Exception e)
        {
            ViewBag.ErrorMessage = e.Message;
        }
        
        
        return View(jobTypeModel);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var jobTypeModel = await jobTypeService.GetByIdAsync(id);
        return View(jobTypeModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(JobTypeModel jobTypeModel)
    {
        try
        {
            var user = HttpContext.Session.GetUser();
            await jobTypeService.UpdateAsync(jobTypeModel, user!.UserId);
            TempData["message"] = "El servicio fue modificado con exito";
            return RedirectToAction("Index");
                
        } catch (Exception e)
        {
            ViewBag.ErrorMessage = e.Message;
        } 
        return View(jobTypeModel);

    }

    [HttpPost]
    public async Task<PartialViewResult> Details(int id)
    {
        var  jobTypeModel = await jobTypeService.GetByIdAsync(id);
        return PartialView("_Details",jobTypeModel);
    }
    
}