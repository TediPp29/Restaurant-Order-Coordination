namespace PredictionModule;

public sealed class OrderPredictionInput
{
    public IReadOnlyList<double> PreparationTimesMinutes { get; init; } = Array.Empty<double>();

    public int WaitingOrders { get; init; }

    /// <summary>1 (low), 2 (medium), 3 (high).</summary>
    public int KitchenLoadLevel { get; init; }
}
