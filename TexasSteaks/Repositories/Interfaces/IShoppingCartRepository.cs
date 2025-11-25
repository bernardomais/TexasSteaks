using TexasSteaks.Models;

namespace TexasSteaks.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetCart(IServiceProvider services);
        void AddToCart(int steakId, string shoppingCartId);
        void RemoveFromCart(int steakId, string shoppingCartId);
        List<ShoppingCartItem> GetShoppingCartItems();
        void CleanCart(string shoppingCartId);
        decimal GetShoppingCartTotal(string shoppingCartId);
    }
}
