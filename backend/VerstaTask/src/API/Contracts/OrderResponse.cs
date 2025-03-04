namespace API.Contracts
{
    public record OrderResponse
    (
        int Id,
        string SenderCity,
        string SenderAddress,
        string RecipientCity,
        string RecipientAddress,
        decimal CargoWeight,
        DateOnly PickupDate,
        DateTime CreatedAt
    );
}
