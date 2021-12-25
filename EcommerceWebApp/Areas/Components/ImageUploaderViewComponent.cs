using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Areas.Components
{
    public class ImageUploaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string FieldName)
        {
            return View("Default",FieldName);
        }
    }
}
