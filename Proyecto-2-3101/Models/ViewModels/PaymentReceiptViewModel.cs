using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Models.ViewModels;

public class PaymentReceiptViewModel
{
    public int TransactionReference { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string PlateNumber { get; set; } = string.Empty;
    public decimal AmountPaid { get; set; }
    public PaymentMethods PaymentMethodName { get; set; }
    public DateTimeOffset PaymentTimestamp { get; set; }
}