using Microsoft.AspNetCore.Mvc;
using Proyecto_2_3101.Extensions;
using Proyecto_2_3101.Models.Enums;
using Proyecto_2_3101.Models.ViewModels;
using Proyecto_2_3101.Services;

namespace Proyecto_2_3101.Controllers;

public class PaymentController(IOrderService orderService, IPaymentService paymentService) : SecureController
{
    // GET
    public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, PaymentMethods? paymentMethod)
    {
        
        if (startDate.HasValue) ViewBag.StartDate = startDate.Value;
        if (endDate.HasValue) ViewBag.EndDate = endDate.Value;
        if (paymentMethod.HasValue) ViewBag.CurrentMethod = (int)paymentMethod.Value;
        
        var paymentHistory = await paymentService.GetPaymentsByDateByTypeAsync(startDate, endDate, paymentMethod);
        
        return View(paymentHistory);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> MakePayment(int orderId)
    {
        var order = await orderService.GetByIdAsync(orderId);
        if (order != null) return PartialView("_MakePayment", order);
        TempData["errorMessage"] = $"No se encontraron la orden {orderId}.";
        return RedirectToAction("Index", "Order");
    }

    [HttpPost]
    public async Task<IActionResult> MakePayment(int orderId, PaymentMethods? payment)
    {
        if (!payment.HasValue)
        {
            TempData["errorMessage"] = "Error: Debe seleccionar un método de pago válido.";
            return RedirectToAction("Index", "Order");
        }

        PaymentReceiptViewModel receiptData;
        
        try
        {

            var user = HttpContext.Session.GetUser();

            var order = await orderService.GetByIdAsync(orderId);
            if (order == null) return NotFound("La orden especificada no existe.");

            await orderService.MakePaymentAsync(order, user!.UserId, payment.Value);

            receiptData = new PaymentReceiptViewModel
            {
                TransactionReference = order.Id,
                ClientName = order.Client?.Fullname ?? "Cliente General",
                PlateNumber = order.Vehicle?.PlateNumber ?? "N/A",
                AmountPaid = order.TotalPrice,
                PaymentMethodName = payment.Value,
                PaymentTimestamp = DateTimeOffset.Now
            };
            
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = $"Ocurrió un error inesperado al procesar el pago: {ex.Message}";
            return RedirectToAction("Index", "Order");
        }
        
        return PartialView("_PaymentReceipt", receiptData);
    }
}