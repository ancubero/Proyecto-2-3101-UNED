using Microsoft.AspNetCore.Mvc;
using Proyecto_2_3101.Services;

namespace Proyecto_2_3101.Controllers;

public class JobTypeController(IJobTypeService jobTypeService) : SecureController
{
    
    public async Task<IActionResult> Index()
    {
        
        var jobTypes = await jobTypeService.GetAllAsync();
        
        return View(jobTypes);
    }
}