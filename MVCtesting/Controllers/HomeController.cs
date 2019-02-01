using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCtesting.Model;

namespace MVCtesting.Controllers.Controllers
{
    public class HomeController : Controller
    {
        //SimpleRepository Repository = SimpleRepository.SharedRepository;
        public IRepository Repository = SimpleRepository.SharedRepository;

        public IActionResult Index() => View(SimpleRepository.SharedRepository.Product);

        [HttpGet]
        public IActionResult AddProduct() => View(new Products());

        [HttpPost]
        public IActionResult AddProduct(Products p)
        {
            Repository.AddProducts(p);
            return RedirectToAction("Index");
        }
    }
}
