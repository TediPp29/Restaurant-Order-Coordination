using System.Security.Claims;

namespace RestaurantOrderCoordination.Application.Interfaces;

public interface IOrderAccessChecker
{
    Task<bool> HasAccessAsync(
        ClaimsPrincipal? user,
        int orderId,
        CancellationToken cancellationToken = default);
}
