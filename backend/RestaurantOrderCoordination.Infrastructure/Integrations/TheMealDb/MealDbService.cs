using System.Net.Http.Json;
using RestaurantOrderCoordination.Application.Interfaces;
using RestaurantOrderCoordination.Application.DTOs;

namespace RestaurantOrderCoordination.Infrastructure.Integrations.TheMealDb;


public sealed class MealDbService(IHttpClientFactory httpClientFactory) : IMealDbService
{
    public Task<IReadOnlyList<MealDto>> SearchByNameAsync(
        string name,
        CancellationToken cancellationToken) =>
        GetMealsAsync($"search.php?s={Uri.EscapeDataString(name)}", cancellationToken);

    public Task<IReadOnlyList<MealDto>> SearchByCategoryAsync(
        string category,
        CancellationToken cancellationToken) =>
        GetMealsAsync($"filter.php?c={Uri.EscapeDataString(category)}", cancellationToken);

    public async Task<MealDto?> GetRandomMealAsync(CancellationToken cancellationToken)
    {
        var meals = await GetMealsAsync("random.php", cancellationToken);
        return meals.FirstOrDefault();
    }

    public async Task<MealDto?> SearchByIdAsync(
        string id,
        CancellationToken cancellationToken)
    {
        var meals = await GetMealsAsync($"lookup.php?i={Uri.EscapeDataString(id)}", cancellationToken);
        return meals.FirstOrDefault();
    }

    private async Task<IReadOnlyList<MealDto>> GetMealsAsync(
        string relativeUrl,
        CancellationToken cancellationToken)
    {
        var client = httpClientFactory.CreateClient("MealDbClient");
        var result = await client.GetFromJsonAsync<MealDbSearchResponse>(
            relativeUrl,
            cancellationToken);

        return result?.Meals ?? [];
    }
}
