using TexasSteaks.Models;

namespace TexasSteaks.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetCart();
        void AddToCart(Steak steak, string shoppingCartId);
        void RemoveFromCart(Steak steak, string shoppingCartId);
        List<ShoppingCartItem> GetShoppingCartItems();
        void CleanCart(string shoppingCartId);
        decimal GetShoppingCartTotal(string shoppingCartId);
    }
}
