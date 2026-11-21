using System.Text.Json.Serialization;

namespace RestaurantOrderCoordination.Application.DTOs;

// Represents response from TheMealDB Api
public sealed record MealDbSearchResponse
{
    [JsonPropertyName("meals")]
    public List<MealDto>? Meals { get; init; }
}

// Represents a single meal from TheMealDB Api
public sealed record MealDto
{
    [JsonPropertyName("idMeal")]
    public string IdMeal { get; init; } = string.Empty;

    [JsonPropertyName("strMeal")]
    public string? Name { get; init; }

    [JsonPropertyName("strCategory")]
    public string? Category { get; init; }

    [JsonPropertyName("strArea")]
    public string? Area { get; init; }

    [JsonPropertyName("strInstructions")]
    public string? Instructions { get; init; }

    [JsonPropertyName("strMealThumb")]
    public string? ThumbnailUrl { get; init; }

    [JsonPropertyName("strTags")]
    public string? Tags { get; init; }

    [JsonPropertyName("strYoutube")]
    public string? YoutubeUrl { get; init; }

    [JsonPropertyName("strIngredient1")]
    public string? Ingredient1 { get; init; }

    [JsonPropertyName("strIngredient2")]
    public string? Ingredient2 { get; init; }

    [JsonPropertyName("strIngredient3")]
    public string? Ingredient3 { get; init; }

    [JsonPropertyName("strIngredient4")]
    public string? Ingredient4 { get; init; }

    [JsonPropertyName("strIngredient5")]
    public string? Ingredient5 { get; init; }

    [JsonPropertyName("strIngredient6")]
    public string? Ingredient6 { get; init; }

    [JsonPropertyName("strIngredient7")]
    public string? Ingredient7 { get; init; }

    [JsonPropertyName("strIngredient8")]
    public string? Ingredient8 { get; init; }

    [JsonPropertyName("strIngredient9")]
    public string? Ingredient9 { get; init; }

    [JsonPropertyName("strIngredient10")]
    public string? Ingredient10 { get; init; }

    [JsonPropertyName("strIngredient11")]
    public string? Ingredient11 { get; init; }

    [JsonPropertyName("strIngredient12")]
    public string? Ingredient12 { get; init; }

    [JsonPropertyName("strIngredient13")]
    public string? Ingredient13 { get; init; }

    [JsonPropertyName("strIngredient14")]
    public string? Ingredient14 { get; init; }

    [JsonPropertyName("strIngredient15")]
    public string? Ingredient15 { get; init; }

    [JsonPropertyName("strIngredient16")]
    public string? Ingredient16 { get; init; }

    [JsonPropertyName("strIngredient17")]
    public string? Ingredient17 { get; init; }

    [JsonPropertyName("strIngredient18")]
    public string? Ingredient18 { get; init; }

    [JsonPropertyName("strIngredient19")]
    public string? Ingredient19 { get; init; }

    [JsonPropertyName("strIngredient20")]
    public string? Ingredient20 { get; init; }

    [JsonPropertyName("strMeasure1")]
    public string? Measure1 { get; init; }

    [JsonPropertyName("strMeasure2")]
    public string? Measure2 { get; init; }

    [JsonPropertyName("strMeasure3")]
    public string? Measure3 { get; init; }

    [JsonPropertyName("strMeasure4")]
    public string? Measure4 { get; init; }

    [JsonPropertyName("strMeasure5")]
    public string? Measure5 { get; init; }

    [JsonPropertyName("strMeasure6")]
    public string? Measure6 { get; init; }

    [JsonPropertyName("strMeasure7")]
    public string? Measure7 { get; init; }

    [JsonPropertyName("strMeasure8")]
    public string? Measure8 { get; init; }

    [JsonPropertyName("strMeasure9")]
    public string? Measure9 { get; init; }

    [JsonPropertyName("strMeasure10")]
    public string? Measure10 { get; init; }

    [JsonPropertyName("strMeasure11")]
    public string? Measure11 { get; init; }

    [JsonPropertyName("strMeasure12")]
    public string? Measure12 { get; init; }

    [JsonPropertyName("strMeasure13")]
    public string? Measure13 { get; init; }

    [JsonPropertyName("strMeasure14")]
    public string? Measure14 { get; init; }

    [JsonPropertyName("strMeasure15")]
    public string? Measure15 { get; init; }

    [JsonPropertyName("strMeasure16")]
    public string? Measure16 { get; init; }

    [JsonPropertyName("strMeasure17")]
    public string? Measure17 { get; init; }

    [JsonPropertyName("strMeasure18")]
    public string? Measure18 { get; init; }

    [JsonPropertyName("strMeasure19")]
    public string? Measure19 { get; init; }

    [JsonPropertyName("strMeasure20")]
    public string? Measure20 { get; init; }

    [JsonIgnore]
    public IReadOnlyList<string> IngredientsWithMeasures =>
        new[]
        {
            (Ingredient1, Measure1), (Ingredient2, Measure2),
            (Ingredient3, Measure3), (Ingredient4, Measure4),
            (Ingredient5, Measure5), (Ingredient6, Measure6),
            (Ingredient7, Measure7), (Ingredient8, Measure8),
            (Ingredient9, Measure9), (Ingredient10, Measure10),
            (Ingredient11, Measure11), (Ingredient12, Measure12),
            (Ingredient13, Measure13), (Ingredient14, Measure14),
            (Ingredient15, Measure15), (Ingredient16, Measure16),
            (Ingredient17, Measure17), (Ingredient18, Measure18),
            (Ingredient19, Measure19), (Ingredient20, Measure20)
        }
        .Where(item => !string.IsNullOrWhiteSpace(item.Item1))
        .Select(item => string.IsNullOrWhiteSpace(item.Item2)
            ? item.Item1!
            : $"{item.Item1} ({item.Item2.Trim()})")
        .ToArray();
}
