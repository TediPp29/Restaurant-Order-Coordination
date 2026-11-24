using Microsoft.AspNetCore.SignalR;
using RestaurantOrderCoordination.Application.Interfaces;
using RestaurantOrderCoordination.Application.Notifications;

namespace RestaurantOrderCoordination.Api.Hubs;

public sealed class OrdersHub(IOrderAccessChecker orderAccessChecker) : Hub<IOrdersClient>
{
    
    public override async Task OnConnectedAsync()
    {
        if (Context.User?.IsInRole("Chef") == true)
            await Groups.AddToGroupAsync(Context.ConnectionId, OrdersGroups.Kitchen);

        if (Context.User?.IsInRole("Waiter") == true)
            await Groups.AddToGroupAsync(Context.ConnectionId, OrdersGroups.Waiters);

        if (Context.User?.IsInRole("Manager") == true)
            await Groups.AddToGroupAsync(Context.ConnectionId, OrdersGroups.Managers);

        await base.OnConnectedAsync();
    }

    public async Task<bool> JoinOrderGroup(int orderId)
    {
        if (!await orderAccessChecker.HasAccessAsync(Context.User, orderId, Context.ConnectionAborted))
            return false;

        await Groups.AddToGroupAsync(Context.ConnectionId, OrdersGroups.Order(orderId), Context.ConnectionAborted);
        return true;
    }
}
