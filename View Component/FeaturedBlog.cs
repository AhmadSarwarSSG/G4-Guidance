using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace G4_Guidance.View_Component
{
    public class FeaturedBlog:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
