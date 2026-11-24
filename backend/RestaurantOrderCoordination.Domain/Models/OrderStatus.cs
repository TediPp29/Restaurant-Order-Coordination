namespace RestaurantOrderCoordination.Domain.Models;

public enum OrderStatus
{
    New,
    Pending,
    InProgress,
    Ready,
    Completed,
    Cancelled
}
