using Microsoft.AspNetCore.SignalR;
using RestaurantOrderCoordination.Application.DTOs;
using RestaurantOrderCoordination.Application.Interfaces;
using RestaurantOrderCoordination.Domain.Models;

namespace RestaurantOrderCoordination.Application.Notifications;

public sealed class NotificationService(IHubContext hubContext) : INotificationService
{
    public Task PublishOrderUpdatedAsync(int orderId, CancellationToken cancellationToken = default) =>
        PublishAsync(new OrderStatusChangedEvent
        {
            OrderId = orderId,
            ChangedAt = DateTimeOffset.UtcNow
        });

    public Task PublishOrderUpdatedAsync(
        int orderId,
        OrderStatus status,
        double? estimatedMinutes,
        CancellationToken cancellationToken = default) =>
        PublishAsync(new OrderStatusChangedEvent
        {
            OrderId = orderId,
            Status = status,
            EstimatedMinutes = estimatedMinutes,
            ChangedAt = DateTimeOffset.UtcNow
        });

    private Task PublishAsync(OrderStatusChangedEvent update) =>
        Task.WhenAll(
            hubContext.Clients
                .Group(OrdersGroups.Order(update.OrderId))
                .SendCoreAsync("OrderStatusChanged", [update], cancellationToken: default),
            hubContext.Clients
                .Groups([OrdersGroups.Kitchen, OrdersGroups.Waiters, OrdersGroups.Managers])
                .SendCoreAsync("OrderStatusChanged", [update], cancellationToken: default));
}
