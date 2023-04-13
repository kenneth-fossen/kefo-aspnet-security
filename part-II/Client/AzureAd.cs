namespace Client;

public record AzureAd
{
    public string Instance { get; init; } = string.Empty;
    public string TenantId { get; init; } = string.Empty;
    public string ClientId { get; init; } = string.Empty;
    public string Secret { get; init; } = string.Empty;
}