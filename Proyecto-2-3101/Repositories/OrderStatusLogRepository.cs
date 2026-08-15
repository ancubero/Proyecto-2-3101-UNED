using Proyecto_2_3101.Data;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Repositories;

public class OrderStatusLogRepository(DataBaseContext context) : IOrderStatusLogRepository
{
    public void Add(ChangeOrderStatusLogModel statusLog)
    {
        context.ChangeOrderStatusLogs.Add(statusLog);
    }
}