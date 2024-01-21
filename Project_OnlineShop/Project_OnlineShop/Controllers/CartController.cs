using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.IRepositories;
using Project_OnlineShop.Utilities;

namespace Project_OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly CookiesManeger cookiesManeger;
        public CartController(ICartRepository cartRepository) 
        { 
            _cartRepository = cartRepository;
            cookiesManeger = new CookiesManeger();
        }

        public IActionResult Index()
        {
            var resultGet = _cartRepository.GetMyCart(cookiesManeger.GetBrowserId(HttpContext));

            return View(resultGet.Data);
        }

        public IActionResult AddToCArt(long productId) 
        {

            var resultAdd = _cartRepository.AddToCart(productId, cookiesManeger.GetBrowserId(HttpContext));

            return RedirectToAction("Index");
        }
    }
}
