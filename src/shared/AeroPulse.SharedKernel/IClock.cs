namespace AeroPulse.SharedKernel;

public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
