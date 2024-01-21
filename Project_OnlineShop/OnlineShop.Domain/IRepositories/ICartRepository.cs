using OnlineShop.Domain.DTOs.ResultDto;
using OnlineShop.Domain.DTOs.SiteSide.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IRepositories
{
    public interface ICartRepository
    {
        ResultDTO AddToCart(long ProductId, Guid BrowserId);
        ResultDTO RemoveFromCart(long ProductId, Guid BrowserId);
        ResultDTO<CartDTO> GetMyCart(Guid BrowserId);
    }
}
