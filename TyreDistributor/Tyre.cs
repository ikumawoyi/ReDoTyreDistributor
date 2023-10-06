namespace TyreDistributor
{
    public class Tyre
    {
        public const string Suv = "Sports Utility Vehicle";
        public const string Mini = "Mini";
        public const string Estate = "Estate";

        public Tyre(string brand, string model, int price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }

        public string Brand { get; }
        public string Model { get; }
        public int Price { get; set; }
    }
}