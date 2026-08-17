using Proyecto_2_3101.Models;
using Proyecto_2_3101.Models.Enums;
using Proyecto_2_3101.Models.ViewModels;
using Proyecto_2_3101.Repositories;

namespace Proyecto_2_3101.Services;

public class PaymentService(IPaymentRepository paymentRepository) : IPaymentService
{
    public async Task<IEnumerable<PaymentModel>> GetPaymentsByDateByTypeAsync(DateTime? startDate, DateTime? endDate, PaymentMethods? paymentMethod)
    {
        return await paymentRepository.GetPaymentsByDateByTypeAsync(startDate, endDate, paymentMethod);
    }

    public async Task<RevenueReportViewModel> GetRevenueReportAsync(DateTime? startDate, DateTime? endDate)
    {
        var transactionsStream = await paymentRepository.GetPaymentsByDateByTypeAsync(startDate, endDate, null);

        var transactions = transactionsStream.ToList();
        
        var dailyTotals = transactions.GroupBy(p => p.PaymentDate.LocalDateTime.Date)
            .Select(g => new DailyRevenueItem
            {
                CalendarDate = g.Key,
                TotalTransactions = g.Count(),
                TotalAmount = g.Sum(p => p.AmountToPay)
            })
            .OrderBy(p => p.CalendarDate)
            .ToList();

        return new RevenueReportViewModel
        {
            DetailedPayments = transactions,
            DailyRevenueTotals =  dailyTotals
        };

    }
}