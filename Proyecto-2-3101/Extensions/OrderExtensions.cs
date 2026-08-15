using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Extensions;

public static class OrderExtensions
{

    extension(OrderStatus status)
    {
        public string ToBadgeColor() => status switch
        {
            OrderStatus.Pending => "bg-warning text-dark",
            OrderStatus.Processing => "bg-primary",
            OrderStatus.Finished => "bg-info",
            OrderStatus.Paid => "bg-secondary",
            OrderStatus.Completed => "bg-success",
            _ => "bg-warning"
        };
        
        public string ToButtonColor() => status switch
        {
            OrderStatus.Processing => "btn-primary",
            OrderStatus.Finished => "btn-info",
            OrderStatus.Paid => "btn-secondary",
            OrderStatus.Completed => "btn-success",
            _ => "btn-warning"
        };

        public OrderStatus NextStatus() => status switch
        {

            OrderStatus.Pending => OrderStatus.Processing,
            OrderStatus.Processing => OrderStatus.Finished,
            OrderStatus.Finished => OrderStatus.Paid,
            OrderStatus.Paid => OrderStatus.Completed,
            _ =>  throw new ArgumentOutOfRangeException(nameof(status), status, null)
            
        };
        
        public string GetDisplayName()
        {
            var memberInfo = status.GetType().GetMember(status.ToString()).FirstOrDefault();
            if (memberInfo == null) return status.ToString();

            var attribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
            return attribute?.GetName() ?? status.ToString();
        }
    }

}