using Microsoft.AspNetCore.Mvc;
using Proyecto_2_3101.Models.Enums;
using Proyecto_2_3101.Services;

namespace Proyecto_2_3101.Controllers;

[ApiController]
[Route("/api/")]
public class RestApiController(IJobTypeService jobTypeService,
    IOrderService orderService) : ControllerBase
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
}