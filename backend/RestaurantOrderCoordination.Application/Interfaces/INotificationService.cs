using RestaurantOrderCoordination.Domain.Models;

namespace RestaurantOrderCoordination.Application.Interfaces;

public interface INotificationService
{
    Task PublishOrderUpdatedAsync(int orderId, CancellationToken cancellationToken = default);

    Task PublishOrderUpdatedAsync(
        int orderId,
        OrderStatus status,
        double? estimatedMinutes,
        CancellationToken cancellationToken = default);
}
