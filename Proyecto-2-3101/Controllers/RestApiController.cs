using Microsoft.AspNetCore.Mvc;
using Proyecto_2_3101.Extensions;
using Proyecto_2_3101.Models.Enums;
using Proyecto_2_3101.Services;

namespace Proyecto_2_3101.Controllers;

[ApiController]
[Route("/api/")]
public class RestApiController(IJobTypeService jobTypeService,
    IOrderService orderService,
    IPaymentService paymentService) : ControllerBase
{
    [HttpGet("servicios")]
    public async Task<IActionResult> Index()
    {

        try
        {
            var services = await jobTypeService.GetAllByActiveAsync(true);
            
            if (!services.Any())
            {
                return NotFound(new { message = "No se encontraron servicios activos registrados." });
            }
            
            return Ok(services);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Error interno del servidor", details = ex.Message });
        }
    }
    
    [HttpGet("ordenes/{id:int}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        try
        {
            var order = await orderService.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound(new { message = $"No se encontró ninguna orden de lavado con el ID {id}." });
            }
            
            return Ok(order);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Error interno del servidor", details = ex.Message });
        }
    }

    [HttpPut("ordenes/{id:int}/estado")]
    public async Task<IActionResult> UpdateOrderStatus(int id)
    {

        try
        {

            var order = await orderService.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound(new { message = $"No se encontró ninguna orden de lavado con el ID {id}." });
            }

            if (order.OrderStatus == OrderStatus.Finished)
            {
                return BadRequest(new
                {
                    error = "Transacción Prohibida",
                    message = "No se puede cambiar el estado de 'Finalizado' a 'Pagodo' directamente desde este endpoint general. Use el módulo de facturación y caja asignado.",
                });
            }

            //Esto deberia tener su propio id de usuario para el api
            var userId = -1;
            await orderService.UpdateStatusAsync(order, userId);
            
            return Ok(order);
            
            
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Error interno del servidor", details = ex.Message });
        }
    }

    [HttpGet("ordenes")]
    public async Task<IActionResult> OrdersByState([FromQuery] string estado)
    {
        if (string.IsNullOrWhiteSpace(estado))
        {
            return BadRequest(new { error = "Parámetro Requerido", message = "Debe proporcionar el parámetro 'estado' en la URL." });
        }

        var parsedStatus = OrderStatus.FromDisplayName(estado);

        if (!parsedStatus.HasValue)
        {
            return BadRequest(new 
            { 
                error = "Estado Desconocido", 
                message = $"El valor '{estado}' no coincide con ninguna etiqueta de visualización del sistema." 
            });
        }

        try
        {

            var filteredOrders = await orderService.GetByStatusAsync(parsedStatus.Value);

            if (!filteredOrders.Any())
            {
                return NotFound(new { message = $"No se encontraron órdenes activas con el estado '{estado}'." });
            }
            
            return Ok(filteredOrders);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Error interno del servidor", details = ex.Message });
        }
    }

    [HttpGet("reportes/ordenes-por-estado")]
    public async Task<IActionResult> OrdersSummaryByStatus()
    {
        var orders = await orderService.GetOrderByStatusAsync();
        return Ok(orders);
    }

    [HttpGet("reportes/ingresos")]
    public async Task<IActionResult> GetRevenueReportAsync([FromQuery(Name = "desde")] DateTime? startDate, [FromQuery(Name = "hasta")] DateTime? endDate)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(new { 
                error = "Formato de Fecha Inválido", 
                message = "La fecha proporcionada no tiene un formato válido. Use el estándar YYYY-MM-DD." 
            });
        }
        
        if (!startDate.HasValue)
        {
            return BadRequest(new { 
                error = "Falta Parámetro", 
                message = "El campo 'desde' es requerido." 
            });
        }

        if (!endDate.HasValue)
        {
            return BadRequest(new { 
                error = "Falta Parámetro", 
                message = "El campo 'hasta' es requerido." 
            });
        }
        
        var ingresos = await paymentService.GetRevenueReportAsync(startDate, endDate);
        return Ok(ingresos);
        
    }
}