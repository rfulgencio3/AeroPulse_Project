namespace AeroPulse.Contracts;

public sealed record MaintenanceWorkOrderCreated(
    string WorkOrderId,
    string AircraftId,
    string Description,
    DateTimeOffset CreatedUtc,
    string Priority
);
