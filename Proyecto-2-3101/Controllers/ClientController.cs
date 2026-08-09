using Microsoft.AspNetCore.Mvc;
using Proyecto_2_3101.Extensions;
using Proyecto_2_3101.Models;
using Proyecto_2_3101.Models.Enums;
using Proyecto_2_3101.Services;

namespace Proyecto_2_3101.Controllers;

public class ClientController(IClientService clientService) : SecureController
{
    
    public async Task<IActionResult> Index()
    {
        var clients = await clientService.GetClientsAsync();
        return View(clients);
    }
    
    [HttpGet]
    public IActionResult Create() => View();


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClientModel clientModel)
    {

        try
        {

            //Remueve temporalmente el Id del Cliente para evitar el "The value '' is invalid"
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                var user = HttpContext.Session.GetUser();
                await clientService.AddClientAsync(clientModel, user!.UserId);
                TempData["message"] = "Cliente agregado con exito";
                return RedirectToAction("Index");
            }
            
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
        }
        
        return View(clientModel);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {


        ClientModel? clientModel;
        
        try
        {

           clientModel = await clientService.GetClientByIdAsync(id);
           
           if(clientModel == null) throw new Exception("No se encontro el cliente");

        }
        catch (Exception ex)
        {
            TempData["message"] = ex.Message;
            return RedirectToAction("Index");
            
        }


        return View(clientModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ClientModel clientModel)
    {

        try
        {

            if (ModelState.IsValid)
            {
                var user = HttpContext.Session.GetUser();
                await clientService.UpdateClientAsync(clientModel, user!.UserId);
                
                TempData["message"] = "Cliente editado con exito";
                return RedirectToAction("Edit", new { id = clientModel.Id });
            }
            
            
        } catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
        }
        
        return View(clientModel);
    }

    [HttpGet]
    public IActionResult Search() =>  View();

    [HttpPost]
    public async Task<IActionResult> Search(SearchClientModel searchClientModel)
    {
        
        try
        {

            if (string.IsNullOrWhiteSpace(searchClientModel.Search))
            {
                return RedirectToAction("Index");
            }
            else
            {

                var search = searchClientModel.SearchClientBy switch
                {
                    SearchClientBy.FullName => clientService.SearchClientsByNameAsync(searchClientModel.Search),
                    SearchClientBy.Phone => clientService.SearchClientsByPhoneAsync(searchClientModel.Search),
                    SearchClientBy.Identifier => clientService.SearchClientsByIdentifierAsync(searchClientModel.Search),
                    _ => clientService.GetClientsAsync()
                };
                
                ViewData["Clients"] = await search;
            }
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
        }
        
        return View(searchClientModel);
        
    }

    [HttpPost]
    public async Task<PartialViewResult> Details(int id)
    {
        var client = await clientService.GetClientByIdAsync(id);
        return PartialView("_Details", client);
    }
    
    
}