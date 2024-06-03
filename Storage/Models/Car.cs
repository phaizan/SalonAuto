namespace Storage.Models
{
    public class Car
    {
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public Guid DealerId { get; set; }
        public Dealer Dealer { get; set; }
        public ICollection<CarCustomer> CarCustomers { get; set; }
    }

    
}
