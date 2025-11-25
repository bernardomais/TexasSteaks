namespace TexasSteaks.Models
{
    public class ShoppingCart
    {
        public string Id { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
