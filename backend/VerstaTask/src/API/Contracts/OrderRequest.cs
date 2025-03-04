namespace API.Contracts
{
    public record OrderRequest
    (
        string SenderCity,
        string SenderAddress,
        string RecipientCity,
        string RecipientAddress,
        decimal CargoWeight,
        DateOnly PickupDate
    );
}
