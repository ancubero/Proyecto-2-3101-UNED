using Proyecto_2_3101.Models;
using Proyecto_2_3101.Models.Enums;
using Proyecto_2_3101.Models.ViewModels;

namespace Proyecto_2_3101.Services;

public interface IPaymentService
{
    Task<IEnumerable<PaymentModel>> GetPaymentsByDateByTypeAsync(DateTime? startDate, DateTime? endDate, PaymentMethods? paymentMethod);
    Task<RevenueReportViewModel> GetRevenueReportAsync(DateTime? startDate, DateTime? endDate);
}