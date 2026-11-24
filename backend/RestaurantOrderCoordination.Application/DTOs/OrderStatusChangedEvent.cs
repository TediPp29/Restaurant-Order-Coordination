using RestaurantOrderCoordination.Domain.Models;

namespace RestaurantOrderCoordination.Application.DTOs;

public sealed record OrderStatusChangedEvent
{
    public required int OrderId { get; init; }
    public OrderStatus? Status { get; init; }
    public DateTimeOffset ChangedAt { get; init; }
    public double? EstimatedMinutes { get; init; }
}
