using System.ComponentModel.DataAnnotations;

namespace TexasSteaks.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        
        public Steak Steak { get; set; }
        
        public int Amount { get; set; }
        
        [StringLength(200)]
        public string ShoppingCartId { get; set; }
    }
}
