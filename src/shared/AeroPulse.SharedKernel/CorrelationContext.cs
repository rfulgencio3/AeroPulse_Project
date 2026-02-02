namespace AeroPulse.SharedKernel;

public sealed class CorrelationContext
{
    private static readonly AsyncLocal<CorrelationContext?> CurrentContext = new();

    private CorrelationContext(Guid correlationId, Guid causationId)
    {
        CorrelationId = correlationId;
        CausationId = causationId;
    }

    public Guid CorrelationId { get; }
    public Guid CausationId { get; }

    public static CorrelationContext? Current
    {
        get => CurrentContext.Value;
        set => CurrentContext.Value = value;
    }

    public static CorrelationContext CreateNew()
    {
        var correlationId = UuidV7.NewGuid();
        var causationId = UuidV7.NewGuid();
        return new CorrelationContext(correlationId, causationId);
    }

    public static IDisposable Begin(Guid correlationId, Guid causationId)
    {
        var prior = CurrentContext.Value;
        CurrentContext.Value = new CorrelationContext(correlationId, causationId);
        return new Scope(prior);
    }

    private sealed class Scope : IDisposable
    {
        private readonly CorrelationContext? _prior;

        public Scope(CorrelationContext? prior)
        {
            _prior = prior;
        }

        public void Dispose()
        {
            CurrentContext.Value = _prior;
        }
    }
}
