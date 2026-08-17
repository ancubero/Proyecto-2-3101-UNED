using Microsoft.AspNetCore.Mvc;
using Proyecto_2_3101.Extensions;
using Proyecto_2_3101.Filters;
using Proyecto_2_3101.Models.Enums;
using Proyecto_2_3101.Models.ViewModels;
using Proyecto_2_3101.Services;

namespace Proyecto_2_3101.Controllers;

public class OrderController(
    IJobTypeService jobTypeService,
    IOrderService orderService,
    IVehicleService vehicleService) : SecureController
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var orders = await orderService.GetTodayOrdersAsync();
        return View(orders);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Search(DateTime? startDate, DateTime? endDate, OrderStatus? status)
    {
        var orders = await orderService.GetFilteredOrdersAsync(startDate, endDate, status);

        if (!orders.Any())
        {
            return NotFound("No se encontraron órdenes registradas con los filtros seleccionados.");
        }

        return PartialView("_OrderList", orders);
    }


    [HttpGet]
    [ValidateClientSession]
    public async Task<IActionResult> Create(int vehicleId)
    {
        var vehicle = await vehicleService.GetVehicleAsync(vehicleId);
        var jobTypes = await jobTypeService.GetAllByActiveAsync(true);
        var client = HttpContext.Session.GetClient();

        var jobOrder = new JobOrderViewModel
        {
            JobTypes = jobTypes,
            Vehicle = vehicle!,
            Client = client!
        };

        return View(jobOrder);
    }

    [HttpPost]
    [ValidateClientSession]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(JobOrderViewModel model, List<int>? selectedJobTypeIds)
    {
        try
        {
            var client = HttpContext.Session.GetClient();

            if (selectedJobTypeIds == null || selectedJobTypeIds.Count == 0)
            {
                var vehicle = await vehicleService.GetVehicleAsync(model.Vehicle.IdVehicle);
                var jobTypes = await jobTypeService.GetAllByActiveAsync(true);
                model.Client = client!;
                model.Vehicle = vehicle!;
                model.JobTypes = jobTypes;
                throw new Exception("Debe seleccionar al menos un tipo de servicio.");
            }

            var user = HttpContext.Session.GetUser();

            var order = await orderService.AddAsync(model.Vehicle.IdVehicle, selectedJobTypeIds, user!.UserId,
                client!.Id);

            TempData["message"] =
                $"La orden {order.Id} del cliente {client.Fullname} para el vehículo ${model.Vehicle.PlateNumber} fue procesada y guardada con éxito.";
            return RedirectToAction("Index", "Order");
        }
        catch (Exception ex)
        {
            ModelState.Clear();
            ModelState.AddModelError(string.Empty, ex.Message);
        }


        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Detail(int id)
    {
        var order = await orderService.GetByIdAsync(id);
        return PartialView("_Detail", order);
    }

    [HttpPost]
    public async Task<IActionResult> NextStage(int orderId)
    {
        try
        {
            var order = await orderService.GetByIdAsync(orderId);

            if (order == null) throw new Exception($"No se encontraron la orden número {order}.");
            var user = HttpContext.Session.GetUser();
            var nextStatus = order.OrderStatus.NextStatus().GetDisplayName();
            await orderService.UpdateStatusAsync(order, user!.UserId);
            TempData["message"] = $"La orden número {orderId} ha cambiado a estado {nextStatus} correctamente.";
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
        }

        return RedirectToAction("Index", "Order");
    }
}