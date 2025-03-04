using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required string SenderCity { get; set; }
        public required string SenderAddress {get;set;}
        public required string RecipientCity {get;set;}
        public required string RecipientAddress {get;set;}
        public decimal CargoWeight {get;set;}
        public DateOnly PickupDate {get;set;}
        public DateTime CreatedAt {get;set;}

        public static (Order? Order, string Error) Create(
            int id,
            string senderCity,
            string senderAddress,
            string recipientCity,
            string recipientAddress,
            decimal cargoWeight,
            DateOnly pickupDate,
            DateTime createdAt)
        {
            var error = string.Empty;
            if (string.IsNullOrWhiteSpace(senderCity))
                error = "Город отправителя обязателен.";
            else if (string.IsNullOrWhiteSpace(recipientCity))
                error = "Город получателя обязателен.";
            else if (string.IsNullOrWhiteSpace(senderAddress))
                error = "Адрес отправителя обязателен.";
            else if (string.IsNullOrWhiteSpace(recipientAddress))
                error = "Адрес получателя обязателен.";
            else if (cargoWeight <= 0)
                error = "Вес груза должен быть больше 0.";
            else if (cargoWeight > 10000)
                error = "Вес груза слишком большой.";
            else if (pickupDate < DateOnly.FromDateTime(DateTime.UtcNow))
                error = "Дата забора груза не может быть в прошлом.";
            else if (pickupDate > DateOnly.FromDateTime(DateTime.UtcNow.AddYears(1)))
                error = "Дата забора груза слишком далека.";
            else if (createdAt > DateTime.UtcNow)
                error = "Некорректная дата создания заказа.";

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            return (new Order
            {
                Id = id,
                SenderCity = senderCity,
                SenderAddress = senderAddress,
                RecipientCity = recipientCity,
                RecipientAddress = recipientAddress,
                CargoWeight = cargoWeight,
                PickupDate = pickupDate,
                CreatedAt = createdAt
            }, string.Empty);
        }
    }
}
