using Proyecto_2_3101.Data;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Repositories;

public class PaymentRepository(DataBaseContext context) : IPaymentRepository
{
    public void AddPayment(PaymentModel payment)
    {
        context.Payments.Add(payment);
    }
}