using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Controllers
{
    public class ProductController : Controller
    {


        public ViewResult ShowCategryAllProducts() {
            return View();
            }
        public ViewResult ShowBrandAllProducts() {
        return View();
         }


    }
}
