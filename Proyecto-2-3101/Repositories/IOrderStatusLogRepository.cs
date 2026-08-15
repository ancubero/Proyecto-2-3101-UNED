using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Repositories;

public interface IOrderStatusLogRepository
{
    void Add(ChangeOrderStatusLogModel statusLog);
}