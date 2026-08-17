using Microsoft.AspNetCore.Mvc;
using Proyecto_2_3101.Services;

namespace Proyecto_2_3101.Controllers;

public class ReportController(IOrderService orderService, IPaymentService paymentService
, IJobOrdersService jobOrdersService) : SecureController
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> OrdersByStatus()
    {
        var report = await orderService.GetOrderByStatusAsync();
        return View(report);
    }

    public async Task<IActionResult> OrdersByDate(DateTime? startDate, DateTime? endDate)
    {
        if (startDate.HasValue) ViewBag.StartDate = startDate.Value;
        if (endDate.HasValue) ViewBag.EndDate = endDate.Value;
        
        var transactions = await paymentService.GetRevenueReportAsync(startDate, endDate);
        return View(transactions);
    }

    public async Task<IActionResult> JobPerformanceSummary()
    {
        var report = await jobOrdersService.GetJobPerformanceReportAsync();
        return View(report);
    }
    
}