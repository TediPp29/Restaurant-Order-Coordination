using RestaurantOrderCoordination.Application.DTOs;

namespace RestaurantOrderCoordination.Application.Notifications;

public interface IOrdersClient
{
    Task OrderStatusChanged(OrderStatusChangedEvent update);
}
