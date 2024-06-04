namespace Storage.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }

    public class Dealer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
