﻿using Microsoft.AspNetCore.Mvc;
using Project_OnlineShop.Models;
using System.Diagnostics;
using OnlineShop.Application.Services.Interfaces;

namespace Project_OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger,IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetAllProductAsync(1,10,"");
            var products = response.Data;
            return View(products);
        }


        #region shop pages

        public IActionResult NotFound404()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult CartEmpty()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Faq1()
        {
            return View();
        }

        public IActionResult Faq2()
        {
            return View();
        }

        public IActionResult Faq3()
        {
            return View();
        }

        public IActionResult PasswordChange()
        {
            return View();
        }

        public IActionResult PasswordForget()
        {
            return View();
        }

        public IActionResult ProductComment()
        {
            return View();
        }

        public IActionResult ProductComparision()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult ProfileAdditionalInfo()
        {
            return View();
        }

        public IActionResult ProfileAddresses()
        {
            return View();
        }

        public IActionResult ProfileComments()
        {
            return View();
        }

        #endregion






        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}