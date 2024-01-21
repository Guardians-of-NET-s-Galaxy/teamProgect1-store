using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.DTOs.ResultDto;
using OnlineShop.Domain.DTOs.SiteSide.Cart;
using OnlineShop.Domain.Entities.Cart;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ShopDbContext _context;
        public CartRepository(ShopDbContext context)
        {
            _context = context;
        }


        public ResultDTO AddToCart(long ProductId, Guid BrowserId)
        {
            var cart = _context.carts.Where(P => P.BrowserId == BrowserId && P.Finished == false).FirstOrDefault();
            if (cart == null) 
            {
                Cart newCart = new Cart()
                {
                    Finished = false,
                    BrowserId = BrowserId,
                };
                _context.carts.Add(newCart);
                _context.SaveChanges();
                cart = newCart;
            }

            var product = _context.products.Find(ProductId);
            var cartItem = _context.CartItems.Where(p => p.ProductId == ProductId && p.CartId == cart.Id).FirstOrDefault();

            if (cartItem == null) 
            {
                cartItem.Quantity++;
            }
            else
            {
                CartItem newCartItem = new CartItem()
                {
                    Cart = cart,
                    Quantity = 1,
                    Price = product.Price,
                    Product = product,
                };

                _context.CartItems.Add(newCartItem);
                _context.SaveChanges();
            }

            return new ResultDTO()
            {
                IsSuccess = true,
                Message = $"محصول  {product.Name} با موفقیت به سبد خرید شما اضافه شد ",
            };
        }

        public ResultDTO<CartDTO> GetMyCart(Guid BrowserId)
        {
            var cart = _context.carts
                       .Include(p => p.CartItem)
                       .ThenInclude(p => p.Product)
                       .Where(p => p.BrowserId == BrowserId && p.Finished == false)
                       .OrderByDescending(p => p.Id)
                       .FirstOrDefault();

            return new ResultDTO<CartDTO>()
            {
                Data = new CartDTO()
                {
                    CardItems = _context.CartItems.Select(p => new CartItemDTO
                    {
                        Quantity = p.Quantity,
                        Price = p.Price,
                        ProductName = p.Product.Name,
                    }).ToList(),
                },
                IsSuccess = true,
            };
        }

        public ResultDTO RemoveFromCart(long ProductId, Guid BrowserId)
        {
            var cartItem = _context.CartItems.Where(p => p.Cart.BrowserId ==  BrowserId).FirstOrDefault();  
            if (cartItem == null) 
            { 
                cartItem.IsRemoved = true;
                cartItem.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDTO
                {
                    IsSuccess = true,
                    Message = "محصول از سبد خرید شما حذف شد"
                };
            }
            else
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };
            }
        }
    }
}
