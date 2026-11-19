namespace PredictionModule;

public sealed class PredictionService
{
    private const double QueueDelayPerWaitingOrder = 2.0;

    public PredictionResult Predict(OrderPredictionInput input)
    {
        ArgumentNullException.ThrowIfNull(input);

        if (input.PreparationTimesMinutes is null ||
            input.PreparationTimesMinutes.Count == 0)
        {
            throw new ArgumentException(
                "The order should contains one or more meals.",
                nameof(input));
        }

        if (input.PreparationTimesMinutes.Any(t => !double.IsFinite(t) || t <= 0))
        {
            throw new ArgumentException(
                "Preparation time should be valid and positive number.",
                nameof(input));
        }

        if (input.WaitingOrders < 0)
            throw new ArgumentOutOfRangeException(
                nameof(input.WaitingOrders), "Count of the waiting orders should be positive");

        if (input.KitchenLoadLevel is < 1 or > 3)
            throw new ArgumentOutOfRangeException(
                nameof(input.KitchenLoadLevel), "Kitchen Load Level should be 1, 2 or 3.");

        double baseTime = input.PreparationTimesMinutes.Max();

        double loadMultiplier = input.KitchenLoadLevel switch
        {
            1 => 1.00,
            2 => 1.20,
            3 => 1.50,
            _ => throw new InvalidOperationException("Invalid value.")
        };

        double queueDelay = input.WaitingOrders * QueueDelayPerWaitingOrder;
        double estimate = baseTime * loadMultiplier + queueDelay;

        return new PredictionResult(
            Math.Round(estimate, 2),
            baseTime,
            loadMultiplier,
            queueDelay);
    }
}
