using OnlineShop.Application.Services.Interfaces;
using OnlineShop.Domain.DTOs.ResultDto;
using OnlineShop.Domain.DTOs.SiteSide.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Implementations
{
    public class CartService : ICartService
    {
        public ResultDTO AddToCart(long ProductId, Guid BrowserId)
        {
            throw new NotImplementedException();
        }

        public ResultDTO<CartDTO> GetMyCart(Guid BrowserId)
        {
            throw new NotImplementedException();
        }

        public ResultDTO RemoveFromCart(long ProductId, Guid BrowserId)
        {
            throw new NotImplementedException();
        }
    }
}
