using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Data;
using Proyecto_2_3101.Models;
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Repositories;

public class PaymentRepository(DataBaseContext context) : IPaymentRepository
{
    public void AddPayment(PaymentModel payment)
    {
        context.Payments.Add(payment);
    }

    public async Task<IEnumerable<PaymentModel>> GetPaymentsByDateAsync(DateTimeOffset startDate, DateTimeOffset endDate)
    {
        return await context.Payments
            .Include(o => o.Order)
                .ThenInclude(c => c!.Client)
            .Include(o => o.Order)
                .ThenInclude(v => v!.Vehicle)
            .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<PaymentModel>> GetPaymentsByDateByTypeAsync(DateTime? startDate, DateTime? endDate, PaymentMethods? paymentMethod)
    {

        var query = context.Payments
            .Include(o => o.Order)
            .ThenInclude(c => c!.Client)
            .Include(o => o.Order)
            .ThenInclude(v => v!.Vehicle)
            .AsQueryable();

        if (startDate.HasValue)
        {
            DateTimeOffset startBoundary = DateTime.SpecifyKind(startDate.Value.Date, DateTimeKind.Local);
            query = query.Where(p => p.PaymentDate >= startBoundary);
        }

        if (endDate.HasValue)
        {
            DateTimeOffset endBoundary = DateTime.SpecifyKind(endDate.Value.Date.AddDays(1), DateTimeKind.Local);
            query = query.Where(p => p.PaymentDate < endBoundary);
        }

        if (paymentMethod.HasValue)
        {
            query = query.Where(p => p.PaymentMethod == paymentMethod.Value);
        }
        
        return await query
            .OrderByDescending(p => p.PaymentDate)
            .ToListAsync();
        
    }

    public Task<IEnumerable<PaymentModel>> GetByTypeAsync(PaymentMethods paymentMethod)
    {
        throw new NotImplementedException();
    }
}