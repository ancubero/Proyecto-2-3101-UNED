using Microsoft.AspNetCore.Mvc;
using Proyecto_2_3101.Models;
using Proyecto_2_3101.Services;

namespace Proyecto_2_3101.Controllers;

public class UserController(IUserService userService) : SecureController
{
    public async Task<IActionResult> Index()
    {
        var users = await userService.GetAllAsync();
        return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var user = await userService.GetByIdAsync(id);
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UserModel userModel)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(userModel.Password))
            {
                await userService.UpdateWithOutPasswordAsync(userModel);
            }
            else
            {
                await userService.UpdateAsync(userModel);
            }

            TempData["message"] = "Usuario editado con exito";
            return RedirectToAction("Edit", new { id = userModel.UserId });
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
        }

        return View(userModel);
    }

    [HttpGet]
    public IActionResult Add() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(UserModel userModel)
    {
        
        try
        {
            
            //Remueve temporalmente el UserId para evitar el "The value '' is invalid"
            ModelState.Remove("UserId");
            
            if (string.IsNullOrWhiteSpace(userModel.Password))
            {
                ModelState.AddModelError("Password", "Ingrese la contraseña del usuario");
            }
            
            if (ModelState.IsValid)
            {
                await userService.AddAsync(userModel);
                TempData["message"] = "Usuario agregado con exito";
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
        }

        return View(userModel);
    }
}