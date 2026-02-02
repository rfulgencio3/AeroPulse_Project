namespace AeroPulse.Contracts;

public sealed record TelemetryIngested(
    string AircraftId,
    DateTimeOffset OccurredUtc,
    string SourceSystem,
    IReadOnlyDictionary<string, decimal> Metrics
);
