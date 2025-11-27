using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TexasSteaks.Context;
using TexasSteaks.Models;
using TexasSteaks.Repositories.Interfaces;

namespace TexasSteaks.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCartRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public ShoppingCart GetCart()
        {
            //Defines a session
            ISession session =
                _httpContextAccessor.HttpContext?.Session;

            //Gets or generates the cart ID.
            string cartId = session.GetString("cartId") ?? Guid.NewGuid().ToString();

            //Assigns the cart ID in the Session
            session.SetString("cartId", cartId);

            //Returns the shopping cart with the assigned or obtained ID and yours items.
            return new ShoppingCart
            {
                Id = cartId,
                ShoppingCartItems = _context.ShoppingCartItems
                    .Where(s => s.ShoppingCartId == cartId)
                    .Include(s => s.Steak)
                    .ToList()
            };
        }

        public void AddToCart(Steak steak, string shoppingCartId)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                     s => s.Steak.Id == steak.Id &&
                     s.ShoppingCartId == shoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = shoppingCartId,
                    Steak = steak,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveFromCart(Steak steak, string shoppingCartId)
        {
            ShoppingCartItem shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                   s => s.Steak.Id == steak.Id &&
                   s.ShoppingCartId == shoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return _context.ShoppingCartItems.Include(s => s.Steak).ToList();
        }

        public void CleanCart(string shoppingCartId)
        {
            IQueryable<ShoppingCartItem> cartItems = _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == shoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal(string shoppingCartId)
        {
            return _context.ShoppingCartItems.Where(c => c.ShoppingCartId == shoppingCartId)
                .Select(c => c.Steak.Price * c.Amount).Sum();
        }
    }
}
