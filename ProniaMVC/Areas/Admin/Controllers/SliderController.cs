using Microsoft.AspNetCore.Mvc;
using ProniaMVC.Business.Services.Abstracts;

namespace ProniaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public IActionResult Index()
        {
            var slider = _sliderService.GetAllSliders();
            
            return View(slider);
        }
    }
}
