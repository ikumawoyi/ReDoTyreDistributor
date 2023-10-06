namespace TyreDistributor
{
    public class Line
    {
        public Line(Tyre tyre, int quantity)
        {
            Tyre = tyre;
            Quantity = quantity;
        }

        public Tyre Tyre { get; }
        public int Quantity { get; }
    }
}