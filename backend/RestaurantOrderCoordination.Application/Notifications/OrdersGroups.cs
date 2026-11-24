namespace RestaurantOrderCoordination.Application.Notifications;

public static class OrdersGroups
{
    public const string Kitchen = "Kitchen";
    public const string Waiters = "Waiters";
    public const string Managers = "Managers";

    public static string Order(int orderId) => $"order:{orderId}";
}
