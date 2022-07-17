namespace TaskAdd.Models
{
    public partial class Product
    {
        public override string ToString()
        {
            return $"ProdId: {ProdId}\n" +
                $"Weight: {Weight}\n" +
                $"Description: {Description}\n" +
                $"UnitPrice: {UnitPrice}\n" +
                $"Weight: {Weight}\n" +
                $"OrderDetails.Count: {OrderDetails.Count}\n\n";
        }
    }
}
