using Microsoft.AspNetCore.Mvc;
using Proyecto_2_3101.Extensions;
using Proyecto_2_3101.Filters;
using Proyecto_2_3101.Models;
using Proyecto_2_3101.Models.ViewModels;
using Proyecto_2_3101.Services;

namespace Proyecto_2_3101.Controllers;

public class VehicleController(IVehicleService vehicleService, IClientService clientService) : SecureController
{
    [HttpGet]
    public async Task<IActionResult> Index(int clientId)
    {
        var model = new ClientVehiclesViewModel();

        try
        {
            var client = await clientService.GetClientByIdAsync(clientId);

            if (client == null) throw new Exception("El cliente no ha sido encontrado");
            var vehicles = await vehicleService.GetVehiclesAsync(clientId);

            HttpContext.Session.SetClient(client);

            model.Client = client;
            model.Vehicles = vehicles;
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
        }

        return View(model);
    }


    [HttpGet]
    [ValidateClientSession]
    public IActionResult Create()
    {
        var model = new ClientVehicleViewModel
        {
            Client = HttpContext.Session.GetClient()!
        };

        return View(model);
    }

    [HttpPost]
    [ValidateClientSession]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VehicleModel vehicleModel)
    {
        ModelState.Remove("IdVehicle");
        var client = HttpContext.Session.GetClient();

        var model = new ClientVehicleViewModel
        {
            Client = client!
        };

        try
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.Session.GetUser();
                await vehicleService.CreateVehicleAsync(vehicleModel, user!.UserId, client!.Id);
                TempData["message"] = "El vehículo ha sido agregado con exito";
                return RedirectToAction("Index", new { clientId = client.Id });
            }
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
        }

        return View(model);
    }


    [HttpGet]
    public IActionResult Search() => View();

    [HttpPost]
    public async Task<IActionResult> Search(string plateNumber)
    {
        IEnumerable<VehicleModel> vehicles = [];

        if (string.IsNullOrWhiteSpace(plateNumber))
        {
            return BadRequest("Por favor ingrese el número de placa");
        }
        
        var vehicle = await vehicleService.GetVehicleAsync(plateNumber);
        if (vehicle == null)
        {
            return NotFound($"No se encontro el vehículo con la placa {plateNumber}");
        }
        vehicles = vehicles.Append(vehicle);
        
        return PartialView("_VehicleList", vehicles);
    }
}