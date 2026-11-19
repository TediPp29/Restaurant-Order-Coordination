namespace PredictionModule;

public sealed record PredictionResult(
    double EstimatedMinutes,
    double BasePreparationMinutes,
    double LoadMultiplier,
    double QueueDelayMinutes);
