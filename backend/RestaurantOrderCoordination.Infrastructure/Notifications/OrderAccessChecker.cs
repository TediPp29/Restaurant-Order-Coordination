using System.Security.Claims;
using RestaurantOrderCoordination.Application.Interfaces;

namespace RestaurantOrderCoordination.Infrastructure.Notifications;

public sealed class OrderAccessChecker : IOrderAccessChecker
{
    public Task<bool> HasAccessAsync(
        ClaimsPrincipal? user,
        int orderId,
        CancellationToken cancellationToken = default)
    {
        if (user?.Identity?.IsAuthenticated != true)
            return Task.FromResult(false);

        if (user.IsInRole("Chef") || user.IsInRole("Waiter") || user.IsInRole("Manager"))
            return Task.FromResult(true);

        var hasOrderClaim = user.FindAll("order_access")
            .SelectMany(claim => claim.Value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .Any(value => int.TryParse(value, out var claimedOrderId) && claimedOrderId == orderId);

        return Task.FromResult(hasOrderClaim);
    }
}
