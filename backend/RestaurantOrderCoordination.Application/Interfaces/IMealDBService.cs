using RestaurantOrderCoordination.Application.DTOs;

namespace RestaurantOrderCoordination.Application.Interfaces;

public interface IMealDbService
{
    Task<IReadOnlyList<MealDto>> SearchByNameAsync(
        string name,
        CancellationToken cancellationToken);

    Task<IReadOnlyList<MealDto>> SearchByCategoryAsync(
        string category,
        CancellationToken cancellationToken);

    Task<MealDto?> SearchByIdAsync(
        string id,
        CancellationToken cancellationToken);

    Task<MealDto?> GetRandomMealAsync(CancellationToken cancellationToken);
}